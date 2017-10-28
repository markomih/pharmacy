using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IPrasakService : IService<Prasak>
    {
        DataTable GetDataTable();
    }
}