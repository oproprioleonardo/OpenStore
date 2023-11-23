using Microsoft.AspNetCore.Mvc;
using OpenStore.Application.Venda.Create;
using OpenStore.Infra.Sale.Models;

namespace OpenStore.Infra.Api.Controllers
{

    [ApiController]
    [Route("/v1/[controller]")]
    public class CupomController : ControllerBase
    {

        public readonly CreateCupomUseCase createCupomUseCase;

        public CupomController(CreateCupomUseCase createCupomUseCase)
        {
            this.createCupomUseCase = createCupomUseCase;
        }

        [HttpPost]
        public IActionResult CreateCupom([FromBody] CreateCupomRequest request)
        {
            CreateCupomInput command = new CreateCupomInput(
                request.Date,
                request.Cliente,
                request.Items.ConvertAll(i => new CreateCupomItemInput(i.Code, i.Description, i.Price, i.Quantity))
                );

            var output = createCupomUseCase.Execute(command);
            return Ok(output);
        }

    }
}
