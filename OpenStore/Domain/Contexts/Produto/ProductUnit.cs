namespace OpenStore.Domain.Contexts.Produto
{

    public enum ProductUnit
    {
        UNIDADE = 'U',
        KG = 'K',
        METROS = 'M',
        LITROS = 'L',
        INDETERMINADO = 'I',
    }

    public static class ProductUnitExtensions
    {
        public static ProductUnit Parse(char value)
        {
            foreach (ProductUnit unit in Enum.GetValues(typeof(ProductUnit)))
            {
                if ((char)unit == value) return unit;
            }

            return ProductUnit.INDETERMINADO;
        }
    }

}