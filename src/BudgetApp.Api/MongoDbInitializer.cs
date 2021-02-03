using BudgetApp.Infrastructure.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BudgetApp.Api
{
    public class MongoDbInitializer
    {
        public static void Seed(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            var directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var files = Directory.GetFiles($"{directory}\\SeedData", "*.json");
            foreach (var file in files)
            {
                var content = File.ReadAllText(file);
                var collectionName = Path.GetFileNameWithoutExtension(file);

                var documents = BsonSerializer.Deserialize<IEnumerable<BsonDocument>>(content);
                var collection = database.GetCollection<BsonDocument>(collectionName);

                foreach(var document in documents)
                {
                    collection.ReplaceOne(q => q["_id"] == document["_id"], document, new ReplaceOptions { IsUpsert = true });
                }
            }
        }
    }
}
