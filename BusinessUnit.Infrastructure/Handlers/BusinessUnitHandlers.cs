using Dapper;
using MediatR;
using System.Data;
using BusinessUnit.Domain;
using BusinessUnit.Application.Queries;
using BusinessUnit.Application.Commands;
using BusinessUnit.Infrastructure.Data;

namespace BusinessUnit.Infrastructure.Handlers;

public class BusinessUnitHandlers(DapperDbContext context) :
    IRequestHandler<GetAllBusinessUnitsQuery, IEnumerable<Domain.BusinessUnit>>,
    IRequestHandler<GetBusinessUnitByIdQuery, Domain.BusinessUnit?>,
    IRequestHandler<CreateBusinessUnitCommand, int>,
    IRequestHandler<UpdateBusinessUnitCommand, bool>
{
    public async Task<IEnumerable<Domain.BusinessUnit>> Handle(GetAllBusinessUnitsQuery request, CancellationToken ct)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Domain.BusinessUnit>("sp_SQBusinessUnit_GetAll", commandType: CommandType.StoredProcedure);
    }

    public async Task<Domain.BusinessUnit?> Handle(GetBusinessUnitByIdQuery request, CancellationToken ct)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Domain.BusinessUnit>(
            "sp_SQBusinessUnit_GetById", new { Id = request.Id }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> Handle(CreateBusinessUnitCommand request, CancellationToken ct)
    {
        using var connection = context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>("sp_SQBusinessUnit_Insert", request, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> Handle(UpdateBusinessUnitCommand request, CancellationToken ct)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync("sp_SQBusinessUnit_Update", new
        {
            Id = request.Id,
            BusinessUnit = request.BusinessUnit,
            BusinessUnitName = request.BusinessUnitName,
            AddressLine1 = request.AddressLine1,
            TelephoneNumber = request.TelephoneNumber,
            IsActive = request.IsActive,
            Logo = request.Logo,
            District = request.District
        }, commandType: CommandType.StoredProcedure);

        return true; // ← if no exception was thrown, the update succeeded
    }
}