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
    public class ProveedorController : ApiController
    {
        string cadena = "Data Source=DEREK\\SQLEXPRESS;Initial Catalog=ProyectoServiciosWeb;Integrated Security=True";

        // GET: api/Proveedor
        public string Get()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "select * from Proveedor";
                SqlCommand comando = new SqlCommand(query, conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Proveedor> proveedores = new List<Proveedor>();

                while (reader.Read())
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.cod_proveedor = Int32.Parse(reader["cod_proveedor"].ToString());
                    proveedor.cedula = Int32.Parse(reader["cedula"].ToString());
                    proveedor.fechaIngreso = DateTime.Parse(reader["fechaIngreso"].ToString());
                    proveedor.nombre = reader["nombre"].ToString();
                    proveedor.primerApellido = reader["primerApellido"].ToString();
                    proveedor.segundoApellido = reader["segundoApellido"].ToString();
                    proveedor.correo = reader["correo"].ToString();
                    proveedor.direccion = reader["direccion"].ToString();
                    proveedor.telefono_oficina = Int32.Parse(reader["telefono_oficina"].ToString());
                    proveedor.fax = Int32.Parse(reader["fax"].ToString());
                    proveedor.cedula = Int32.Parse(reader["celular"].ToString());

                    proveedores.Add(proveedor);
                }
                conexion.Close();

                var json = JsonConvert.SerializeObject(proveedores);
                //build json result
                return json;
            }
        }

        // GET: api/Proveedor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Proveedor
        public string Post([FromBody]Proveedor proveedor)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {

                string query = "sp_insert_proveedor";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cedula", SqlDbType.Int).Value = proveedor.cedula;
                comando.Parameters.Add("@fechaIngreso", SqlDbType.Date).Value = proveedor.fechaIngreso;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = proveedor.nombre;
                comando.Parameters.Add("@primerApellido", SqlDbType.VarChar).Value = proveedor.primerApellido;
                comando.Parameters.Add("@segundoApellido", SqlDbType.VarChar).Value = proveedor.segundoApellido;
                comando.Parameters.Add("@correo", SqlDbType.VarChar).Value = proveedor.correo;
                comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = proveedor.direccion;
                comando.Parameters.Add("@telefono_oficina", SqlDbType.Int).Value = proveedor.telefono_oficina;
                comando.Parameters.Add("@fax", SqlDbType.Int).Value = proveedor.fax;
                comando.Parameters.Add("@celular", SqlDbType.Int).Value = proveedor.celular;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            return "Ok";
        }

        // PUT: api/Proveedor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Proveedor/5
        public void Delete(int id)
        {
        }
    }
}
