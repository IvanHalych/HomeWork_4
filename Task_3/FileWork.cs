using System;
using System.Collections.Generic;
using System.Text;
using Task_3.Model;
using System.Text.Json;
using System.IO;

namespace Task_3
{
    class FileWork
    {
        const string FileName = "Notes.json";
        public static List<Note> Load()
        {
            try
            {
                return JsonSerializer.Deserialize<List<Note>>(File.ReadAllText(FileName));
            }
            catch (FileNotFoundException)
            {
                return new List<Note>();
            }
        }
        public static void Save(List<Note> notes)
        {
            File.WriteAllText(FileName, JsonSerializer.Serialize<List<Note>>(notes));
        }
    }
}
