using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;


namespace Domain.IServices;


public interface IContactService
{
    Task SaveInformationInDataBase(string Name, string Title, string PhoneNumber, string Email, string Text);

    

    // Task AddContactUsEntryAsync(ContactEntity contactUs);
}