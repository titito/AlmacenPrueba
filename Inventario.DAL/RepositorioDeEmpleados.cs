using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventario.DAL
{
    public class RepositorioDeEmpleados : IRepositorio<Empleado>
    //Base de datos NoSQL -> Orientada a Objetos -> LiteDB
    {
        private string DBName = "Inventario.db";
        private string TableName = "Empleados";



        public List<Empleado> Leer
        {

            get
            {
                List<Empleado> datos = new List<Empleado>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Empleado>(TableName).FindAll().ToList();

                }
                return datos;
             }
        }
}
        public bool Crear(Empleado entidad)
        {
        entidad.Id = new Guid.NewGuid().ToString();
        try
        {
            using (var db = new LiteDatabase(DBName))
            {
                var coleccion = db.GetCollection<Empleado>(TableName);
                coleccion.Insert(entidad);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        }
        

        public bool Editar(Empleado entidadModificada)
        {
       try
          {
        using (var db = new LiteDatabase(DBName))
        {
            var coleccion = db.GetCollection<Empleado>(TableName);
            coleccion.Update(entidadModificada);
        }
        return true;
          }
             catch (Exception)
          {
        return false;
          }
        }

        public bool Eliminar(string id)
        {
           try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
            var coleccion = db.GetCollection<Empleado>(TableName);
            r = coleccion.Delete(e => e.Id == id);
                }
        return r > 0;
            }
    catch (Exception)
                  {
        return false;
                 }
   
        }
    }
}

