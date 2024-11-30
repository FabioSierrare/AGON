using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface IRespuestasFAQ
    {
        Task<List<RespuestasFAQ>> GetRespuestasFAQ();
        Task<bool> PostRespuestaFAQ(RespuestasFAQ respuestasFAQ);
        Task<bool> PutRespuestasFAQ(RespuestasFAQ respuestasFAQ);
        Task<bool> DeleteRespuestasFAQ(RespuestasFAQ respuestasFAQ);
    }
}
