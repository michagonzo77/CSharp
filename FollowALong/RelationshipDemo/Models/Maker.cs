#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace RelationshipDemo.Models;
public class Maker
{
    [Key]
    public int MakerId {get;set;}
    public string Name {get;set;}
    public string CountryOfOrigin {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}