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

namespace RestauranteAPIFinal.Controllers
{
    public class MarcaController : ApiController
    {
        string cadena = "Data Source=DEREK\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/Marca
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Marca";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Marca> marcas = new List<Marca>();

                while (reader.Read())
                {
                    Marca marca = new Marca();
                    marca.cod_marca = Int32.Parse(reader["cod_marca"].ToString());
                    marca.nombre = reader["nombre"].ToString();
                    marca.cod_nacionalidad = Int32.Parse(reader["cod_nacionalidad"].ToString());
                    marca.descripcion = reader["descripcion"].ToString();
                    marca.empresa = Int32.Parse(reader["empresa"].ToString());

                    marcas.Add(marca);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(marcas);
                //build json result
                return json;
            }
        }

        // GET: api/Marca/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Marca                          FALTA SP
        public string Post([FromBody]Marca marca)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_restaurante"; // falta sp
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = marca.nombre;
                comando.Parameters.Add("@cod_nacionalidad", SqlDbType.Int).Value = marca.cod_nacionalidad;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = marca.descripcion;
                comando.Parameters.Add("@empresa", SqlDbType.Int).Value = marca.empresa;

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/Marca/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Marca/5
        public void Delete(int id)
        {
        }
    }
}
