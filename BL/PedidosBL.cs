/*
 * Nombre de la Clase: PedidosBL
 * Descripcion: Clase de logica de negocios
 * Autor: Equipo Makross - Grupo de Desarrollo
 * Fecha: 03/01/2016
 */

/*
 * Listado de Metodos:
 * >> PedidosBL()
 * >> bool ObtenerEstadoPedidos(string cs, string fechaActual)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BL
{
    public class PedidosBL
    {
        /* 
         * Metodo
         * Descripcion: Metodo constructor
         * Entrada: void
         * Salida: void
         */
        public PedidosBL() { }

        /* 
         * Metodo
         * Descripcion: Retorna un valor booleano si encuentra pedidos sincronizados 
         * Entrada: (string cs, string fechaActual
         * Salida: bool
         */
        public bool ObtenerEstadoPedidos(string cs, string fechaActual)
        {
            var val = false;
            PedidosDAL contexto = new PedidosDAL(cs);
            List<Pedidos> pedidos = contexto.ObtenerEstadoPedidos(fechaActual);
            if (pedidos.Count <= 0)
            {
                val = true;
            }
            else if (pedidos.Count > 0)
            {
                val = false;
            }

            return val;
        }
    }
}
