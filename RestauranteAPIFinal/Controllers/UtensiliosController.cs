using System;
using System.Collections.Generic;
using System.Web.Http;
using RestauranteAPIFinal.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace RestauranteAPIFinal.Controllers
{
    public class UtensiliosController : ApiController
    {
        string cadena = "Data Source=DESKTOP-7N6N3E8\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";
        // GET: api/Utensilios
        [HttpGet]
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from EquipoUtensilio";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Utensilios> utensilios = new List<Utensilios>();

                while (reader.Read())
                {
                    Utensilios utensilio = new Utensilios();
                    utensilio.cod_equipo = Int32.Parse(reader["cod_equipo"].ToString());
                    utensilio.cod_restaurante = Int32.Parse(reader["cod_restaurante"].ToString());
                    utensilio.nombre = reader["nombre"].ToString();
                    utensilio.cod_marca = Int32.Parse(reader["cod_marca"].ToString());
                    utensilio.cantidad = Int32.Parse(reader["cantidad"].ToString());
                    utensilio.descripcion = reader["descripcion"].ToString();
                    utensilio.proveedor = Int32.Parse(reader["proveedor"].ToString());



                    utensilios.Add(utensilio);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(utensilios);
                //build json result
                return json;
            }
        }

        // GET: api/Utensilios/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Utensilios
        [HttpPost]
        public string Post([FromBody]Utensilios utensilios)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_desechableEmpaque";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cod_equipo", SqlDbType.Int).Value = utensilios.cod_equipo;
                comando.Parameters.Add("@cod_restaurante", SqlDbType.Int).Value = utensilios.cod_restaurante;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = utensilios.nombre;
                comando.Parameters.Add("@cod_marca", SqlDbType.Int).Value = utensilios.cod_marca;
                comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = utensilios.cantidad;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = utensilios.descripcion;
                comando.Parameters.Add("@proveedor", SqlDbType.Int).Value = utensilios.proveedor;



                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";

        }

        // PUT: api/Utensilios/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Utensilios/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
