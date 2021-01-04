using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BudgetApp.Infrastructure.Mongo.Documents
{
    internal sealed class ExpenseDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public decimal Value { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
    }
}
