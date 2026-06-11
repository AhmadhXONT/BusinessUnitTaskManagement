using MediatR;

namespace BusinessUnit.Application.Commands;

public record CreateBusinessUnitCommand(
    string BusinessUnit, string BusinessUnitName, string AddressLine1,
    string TelephoneNumber, bool IsActive, string CreatedBy,
    string Logo, string District) : IRequest<int>;

public record UpdateBusinessUnitCommand(
    int Id, string BusinessUnit, string BusinessUnitName,
    string AddressLine1, string TelephoneNumber, bool IsActive,
    string Logo, string District) : IRequest<bool>;