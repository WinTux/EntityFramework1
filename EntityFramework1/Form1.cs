using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cadenaDeConexion = @"Server=192.168.1.253,1433;DataBase=Supermercado;User=Pepe;Password=123456";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion)) { 
                con.Open();
                label1.Text = "Estado: Conectado";

                //Ejemplo: crear tabla
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "CREATE TABLE Cliente (nit INT, apellido VARCHAR(40));";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                comando.Dispose();

                //Ejemplo: insertar en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO Empleado (idEmpleado, apellido, nombre) VALUES ('2', 'Roca','Sofia');";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                comando.Dispose();

                //Ejemplo: delete en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "DELETE FROM Cliente WHERE idEmpleado = '2';";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                comando.Dispose();

                //Ejemplo: select en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM Empleado;";
                comando.Connection = con;
                SqlDataReader reader = comando.ExecuteReader();
                string aux = "";
                while (reader.Read()) {
                    aux += $"id: {reader.GetString(0)}, nombre completo: {reader.GetString(1)} {reader.GetString(2)}\n";
                }

                /*
                
                []
                []
                []
                []
                -> 
                 
                 
                 */

                //Ejemplo: select complejo en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT nombre, AVG(edad) FROM Empleado GROUP BY APELLIDO;";
                comando.Connection = con;
                 reader = comando.ExecuteReader();
                 aux = "";
                while (reader.Read())
                {
                    aux += $"id: {reader.GetString(0)}, nombre completo: {reader.GetString(1)} {reader.GetString(2)}\n";
                }

                reader.Close();

                comando.Dispose();
            }
                
        }
    }
}
