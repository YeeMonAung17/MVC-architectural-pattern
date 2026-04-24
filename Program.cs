using MVC.Models;
using MVC.Services;
 


            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddScoped<AuthorServices>();
            builder.Services.AddScoped<AuthorsModel>();

            var app = builder.Build();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });

            app.Run();


          
 
