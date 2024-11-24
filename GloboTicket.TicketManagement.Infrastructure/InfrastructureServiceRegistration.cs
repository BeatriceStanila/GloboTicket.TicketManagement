
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Infrastructure.FileExport;
using GloboTicket.TicketManagement.Infrastructure.Mail;
using GloboTicket.TIcketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TIcketManagement.Application.Models.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();

            // Register the CsvExporter as a transient service
            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }
    }
}
