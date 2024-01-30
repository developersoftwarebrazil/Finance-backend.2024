﻿using Finance.Domain.Entity.Entities.Systems.SystemExpenses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Domain.Entity.Entities.Users.Systems.Expenses
{
    [Table("UsuarioSistema")]
    public class UserExpense
    {
        public int Id { get; set; }

        [Display(Name = "NOMEUSUARIO")]
        [Column("NomeUsuario")]
        public string UserName { get; set; }

        [Display(Name = "EMAILUSUARIO")]
        [Column("EmailUsuario")]
        public string UserEmail { get; set; }

        [Display(Name = "ADMINISTRADOR")]
        [Column("Administrador")]
        public bool Administrator { get; set; }

        [Display(Name = "MESATUAL")]
        [Column("MesAtual")]
        public bool ActualSystemMonth { get; set; }

        //Foreign Key
        [ForeignKey("SystemExpense")]
        [Column(Order = 1)]
        public int SystemId { get; set; }
        public virtual SystemExpense SystemExpense { get; set; }
    }
}
