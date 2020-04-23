using System;
using System.Collections.Generic;
using System.Web.Http;
using RestauranteAPIFinal.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace RestauranteAPIFinal.Controllers
{
    public class BitacoraController : ApiController
    {
        string cadena = "Data Source=DESKTOP-7N6N3E8\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/Bitacora
        [HttpGet]
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Bitacora";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Bitacora> bitacoras = new List<Bitacora>();

                while (reader.Read())
                {
                    Bitacora bitacora = new Bitacora();
                    bitacora.cod_bitacora = Int32.Parse(reader["cod_bitacora"].ToString());
                    bitacora.usuario = reader["usuario"].ToString();
                    bitacora.fecha_hora_accion = DateTime.Parse(reader["fecha_hora_accion"].ToString());
                    bitacora.descripcion_accion = reader["descripcion_accion"].ToString();
                    bitacora.detalle_accion = reader["detalle_accion"].ToString();
                    bitacora.restaurante = Int32.Parse(reader["restaurante"].ToString());

                    bitacoras.Add(bitacora);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(bitacoras);
                //build json result
                return json;
            }
        }

        // GET: api/Bitacora/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bitacora
        [HttpPost]
        public string Post([FromBody]Bitacora bitacora)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_restaurante"; //falta sp de insertar bitacora
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@usuario", SqlDbType.Int).Value = bitacora.usuario;
                comando.Parameters.Add("@fecha_hora_accion", SqlDbType.DateTime).Value = bitacora.fecha_hora_accion;
                comando.Parameters.Add("@descripcion_accion", SqlDbType.NVarChar).Value = bitacora.descripcion_accion;
                comando.Parameters.Add("@detalle_accion", SqlDbType.NVarChar).Value = bitacora.detalle_accion;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/Bitacora/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bitacora/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
