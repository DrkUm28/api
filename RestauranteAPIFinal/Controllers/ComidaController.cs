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
    

    public class ComidaController : ApiController
    {

        string cadena = "Data Source=DEREK\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";
        // GET: api/Comida
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Comida";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Comida> comidas = new List<Comida>();

                while (reader.Read())
                {
                    Comida comida = new Comida();
                    comida.cod_comida = Int32.Parse(reader["cod_comida"].ToString());
                    comida.nombre = reader["nombre"].ToString();
                    comida.precio = Double.Parse(reader["precio"].ToString());
                    comida.cod_tipoComestible = Int32.Parse(reader["cod_tipoComestible"].ToString());
                    comida.cod_unidadMedida = Int32.Parse(reader["cod_unidadMedida"].ToString());
                    comida.detalle = reader["detalle"].ToString();
                    comida.ingredientes = reader["ingredientes"].ToString();
                    comida.linea = Int32.Parse(reader["linea"].ToString());
                    comida.clase = Int32.Parse(reader["clase"].ToString());
                    comida.es_bufet = Boolean.Parse(reader["es_bufet"].ToString());
                    comida.es_especialidad = Boolean.Parse(reader["es_especialidad"].ToString());

                    comidas.Add(comida);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(comidas);
                //build json result
                return json;
            }
        }

        // GET: api/Comida/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comida
        public string Post([FromBody]Comida comida)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_comida";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cod_comida", SqlDbType.Int).Value = comida.cod_comida;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = comida.nombre;
                comando.Parameters.Add("@precio", SqlDbType.Decimal).Value = comida.precio;
                comando.Parameters.Add("@cod_tipoComestible", SqlDbType.Int).Value = comida.cod_tipoComestible;
                comando.Parameters.Add("@cod_unidadMedida", SqlDbType.Int).Value = comida.cod_unidadMedida;
                comando.Parameters.Add("@detalle", SqlDbType.VarChar).Value = comida.detalle;
                comando.Parameters.Add("@ingredientes", SqlDbType.VarChar).Value = comida.ingredientes;
                comando.Parameters.Add("@linea", SqlDbType.Int).Value = comida.linea;
                comando.Parameters.Add("@clase", SqlDbType.Int).Value = comida.clase;
                comando.Parameters.Add("@es_bufet", SqlDbType.Bit).Value = comida.es_bufet;
                comando.Parameters.Add("@es_restaurante", SqlDbType.Bit).Value = comida.es_especialidad;
                comando.Parameters.Add("@restaurantee", SqlDbType.Int).Value = comida.restaurante;

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/Comida/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comida/5
        public void Delete(int id)
        {
        }
    }
}
