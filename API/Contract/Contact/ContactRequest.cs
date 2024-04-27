using Domain.Enums;


namespace API.Contract.Contact;
/// <summary>
/// Contact To Us
/// </summary>
/// <param name="Name"></param>
/// <param name="Title"></param>
/// <param name="PhoneNumber"></param>
/// <param name="Email"></param>
/// <param name="Text"></param>
/// 

public record ContactRequest(
    string Name,
    string Title,
    string PhoneNumber,
    string Email,
    string Text,
    long ID
);