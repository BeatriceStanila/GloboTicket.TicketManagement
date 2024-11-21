

namespace GloboTicket.TIcketManagement.Application.Models.Mail
{
    public class EmailSettings
    {
        public string ApiKey { get; set; } = string.Empty;
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
