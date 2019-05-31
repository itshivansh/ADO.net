using System;
using System.Collections.Generic;
using System.Text;

namespace KeepNote.DAL.Entities
{
  public class Note
  {
    public int NoteId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CreatedBy { get; set; }
  }
}
