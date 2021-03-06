﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using RestauranteAPIFinal.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace RestauranteAPIFinal.Controllers
{
    public class ReporteCajaController : ApiController
    {
        string cadena = "Data Source=DESKTOP-7N6N3E8\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/ReporteCaja
        [HttpGet]
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from ReporteCaja_Factura";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<ReporteCaja> reporteCajas = new List<ReporteCaja>();

                while (reader.Read())
                {
                    ReporteCaja reporteC = new ReporteCaja();
                    reporteC.cod_caja = Int32.Parse(reader["cod_caja"].ToString());
                    reporteC.cod_reporteCaja = Int32.Parse(reader["cod_reporteCaja"].ToString());
                    reporteC.cod_factura = Int32.Parse(reader["cod_factura"].ToString());


                    reporteCajas.Add(reporteC);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(reporteCajas);
                //build json result
                return json;
            }
        }

        // GET: api/ReporteCaja/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ReporteCaja
        [HttpPost]
        public string Post([FromBody]ReporteCaja reporteCa)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_reporteCaja_factura";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cod_caja", SqlDbType.Int).Value = reporteCa.cod_caja;
                comando.Parameters.Add("@factura", SqlDbType.Int).Value = reporteCa.cod_factura;

                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";


        }

        // PUT: api/ReporteCaja/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReporteCaja/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
