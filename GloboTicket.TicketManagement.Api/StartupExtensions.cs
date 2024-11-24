using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplication CongfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices(); // AutoMapper and MediatR
            builder.Services.AddInfrastructureServices(builder.Configuration); // email service
            builder.Services.AddPersistenceServices(builder.Configuration); // DbContext and Repositories

            builder.Services.AddControllers();

            // define cors policy -> open up the APi so that it can be used from client-side technologies 
            // need for the Blazor app
            builder.Services.AddCors(
                options => options.AddPolicy(
                    "open",
                    policy => policy.WithOrigins([builder.Configuration["ApiUrl"]??
                    "https://localhost:7020",
                        builder.Configuration["BlazorUrl"] ??
                        "https://localhost:7080"])
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(pool => true)
                    .AllowAnyHeader()
                    .AllowCredentials()));

            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCors("open");

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers(); // routing to controllers is automatically enabled 



            return app;
        }

       

        // reset the database every time we run the app (fine for testing and developing)
        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<GloboTicketDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                //add logging here later on
            }
        }


        // this code won't be invoked automatically like with the regular startup class
        // call it in the Program class

    }
}
