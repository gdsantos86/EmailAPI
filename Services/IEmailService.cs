using EmailAPI.Models;

namespace EmailAPI.Services
{
    public interface IEmailService
    {
        Task<bool> EnviarEmailAsync(EmailData emailData);

        Task<bool> EnviarEmailComAnexoAsync(EmailData emailData);

        Task<bool> EnviarEmailUsandoTemplatesAsync(EmailData emailData);
    }
}
