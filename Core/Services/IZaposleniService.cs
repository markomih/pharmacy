using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IZaposleniService : IService<Zaposleni>
    {
        DataTable GetDataTable();
        DataTable GetFarmaceutDataTable();

    }
}