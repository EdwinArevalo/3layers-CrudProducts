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
            BCategoria BCategoria = null;
            try
            {
                BCategoria = new BCategoria();
                dgvCategoria.ItemsSource = BCategoria.Listar(0);

            }
            catch (Exception)
            {
                MessageBox.Show("Error, Comunicarse con el Administrador");
            }
            finally
            {
                BCategoria = null;
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        { 
            ManCategoria manCategoria= new ManCategoria(0);
            manCategoria.ShowDialog();
            Cargar();
        }

        private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCategoria;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (item == null) return;
            idCategoria = Convert.ToInt32(item.IdCategoria);
            ManCategoria manCategoria = new ManCategoria(idCategoria);
            manCategoria.ShowDialog();
            Cargar();
        }
    }
}
