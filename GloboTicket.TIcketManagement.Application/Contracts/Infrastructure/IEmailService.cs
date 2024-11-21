

using GloboTicket.TIcketManagement.Application.Models.Mail;

namespace GloboTicket.TIcketManagement.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
