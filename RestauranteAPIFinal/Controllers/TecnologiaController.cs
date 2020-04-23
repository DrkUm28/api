using System;
using System.Collections.Generic;
using System.Web.Http;
using RestauranteAPIFinal.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace RestauranteAPIFinal.Controllers
{
    public class TecnologiaController : ApiController
    {
        string cadena = "Data Source=DESKTOP-7N6N3E8\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/Tecnologia
        [HttpGet]
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Tecnologia";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Tecnologia> tecnologias = new List<Tecnologia>();

                while (reader.Read())
                {
                    Tecnologia tecnologia = new Tecnologia();
                    tecnologia.cod_tecnologia = Int32.Parse(reader["cod_tecnologia"].ToString());
                    tecnologia.nombre = reader["nombre"].ToString();
                    tecnologia.cantidad = Int32.Parse(reader["cantidad"].ToString());
                    tecnologia.precio = Double.Parse(reader["precio"].ToString());
                    tecnologia.cod_restaurante = Int32.Parse(reader["cod_restaurante"].ToString());
                    tecnologia.cod_marca = Int32.Parse(reader["cod_marca"].ToString());
                    tecnologia.descripcion = reader["descripcion"].ToString();
                    tecnologia.proveedor = Int32.Parse(reader["proveedor"].ToString());

                    tecnologias.Add(tecnologia);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(tecnologias);
                //build json result
                return json;
            }
        }

        // GET: api/Tecnologia/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tecnologia
        [HttpPost]
        public string Post([FromBody]Tecnologia tecnologia)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_tecnologia";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cod_tecnologia", SqlDbType.Int).Value = tecnologia.cod_tecnologia;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = tecnologia.nombre;
                comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = tecnologia.cantidad;
                comando.Parameters.Add("@precio", SqlDbType.Decimal).Value = tecnologia.precio;
                comando.Parameters.Add("@cod_restaurante", SqlDbType.Int).Value = tecnologia.cod_restaurante;
                comando.Parameters.Add("@cod_marca", SqlDbType.Int).Value = tecnologia.cod_marca;
                comando.Parameters.Add("@descipcion", SqlDbType.NVarChar).Value = tecnologia.descripcion;
                comando.Parameters.Add("@proveedor", SqlDbType.Int).Value = tecnologia.proveedor;



                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/Tecnologia/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tecnologia/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
