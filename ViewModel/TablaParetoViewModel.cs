using SIS310.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS310.ViewModel
{
    public class TablaParetoViewModel : INotifyPropertyChanged
    {
        private List<TablaParetoModel> tablaParetoModels;
        private ObservableCollection <GraficaModel> datosGrafica;

       

        public TablaParetoViewModel()
        {
            tablaParetoModels = new List<TablaParetoModel>();
            datosGrafica = new ObservableCollection<GraficaModel>();
            
        }

        public void ActualizarTablaParetoModels(List<TablaParetoModel> nuevosDatos)
        {
            TablaParetoModels = nuevosDatos;
            OnPropertyChanged(nameof(TablaParetoModels));
        }


        public ObservableCollection<GraficaModel> DatosGrafica
        {
            get { return datosGrafica; }
            private set
            {
                datosGrafica = value;
                OnPropertyChanged(nameof(DatosGrafica));
            }
        }

        public List<TablaParetoModel> TablaParetoModels
        {
            get { return tablaParetoModels; }
            private set
            {
                tablaParetoModels = value;
                OnPropertyChanged(nameof(TablaParetoModels));
            }
        }

        public void AgregarItem(string producto, int cantidad, int unidades)
        {
            int ventasTotales = cantidad * unidades;

            TablaParetoModels.Add(new TablaParetoModel
            {
                Producto = producto,
                Cantidad = cantidad,
                Unidades = unidades,
                Resultado = ventasTotales
            });

            OnPropertyChanged(nameof(TablaParetoModels));
            ActualizarDatosGrafica();
        }

        public void CalcularPorcentaje()
        {
            if (TablaParetoModels.Count > 1)
            {
                TablaParetoModels = TablaParetoModels.OrderByDescending(item => item.Resultado).ToList();

                for (int i = 0; i < TablaParetoModels.Count; i++)
                {
                    if (i == 0)
                    {
                        TablaParetoModels[i].Unidades = TablaParetoModels[i].Resultado;
                    }
                    else
                    {
                        TablaParetoModels[i].Unidades = TablaParetoModels[i - 1].Unidades + TablaParetoModels[i].Resultado;
                    }

                    double porcentaje = ((double)TablaParetoModels[i].Unidades / TotalVentas) * 100;
                    TablaParetoModels[i].Porcentaje = Math.Round(porcentaje, 2);
                }

                OnPropertyChanged(nameof(TablaParetoModels));

                
                ActualizarDatosGrafica();
            }
            else
            {
                // Manejar el caso donde hay menos de dos resultados
                // Puedes mostrar un mensaje o manejarlo según tus necesidades
                // ...
            }
        }

        public void ActualizarDatosGrafica()
        {
            DatosGrafica.Clear();

            foreach (var item in TablaParetoModels)
            {
              
                DatosGrafica.Add(new GraficaModel { Producto = item.Producto, Porcentaje = item.Resultado });
                OnPropertyChanged(nameof(DatosGrafica));
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int TotalVentas => TablaParetoModels.Sum(item => item.Resultado);
    }
}