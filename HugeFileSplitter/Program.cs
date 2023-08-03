namespace HugeFileSplitter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string folderPath = "D:\\updateFiles";
            string largeFileName = "updateFile.upgrade";
            int chunkSizeInBytes = 262144; // Örnek olarak her parça 256 KB boyutunda olacak

            string filePath = Path.Combine(folderPath, largeFileName);
            byte[] data = File.ReadAllBytes(filePath);

            for (int i = 0; i < data.Length; i += chunkSizeInBytes)
            {
                int chunkSize = Math.Min(chunkSizeInBytes, data.Length - i);
                byte[] chunk = new byte[chunkSize];
                Array.Copy(data, i, chunk, 0, chunkSize);

                string chunkFileName = $"chunk_{i / chunkSizeInBytes}.upgrade";
                string chunkFilePath = Path.Combine(folderPath, chunkFileName);

                File.WriteAllBytes(chunkFilePath, chunk);
            }

            Console.WriteLine("Dosya parçalama işlemi tamamlandı!");

            Console.ReadLine();
        }
    }
}