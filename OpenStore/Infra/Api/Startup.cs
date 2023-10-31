using Microsoft.OpenApi.Models;
using OpenStore.Application.Produto.Create;
using OpenStore.Application.Produto.Delete;
using OpenStore.Application.Produto.Get;
using OpenStore.Application.Produto.List;
using OpenStore.Application.Produto.Update;
using OpenStore.Application.Venda.Create;
using OpenStore.Domain.Contexts.Produto;
using OpenStore.Domain.Contexts.Venda;
using OpenStore.Infra.Api.Filters;
using OpenStore.Infra.Produto;
using OpenStore.Infra.Produto.Persistence;
using OpenStore.Infra.Sale;

namespace OpenStore.Infra.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<DefaultExceptionFilter>();
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "OpenStore API",
                    Description = "An ASP.NET Core Web API for managing point of sale"
                });
            });
    

            services.AddSingleton(provider => new CupomRepository(@"C:\TEMP\cupom-list.json"));
            services.AddSingleton<CupomJsonFileGateway>();
            services.AddSingleton<ICupomGateway, CupomJsonFileGateway>();
            
            services.AddSingleton(provider => new ProductRepository(@"C:\TEMP\product-list.json"));
            services.AddSingleton<ProductJsonFileGateway>();
            services.AddSingleton<IProductGateway, ProductJsonFileGateway>();

            services.AddSingleton<GetProductByCodeUseCase, DefaultGetProductByCodeUseCase>();
            services.AddSingleton<GetProductByTermsUseCase, DefaultGetProductByTermsUseCase>();
            services.AddSingleton<CreateProductUseCase, DefaultCreateProductUseCase>();
            services.AddSingleton<DeleteProductUseCase, DefaultDeleteProductUseCase>();
            services.AddSingleton<ListProductsUseCase, DefaultListProductsUseCase>();
            services.AddSingleton<UpdateProductUseCase, DefaultUpdateProductUseCase>();

            services.AddSingleton<CreateCupomUseCase, DefaultCreateCupomUseCase>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();
            app.UseHttpLogging();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenStore");
                options.RoutePrefix = "swagger";
            });

                        
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });
        }
    }
}
