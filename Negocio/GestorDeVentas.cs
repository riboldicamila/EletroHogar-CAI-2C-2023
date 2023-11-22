using AccesoDatos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorDeVentas
    {

        //REPORTES: por stock y vendor. Genere una lista total por ventas
        //no encuentro los campos para hacer relación. El ws, no devuelve esos datos. 


        public List<VentasWS> ListadoVentasDeCliente(string idCliente)
        {
            return VentasDatos.BuscarVentasPorCliente(idCliente);
        }

        //List<VentasWS> ventasCliente = gestorDeVentas.ListadoVentasDeCliente(idCliente);

        public List<string> ListarClientesIds()
        {
            List<Cliente> clientes = ClienteDatos.DevolverClientes();
            List<string> ids = new List<string>();

            foreach (var cliente in clientes)
            {
                ids.Add(cliente.id);
            }

            return ids;
        }

        //LA IDEA ERA FILTRAR LAS VENTAS POR VENDEDOR PARA HACER REPORTE
        //REPORTES: por stock y vendor. Genere una lista total por ventas
        //no encuentro los campos para hacer relación. El ws, no devuelve esos datos. 
        public List<VentasWS> ObtenerTodasLasVentas()
        {
            List<VentasWS> todasLasVentas = new List<VentasWS>();
            List<string> idsClientes = ListarClientesIds();


            // la lista de id de clientes y agregar todas las ventas a la lista general
            foreach (var idCliente in idsClientes)
            {
                List<VentasWS> ventasCliente = ListadoVentasDeCliente(idCliente);
                todasLasVentas.AddRange(ventasCliente);
            }

            return todasLasVentas;
        }




        public bool AgregarAListaVenta(ProductosVenta productosVenta)
        {
            String idCliente = productosVenta.IdCliente;
            String idUsuario = productosVenta.IdUsuario;

            List<Ventas> listaVentas = new List<Ventas>();
            foreach (ItemProductosVentas item in productosVenta.ListadoProductosVentas)
            {
                listaVentas.Add(new Ventas(idCliente, idUsuario, item.IdProducto, item.Cantidad));
            }

            return LlamarWSporProducto(listaVentas);
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
