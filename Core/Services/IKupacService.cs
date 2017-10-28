using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IKupacService : IService<Kupac>
    {
        DataTable GetDataTable();

    }
}