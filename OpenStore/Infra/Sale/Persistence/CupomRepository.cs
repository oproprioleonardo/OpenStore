using OpenStore.Infra.Produto.Persistence;
using OpenStore.Infra.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStore.Infra.Sale
{
    public class CupomRepository
    {

        private readonly string filePath;
        private bool _isCached;
        private List<CupomEntity> _cached;

        public CupomRepository(string filePath)
        {
            this.filePath = filePath;
            _cached = new List<CupomEntity>();
        }

        public CupomEntity Save(CupomEntity cupom)
        {
            if (cupom.Id == 0)
            {
                cupom.Id = IDGenerator.Generate("Cupom");
            }
            List<CupomEntity> cupons = FindAll();

            cupons.RemoveAll(c => c.Id == cupom.Id);
            cupons.Add(cupom);
            TextWriter writer = new StreamWriter(filePath);
            writer.Write(JsonConvert.SerializeObject(cupons));
            writer.Close();
            return cupom;
        }

        public CupomEntity? FindById(long id)
        {
            List<CupomEntity> cupons = FindAll();

            return cupons.Find(c => c.Id == id);
        }

        public List<CupomEntity> FindAll()
        {
            if (!_isCached)
            {
                TextReader reader = new StreamReader(filePath);
                string json = reader.ReadToEnd();
                reader.Close();
                _cached = JsonConvert.DeserializeObject<List<CupomEntity>>(json) ?? new List<CupomEntity>();
                _isCached = true;
            }
            return _cached;
        }

        public void Delete(long id)
        {
            List<CupomEntity> cupons = FindAll();

            cupons.RemoveAll(c => c.Id == id);
            TextWriter writer = new StreamWriter(filePath);
            writer.Write(JsonConvert.SerializeObject(cupons));
            writer.Close();
        }




    }
}
