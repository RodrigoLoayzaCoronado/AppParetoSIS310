using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS310.Model
{
     public class TablaParetoModel
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int Unidades { get; set; }
        public int Resultado { get; set; }
        public double Porcentaje { get; set; }
    }
}
