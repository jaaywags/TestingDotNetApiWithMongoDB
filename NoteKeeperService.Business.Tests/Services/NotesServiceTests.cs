using NoteKeeperService.Business.Repositories;
using NoteKeeperService.Business.Services;

namespace NoteKeeperService.Business.Tests.Services;

public class NotesServiceTests : TestDBContext
{
  public NotesServiceTests()
  {
  }

  [Fact]
  public async Task GetNoteById()
  {
    // Arrange
    SeedData(_notesCollection, "SeedMongo/TestNotes.json");
    var notesService = CreateSut();

    // Act
    var response = await notesService.GetNote("1");

    // Assert
    Assert.NotNull(response);
    Assert.Equal("first note", response.Title);
  }

  private NotesService CreateSut
  (
    INotesRepository? notesRepository = null
  )
  {
    // In this particular example, we do not need to mock anything. We only have a single DIed class
    // and we need to have an actual instance of it. But you might have other classes that are DIed
    // that you don't care about. This is how you might mock those and responses to their methods.

    // var mockNotesRepository = new Mock<INotesRepository>();
    // mockNotesRepository
    //   .Setup(m => m.SearchAsync(It.IsAny<SomeClassType>()))
    //   .ReturnsAsync(new PaginatedResponse<SomeOtherClassType>());

    return new NotesService
    (
      CreateNotesRepositorySut(notesRepository)
    );
  }

  private INotesRepository CreateNotesRepositorySut(
    INotesRepository? notesRepository = null
  )
  {
    if (notesRepository != null)
      return notesRepository;

    // Our repository has a DI for this DBContext class, which holds our connection to the database.
    // Here we overwrite that database with the on we setup for our tests. Then when our repository
    // calls the database, it uses our test one running in Mongo2Go.

    var dbContext = new DBContext();
    dbContext._database = _database;

    return new NotesRepository(dbContext);
  }
}