using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Logging;
using System;
using System.Buffers;

namespace HugeFileSplitter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string folderPath = "D:\\KecUpdate\\MilkoKec\\2.6\\00002735";
            string largeFileName = "1689150714.upgrade";
            //string chunkFileNameWithoutExtension = largeFileName.Split('.')[0];
            int chunkSizeInBytes = 262144; // Örnek olarak her parça 256 KB boyutunda olacak

            string filePath = Path.Combine(folderPath, largeFileName);
            //byte[] data = File.ReadAllBytes(filePath);

            //for (int i = 0; i < data.Length; i += chunkSizeInBytes)
            //{
            //    int chunkSize = Math.Min(chunkSizeInBytes, data.Length - i);
            //    byte[] chunk = new byte[chunkSize];
            //    Array.Copy(data, i, chunk, 0, chunkSize);

            //    string chunkFileName = $"{chunkFileNameWithoutExtension}_{i / chunkSizeInBytes}.upgrade";
            //    string chunkFilePath = Path.Combine(folderPath, chunkFileName);

            //    File.WriteAllBytes(chunkFilePath, chunk);
            //}

            //int i = 0;
            //using (FileStream fs = File.OpenRead(filePath))
            //{
            //    byte[] buffer = new byte[chunkSizeInBytes];
            //    int bytesRead;

            //    while ((bytesRead = fs.Read(buffer, 0, chunkSizeInBytes)) > 0)
            //    {
            //        if (bytesRead == buffer.Length)
            //        {
            //            Console.WriteLine($"Read {bytesRead} {buffer.Length} bytes {i}");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Read {bytesRead} {buffer.Take(bytesRead).ToArray().Length} bytes {i}");
            //        }

            //        i++;
            //    }
            //}

            //var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            //var blockCount = stream.Length > chunkSizeInBytes ? (uint)Math.Ceiling((decimal)stream.Length / (decimal)chunkSizeInBytes) : 1;

            //var arrayPool = ArrayPool<byte>.Shared;
            //var buffer = arrayPool.Rent(chunkSizeInBytes);

            //try
            //{
            //    for (uint i = 0; i < blockCount; i++)
            //    {
            //        var bytesRead = stream.Read(buffer, 0, buffer.Length);

            //        if (bytesRead == buffer.Length)
            //            Console.WriteLine($"Read {bytesRead} {buffer.Length} bytes {i}");
            //        else
            //            Console.WriteLine($"Read {bytesRead} {buffer.Take(bytesRead).ToArray().Length} bytes {i}");
            //    }
            //}
            //finally
            //{
            //    arrayPool.Return(buffer, false);
            //}

            //int i = 0;
            //using (FileStream fs = File.OpenRead(filePath))
            //{
            //    byte[] buffer = new byte[chunkSizeInBytes];

            //    for (int startingIndex = 0; startingIndex < fs.Length; startingIndex += chunkSizeInBytes)
            //    {
            //        int bytesRead = fs.Read(buffer, 0, chunkSizeInBytes);

            //        Console.WriteLine($"Read {bytesRead} bytes from index {startingIndex} {i}");
            //        i++;
            //    }
            //}

            long startingPosition = 2;
            int bytesToRead = 3;

            using (FileStream fs = File.OpenRead("D:\\KecUpdate\\MilkoKec\\2.6\\00002735\\file.txt"))
            {
                fs.Seek(startingPosition, SeekOrigin.Begin); // Konumu ayarla

                byte[] buffer = new byte[bytesToRead];
                int bytesRead = fs.Read(buffer, 0, bytesToRead);

                char[] cArray = System.Text.Encoding.UTF8.GetString(buffer).ToCharArray();

                Console.WriteLine($"Read {bytesRead} bytes from position {startingPosition}");
            }

            Console.WriteLine("Dosya parçalama işlemi tamamlandı!");

            Console.ReadLine();

            //var summary = BenchmarkRunner.Run<BenchmarkDemo>();
        }
    }
}