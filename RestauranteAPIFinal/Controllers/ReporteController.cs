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
    public class ReporteController : ApiController
    {
        string cadena = "Data Source=DEREK\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/Reporte
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from ReporteCaja";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Reporte> reportes = new List<Reporte>();

                while (reader.Read())
                {
                    Reporte reporte = new Reporte();
                    reporte.cod_caja = Int32.Parse(reader["cod_caja"].ToString());
                    reporte.fecha_hora = DateTime.Parse(reader["fecha_hora"].ToString());
                    reporte.descripcion_accion = reader["descripcion_accion"].ToString();
                    reporte.monto_dinero = Double.Parse(reader["monto_dinero"].ToString());
                    reporte.apertura_caja = Double.Parse(reader["apertura_caja"].ToString());
                    reporte.cierre_caja = Double.Parse(reader["cierre_caja"].ToString());

                    reportes.Add(reporte);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(reportes);
                //build json result
                return json;
            }
        }

        // GET: api/Reporte/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reporte
        public string Post([FromBody]Reporte reporte)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_reporteCaja";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cod_caja", SqlDbType.Int).Value = reporte.cod_caja; //hay que quitarle los codigos a cada sp porque tienen que ser generados automaticamente
                comando.Parameters.Add("@fecha_hora", SqlDbType.DateTime).Value = reporte.fecha_hora;
                comando.Parameters.Add("@descripcion_accion", SqlDbType.NVarChar).Value = reporte.descripcion_accion;
                comando.Parameters.Add("@monto_dinero", SqlDbType.Decimal).Value = reporte.monto_dinero;
                comando.Parameters.Add("@apertura_caja", SqlDbType.Decimal).Value = reporte.apertura_caja;
                comando.Parameters.Add("@cierre_caja", SqlDbType.Decimal).Value = reporte.cierre_caja;
                comando.Parameters.Add("@restaurante", SqlDbType.Int).Value = reporte.restaurante; 

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/Reporte/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reporte/5
        public void Delete(int id)
        {
        }
    }
}
