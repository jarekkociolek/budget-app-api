using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BudgetApp.Infrastructure.Mongo.Documents
{
    public class BaseDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
    }
}
