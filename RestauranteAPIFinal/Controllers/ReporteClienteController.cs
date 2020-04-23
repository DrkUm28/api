using System;
using System.Collections.Generic;
using System.Web.Http;
using RestauranteAPIFinal.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace RestauranteAPIFinal.Controllers
{

    public class ReporteClienteController : ApiController
    {
        string cadena = "Data Source=DESKTOP-7N6N3E8\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/ReporteCliente
        [HttpGet]
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from ReporteClientes";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<ReporteClientes> clientes = new List<ReporteClientes>();

                while (reader.Read())
                {
                    ReporteClientes reporteClien = new ReporteClientes();
                    reporteClien.cod_reporteCliente = Int32.Parse(reader["cod_reporteCliente"].ToString());
                    reporteClien.cod_cliente = Int32.Parse(reader["cod_cliente"].ToString());
                    reporteClien.descripcion = reader["descripcion"].ToString();
                    reporteClien.restaurante = Int32.Parse(reader["restaurante"].ToString());
                    reporteClien.cod_factura = Int32.Parse(reader["cod_factura"].ToString());


                    clientes.Add(reporteClien);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(clientes);
                //build json result
                return json;
            }

        }

        // GET: api/ReporteCliente/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ReporteCliente
        [HttpPost]
        public string Post([FromBody]ReporteClientes cliente)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_reporteCliente";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cod_reporteCliente", SqlDbType.Int).Value = cliente.cod_reporteCliente;
                comando.Parameters.Add("@cod_cliente", SqlDbType.Int).Value = cliente.cod_cliente;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = cliente.descripcion;
                comando.Parameters.Add("@restaurante", SqlDbType.Int).Value = cliente.restaurante;
                comando.Parameters.Add("@cod_factura", SqlDbType.Int).Value = cliente.cod_factura;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/ReporteCliente/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReporteCliente/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
