using GaleriaDavinci.Shared.Dto;
using GaleriaDavinci.Shared.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GaleriaDavinci.Mobile.Services
{
    public class GalleryApiService : IGalleryApiService
    {
        private readonly HttpClient httpClient;

        public GalleryApiService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://10.0.2.2:14097/api/")
            };
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        public async Task<PaginatedResult<ArtPieceDto>> GetArtPieces(int page = 1, int size = 6, string search = null)
        {
            var url = $"GalleryItems?page={page}&size={size}";
            if (!string.IsNullOrEmpty(search))
            {
                url += $"&search={search}";
            }
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            string body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PaginatedResult<ArtPieceDto>>(body);
        }

        public async Task<ArtPieceDto> GetArtPiece(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"GalleryItems/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            string body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ArtPieceDto>(body);
        }

        public async Task<int> CreateArtPiece(string name, string authorId, int year, string description, string imageName, Stream imageStream)
        {

            StreamContent fileStream = new StreamContent(imageStream);
            fileStream.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = "file", FileName = imageName };
            fileStream.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            MultipartFormDataContent requestContent = new MultipartFormDataContent
            {
                { new StringContent(name), "name" },
                { new StringContent(authorId), "authorId" },
                { new StringContent(year.ToString()), "year" },
                { new StringContent(description), "description" },
                { fileStream, "file" }
            };

            HttpResponseMessage response = await httpClient.PostAsync($"GalleryItems", requestContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            string body = await response.Content.ReadAsStringAsync();
            return int.Parse(body);
        }

        public async Task EditArtPiece(int id, string name, string authorId, int year, string description, string imageName, Stream imageStream)
        {
            MultipartFormDataContent requestContent = new MultipartFormDataContent
            {
                { new StringContent(name), "name" },
                { new StringContent(authorId), "authorId" },
                { new StringContent(year.ToString()), "year" },
                { new StringContent(description), "description" },
            };

            if (imageName != null && imageStream != null)
            {
                StreamContent fileStream = new StreamContent(imageStream);
                fileStream.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = "file", FileName = imageName };
                fileStream.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                requestContent.Add(fileStream, "file");
            }

            HttpResponseMessage response = await httpClient.PutAsync($"GalleryItems/{id}", requestContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

        }

        public async Task DeleteArtPiece(int id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync($"GalleryItems/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task BuyArtPiece(int id, string buyerEmail)
        {
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(new BuyArtPieceDto(buyerEmail)),
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"GalleryItems/{id}/buy", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IEnumerable<AuthorDto>> GetAuthors()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"Authors");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            string body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<AuthorDto>>(body);
        }
    }
}
