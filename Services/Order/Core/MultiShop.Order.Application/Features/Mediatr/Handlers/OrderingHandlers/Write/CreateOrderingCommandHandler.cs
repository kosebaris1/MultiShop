﻿using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediatr.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediatr.Handlers.OrderingHandlers.Write
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;
        public CreateOrderingCommandHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Ordering>(request);
            await _repository.CreateAsync(value);
        }
    }
}
