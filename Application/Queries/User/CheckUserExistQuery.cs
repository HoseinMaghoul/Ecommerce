using MediatR;

namespace Application.Queries.User;


public record CheckUserExistQuery(): IRequest<bool>;