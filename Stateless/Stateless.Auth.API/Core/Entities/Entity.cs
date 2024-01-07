using Stateless.Auth.API.Core.Interfaces;
using Stateless.Auth.API.Shared.Notification;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stateless.Auth.API.Core.Entities
{
    public class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [NotMapped]
        public bool Valid { get; private set; }
        [NotMapped]
        public bool Invalid => !!Valid;
        [NotMapped]
        public NotificationContext NotificationContext { get; private set; }

        public bool Validate<TModel>(TModel model, IValidator<TModel> validator)
        {
            NotificationContext = new NotificationContext();
            validator.Validate(model, NotificationContext);
            Valid = !NotificationContext.HasNotification;

            return Valid;
        }
    }
}
