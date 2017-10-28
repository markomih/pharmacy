using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IOsobaService : IService<Osoba>
    {
        DataTable GetDataTable();
    }
}