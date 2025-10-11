using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers.Read;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers.Write;
using MultiShop.Order.Application.Features.CQRS.Queries.AdressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly CreateAdressCommandHandler _createAdressCommandHandler;
        private readonly RemoveAdressCommandHandler _removeAdressCommandHandler;
        private readonly UpdateAdressCommandHandler _updateAdressCommandHandler;
        private readonly GetAdressQueryHandler _getAdressQueryHandler;
        private readonly GetAdressByIdQueryHandler _getAdressByIdQueryHandler;

        public AdressesController(GetAdressByIdQueryHandler getAdressByIdQueryHandler, GetAdressQueryHandler getAdressQueryHandler, UpdateAdressCommandHandler updateAdressCommandHandler, RemoveAdressCommandHandler removeAdressCommandHandler, CreateAdressCommandHandler createAdressCommandHandler)
        {
            _getAdressByIdQueryHandler = getAdressByIdQueryHandler;
            _getAdressQueryHandler = getAdressQueryHandler;
            _updateAdressCommandHandler = updateAdressCommandHandler;
            _removeAdressCommandHandler = removeAdressCommandHandler;
            _createAdressCommandHandler = createAdressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ListAdress()
        {
          var values =  _getAdressQueryHandler.Handle();
          return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdressById(int id)
        {
            var values = await _getAdressByIdQueryHandler.Handle(new GetAdressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdress(CreateAdressCommand command)
        {
            await _createAdressCommandHandler.Handle(command);
            return Ok("Adres Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdress(UpdateAdressCommand command)
        {
            await _updateAdressCommandHandler.Handle(command);
            return Ok("Adres Başarıyla Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            await _removeAdressCommandHandler.Handle(new RemoveAdressCommand(id));
            return Ok("Adress Başarıyla Silindi");
        }
    }
}
