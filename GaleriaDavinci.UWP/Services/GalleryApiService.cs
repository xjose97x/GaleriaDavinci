using GaleriaDavinci.Shared.Dto;
using GaleriaDavinci.Shared.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GaleriaDavinci.UWP.Services
{
    public class GalleryApiService
    {
        private readonly HttpClient httpClient;

        public GalleryApiService()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            HttpResponseMessage response = await httpClient.GetAsync($"GalleryItems/${id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            string body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ArtPieceDto>(body);
        }

        public async Task<int> CreateArtPiece(string name, string authorId, int year, string description, Stream imageStream)
        {

            MultipartFormDataContent requestContent = new MultipartFormDataContent
            {
                { new StringContent(name), "name" },
                { new StringContent(authorId), "authorId" },
                { new StringContent(year.ToString()), "year" },
                { new StringContent(description), "description" },
                { new StreamContent(imageStream), "file" }
            };

            HttpResponseMessage response = await httpClient.PostAsync($"GalleryItems", requestContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            string body = await response.Content.ReadAsStringAsync();
            return int.Parse(body);
        }

        public async Task EditArtPiece(int id, string name, int year, string description, Stream imageStream)
        {

            MultipartFormDataContent requestContent = new MultipartFormDataContent
            {
                { new StringContent(name), "name" },
                { new StringContent(year.ToString()), "year" },
                { new StringContent(description), "description" },
                { new StreamContent(imageStream), "file" }
            };

            HttpResponseMessage response = await httpClient.PostAsync($"GalleryItems/{id}", requestContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task DeleteArtPiece(int id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync($"GalleryItems/${id}");

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
            HttpResponseMessage response = await httpClient.PostAsync($"GalleryItems/{id}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
