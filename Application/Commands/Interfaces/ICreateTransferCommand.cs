using Application.Results;
using Application.Failures;
using MediatR;
using OneOf;

namespace Application.Commands.Interfaces;

public interface ICreateTransferCommand<T,F> : IRequest<OneOf<T,F>> where T : ICreateTransferResult where F : Failure
{
}
