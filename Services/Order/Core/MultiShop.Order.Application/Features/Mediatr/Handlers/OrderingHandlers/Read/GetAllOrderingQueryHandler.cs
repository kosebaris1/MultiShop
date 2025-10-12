using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediatr.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediatr.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediatr.Handlers.OrderingHandlers.Read
{
    public class GetAllOrderingQueryHandler : IRequestHandler<GetAllOrderingQuery, List<GetAllOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;
        public GetAllOrderingQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllOrderingQueryResult>> Handle(GetAllOrderingQuery request, CancellationToken cancellationToken)
        {
            var vaule = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAllOrderingQueryResult>>(vaule);
        }
    }
}
