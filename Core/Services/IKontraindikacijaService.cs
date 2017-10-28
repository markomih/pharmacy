using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IKontraindikacijaService : IService<Kontraindikacija>
    {
        DataTable GetDataTable();

    }
}