using System;
using System.Collections.Generic;
using System.Web.Http;
using RestauranteAPIFinal.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace RestauranteAPIFinal.Controllers
{
    public class ComestibleClaseController : ApiController
    {
        string cadena = "Data Source=DESKTOP-7N6N3E8\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/ComestibleClase
        [HttpGet]
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Restaurante";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Comestible> comestibles = new List<Comestible>();

                while (reader.Read())
                {
                    Comestible comestible = new Comestible();
                    comestible.cod_claseComestible = Int32.Parse(reader["cod_claseComestible"].ToString());
                    comestible.nombre = reader["nombre"].ToString();
                    

                    comestibles.Add(comestible);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(comestibles);
                //build json result
                return json;
            }
        }

        // GET: api/ComestibleClase/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ComestibleClase
        [HttpPost]
        public string Post([FromBody]Comestible comestible)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_restaurante"; // falta sp post
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cod_claseComestible", SqlDbType.Int).Value = comestible;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = comestible.nombre;
                
                
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";


        }

        // PUT: api/ComestibleClase/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ComestibleClase/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
