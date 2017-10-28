using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IPakovanjeService : IService<Pakovanje>
    {
        DataTable GetDataTable();
    }
}