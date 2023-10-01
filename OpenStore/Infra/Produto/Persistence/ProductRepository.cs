using OpenStore.Infra.Utils;
using Newtonsoft.Json;

namespace OpenStore.Infra.Produto.Persistence
{
    public class ProductRepository
    {

        private readonly string filePath;
        private bool _isCached;
        private List<ProductEntity> _cached;

        public ProductRepository(string filePath)
        {
            this.filePath = filePath;
            _cached = new List<ProductEntity>();
        }

        public ProductEntity Save(ProductEntity produto)
        {
            if (produto.Id == 0)
            {
                produto.Id = IDGenerator.Generate("Product");
            }
            List<ProductEntity> produtos = FindAll();

            produtos.RemoveAll(p => p.Id == produto.Id);
            produtos.Add(produto);
            TextWriter writer = new StreamWriter(filePath);
            writer.Write(JsonConvert.SerializeObject(produtos));
            writer.Close();
            return produto;
        }

        public ProductEntity? FindByTerm(string term)
        {
            List<ProductEntity> produtos = FindAll();

            return produtos.Find(p => p.Code.Contains(term) || p.InternCode.Contains(term) || p.Description.Contains(term));
        }

        public ProductEntity? FindByCode(string code)
        {
            List<ProductEntity> produtos = FindAll();

            return produtos.Find(p => p.Code == code);
        }

        public ProductEntity? FindByInternCode(string internCode)
        {
            List<ProductEntity> produtos = FindAll();

            return produtos.Find(p => p.InternCode == internCode);
        }

        public ProductEntity? FindById(long id)
        {
            List<ProductEntity> produtos = FindAll();

            return produtos.Find(p => p.Id == id);
        }

        public List<ProductEntity> FindAllByDescription(string description)
        {
            List<ProductEntity> produtos = FindAll();
            return produtos.FindAll(p => p.Description.Contains(description));
        }

        public List<ProductEntity> FindAll()
        {
            if (_isCached) return _cached;
            List<ProductEntity> produtos = new List<ProductEntity>();
            if (File.Exists(filePath))
            {
                TextReader reader = new StreamReader(filePath);
                produtos = JsonConvert.DeserializeObject<List<ProductEntity>>(reader.ReadToEnd()) ?? new List<ProductEntity>();
                reader.Close();
            }
            else
            {
                File.Create(filePath);
            }

            _isCached = true;
            _cached = produtos;
            return produtos;
        }

        public void Delete(long id)
        {
            List<ProductEntity> produtos = FindAll();

            produtos.RemoveAll(p => p.Id == id);

            TextWriter writer = new StreamWriter(filePath);
            writer.Write(JsonConvert.SerializeObject(produtos));
            writer.Close();
        }

    }
}
