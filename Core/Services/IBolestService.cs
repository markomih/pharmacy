
using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IBolestService : IService<Bolest>
    {
        DataTable GetDataTable();

    }
}