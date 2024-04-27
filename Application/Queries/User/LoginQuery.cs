using Application.Results.Login;
using Domain.Enums;
using Application.Failures;
using MediatR;
using OneOf;


namespace Application.Queries.User;

public record LoginQuery(string Username, string Password, string IP, PlatformType PlatformType):IRequest<OneOf<LoginResult, LoginFailure>>;


