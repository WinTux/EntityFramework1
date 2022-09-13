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

            }
                
        }
    }
}
