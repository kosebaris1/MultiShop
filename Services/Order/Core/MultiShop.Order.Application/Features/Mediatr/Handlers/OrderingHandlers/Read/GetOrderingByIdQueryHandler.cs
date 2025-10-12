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
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;
        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetOrderingByIdQueryResult>(value);
        }
    }
}
