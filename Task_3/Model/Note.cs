using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Model
{
    public class Note : Interface.INote
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public override string ToString()
        {
            return Id + "\n" + Title + "\n"+Text+"\n" + CreatedOn + "\n";
        }
        public string ToStringWithOutText()
        {
            return Id + "\n" + Title + "\n" + CreatedOn + "\n";
        }
        public Note() { }
        public Note(int id, string title, string text, DateTime createdOn)
        {
            Id = id;
            Title = title;
            Text = text;
            CreatedOn = createdOn;
        }
    }
}
