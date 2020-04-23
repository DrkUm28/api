using System;
using System.Collections.Generic;
using System.Web.Http;
using RestauranteAPIFinal.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace RestauranteAPIFinal.Controllers
{
    public class RolController : ApiController
    {
        string cadena = "Data Source=DESKTOP-7N6N3E8\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/Rol
        [HttpGet]
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Rol";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Rol> roles = new List<Rol>();

                while (reader.Read())
                {
                    Rol rol = new Rol();
                    rol.cod_rol = Int32.Parse(reader["cod_rol"].ToString());
                    rol.nombre = reader["nombre"].ToString();
                    rol.descripcion = reader["descripcion"].ToString();

                    roles.Add(rol);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(roles);
                //build json result
                return json;
            }

        }

        // GET: api/Rol/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rol
        [HttpPost]
        public string Post([FromBody]Rol rol)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_rol";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = rol.nombre;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = rol.descripcion;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";

        }

        // PUT: api/Rol/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rol/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
