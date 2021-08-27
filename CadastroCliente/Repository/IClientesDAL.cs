using System.Collections.Generic;

namespace CadastroCliente.Models
{
    public interface IClientesDAL
    {
        
        IEnumerable<Cliente> GetAllDbClientes();
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int? id);
        Cliente GetCliente(int? id);        
    }
}
