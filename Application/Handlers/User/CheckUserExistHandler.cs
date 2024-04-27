using Application.Queries;
using Application.Failures;
using Domain.IServices;
using OneOf;
using MediatR;
using Application.Queries.User;

namespace Application.Handlers.User;


public class CheckUserExistHandler : IRequestHandler<CheckUserExistQuery, bool>
{
    private readonly IUserService service;

    public CheckUserExistHandler(IUserService service)
    {
        this.service = service;
    }
    public async Task<bool> Handle(CheckUserExistQuery request, CancellationToken cancellationToken)
    {
        return await service.CheckUserExist();
    }
    
}

