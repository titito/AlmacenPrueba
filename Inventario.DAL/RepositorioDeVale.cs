using Inventario.COMMON.Interfaces;
using Inventario.COMMON.Entidades;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventario.DAL
{
    public class RepositorioDeVale : IRepositorio<Vale>
    //Base de datos NoSQL -> Orientada a Objetos -> LiteDB
    {
        private string DBName = "Inventario.db";
        private string TableName = "Vale";



        public List<Vale> Read
        {

            get
            {
                List<Vale> datos = new List<Vale>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Vale>(TableName).FindAll().ToList();

                }
                return datos;
            }
        }

        public bool Crear(Vale entidad)
        {
            entidad.Id = new Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Vale>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Vale entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Vale>(TableName);
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
                    var coleccion = db.GetCollection<Vale>(TableName);
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