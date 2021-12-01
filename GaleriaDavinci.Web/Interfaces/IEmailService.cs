using System.Threading.Tasks;

namespace GaleriaDavinci.Web.Interfaces
{
    //comentario prueba clase
    public interface IEmailService
    {
        public Task SendEmail(string to, string subject, string content);
    }
}
