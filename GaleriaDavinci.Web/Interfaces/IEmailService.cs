using System.Threading.Tasks;

namespace GaleriaDavinci.Web.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmail(string to, string subject, string content);
    }
}
