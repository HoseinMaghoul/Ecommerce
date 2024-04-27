using Application.Commands.User;
using Application.Failures;
using Application.Results;
using Domain.IServices;
using MediatR;
using OneOf;


namespace Application.Handlers.User;

public class CreateFirstUserHandler : IRequestHandler<CreateFirstUserCommand, OneOf<NoResult, UserFailure>>
{

    public readonly IUserService service;
    public CreateFirstUserHandler(IUserService service)
    {
        this.service = service;
    }
    public async Task<OneOf<NoResult, UserFailure>> Handle(CreateFirstUserCommand request, CancellationToken cancellationToken)
    {
        var result = await service.CheckUserExist();
        if (result)
        {
            return new AlreadyUserExistInSystem();
        }
        else
        {
            await service.CreateFirstUser(request.UserName, request.Password);
            return new NoResult();
        }
    }
}