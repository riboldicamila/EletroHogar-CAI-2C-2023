using AccesoDatos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorDeVentas
    {
        public bool AgregarVenta(string idCliente, string idUsuarioActual, string idProducto, int cantidad)
        {
            //ID USUARIO ES DE VENDEDOR, SE VALIDA SOLO SI SE ARREGLA EL LOGIN 
            // Crear un objeto VentasWS
            var nuevaVenta = new VentasWS
            {
                idCliente = "6d12f32b-44b7-48ed-9993-0f63b56c206c",
                idUsuario= "99cf271d-aaee-4392-af0b-123343c52ea7",
                idProducto=idProducto,
                cantidad=cantidad
              
            };

            try
            {
                VentasDatos.AgregarVenta(nuevaVenta);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
