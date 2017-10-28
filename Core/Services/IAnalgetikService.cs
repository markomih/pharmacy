using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IAnalgetikService : IService<Analgetik>
    {
        DataTable GetDataTable(bool naRecept);

    }
}