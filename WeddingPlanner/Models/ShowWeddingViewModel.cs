#pragma warning disable CS8618

namespace WeddingPlanner.Models;
public class ShowWeddingViewModel
{
    public Wedding Wedding {get;set;}
    public List<Wedding> AllWeddings {get;set;}
    public User OneUser {get;set;}
    public List<Reservation> RSVPS {get;set;}
    public Reservation Reservation {get;set;}
}