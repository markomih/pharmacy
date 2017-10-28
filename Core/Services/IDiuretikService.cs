using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IDiuretikService : IService<Diuretik>
    {
        DataTable GetDataTable(bool naRecept);

    }
}