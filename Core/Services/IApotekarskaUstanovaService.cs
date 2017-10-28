using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IApotekarskaUstanovaService : IService<ApotekarskaUstanova>
    {
        DataTable GetDataTable();
    }
}