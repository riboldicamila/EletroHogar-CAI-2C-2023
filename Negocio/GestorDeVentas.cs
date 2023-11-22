﻿using AccesoDatos;
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
        public List<VentasWS> ListadoVentasDeCliente(string idCliente)
        {
            return VentasDatos.BuscarVentasPorCliente(idCliente);
        }

        //List<VentasWS> ventasCliente = gestorDeVentas.ListadoVentasDeCliente(idCliente);


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
            // Crear un objeto VentasWS  
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
