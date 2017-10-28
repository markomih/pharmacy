using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface ILekService : IService<Lek>
    {
        DataTable GetDataTable(bool naRecept);
        DataTable GetDataTable();

    }
}