using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface ISirupService : IService<Sirup>
    {
        DataTable GetDataTable();

    }
}