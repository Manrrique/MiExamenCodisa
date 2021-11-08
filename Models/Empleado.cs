﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EXAMEN.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Empleado_Habilidad = new HashSet<Empleado_Habilidad>();
            InverseIdJefeNavigation = new HashSet<Empleado>();
        }

        [Key]
        public int IdEmpleado { get; set; }
        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }
        [StringLength(50)]
        public string Cedula { get; set; }
        [StringLength(100)]
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Correo { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaIngreso { get; set; }
        public int? IdJefe { get; set; }
        public int IdArea { get; set; }
        public byte[] Foto { get; set; }

        [ForeignKey(nameof(IdArea))]
        [InverseProperty(nameof(Area.Empleado))]
        public virtual Area IdAreaNavigation { get; set; }
        [ForeignKey(nameof(IdJefe))]
        [InverseProperty(nameof(Empleado.InverseIdJefeNavigation))]
        public virtual Empleado IdJefeNavigation { get; set; }
        [InverseProperty("IdEmpleadoNavigation")]
        public virtual ICollection<Empleado_Habilidad> Empleado_Habilidad { get; set; }
        [InverseProperty(nameof(Empleado.IdJefeNavigation))]
        public virtual ICollection<Empleado> InverseIdJefeNavigation { get; set; }
    }
}