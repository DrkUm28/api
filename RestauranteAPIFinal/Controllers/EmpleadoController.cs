﻿using System;
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
    public class EmpleadoController : ApiController
    {
        string cadena = "Data Source=DEREK\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/Empleado
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Empleado";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Empleado> empleados = new List<Empleado>();

                while (reader.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.cod_empleado = Int32.Parse(reader["cod_empleado"].ToString());
                    empleado.cedula = Int32.Parse(reader["cedula"].ToString());
                    empleado.nombre = reader["nombre"].ToString();
                    empleado.primerApellido = reader["primerApellido"].ToString();
                    empleado.segundoApellido = reader["segundoApellido"].ToString();
                    empleado.telefono1 = Int32.Parse(reader["telefono1"].ToString());
                    empleado.telefono2 = Int32.Parse(reader["telefono2"].ToString());
                    empleado.cod_puesto = Int32.Parse(reader["cod_puesto"].ToString());
                    empleado.cod_nacionalidad = Int32.Parse(reader["cod_nacionalidad"].ToString());
                    empleado.cod_restaurante = Int32.Parse(reader["cod_restaurante"].ToString());


                    empleados.Add(empleado);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(empleados);
                //build json result
                return json;
            }
        }

        // GET: api/Empleado/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empleado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Empleado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empleado/5
        public void Delete(int id)
        {
        }
    }
}