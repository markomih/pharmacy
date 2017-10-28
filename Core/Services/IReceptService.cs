using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IReceptService : IService<Recept>
    {
        DataTable GetDataTable();

    }
}