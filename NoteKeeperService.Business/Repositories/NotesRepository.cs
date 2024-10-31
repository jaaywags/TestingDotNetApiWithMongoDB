using MongoDB.Driver;
using NoteKeeperService.Business.Models;

namespace NoteKeeperService.Business.Repositories;

public interface INotesRepository
{
  Task<Note> GetNote(string id);
}

public class NotesRepository : INotesRepository
{
  private readonly IMongoDatabase _database;
  private readonly IMongoCollection<Note> _collection;

  public NotesRepository(DBContext dbContext)
  {
    _collection = dbContext._database.GetCollection<Note>("notes");
  }

  public async Task<Note> GetNote(string id)
  {
    var filterBuilder = Builders<Note>.Filter;
    var filter = filterBuilder.Eq("_id", "");
    return await _collection.Find(filter).SingleOrDefaultAsync();
  }
}