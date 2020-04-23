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
    [EnableCors(origins: "https://localhost:3000", headers: "*", methods: "*")]
    public class RestauranteController : ApiController
    {
        

        string cadena = "Data Source=DEREK\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/Restaurante
        public string Get()
        {

            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Restaurante";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Restaurante> restaurantes = new List<Restaurante>();

                while (reader.Read())
                {
                    Restaurante restaurante = new Restaurante();
                    restaurante.cod_restaurante = Int32.Parse(reader["cod_restaurante"].ToString());
                    restaurante.nombre = reader["nombre"].ToString();
                    restaurante.direccion = reader["direccion"].ToString();
                    restaurante.telefono = Int32.Parse(reader["telefono"].ToString());
                    restaurante.activo = Boolean.Parse(reader["activo"].ToString());
                    restaurante.cant_clientes = Int32.Parse(reader["cant_clientes"].ToString());
                    restaurante.especialidad = reader["especialidad"].ToString();

                    restaurantes.Add(restaurante);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(restaurantes);
                //build json result
                return json;
            }
            
        }

        // GET: api/Restaurante/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Restaurante
        [EnableCors(origins: "https://localhost:3000/agregar-restaurante", headers: "*", methods: "*")]
        public string Post([FromBody]Restaurante restaurante)
        {

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();

                string query = "sp_insert_restaurante";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = restaurante.nombre;
                comando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = restaurante.direccion;
                comando.Parameters.Add("@telefono", SqlDbType.Int).Value = restaurante.telefono;
                comando.Parameters.Add("@activo", SqlDbType.Bit).Value = restaurante.activo;
                comando.Parameters.Add("@cant_clientes", SqlDbType.Int).Value = restaurante.cant_clientes;
                comando.Parameters.Add("@especialidad", SqlDbType.NVarChar).Value = restaurante.especialidad;
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            return "Ok";
            
        }

        // PUT: api/Restaurante/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Restaurante/5
        public void Delete(int id)
        {
        }
    }
}
