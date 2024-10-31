using NoteKeeperService.Business.Models;
using NoteKeeperService.Business.Repositories;

namespace NoteKeeperService.Business.Services;

public interface INotesService
{
  Task<Note> GetNote(string id);
}
public class NotesService : INotesService
{
  private readonly INotesRepository _notesRepository;

  public NotesService(INotesRepository notesRepository)
  {
    _notesRepository = notesRepository;
  }

  public async Task<Note> GetNote(string id)
  {
    return await _notesRepository.GetNote(id);
  }
}