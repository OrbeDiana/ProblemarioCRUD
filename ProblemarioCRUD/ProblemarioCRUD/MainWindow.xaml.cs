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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProblemarioCRUD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string rutaBaseDeDatos = Environment.CurrentDirectory + "//Calificaciones.db";
        public MainWindow()
        {
            InitializeComponent();
            LeerDatos();
        }

        private void LeerDatos()
        {
            using (SQLiteConnection conn = new SQLiteConnection(rutaBaseDeDatos))
            {
                conn.CreateTable<Registros>();
                RegistrosList.ItemsSource = conn.Table<Registros>();
            }
        }

        private void AgregarBtn_Click(object sender, RoutedEventArgs e)
        {
            AgregarRegistro form = new AgregarRegistro();
            form.ShowDialog();
            LeerDatos();
        }

        private void EditarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RegistrosList.SelectedItems.Count > 0)
            {
                Registros registro = (Registros)RegistrosList.SelectedItems[0];
                EditarRegistro form = new EditarRegistro(registro.Id, registro.Nombre, registro.Grado, registro.Grupo, registro.Calificacion);
                form.ShowDialog();
                LeerDatos();
            }
        }

        private void EliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RegistrosList.SelectedItems.Count > 0)
            {
                Registros registro = (Registros)RegistrosList.SelectedItems[0];
                using (SQLiteConnection conn = new SQLiteConnection(rutaBaseDeDatos))
                {
                    conn.CreateTable<Registros>();
                    conn.Delete(registro);
                }
                LeerDatos();
            }
        }
        private void ActualizarBtn_Click(object sender, RoutedEventArgs e)
        {
            LeerDatos();
        }
    }
}
