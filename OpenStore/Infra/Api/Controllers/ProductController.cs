using Microsoft.AspNetCore.Mvc;
using OpenStore.Application.Produto.Create;
using OpenStore.Application.Produto.Delete;
using OpenStore.Application.Produto.Get;
using OpenStore.Application.Produto.List;
using OpenStore.Application.Produto.Update;
using OpenStore.Infra.Produto.Models;

namespace OpenStore.Infra.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {

        public readonly GetProductByCodeUseCase getProductByCodeUseCase;
        public readonly GetProductByTermsUseCase getProductByTermsUseCase;
        public readonly CreateProductUseCase createProductUseCase;
        public readonly DeleteProductUseCase deleteProductUseCase;
        public readonly ListProductsUseCase listProductsUseCase;
        public readonly UpdateProductUseCase updateProductUseCase;

        public ProductController(GetProductByCodeUseCase getProductByCodeUseCase, GetProductByTermsUseCase getProductByTermsUseCase, CreateProductUseCase createProductUseCase, DeleteProductUseCase deleteProductUseCase, ListProductsUseCase listProductsUseCase, UpdateProductUseCase updateProductUseCase)
        {
            this.getProductByCodeUseCase = getProductByCodeUseCase;
            this.getProductByTermsUseCase = getProductByTermsUseCase;
            this.createProductUseCase = createProductUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.listProductsUseCase = listProductsUseCase;
            this.updateProductUseCase = updateProductUseCase;
        }

        [HttpGet]
        public IActionResult GetByCode([FromQuery] string code)
        {
            var output = getProductByCodeUseCase.Execute(code);
            return Ok(output);
        }

        [HttpGet("search")]
        public IActionResult GetByTerms([FromQuery] string terms)
        {
            var output = getProductByTermsUseCase.Execute(terms);
            return Ok(output);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductRequest request)
        {
            CreateProductCommand input = new CreateProductCommand(
                request.Code,
                request.InternCode,
                request.Description,
                request.Unit,
                request.Stock,
                request.CostPrice,
                request.RetailPrice,
                request.WholesalePrice,
                request.WholesaleQuantity);

            var output = createProductUseCase.Execute(input);
            return Ok(output);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            deleteProductUseCase.Execute(id);
            return NoContent();
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var output = listProductsUseCase.Execute();
            return Ok(output);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] UpdateProductRequest request)
        {
            UpdateProductCommand input = new UpdateProductCommand(
                id,
                request.InternCode,
                request.Description,
                request.Unit,
                request.Stock,
                request.CostPrice,
                request.RetailPrice,
                request.WholesalePrice,
                request.WholesaleQuantity);

            var output = updateProductUseCase.Execute(input);
            return Ok(output);
        }  
        
    }
}
