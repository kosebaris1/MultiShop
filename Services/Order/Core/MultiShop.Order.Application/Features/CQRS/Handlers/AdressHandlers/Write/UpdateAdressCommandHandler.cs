using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers.Write
{
    public class UpdateAdressCommandHandler
    {
        private readonly IRepository<Adress> _repository;
        private readonly IMapper _mapper;
        public UpdateAdressCommandHandler(IRepository<Adress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAdressCommand updateAdressCommand)
        {
            var value = _mapper.Map<Adress>(updateAdressCommand);
            await _repository.UpdateAsync(value);
        }
    }
}
