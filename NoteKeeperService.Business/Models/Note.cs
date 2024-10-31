using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NoteKeeperService.Business.Models;

public class Note
{
  [BsonId]
  [BsonElement("_id")]
  [BsonRepresentation(BsonType.String)]
  public required string Id { get; set; }
  public required string Title { get; set; }
  public required string Notes { get; set; }
}