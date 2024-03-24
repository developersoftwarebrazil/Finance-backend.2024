using Finance.Domain.Entity.Entities.Systems.Incomes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Domain.Entity.Entities.Users.Systems.Incomes
{
    [Table("UsuarioInvestimentoSistema")]
    public class UserSystemIncome

    {
        public int Id { get; set; }

        //[Display(Name = "NOMEUSUARIO")]
        //[Column("NomeUsuario")]
        //public string UserName? { get; set; }

        public string UserEmail { get; set; }

        public bool Administrator { get; set; }

        public bool ActualSystemMonth { get; set; }

        public int SystemIncomeId { get; set; }
        //public virtual SystemIncome SystemIncome { get; set; }
    }
}
