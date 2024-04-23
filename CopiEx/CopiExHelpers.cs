using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;

public static class CopiExHelpers
{

    public static bool AreFilesEqual(string filePath1, string filePath2)
    {
        // Check if files have the same size
        FileInfo fileInfo1 = new FileInfo(filePath1);
        FileInfo fileInfo2 = new FileInfo(filePath2);

        if (fileInfo1.Length != fileInfo2.Length)
        {
            return false; // Different size means different content
        }

        // Open file streams
        using (FileStream fileStream1 = fileInfo1.OpenRead())
        using (FileStream fileStream2 = fileInfo2.OpenRead())
        {
            // Compare byte by byte
            int byte1, byte2;
            do
            {
                byte1 = fileStream1.ReadByte();
                byte2 = fileStream2.ReadByte();

                if (byte1 != byte2)
                {
                    return false; // Files have different content
                }
            } while (byte1 != -1);

            // Files have the same content
            return true;
        }
    }

    public static string CalculateChecksum(string filePath)
    {
        using (var sha256 = SHA256.Create())
        {
            using (var stream = File.OpenRead(filePath))
            {
                byte[] hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
	
    public static string GetDescription(this Enum e)
	{
		var descriptionAttribute = e.GetType().GetMember(e.ToString())[0]
			.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)[0]
			as DescriptionAttribute;

		return descriptionAttribute.Description;
	}

	/// <summary>
	/// Compares the checksum of the source file with the destination file.
	/// </summary>
	/// <param name="sourceFile">The path of the source file.</param>
	/// <param name="destinationFile">The path of the destination file.</param>
	/// <returns>True if the checksums match, otherwise false.</returns>
	public static bool CompareChecksum(string sourceFile, string destinationFile)
    {
        var sourceChecksum = CalculateChecksum(sourceFile);
        var destinationChecksum = CalculateChecksum(destinationFile);

        return StructuralComparisons.StructuralEqualityComparer.Equals(sourceChecksum, destinationChecksum);
    }
}