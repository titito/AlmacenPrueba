using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.BIZ
{
    public class ManejadorVales : IManejadorVales
    {
        IRepositorio<Vale> repositorio;
        public ManejadorVales(IRepositorio<Vale> repositorio);
        {
        this.repositorio = IRepositorio;
            }


    public List<Vale> Listar => repositorio.Read;

        
        
        public bool Agregar(Vale entidad)
        {
        return repositorio.Create(entidad);
        }

        public bool Eliminar(string Id)
        {
        return repositorio.Delete(Id);
        }

        public Vale Modificar(Vale entidad)
        {
        return repositorio.Update(entidad);
        }

        public Vale BuscarPorId(string Id)
        {
        return Listar.Where(e => e.Id == Id).SingleOrDefault();
        }
    }
      
}
