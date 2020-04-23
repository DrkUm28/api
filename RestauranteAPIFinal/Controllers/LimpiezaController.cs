using System;
using System.Collections.Generic;
using System.Web.Http;
using RestauranteAPIFinal.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace RestauranteAPIFinal.Controllers
{
    public class LimpiezaController : ApiController
    {
        string cadena = "Data Source=DESKTOP-7N6N3E8\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/Limpieza
        [HttpGet]
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from LimpiezaHigiene";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<LimpiezaHigiene> limpieza = new List<LimpiezaHigiene>();

                while (reader.Read())
                {
                    LimpiezaHigiene higiene = new LimpiezaHigiene();
                    higiene.cod_limpieza = Int32.Parse(reader["cod_limpieza"].ToString());
                    higiene.cod_restaurante = Int32.Parse(reader["cod_restaurante"].ToString());
                    higiene.nombre = reader["nombre"].ToString();
                    higiene.cod_marca = Int32.Parse(reader["cod_marca"].ToString());
                    higiene.cantidad = Int32.Parse(reader["cantidad"].ToString());
                    higiene.descripcion = reader["descripcion"].ToString();
                    higiene.liquido = Boolean.Parse(reader["liquido"].ToString());
                    higiene.tipo = reader["tipo"].ToString();
                    higiene.cantidadMedida = reader["cantidadMedida"].ToString();
                    higiene.cod_unidadMedida = Int32.Parse(reader["cod_unidadMedida"].ToString());



                    limpieza.Add(higiene);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(limpieza);
                //build json result
                return json;
            }
        }

        // GET: api/Limpieza/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Limpieza
        [HttpPost]
        public string Post([FromBody]LimpiezaHigiene limpiezaHigiene)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_limpiezaHigiene";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cod_limpieza", SqlDbType.Int).Value = limpiezaHigiene.cod_limpieza;
                comando.Parameters.Add("@cod_restaurante", SqlDbType.Int).Value = limpiezaHigiene.cod_restaurante;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = limpiezaHigiene.nombre;
                comando.Parameters.Add("@cod_marca", SqlDbType.Int).Value = limpiezaHigiene.cod_marca;
                comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = limpiezaHigiene.cantidad;
                comando.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = limpiezaHigiene.descripcion;
                comando.Parameters.Add("@liquido", SqlDbType.Bit).Value = limpiezaHigiene.liquido;
                comando.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = limpiezaHigiene.tipo;
                comando.Parameters.Add("@cantidadMedida", SqlDbType.NVarChar).Value = limpiezaHigiene.cantidadMedida;
                comando.Parameters.Add("@cod_unidadMedida", SqlDbType.Int).Value = limpiezaHigiene.cod_unidadMedida;
                comando.Parameters.Add("@proveedor", SqlDbType.Int).Value = limpiezaHigiene.proveedor;

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/Limpieza/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Limpieza/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
