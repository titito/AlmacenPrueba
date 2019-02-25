using Inventario.COMMON.Interfaces;
using Inventario.COMMON.Entidades;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventario.DAL
{
    public class RepositorioDeMateriales : IRepositorio<Material>
    //Base de datos NoSQL -> Orientada a Objetos -> LiteDB
    {
        private string DBName = "Inventario.db";
        private string TableName = "Material";



        public List<Material> Read
        {

            get
            {
                List<Material> datos = new List<Material>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Material>(TableName).FindAll().ToList();

                }
                return datos;
            }
        }

        public bool Crear(Material entidad)
        {
            entidad.Id = new Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Material>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Material entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Material>(TableName);
                    coleccion.Update(entidadModificada);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(string Id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Material>(TableName);
                    r = coleccion.Delete(e => e.Id == Id);
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

