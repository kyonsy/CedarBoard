using Prism.Mvvm;
using System.Collections.Generic;
using System.IO;
using System;

namespace BlankApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            try
            {
                // Set a variable to the My Documents path.
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                List<string> dirs = new List<string>(Directory.EnumerateDirectories(docPath));

                foreach (var dir in dirs)
                {
                    Console.WriteLine($"{dir.Substring(dir.LastIndexOf(Path.DirectorySeparatorChar) + 1)}");
                }
                Console.WriteLine($"{dirs.Count} directories found.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
