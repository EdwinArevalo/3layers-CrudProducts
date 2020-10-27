using System;
using System.Collections.Generic;
using Business;
using Entity;
using System.Windows; 

namespace Semana04
{
    /// <summary>
    /// Lógica de interacción para ManCategoria.xaml
    /// </summary>
    public partial class ManCategoria : Window
    {
        public int ID { get; set; }
        public ManCategoria(int Id)
        {
            InitializeComponent();
            ID = Id;
            if (ID > 0)
            {
                BtnEliminar.Opacity = 100;
                BtnEliminar.IsEnabled = true;

                BCategoria bCategoria = new BCategoria();
                List<Categoria> categorias = new List<Categoria>();
                categorias = bCategoria.Listar(ID);
                if (categorias.Count > 0)
                {
                    lblID.Content = categorias[0].IdCategoria;
                    txtNombre.Text = categorias[0].NombreCategoria;
                    txtDescripcion.Text = categorias[0].Descripcion; 
                }
                
            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BCategoria BCategoria = null;
            bool result = true;
            try
            {
                BCategoria = new BCategoria();
                if (this.ID > 0)
                {
                    result = BCategoria.Actualizar(new Categoria { IdCategoria = this.ID, NombreCategoria = txtNombre.Text, Descripcion=txtDescripcion.Text });
                }
                else
                {
                    result = BCategoria.Insertar(new Categoria { NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });
                }

                if (!result)
                {
                    MessageBox.Show("Error");
                }

                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Comunicarse con el administrador");
            }
            finally
            {
                BCategoria = null;
            }

        }

        private void BtnEliminar_Click(Object sender, RoutedEventArgs e) 
        {
            BCategoria BCategoria = null;
            bool result = true;
            try
            {
                BCategoria = new BCategoria();
                if (this.ID > 0)
                {
                    result = BCategoria.Eliminar(this.ID);
                } 

                if (!result)
                {
                    MessageBox.Show("Error al eliminar");
                }

                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Comunicarse con el administrador");
            }
            finally
            {
                BCategoria = null;
            }
        }

        private void BtnCerrar_Click(Object sender, RoutedEventArgs e) 
        {
            Close();
        }

    }
}
