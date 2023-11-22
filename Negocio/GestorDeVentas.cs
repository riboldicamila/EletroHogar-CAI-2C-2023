using AccesoDatos;
using Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorDeVentas
    {
        //REPORTES: por stock y vendor.Genere una lista total por ventas, conectando las listas del ws por id de cliente.
        //pero no encuentro los campos para hacer relación. El ws, no devuelve esos datos. 
        //Mi idea era en base a la lista total de ventas hacer la relación con idVendedor y idProducto.
        //Con idProducto poner saber la cantidad y eso compararlo con el stock cuando se da de alta el producto.
        //El ws de getVentas, no provee esos datos. Lo deje hasta ahí. 
        //IDEA REPORTE nuestro de VENTAS POR FECHA DE ALTA



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


        //IDEA REPORTE VENTAS POR FECHA DE ALTA
        public List<VentasWS> FiltrarVentasPorFechaDeAlta(DateTime fechaDeAlta)
        {
            List<VentasWS> todasLasVentas = ObtenerTodasLasVentas();
            List<VentasWS> ventasFiltradas = todasLasVentas.Where(venta => venta.fechaAlta.Date == fechaDeAlta.Date).ToList();
            return ventasFiltradas;
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
