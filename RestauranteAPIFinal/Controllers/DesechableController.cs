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
    public class DesechableController : ApiController
    {
        string cadena = "Data Source=DEREK\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/Desechable
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from DesechableEmpaque";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Desechables> desechables = new List<Desechables>();

                while (reader.Read())
                {
                    Desechables desechable = new Desechables();
                    desechable.cod_empaque = Int32.Parse(reader["cod_empaque"].ToString());
                    desechable.cod_restaurante = Int32.Parse(reader["cod_restaurante"].ToString());
                    desechable.nombre = reader["nombre"].ToString();
                    desechable.cod_marca = Int32.Parse(reader["cod_marca"].ToString());
                    desechable.descripcion = reader["descripcion"].ToString();
                    desechable.cantidad = Int32.Parse(reader["cantidad"].ToString());

                    desechables.Add(desechable);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(desechables);
                //build json result
                return json;
            }
        }

        // GET: api/Desechable/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Desechable
        public string Post([FromBody]Desechables desechable)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_desechableEmpaque";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cod_empaque", SqlDbType.Int).Value = desechable.cod_empaque;
                comando.Parameters.Add("@cod_restaurante", SqlDbType.Int).Value = desechable.cod_restaurante;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = desechable.nombre;
                comando.Parameters.Add("@cod_marca", SqlDbType.Int).Value = desechable.cod_marca;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = desechable.descripcion;
                comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = desechable.cantidad;
                comando.Parameters.Add("@proveedor", SqlDbType.Int).Value = desechable.proveedor;



                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";


        }

        // PUT: api/Desechable/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Desechable/5
        public void Delete(int id)
        {
        }
    }
}
