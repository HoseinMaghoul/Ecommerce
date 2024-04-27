using Application.Results;
using Application.Failures;
using MediatR;
using OneOf;
using Domain.Entities;

namespace Application.Commands.Contact;

public record ContactCommand(string Name, string Title, string PhoneNumber, string Email, string Text): IRequest<OneOf<NoResult, ContactFailure>>;
// public record ContactCommand(ContactEntity ContactUs) : IRequest<OneOf<NoResult, ContactFailure>>;