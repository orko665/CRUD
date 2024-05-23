using CRUD.Model.Dto;

namespace CRUD.Model.Dao
{
    public interface IFactura
    {
        Task<bool> CreateFactura(FacturaDto factura);

        Task<bool> UpdateFactura(FacturaDto factura);

        Task<bool> DeleteFactura(int id);

        Task<List<FacturaDto>> GetAllFacturas();

        Task<List<FacturaDto>> GetFactura(int id);

    }
}
