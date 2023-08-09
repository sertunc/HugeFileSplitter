using BenchmarkDotNet.Running;

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

            int i = 0;
            using (FileStream fs = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[chunkSizeInBytes];
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, chunkSizeInBytes)) > 0)
                {
                    Console.WriteLine($"Read {bytesRead} bytes {i}");
                    i++;
                }
            }

            Console.WriteLine("Dosya parçalama işlemi tamamlandı!");

            Console.ReadLine();

            //var summary = BenchmarkRunner.Run<BenchmarkDemo>();
        }
    }
}