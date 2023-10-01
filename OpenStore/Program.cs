using Microsoft.AspNetCore.Hosting;
using OpenStore.Infra.Api;

Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:5000");
                }).Build().Run();