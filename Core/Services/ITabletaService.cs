using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface ITabletaService : IService<Tableta>
    {
        DataTable GetDataTable();

    }
}