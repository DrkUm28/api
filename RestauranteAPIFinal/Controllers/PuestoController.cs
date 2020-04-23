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
    public class PuestoController : ApiController
    {

        string cadena = "Data Source=DEREK\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";
        // GET: api/Puesto
        public string  Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Puesto";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Puesto> puestos = new List<Puesto>();

                while (reader.Read())
                {
                    Puesto puesto = new Puesto();
                    puesto.cod_puesto = Int32.Parse(reader["cod_puesto"].ToString());
                    puesto.cod_rol = Int32.Parse(reader["cod_rol"].ToString());
                    puesto.nombre = reader["nombre"].ToString();
                    puesto.interno_restaurante = Boolean.Parse(reader["interno_restaurante"].ToString());
                    puesto.externo_restaurante = Boolean.Parse(reader["externo_restaurante"].ToString());

                    puestos.Add(puesto);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(puestos);
                //build json result
                return json;
            }
        }

        // GET: api/Puesto/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Puesto
        public string Post([FromBody]Puesto puesto)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_puesto";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = puesto.nombre;
                comando.Parameters.Add("@interno_restaurante", SqlDbType.Bit).Value = puesto.interno_restaurante;
                comando.Parameters.Add("@externo_restaurante", SqlDbType.Bit).Value = puesto.externo_restaurante;
                comando.Parameters.Add("@cod_rol", SqlDbType.Int).Value = puesto.cod_rol;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/Puesto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Puesto/5
        public void Delete(int id)
        {
        }
    }
}
