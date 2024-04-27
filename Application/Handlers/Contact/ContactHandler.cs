using Application.Failures;
using Application.Commands.Contact;
using Application.Results;
using Domain.IServices;
using MediatR;
using OneOf;

namespace Application.Handlers.Contact;

public class ContactHandler : IRequestHandler<ContactCommand, OneOf<NoResult, ContactFailure>>
{
    private readonly ILoginService loginService;
    private readonly IContactService contactService;

    public ContactHandler(ILoginService loginService, IContactService contactService)
    {
        this.loginService = loginService;
        this.contactService = contactService;
    }
    public async Task<OneOf<NoResult, ContactFailure>> Handle(ContactCommand request, CancellationToken cancellationToken)
    {
        await contactService.SaveInformationInDataBase(request.Name, request.Title, request.PhoneNumber, request.Email, request.Text);
        return new NoResult();

    }
}



// public class ContactHandler : IRequestHandler<ContactCommand, OneOf<NoResult, ContactFailure>>
// {

//         private readonly IContactService contactService;

//         public ContactHandler(IContactService contactService)
//         {
//             this.contactService = contactService;
//         }

//     public async Task<OneOf<NoResult, ContactFailure>> Handle(ContactCommand request, CancellationToken cancellationToken)
//     {
//         try
//         {
//         var contactUs = request.ContactUs;
//          await contactService.SaveInformationInDataBase(contactUs.Name, contactUs.Title, contactUs.PhoneNumber, contactUs.Email, contactUs.Text);
//          return new NoResult();

//         }
//         catch
//         {
//             return new FailedToSaveMessage();
//         }
      
      
//     }
   
