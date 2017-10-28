using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IProizvodjacService : IService<Proizvodjac>
    {
        DataTable GetDataTable();

    }
}