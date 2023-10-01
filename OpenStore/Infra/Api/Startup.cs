using OpenStore.Application.Produto.Create;
using OpenStore.Application.Produto.Delete;
using OpenStore.Application.Produto.Get;
using OpenStore.Application.Produto.List;
using OpenStore.Application.Produto.Update;
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

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
