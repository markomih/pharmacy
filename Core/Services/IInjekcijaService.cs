using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IInjekcijaService : IService<Injekcija>
    {
        DataTable GetDataTable();
    }
}