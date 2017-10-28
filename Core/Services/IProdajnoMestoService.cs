using System.Data;
using Core.Entities;

namespace Core.Services
{
    public interface IProdajnoMestoService : IService<ProdajnoMesto>
    {
        DataTable GetDataTable();

    }
}