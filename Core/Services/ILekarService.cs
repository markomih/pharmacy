using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface ILekarService : IService<Lekar>
    {
        DataTable GetDataTable();

    }
}