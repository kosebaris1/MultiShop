using MediatR;
using MultiShop.Order.Application.Features.Mediatr.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediatr.Queries.OrderingQueries
{
    public class GetAllOrderingQuery : IRequest<List<GetAllOrderingQueryResult>>
    {
    }
}
