using System.Diagnostics.Contracts;
using System.Text;
using Domain.IServices;
using Infrastructure.DBContext;
using Domain.Entities;


namespace Infrastructure.Services;


public class ContactService : IContactService
{
    private readonly ProjectDbContext context;

    public ContactService(ProjectDbContext context)
    {
        this.context = context;
    }

    // public async Task AddContactUsEntryAsync(ContactEntity contactUs)
    // {
    //     context.Contact.Add(contactUs);
    //     await context.SaveChangesAsync();
    // }

    public async Task SaveInformationInDataBase(string Name, string Title, string PhoneNumber, string Email, string Text)
    {
        var contact = new ContactEntity
        {
            Name = Name,
            Title = Title,
            PhoneNumber = PhoneNumber,
            Email = Email,
            Text = Text,
            CreatedAt = DateTime.UtcNow
            
        };

        context.Contact.Add(contact);
        await context.SaveChangesAsync();
    }
}

