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
    public class BebidasController : ApiController
    {
        string cadena = "Data Source=DEREK\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";


        // GET: api/Bebidas
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_get_bebidas";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Bebidas> bebidas = new List<Bebidas>();

                while (reader.Read())
                {
                    Bebidas bebida = new Bebidas();
                    bebida.cod_bebida = Int32.Parse(reader["cod_bebida"].ToString());
                    bebida.nombre = reader["nombre"].ToString();
                    bebida.tipo = Int32.Parse(reader["tipo"].ToString());
                    bebida.nacionalidad = Int32.Parse(reader["nacionalidad"].ToString());
                    bebida.marca = Int32.Parse(reader["marca"].ToString());
                    bebida.precio_unitario = Double.Parse(reader["precio_unitario"].ToString());  //este dato es un decimal entonces no me deja parsearlo como un int
                    bebida.precio_botella = Double.Parse(reader["precio_botella"].ToString());
                    bebida.cantidad = Int32.Parse(reader["cantidad"].ToString());
                    bebida.anio_cosecha = Int32.Parse(reader["anio_cosecha"].ToString());
                    bebida.descripcion = reader["descripcion"].ToString();
                    bebida.proveedor = Int32.Parse(reader["proveedor"].ToString());



                    bebidas.Add(bebida);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(bebidas);
                //build json result
                return json;
            }
        }

        // GET: api/Bebidas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bebidas
        public string Post([FromBody]Bebidas bebida)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_bebida";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cod_bebida", SqlDbType.Int).Value = bebida.cod_bebida;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = bebida.nombre;
                comando.Parameters.Add("@tipo", SqlDbType.Int).Value = bebida.tipo;
                comando.Parameters.Add("@nacionalidad", SqlDbType.Int).Value = bebida.nacionalidad;
                comando.Parameters.Add("@marca", SqlDbType.Int).Value = bebida.marca;
                comando.Parameters.Add("@precio_unitario", SqlDbType.Decimal).Value = bebida.precio_unitario; 
                comando.Parameters.Add("@precio_botella", SqlDbType.Decimal).Value = bebida.precio_botella;
                comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = bebida.cantidad;
                comando.Parameters.Add("@anio_cosecha", SqlDbType.Int).Value = bebida.anio_cosecha;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = bebida.descripcion;
                comando.Parameters.Add("@proveedor", SqlDbType.Int).Value = bebida.proveedor;
                comando.Parameters.Add("@restaurante", SqlDbType.Int).Value = bebida.restaurante;



                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/Bebidas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bebidas/5
        public void Delete(int id)
        {
        }
    }
}
