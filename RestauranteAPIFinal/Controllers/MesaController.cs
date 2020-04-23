using System;
using System.Collections.Generic;
using System.Web.Http;
using RestauranteAPIFinal.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace RestauranteAPIFinal.Controllers
{
    public class MesaController : ApiController
    {
        string cadena = "Data Source=DESKTOP-7N6N3E8\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";
        // GET: api/Mesa
        [HttpGet]
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Mesa";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Mesa> mesas = new List<Mesa>();

                while (reader.Read())
                {
                    Mesa mesita = new Mesa();
                    mesita.cod_mesa = Int32.Parse(reader["cod_mesa"].ToString());

                    mesita.nombre = reader["nombre"].ToString();
                    mesita.numero = Int32.Parse(reader["numero"].ToString());
                    mesita.cantidadSillas = Int32.Parse(reader["cantidadSillas"].ToString());

                    mesas.Add(mesita);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(mesas);
                //build json result
                return json;
            }
        }

        // GET: api/Mesa/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mesa
        [HttpPost]
        public string Post([FromBody] Mesa mesa)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_mesa";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cod_mesa", SqlDbType.Int).Value = mesa.cod_mesa;
                comando.Parameters.Add("@restaurante", SqlDbType.Int).Value = mesa.restaurante;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = mesa.nombre;
                comando.Parameters.Add("@numero", SqlDbType.Int).Value = mesa.numero;
                comando.Parameters.Add("@cantidadSillas", SqlDbType.Int).Value = mesa.cantidadSillas;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/Mesa/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mesa/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
