namespace OpenStore.Domain.Shared.Exceptions
{
    public class NotFoundException : Exception
    {

        public Type T { get; private set; }
        public string Id { get; private set; }

        public NotFoundException(Type t, string id) : base($"{t.Name} não foi encontrado a partir do(s) identificador(es) {id}.")
        {
            T = t;
            Id = id;
        }
    }
}
