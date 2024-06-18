namespace RemovingAccentCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var files = Directory.GetFiles("path\\path");

            foreach (var file in files)
            {

                var newPath = file;

                var specialCharacters = new Dictionary<string, string>();
                specialCharacters.Add("è", "e");
                specialCharacters.Add("é", "e"); 
                specialCharacters.Add("È", "E");
                specialCharacters.Add("É", "E");
                specialCharacters.Add("Ô", "O");

                foreach (var entry in specialCharacters)
                {
                    newPath = newPath.Replace(entry.Key, entry.Value);
                }

                try
                {
                    if(newPath != file)
                    {
                        File.Move(file, newPath);
                        Console.WriteLine("Move file " + file + ", to " + newPath);

                    }
                } catch (Exception ex)
                {
                    File.Move(file, newPath + "-1");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
