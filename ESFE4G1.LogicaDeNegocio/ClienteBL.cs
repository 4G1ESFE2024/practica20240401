using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE4G1.AccesoADatos;
using ESFE4G1.EntidadesNegocio;
namespace ESFE4G1.LogicaDeNegocio
{
    public class ClienteBL
    {
        readonly ClienteDAL _clienteDAL;
        public ClienteBL(ClienteDAL clienteDAL)
        {
            _clienteDAL= clienteDAL;
        }
        public async Task<int> Crear(Cliente cliente)
        {
           return await _clienteDAL.Crear(cliente);
        }
        public async Task<int> Modificar(Cliente cliente)
        {
            return await _clienteDAL.Modificar(cliente);
        }
        public async Task<int> Eliminar(Cliente cliente)
        {
            return await _clienteDAL.Eliminar(cliente);
        }
        public async Task<Cliente> ObtenerPorId(int id)
        {
            return await _clienteDAL.ObtenerPorId(id);
        }
        public async Task<List<Cliente>> Buscar(Cliente cliente)
        {
            return await _clienteDAL.Buscar(cliente);
        }
    }
}
