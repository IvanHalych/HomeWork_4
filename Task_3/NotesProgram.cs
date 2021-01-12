using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_3.Model;

namespace Task_3
{
    static class NotesProgram
    {
        static List<Note> notes;
        public static void Run()
        {
            notes = FileWork.Load();
            Console.WriteLine("Name program: Notes");
            Console.WriteLine("Author: Halych Ivan");
            while (true)
            {
                Console.WriteLine("1.Search notes");
                Console.WriteLine("2.View note");
                Console.WriteLine("3.Create note");
                Console.WriteLine("4.Delete note");
                Console.WriteLine("5.Exit");
                string input = Console.ReadLine();
                switch (input) 
                {
                    case "1":
                        Search();
                        break;
                    case "2":
                        ViewNote();
                        break;
                    case "3":
                        CreateNote();
                        break;
                    case "4":
                        DeleteNote();
                        break;
                    case "5":
                        return;
                }

            }
        }
        static void DeleteNote()
        {
            Console.Write("Enter the Id delete note:");
            string input = Console.ReadLine();
            var note = notes.Find(n => n.Id.ToString() == input);
            if (note == null)
            {
                Console.WriteLine("Note not found\n");
            }
            else
            {
                Console.WriteLine(note);
                Console.WriteLine("Confirm the deletion(yes)");
                input = Console.ReadLine();
                if(input == "yes")
                {
                    notes.Remove(note);
                    FileWork.Save(notes);
                }
            }
        }
        static void CreateNote()
        {
            Console.WriteLine("Enter text");
            string input = Console.ReadLine();
            input = input.Trim(' ');
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("the empty note will not be created\n");
            }
            else
            {
                Note note;
                if (input.Length >= 32)
                    note = new Note(notes[^1].Id + 1, input.Substring(0, 32), input, DateTime.UtcNow);
                else
                    note = new Note(notes[^1].Id + 1, input, input, DateTime.UtcNow);
                notes.Add(note);
                FileWork.Save(notes);
            }
        }
        static void ViewNote()
        {
            Console.Write("Enter the Id note:");
            string input = Console.ReadLine();
            var note = notes.Find(n=>n.Id.ToString()==input);
            if(note == null)
            {
                Console.WriteLine("Note not found\n");
            }
            else
            {
                Console.WriteLine(note);
            }
        }
        static void Search()
        {
            Console.Write("Enter the filter string:");
            string input = Console.ReadLine();
            var searchNotes = notes;
            if (!string.IsNullOrEmpty(input))
            {
                searchNotes = searchNotes.Where(n=>n.Id.ToString().Contains(input)
                ||n.Title.Contains(input)||n.Text.Contains(input)||n.CreatedOn.ToString().Contains(input)).ToList();
            }
            searchNotes.OrderBy(n => n.Id);
            if (searchNotes.Count == 0)
            {
                Console.WriteLine("Note not found\n");
            }
            else
            {
                Console.WriteLine(searchNotes.ToStringAll());
            }
        }
        static string ToStringAll(this List<Note> notes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Note note in notes)
            {
                stringBuilder.Append(note.ToStringWithOutText() + "\n");
            }
            return stringBuilder.ToString();
        }
    }
}
