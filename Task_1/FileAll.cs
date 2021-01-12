using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Task_1.Model;
using System.IO;
using Task_1.MyExceptions;

namespace Task_1
{
    public static class FileAll
    {
        public static Input Read(string pathFile)
        {
            string json;
            try
            {
                json = File.ReadAllText(pathFile);
            }
            catch(Exception)
            {
                throw new FileException();
            }

            Input result;
            try
            {
                result = JsonSerializer.Deserialize<Input>(json);
            }
            catch(Exception)
            {
                throw new MyExceptions.JsonException();
            }
            return result;
        }
        public static void Write(string pathFile, Output output)
        {
            File.WriteAllText(pathFile, JsonSerializer.Serialize<Output>(output));
        }
    }
}
