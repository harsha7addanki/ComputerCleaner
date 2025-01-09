using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Cleaner
{
    internal class TemporaryFileRemover
    {

        private List<string> files;
        private List<string> folders;
        private long discoveredSize;
        public bool cont = false;


        private string ToSI(double d, string format = null)
        {
            if(d == 0)
            {
                return "0";
            }
            char[] incPrefixes = new[] { 'K', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
            char[] decPrefixes = new[] { 'm', '\u03bc', 'n', 'p', 'f', 'a', 'z', 'y' };

            int degree = (int)Math.Floor(Math.Log10(Math.Abs(d)) / 3);
            double scaled = d * Math.Pow(1000, -degree);

            char? prefix = null;
            switch (Math.Sign(degree))
            {
                case 1: prefix = incPrefixes[degree - 1]; break;
                case -1: prefix = decPrefixes[-degree - 1]; break;
            }

            return Math.Round(scaled, 2, MidpointRounding.ToEven).ToString(format) + prefix;
        }

        public (List<string>, List<string>) DicoverFiles(Label status) {
            var locations = new List<string>();
            locations.Add(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Temp");
            var configadded = File.ReadAllText("searchlocations.txt").Split("\n").ToList();
            configadded.ForEach(x => x.Trim().Trim(Environment.NewLine.ToCharArray()));
            locations.AddRange(configadded);
            var files = new List<string>();
            var folders = new List<string>();
            var filesdiscovered = 0;
            var totalfilesize = 0l;
            foreach(var location in locations) {
                foreach(var file in Directory.EnumerateFiles(location))
                {
                    var fi1 = new FileInfo(file);
                    totalfilesize += fi1.Length;
                    status.Text = $"Discovering {ToSI(totalfilesize)}B";
                    files.Add(file);
                    filesdiscovered++;
                }
                foreach (var folder in Directory.EnumerateDirectories(location))
                {
                    status.Text = $"Discovering {ToSI(totalfilesize)}B";
                    folders.Add(folder);
                }
            }
            status.Text = $"Discovered {ToSI(totalfilesize)}B";
            this.files = files;
            this.folders = folders;
            this.discoveredSize = totalfilesize;
            if (discoveredSize == 0)
            {
                cont = false;
            }

            return (files, folders);
        }

        public void DeleteDiscoveredFiles(Label status, ProgressBar bar) {
            var originalSize = discoveredSize;
            foreach(var file in files)
            {
                var info = new FileInfo(file);
                discoveredSize -= info.Length;
                status.Text = $"Deleteted {ToSI(discoveredSize)} out of {ToSI(originalSize)}";
                bar.Value = (int)(discoveredSize / originalSize * 100);
            }
        }

        public void DeleteDiscoveredFolders(Label status, ProgressBar bar)
        {
            var folderCount = folders.Count;
            foreach (var folder in folders)
            {
                folderCount--;
                status.Text = $"Deleteted {folderCount} out of {folders.Count}";
                bar.Value = (int)(folderCount / folders.Count * 100);
            }
        }
    }
}
