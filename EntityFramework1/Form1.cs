using EntityFramework1.Modelos;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            string cadenaDeConexion = @"Server=192.168.1.253\SQLDEVELOPERCQ,1433;Database=Supermercado;User=sa;Password=123456";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion)) { 
                con.Open();
                label1.Text = "Estado: Conectado";
                
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cadenaDeConexion = @"Server=192.168.1.253\SQLDEVELOPERCQ,1433;Database=Supermercado;User=sa;Password=123456";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();

                //Ejemplo: crear tabla
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "CREATE TABLE Cliente (nit INT NOT NULL PRIMARY KEY, apellido VARCHAR(40) NOT NULL);";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                comando.Dispose();
                label1.Text = "Estado: Tabla creada";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cadenaDeConexion = @"Server=192.168.1.253\SQLDEVELOPERCQ,1433;Database=Supermercado;User=sa;Password=123456";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: insertar en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO Empleado (idEmpleado, apellido, nombre) VALUES ('3', 'Roca','Sofia');";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                comando.Dispose();
                label1.Text = "Estado: Registro insertado";
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cadenaDeConexion = @"Server=192.168.1.253\SQLDEVELOPERCQ,1433;Database=Supermercado;User=sa;Password=123456";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: delete en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "DELETE FROM Empleado WHERE idEmpleado = '2';";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                comando.Dispose();
                label1.Text = "Estado: Registro eliminado";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            string cadenaDeConexion = @"Server=192.168.1.253\SQLDEVELOPERCQ,1433;Database=Supermercado;User=sa;Password=123456";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: select en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM Empleado;";
                comando.Connection = con;
                SqlDataReader reader = comando.ExecuteReader();
                string aux = "";
                while (reader.Read())
                {
                    aux += $"id: {reader.GetString(0)}, nombre completo: {reader.GetString(1)} {reader.GetString(2)}\n";
                    Empleado emp = new Empleado();
                    emp.idEmpleado = reader.GetString(0);
                    emp.nombre = reader.GetString(1);
                    emp.apellido = reader.GetString(2);
                    listaEmpleados.Add(emp);
                        
                }
                comando.Dispose();
                label1.Text = aux;aux = "";
                foreach(Empleado em in listaEmpleados){
                    aux += $"Nombre: {em.nombre} {em.apellido}; id: {em.idEmpleado}\n";
                }
                label1.Text = aux;
                /*
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
                */
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string cadenaDeConexion = @"Server=192.168.1.253\SQLDEVELOPERCQ,1433;Database=Supermercado;User=sa;Password=123456";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();

                //Ejemplo: crear tabla
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "CREATE PROCEDURE insertar_empleado (@id NCHAR(10), @nom NCHAR(10), @ap NCHAR(10)) AS INSERT INTO Empleado VALUES (@id, @nom, @ap)";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                comando.Dispose();
                label1.Text = "Estado: Procedimiento creado";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cadenaDeConexion = @"Server=192.168.1.253\SQLDEVELOPERCQ,1433;Database=Supermercado;User=sa;Password=123456";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: select en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT SPECIFIC_NAME FROM Supermercado.INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE';";
                comando.Connection = con;
                SqlDataReader reader = comando.ExecuteReader();
                string aux = "";
                while (reader.Read())
                {
                    aux += $"id: {reader["SPECIFIC_NAME"]}\n";
                }
                comando.Dispose();
                label1.Text = aux;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //TODO ejecutar procedimiento almacenado
            string cadenaDeConexion = @"Server=192.168.1.253\SQLDEVELOPERCQ,1433;Database=Supermercado;User=sa;Password=123456";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("insertar_empleado", con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id","333"));
                comando.Parameters.Add(new SqlParameter("@nom", "Luis"));
                comando.Parameters.Add(new SqlParameter("@ap", "Rocha"));
                int resultado = comando.ExecuteNonQuery();
                if(resultado > 0)
                    label1.Text = "Se ingresó un registro";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cadenaDeConexion = @"Server=192.168.1.253;Database=Supermercado;User=sa;Password=123456";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("getEmpByApellido", con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@ap", "Rocha"));
                SqlDataReader reader = comando.ExecuteReader();
                label1.Text = "";
                while (reader.Read()) { 
                    label1.Text += $" nombre: {reader[1]}, apellido: {reader[0]}\n";
                }
                    
            }
        }
    }
}
