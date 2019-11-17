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
using WPFDatabse.Clases;
using SQLite;

namespace WPFDatabse
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        List<Contactos> contactos;
        public Principal()
        {
            InitializeComponent();
            contactos = new List<Contactos>();
            LeerBaseDatos();
        }
        void LeerBaseDatos()
        {
            using (SQLite.SQLiteConnection conn =
                new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contactos>();
                contactos = (conn.Table<Contactos>().ToList()).
                    OrderBy(c => c.Nombre).ToList();
            }
            if (contactos != null)
            {
                lvContactos.ItemsSource = contactos;
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            WPFDatabse.MainWindow form = new WPFDatabse.MainWindow();
            form.ShowDialog();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            WPFDatabse.EliminarDatos form = new WPFDatabse.EliminarDatos();
            form.ShowDialog();

        }
    }
}