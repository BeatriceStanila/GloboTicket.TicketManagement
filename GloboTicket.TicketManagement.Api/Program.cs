
using GloboTicket.TicketManagement.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.
    CongfigureServices()
    .ConfigurePipeline();

await app.ResetDatabaseAsync();

app.Run();
