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


        public void AgregarAListaVenta(List<Ventas> listaVentas, string id, string idCliente, string idProducto, int cantidad)
        {
            Ventas nuevaVenta = new Ventas(idCliente, id, idProducto, cantidad);
            listaVentas.Add(nuevaVenta);

        }

        public bool LlamarWSporProducto(List<Ventas> listaVentas)
        {
            foreach (Ventas venta in listaVentas)
            {
                bool response = AgregarProductoAVenta(venta);
                if (!response)
                {
                    return false;
                }
            }
            return true;
        }


        public bool AgregarProductoAVenta(Ventas venta)
        {
            //ID USUARIO ES DE VENDEDOR, SE VALIDA SOLO SI SE ARREGLA EL LOGIN 
            // Crear un objeto VentasWS
            //Id cliente hardcodeado, mostrar lista de clientes o similar, mismo con producto
     
            try
            {
                VentasDatos.AgregarVenta(venta);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DevolverVenta(string idVenta, string idUsuario)
        {
            try
            {
                VentasDatos.DevolverVenta(idVenta, idUsuario);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
