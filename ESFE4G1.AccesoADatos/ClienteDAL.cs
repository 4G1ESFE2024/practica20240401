using ESFE4G1.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE4G1.AccesoADatos
{
    public class ClienteDAL
    {
         readonly AppDbContext _appDbContext;
        public ClienteDAL(AppDbContext appDbContext) {
            _appDbContext=appDbContext;
        }
     
        public async Task<int> Crear(Cliente cliente)
        {
            _appDbContext.Add(cliente);
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<int> Modificar(Cliente cliente)
        {
            var clienteDATA= await _appDbContext.Clientes
                .FirstOrDefaultAsync(s=> s.Id==cliente.Id);
            clienteDATA.Nombre=cliente.Nombre;
            clienteDATA.Apellido=cliente.Apellido;
            _appDbContext.Update(clienteDATA);
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<int> Eliminar(Cliente cliente)
        {
            var clienteDATA = await _appDbContext.Clientes
               .FirstOrDefaultAsync(s => s.Id == cliente.Id);
            if( clienteDATA!=null ) {
                _appDbContext.Remove(clienteDATA);
            }            
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<Cliente> ObtenerPorId(int id)
        {
            var clienteDATA =await  _appDbContext.Clientes
                          .FirstOrDefaultAsync(s => s.Id == id);           
            return clienteDATA;
        }
        public async Task<List<Cliente>> Buscar(Cliente cliente)
        {
            var query= _appDbContext.Clientes.AsQueryable();
            if(!string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                query=query.Where(s=> s.Nombre.Contains(cliente.Nombre));
            }
            if (!string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                query = query.Where(s => s.Apellido.Contains(cliente.Apellido));
            }
            return  await query.ToListAsync();                       
        }        
    }
}
