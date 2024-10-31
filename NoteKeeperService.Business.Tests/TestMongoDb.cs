using Mongo2Go;
using MongoDB.Driver;

namespace NoteKeeperService.Business.Tests;

public class TestDBContext
{
  internal MongoDbRunner _runner;
  internal string _databaseName = "notes-db-integration-tests";
  internal string _notesCollection = "notes";
  internal IMongoDatabase _database;

  public TestDBContext()
  {
    _runner = MongoDbRunner.StartForDebugging(singleNodeReplSet: false);

    MongoClient client = new MongoClient(_runner.ConnectionString);
    _database = client.GetDatabase(_databaseName);
  }

  public void Dispose()
  {
    _runner.Dispose();
  }

  public void SeedData(string collection, string file)
  {
    _runner.Import(_databaseName, collection, GetFilePath(file), true);
  }

  private string GetFilePath(string file)
  {
    var workingDirectory = Environment.CurrentDirectory;
    return Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, file);
  }
}