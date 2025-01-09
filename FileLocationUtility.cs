namespace Computer_Cleaner
{
    internal class FileLocationUtility
    {
        public static List<string> GetLocationsFromFile(string path)
        {
            List<string> locations = new List<string>();
            if (File.Exists(path)) {
                using (var filestream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using(var file = new StreamReader(filestream, System.Text.Encoding.UTF8, true, 128)){
                        string lineOfText;
                        while ((lineOfText = file.ReadLine()) != null)
                        {
                            locations.Add(lineOfText);
                        }
                    }
                }
            }

            return locations;
        }
    }
}
