
namespace Adoo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot"; // Path to your Angular build output
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.MapWhen(context => !context.Request.Path.StartsWithSegments("/api"),
                    builder =>
                    {
                        builder.UseSpa(spa =>
                        {
                            spa.Options.SourcePath = "wwwroot"; // Path to your Angular project directory

                            //if (env.IsDevelopment())
                            //{
                            //    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200"); // If using Angular CLI development server
                            //}
                        });
                    });

            app.Run();
        }
    }
}