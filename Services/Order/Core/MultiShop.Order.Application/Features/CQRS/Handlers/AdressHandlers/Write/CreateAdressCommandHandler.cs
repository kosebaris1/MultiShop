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
    public class CreateAdressCommandHandler
    {
        private readonly IRepository<Adress> _repository;
        private readonly IMapper _mapper;

        public CreateAdressCommandHandler(IRepository<Adress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAdressCommand createAdressCommand)
        {
            var value = _mapper.Map<Adress>(createAdressCommand);

            await _repository.CreateAsync(value);
        }
    }
}
