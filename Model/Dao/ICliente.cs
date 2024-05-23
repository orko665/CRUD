using CRUD.Model.Dto;

namespace CRUD.Model.Dao
{
    public interface ICliente
    {
        Task<bool> CreateCliente(ClienteDto cliente);

        Task<bool> UpdateCliente(ClienteDto cliente);

        Task<bool> DeleteCliente(int id);

        Task<List<ClienteDto>> GetAllClientes();

        Task<List<ClienteDto>> GetCliente(int id);


    }
}
