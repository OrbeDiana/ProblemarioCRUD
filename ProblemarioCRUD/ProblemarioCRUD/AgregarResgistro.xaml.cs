using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProblemarioCRUD
{
    /// <summary>
    /// Lógica de interacción para AgregarRegistro.xaml
    /// </summary>
    public partial class AgregarRegistro : Window
    {
        string rutaBaseDeDatos = Environment.CurrentDirectory + "//Calificaciones.db";
        public AgregarRegistro()
        {
            InitializeComponent();
        }

        private void GuardarBtn_Click(object sender, RoutedEventArgs e)
        {
            Registros registro = new Registros()
            {
                Nombre = txtNombre.Text,
                Grado = txtGrado.Text,
                Grupo = txtGrupo.Text,
                Calificacion = Convert.ToDecimal(txtCalificacion.Text)
            };

            using (SQLiteConnection conexion = new SQLiteConnection(rutaBaseDeDatos))
            {
                conexion.CreateTable<Registros>();
                conexion.Insert(registro);
            }
            Close();
        }
    }
}