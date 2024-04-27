using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Domain.Entities.BaseEntities;



namespace Domain.Entities;


public class ContactEntity: BaseEntity
{
    
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }

    public string Title {get; set; }

    public string PhoneNumber { get; set; }

    public string Email {get; set;}


    public string Text {get; set; }



}