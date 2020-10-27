using Business;
using Entity;
using System; 
using System.Windows;
using System.Windows.Controls; 

namespace Semana04
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        public void Cargar()
        {
            BProducto BProducto = null;
            try
            {
                BProducto = new BProducto();
                dgvProductos.ItemsSource = BProducto.Listar(0);

            }
            catch (Exception)
            {
                MessageBox.Show("Error, Comunicarse con el Administrador");
            }
            finally
            {
                BProducto = null;
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        { 
            ManProducto manProducto = new ManProducto(0);
            manProducto.ShowDialog();
            Cargar();
        }

        private void DgvProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idProducto;
            var item = (Producto)dgvProductos.SelectedItem;
            if (item == null) return;
            idProducto = Convert.ToInt32(item.IdProducto);
            ManProducto manProducto = new ManProducto(idProducto);
            manProducto.ShowDialog();
            Cargar();
        }
    }
}
