using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Queries.AdressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AdressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers.Read
{
    public class GetAdressByIdQueryHandler
    {
        private readonly IRepository<Adress> _repository;
        private readonly IMapper _mapper;
        public GetAdressByIdQueryHandler(IRepository<Adress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAdressByIdQueryResult> Handle(GetAdressByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return _mapper.Map<GetAdressByIdQueryResult>(value);
        } 
    }
}
