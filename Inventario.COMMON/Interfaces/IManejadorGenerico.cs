using Inventario.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.COMMON.Interfaces
{
    public interface IManejadorGenerico<T> where T : Base

    {
        bool T Agregar(T entidad);
        List<T> Listar {get;}
        bool Eliminar(String Id);
        bool T Modificar(T entidad);
        T BuscarPorId(string Id);
    }
}
