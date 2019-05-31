using KeepNote.DAL;
using KeepNote.DAL.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace test
{
  [TestCaseOrderer("test.PriorityOrderer", "test")]
  public class NoteRepositoryTest : IClassFixture<NoteDbSetup>//, IDisposable
  {
    NoteDbSetup _setup;//= new DbSetup();
    public NoteRepositoryTest(NoteDbSetup setup)
    {
      _setup = setup;
    }

    [Fact,TestPriority(0)]
    public void TestGetAllNotes()
    {

      NoteRepository noteRepository = new NoteRepository(@"server=.\sqlexpress;database=keepnote_db;integrated security=true");


      List<Note> noteList = noteRepository.GetAllNotes();

      Assert.Equal(2, noteList.Count);
    }


    [Fact,TestPriority(1)]
    public void TestAddNote()
    {
      NoteRepository noteRepository = new NoteRepository(@"server=.\sqlexpress;database=keepnote_db;integrated security=true");

      Note newNote = new Note
      {
        NoteId = 1003,
        Title = "Submit Evaluation Report",
        Description = "submit assignment evaluation report",
        CreatedBy = 102
      };

      int records = noteRepository.AddNote(newNote);
      Assert.Equal(1, records);
    }
    //public void Dispose()
    //{
    //  _setup.Dispose();
    //}
  }
}
