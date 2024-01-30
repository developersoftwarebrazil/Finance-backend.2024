using Finance.Domain.Entity.Notifications;
using System.ComponentModel.DataAnnotations;

namespace Finance.Domain.Entity.Entities
{
    public class Base : Notifier
    {
        [Display(Name = "Nome")]
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string Name { get; set; }
    }
}
