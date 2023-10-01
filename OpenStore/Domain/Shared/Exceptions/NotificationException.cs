using OpenStore.Domain.Shared.Validation;
using System.Collections.Generic;
using static OpenStore.Domain.Shared.Validation.Notification;

namespace OpenStore.Domain.Shared.Exceptions
{
    public class NotificationException : Exception
    {

        public readonly List<Error> Errors;

        protected NotificationException(string aMessage, List<Error> anErrors) : base(aMessage)
        {
            Errors = anErrors;
        }

        public static NotificationException With(Notification notification)
        {
            return new NotificationException("Ocorreu um erro de validação" , notification.Errors);
        }

        public static NotificationException With(Error anErrors)
        {
            return new NotificationException(anErrors.Message, new List<Error>() { anErrors });
        }

        public static NotificationException With(List<Error> anErrors)
        {
            return new NotificationException(string.Join("\n", anErrors.ConvertAll(e => e.Message)), anErrors);
        }






    }
}
