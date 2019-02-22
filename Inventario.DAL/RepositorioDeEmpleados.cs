using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.DAL
{
    public class RepositorioDeEmpleados : IRepositorio<Empleado>
        //Base de datos NoSQL -> Orientada a Objetos -> LiteDB
    {
        public List<Empleado> Leer => throw new NotImplementedException();

        public bool Crear(Empleado entidad)
        {
            throw new NotImplementedException();
        }

        public bool Editar(Empleado entidadOriginal, Empleado entidadModificada)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(Empleado entidad)
        {
            throw new NotImplementedException();
        }
    }
}
