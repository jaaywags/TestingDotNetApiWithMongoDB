using MongoDB.Driver;
using MongoDB.Bson.Serialization.Conventions;

namespace NoteKeeperService.Business;

public class DBContext
{
  public IMongoDatabase _database;

  public DBContext()
  {
    var camelCaseConventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
    ConventionRegistry.Register("camelCase", camelCaseConventionPack, type => true);
    var mongoClient = new MongoClient("mongodb://localhost:27017");
    _database = mongoClient.GetDatabase("notes-db");
  }
}