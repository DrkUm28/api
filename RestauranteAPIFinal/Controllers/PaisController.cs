using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestauranteAPIFinal;
using RestauranteAPIFinal.Models;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace RestauranteAPIFinal.Controllers
{
    public class PaisController : ApiController
    {
        string cadena = "Data Source=DEREK\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";
        // GET: api/Pais
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Pais";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Pais> paises = new List<Pais>();

                while (reader.Read())
                {
                    Pais pais = new Pais();
                    
                    pais.cod_pais = Int32.Parse(reader["cod_pais"].ToString());
                    pais.nombre = reader["nombre"].ToString();
                    


                    paises.Add(pais);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(paises);
                //build json result
                return json;
            }
        }

        // GET: api/Pais/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pais
        public string Post([FromBody]Pais pais)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_pais";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
           
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = pais.nombre;

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/Pais/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pais/5
        public void Delete(int id)
        {
        }
    }
}
