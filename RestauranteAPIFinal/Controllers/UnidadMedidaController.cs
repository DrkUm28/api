using System;
using System.Collections.Generic;
using System.Web.Http;
using RestauranteAPIFinal.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace RestauranteAPIFinal.Controllers
{
    public class UnidadMedidaController : ApiController
    {
        string cadena = "Data Source=DESKTOP-7N6N3E8\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/UnidadMedida
        [HttpGet]
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from DesechableEmpaque";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<UnidadMedida> unidad = new List<UnidadMedida>();

                while (reader.Read())
                {
                    UnidadMedida medida = new UnidadMedida();
                    medida.cod_unidadMedida = Int32.Parse(reader["cod_unidadMedida"].ToString());
                    medida.unidad_medida = reader["unidad_medida"].ToString();
                    medida.escala = Int32.Parse(reader["escala"].ToString());
                    medida.tipo_unidad = reader["tipo_unidad"].ToString();
                    medida.simbologia = reader["simbologia"].ToString();

                    unidad.Add(medida);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(unidad);
                //build json result
                return json;
            }
        }

        // GET: api/UnidadMedida/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UnidadMedida
        [HttpPost]
        public string Post([FromBody]UnidadMedida unidadMedida)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_unidadMedida";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@unidad_medida", SqlDbType.NVarChar).Value = unidadMedida.unidad_medida;
                comando.Parameters.Add("@escala", SqlDbType.Int).Value = unidadMedida.escala;
                comando.Parameters.Add("@tipo_unidad", SqlDbType.NVarChar).Value = unidadMedida.tipo_unidad;
                comando.Parameters.Add("@simbologia", SqlDbType.Bit).Value = unidadMedida.simbologia;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/UnidadMedida/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UnidadMedida/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
