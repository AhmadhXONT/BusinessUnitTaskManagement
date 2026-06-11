using MediatR;
using BusinessUnit.Domain;

namespace BusinessUnit.Application.Queries;

public record GetAllBusinessUnitsQuery() : IRequest<IEnumerable<Domain.BusinessUnit>>;
public record GetBusinessUnitByIdQuery(int Id) : IRequest<Domain.BusinessUnit?>;