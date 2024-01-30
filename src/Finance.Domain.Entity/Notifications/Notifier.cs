using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Domain.Entity.Notifications
{
    public class Notifier
    {
        public Notifier()
        {
            Notification = new List<Notifier>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Messages { get; set; }

        [NotMapped]
        public List<Notifier> Notification;

        public bool PropertyStringValidations(string value, string propertyName)
        {
            if ((string.IsNullOrWhiteSpace(value)) || (string.IsNullOrWhiteSpace(propertyName)))
            {
                Notification.Add(new Notifier
                {
                    Messages = "Campo obrigatório",
                    PropertyName = propertyName
                });
                return false;
            }
            return true;
        }
        public bool PropertyIntValidations(int value, string propertyName)
        {
            if ((value < 1) || (string.IsNullOrWhiteSpace(propertyName)))
            {
                Notification.Add(new Notifier
                {
                    Messages = "Campo obrigatório",
                    PropertyName = propertyName
                });
                return false;
            }
            return true;
        }

        public bool PropertyDecimalValidations(decimal value, string propertyName)
        {
            if ((value < 1) || (string.IsNullOrWhiteSpace(propertyName)))
            {
                Notification.Add(new Notifier
                {
                    Messages = "Campo obrigatório",
                    PropertyName = propertyName
                });
                return false;
            }
            return true;
        }
    }
}

