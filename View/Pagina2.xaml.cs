using SIS310.Model;
using SIS310.ViewModel;
using Syncfusion.Maui.Charts;
using System.Collections.ObjectModel;

namespace SIS310.View;

public partial class Pagina2 : ContentPage
{

    private TablaParetoViewModel tablaParetoViewModel;
    public Pagina2(TablaParetoViewModel viewModel)
    {
        InitializeComponent();
        tablaParetoViewModel = viewModel;
        MyPage.BindingContext = tablaParetoViewModel;
        Console.WriteLine($"Hashcode de viewModel en Pagina2: {viewModel.GetHashCode()}");
    }

    private void ActualizarTabla_Clicked(object sender, EventArgs e)
    {
        tablaParetoViewModel.ActualizarDatosGrafica();

    } 



}
