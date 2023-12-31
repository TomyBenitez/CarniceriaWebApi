﻿using Sistema_Carnicería.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarniceriaWebApi.Models
{
    public class Venta
    {
        public int Id { get; set; }
        [Required]
        public int CobradorId { get; set; }
        public Cobrador? Cobrador { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        [Required]
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }

        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoTotal { get; set; }    
    }
}
