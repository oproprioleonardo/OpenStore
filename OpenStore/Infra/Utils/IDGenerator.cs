using Newtonsoft.Json;

namespace OpenStore.Infra.Utils
{
    public class IDGenerator
    {
        private static string _filePath = @"C:/TEMP/idgen.json";
        private static bool _isCached;
        private static List<TableId> _cached = new List<TableId>();

        public static long Generate(string tableName)
        {
            List<TableId> tableIds = FindAll();
            TableId? tableId = tableIds.Find(t => t.TableName == tableName);
            if (tableId == null)
            {
                tableId = new TableId(tableName, 0);
                tableIds.Add(tableId);
            }
            tableId.LastId++;
            Save();
            return tableId.LastId;

        }

        private static void Save()
        {
            if (!File.Exists(_filePath))
                File.Create(_filePath);
            List<TableId> l = FindAll();
            TextWriter writer = new StreamWriter(_filePath);
            writer.Write(JsonConvert.SerializeObject(l));
            writer.Close();
        }

        private static List<TableId> FindAll()
        {
            if (!_isCached)
            {
                if (!File.Exists(_filePath))
                    File.Create(_filePath);
                TextReader reader = new StreamReader(_filePath);
                string json = reader.ReadToEnd() ?? "[]";
                reader.Close();
                _cached = JsonConvert.DeserializeObject<List<TableId>>(json) ?? new List<TableId>();
                _isCached = true;
            }
            return _cached;
        }

        internal class TableId
        {
            public string TableName { get; set; }
            public long LastId { get; set; }

            public TableId() { }

            public TableId(string tableName, long lastId)
            {
                TableName = tableName;
                LastId = lastId;
            }
        }


    }
}
