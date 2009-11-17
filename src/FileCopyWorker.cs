using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace MusicShuffler
{
    public class FileCopyWorker :BackgroundWorker
    {
        private string destinationDirectory;

        public FileCopyWorker(string destinationDirectory)
        {
            // Set the properties
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;

            // Set the destination directory
            if (!(Directory.Exists(destinationDirectory)))
                throw new DirectoryNotFoundException();

            this.destinationDirectory = destinationDirectory;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            // Extract the argument
            if (!(e.Argument is string))
                throw new ArgumentException("Argument must a a string");

            string sourceFileName = e.Argument as string;

            try
            {
                File.Copy(sourceFileName,
                    Path.Combine(destinationDirectory, new FileInfo(sourceFileName).Name));
            }
            catch (Exception ex)
            {
                // TODO: Log the error
                e.Result = ex;
            }
        }
    }
}
