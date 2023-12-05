using SIS310.Model;
using SIS310.ViewModel;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;

namespace SIS310.View;

public partial class Pagina1 : ContentPage
{
    int total = 0;
    private TablaParetoViewModel tablaParetoViewModel;
    public Pagina1()
    {
        InitializeComponent();
        tablaParetoViewModel = new TablaParetoViewModel();
        listaTablaPareto.ItemsSource = tablaParetoViewModel.TablaParetoModels;
        Console.WriteLine($"Hashcode de tablaParetoViewModel en Pagina1: {tablaParetoViewModel.GetHashCode()}");

    }


    private async void Guardar_Clicked(object sender, EventArgs e)
    {
        if(txtCantidad != null && txtUnidades.Text !=null)
        {
            string producto = txtProducto.Text;
            int cantidad = int.Parse(txtCantidad.Text);
            int unidades = int.Parse(txtUnidades.Text);
            tablaParetoViewModel.AgregarItem(producto, cantidad, unidades);
        }
        
       else { await DisplayAlert("Error", "Ingrese los Datos.", "Aceptar"); }
       

        listaTablaPareto.ItemsSource = null;
        listaTablaPareto.ItemsSource = tablaParetoViewModel.TablaParetoModels;

        txtProducto.Text = "";
        txtCantidad.Text = "";
        txtUnidades.Text = "";
        sumarTotal();
    }
    private void sumarTotal()
    {
        ResultadoTablaPareto.ItemsSource = tablaParetoViewModel.TablaParetoModels.OrderByDescending(item => item.Resultado).ToList();
        Total.Text = "Total: " + tablaParetoViewModel.TotalVentas.ToString();
    }
    private  void Calcular_Clicked(object sender, EventArgs e)
    {
        tablaParetoViewModel.CalcularPorcentaje();

        ResultadoTablaPareto.IsVisible = true;
        ResultadoTablaPareto.ItemsSource = tablaParetoViewModel.TablaParetoModels;
        tablaParetoViewModel.ActualizarDatosGrafica();
       
    }
    public async void Grafica_Clicked(object sender, EventArgs e)
    {

        if (tablaParetoViewModel.DatosGrafica.Count > 0)
        {
            await Navigation.PushAsync(new Pagina2(tablaParetoViewModel));
          
        }
        else
        {
            await DisplayAlert("Sin Datos", "No hay datos disponibles para la gráfica.", "Aceptar");
        }

    }
}