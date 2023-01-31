using AppData.Application.Models.EmailModels;

namespace AppData.Application.Contracts.Infrastucture
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailModel email);
    }
}
