using System.Collections;
using System.Collections.Generic;

namespace OpenStore.Domain.Shared.Validation
{
    public class Notification
    {

        public readonly List<Error> Errors;

        private Notification(List<Error> errors)
        {
            Errors = errors;
        }

        public static Notification Create()
        {
            return new Notification(new List<Error>());
        }

        public bool HasError()
        {
            return Errors.Count > 0;
        }

        public static Notification Create(Error anError)
        {
            return new Notification(new List<Error>()).Append(anError);
        }

        public Notification Append(Error anError)
        {
            Errors.Add(anError);
            return this;
        }

        public Notification Append(string anError)
        {
            Errors.Add(new Error(anError));
            return this;
        }

        
    }

    public record Error(string Message);
  
}