using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IAntipiretikService : IService<Antipiretik>
    {
        DataTable GetDataTable(bool naRecept);
    }
}