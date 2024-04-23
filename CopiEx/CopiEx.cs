using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CopiEx
{

	/// <summary>
	/// Represents a file copier that can copy files from a source directory to a destination directory.
	/// </summary>
	public class CopiEx
	{
		private DirectoryInfo _source;
		private DirectoryInfo _destination;
		private int currFI = 0;

		public CopiEx(string source, string destination)
		{
			_source = new DirectoryInfo(source);
			_destination = new DirectoryInfo(destination);
		}

		/// <summary>
		/// The list of files that failed to be copied.
		/// </summary>
		public readonly List<KeyValuePair<string, DiffReason>> failedFileOperation = new List<KeyValuePair<string, DiffReason>>();

		public event EventHandler<int> CurrentFileIndexChanged;

		/// <summary>
		/// The index of the current file being copied.
		/// </summary>
		public int CurrentFileIndex {

			get { return currFI; }
			set { currFI = value; CurrentFileIndexChanged?.Invoke(this, value); }
		}

		/// <summary>
		/// The total number of files to be copied.
		/// </summary>
		public int TotalFiles = 0;

		/// <summary>
		/// The current step of the file copying operation.
		/// </summary>
		public string CurrentStep = "Idle";

		/// <summary>
		/// Asynchronously copies files from the source directory to the destination directory.
		/// </summary>
		/// <returns>A task representing the asynchronous operation.</returns>
		public Task CopyFiles()
		{
			CurrentStep = "Validating Paths...";
			ValidatePaths();
			return Task.Factory.StartNew(copyFiles);
		}

		/// <summary>
		/// Compares files in the source directory with the corresponding files in the destination directory.
		/// </summary>
		/// <returns>A list of different files.</returns>
		public async Task<List<KeyValuePair<string, DiffReason>>> CompareFiles()
		{
			TotalFiles = 0;
			CurrentFileIndex = 0;
			CurrentStep = "Comparing files...";
			List<KeyValuePair<string, DiffReason>> differentFiles = new List<KeyValuePair<string, DiffReason>>();
			Task task = Task.Factory.StartNew(() =>
			{
				// Get all files in the source directory
				FileInfo[] sourceFiles = _source.GetFiles("*.*", SearchOption.AllDirectories);
				TotalFiles = sourceFiles.Length;

				foreach (FileInfo sourceFile in sourceFiles)
				{
					CurrentFileIndex++;
					// Get the corresponding file in the destination directory
					string relativePath = sourceFile.FullName.Substring(_source.FullName.Length + 1);
					FileInfo destinationFile = new FileInfo(Path.Combine(_destination.FullName, relativePath));

					if (!destinationFile.Exists)
					{
						differentFiles.Add(new KeyValuePair<string, DiffReason>(relativePath, DiffReason.DestFileNotExists));
					}
					else if (sourceFile.LastWriteTime > destinationFile.LastWriteTime)
					{
						differentFiles.Add(new KeyValuePair<string, DiffReason>(relativePath, DiffReason.LastWrittenDif));
					}
					else if (sourceFile.Length != destinationFile.Length)
					{
						differentFiles.Add(new KeyValuePair<string, DiffReason>(relativePath, DiffReason.LengthDif));
					}
					else if (!CopiExHelpers.AreFilesEqual(sourceFile.FullName, destinationFile.FullName))
					{
						differentFiles.Add(new KeyValuePair<string, DiffReason>(relativePath, DiffReason.ChecksumDif));
					}
				}
			});
			await task;

			CurrentFileIndex = TotalFiles;

			return differentFiles;
		}

		/// <summary>
		/// Switches the direction of the file copying operation by swapping the source and destination directories.
		/// </summary>
		public void SwitchDirection()
		{
			(_destination, _source) = (_source, _destination);
		}

		private async void copyFiles()
		{
			List<KeyValuePair<string, DiffReason>> compareFiles = await CompareFiles();

			TotalFiles = 0;
			CurrentFileIndex = 0;
			CurrentStep = "Copying files...";

			foreach (KeyValuePair<string, DiffReason> file in compareFiles)
			{
				CurrentFileIndex++;
				string sourceFilePath = Path.Combine(_source.FullName, file.Key);
				string destinationFilePath = Path.Combine(_destination.FullName, file.Key);

				string path = Path.GetDirectoryName(destinationFilePath) ?? "";

				// Skip if the destination filepath is empty (means no file found)
				if (string.IsNullOrWhiteSpace(path))
				{
					continue;
				}

				// Try to copy the file else continue to the next file
				try
				{
					// Create the destination directory if it doesn't exist
					Directory.CreateDirectory(path);

					// Copy the file
					File.Copy(sourceFilePath, destinationFilePath, true);
				}
				catch (Exception)
				{
					failedFileOperation.Add(file);
					continue;
				}

			}
			CurrentFileIndex = TotalFiles;
		}

        private bool ValidatePaths()
		{
			if (!_source.Exists)
			{
				throw new DirectoryNotFoundException("Source directory does not exist.");
			}

			if (!_destination.Exists)
			{
				throw new DirectoryNotFoundException("Destination directory does not exist.");
			}

			return true;

		}

		public enum DiffReason
		{
			DestFileNotExists,
			LastWrittenDif,
			LengthDif,
			ChecksumDif
		}
	}
}
