using ErrorOr;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Application.ProviderMediator.Common;
using MediatR;

namespace Lubricentro.Application.ProviderMediator.Command.Create;

public record CreateProviderCommand(string Name,
                                    string Cuil,
                                    List<PhoneCommand> Phones,
                                    List<EmailCommand> Emails,
                                    string Fax,
                                    string Observation,
                                    string Website,
                                    string Country,
                                    string State,
                                    string City,
                                    string Street,
                                    string PostalCode,
                                    Guid TaxConditionId) : IRequest<ErrorOr<ProviderResult>>;
