using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IAntibiotikService : IService<Antibiotik>
    {
        DataTable GetDataTable(bool naRecept);
    }
}