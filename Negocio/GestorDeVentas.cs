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
   

        public List<Ventas> AgregarAListaVenta(string id, string idCliente, string idProducto, int cantidad)
        {
            List<Ventas> listaVentas = new List<Ventas>();
            Ventas nuevaVenta = new Ventas(id, idCliente, idProducto, cantidad);
            listaVentas.Add(nuevaVenta);
            return listaVentas;

        }

        public void LlamarWSporProducto(List<Ventas> listaVentas)
        {
            foreach (Ventas venta in listaVentas)
            {
                AgregarProductoAVenta(venta);
            }
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
