using Microsoft.AspNetCore.Mvc;
using NoteKeeperService.Business.Services;

namespace NoteKeeperService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
  private readonly INotesService _notesService;

  public NotesController(INotesService notesService)
  {
    _notesService = notesService;
  }

  /// <summary>
  /// Get notes
  /// </summary>
  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(string id)
  {
    try
    {
      var response = await _notesService.GetNote(id);
      return Ok(response);
    }
    catch (Exception)
    {
      return BadRequest(new { message = "Error" });
    }
  }
}
