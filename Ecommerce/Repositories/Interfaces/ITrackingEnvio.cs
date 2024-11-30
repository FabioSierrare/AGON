using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface ITrackingEnvio
    {
        Task<List<TrackingEnvio>> GetTrackingEnvio();
        Task<bool> PostTrackingEnvio(TrackingEnvio trackingEnvio);
        Task<bool> PutTrackingEnvio(TrackingEnvio trackingEnvio);
        Task<bool> DeleteTrackingEnvio(TrackingEnvio trackingEnvio);
    }
}
