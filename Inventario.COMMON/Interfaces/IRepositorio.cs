﻿using Inventario.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.COMMON.Interfaces
{
    public interface IRepositorio<T> where T:Base

    {
        bool Crear(T entidad);

        List<T> Read { get; }

        bool Editar (T entidadModificada);

        bool Eliminar(string Id);

        

    }
}
