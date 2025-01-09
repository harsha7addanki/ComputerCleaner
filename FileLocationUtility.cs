using System.Diagnostics;
using System.Text;

namespace Computer_Cleaner
{
    internal class FileLocationUtility
    {
        public static List<string> GetLocationsFromFile(string path)
        {
            List<string> locations = new List<string>();
            if (File.Exists(path)) {
                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(path))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        locations.Add(line);
                        Debug.WriteLine(line);
                    }
                }
            }
            else
            {
                Debug.WriteLine("no searchoptions");
            }

            return locations;
        }
    }
}
