using Application.Results;
using Application.Failures;
using MediatR;
using OneOf;


namespace Application.Commands.User;

public record CreateFirstUserCommand(string UserName, string Password): IRequest<OneOf<NoResult, UserFailure>>;
