using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface ITicketsSoporte
    {
        Task<List<TicketsSoporte>> GetTicketsSoporte();
        Task<bool> PostTicketsSoporte(TicketsSoporte ticketsSoporte);
        Task<bool> PutTicketsSoporte(TicketsSoporte ticketsSoporte);
        Task<bool> DeleteTicketsSoporte(TicketsSoporte ticketsSoporte);
    }
}
