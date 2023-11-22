using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    //usar para deserializar

//    [
//  {
//    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//    "cantidad": 0,
//    "fechaAlta": "2023-11-22T16:56:41.398Z",
//    "estado": 0
//  }
//]
    public class VentasWS
    {
        public string id { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaAlta { get; set; } = DateTime.Now;
        public int estado { get; set; }

        //es cero o uno

        public VentasWS() { }

    }

}

