using BenchmarkDotNet.Attributes;

namespace HugeFileSplitter
{
    [MemoryDiagnoser]
    public class BenchmarkDemo
    {
        [Benchmark]
        public void ArrayCopyBenchmark()
        {
            string folderPath = "D:\\KecUpdate\\MilkoKec\\2.6\\00002735";
            string largeFileName = "1689150714.upgrade";
            string filePath = Path.Combine(folderPath, largeFileName);
            int chunkSizeInBytes = 262144;

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
        }

        [Benchmark]
        public void FileStreamBenchmark()
        {
            string folderPath = "D:\\KecUpdate\\MilkoKec\\2.6\\00002735";
            string largeFileName = "1689150714.upgrade";
            int chunkSizeInBytes = 262144;

            string filePath = Path.Combine(folderPath, largeFileName);

            int i = 0;
            using (FileStream fs = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[chunkSizeInBytes];
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, chunkSizeInBytes)) > 0)
                {
                    //Console.WriteLine($"Read {bytesRead} bytes {i}");
                    i++;
                }
            }
        }

        //[Benchmark]
        //public void BufferBlockCopyBenchmark()
        //{
        //    string largeFileName = "1682582813 - Copy.upgrade";
        //    string filePath = Path.Combine(folderPath, largeFileName);
        //    byte[] data = File.ReadAllBytes(filePath);

        //    for (int i = 0; i < data.Length; i += chunkSizeInBytes)
        //    {
        //        int chunkSize = Math.Min(chunkSizeInBytes, data.Length - i);
        //        byte[] chunk = new byte[chunkSize];
        //        Buffer.BlockCopy(data, i, chunk, 0, chunkSize);

        //        string chunkFileName = $"chunk_{i / chunkSizeInBytes}.upgrade";
        //        string chunkFilePath = Path.Combine(folderPath, chunkFileName);

        //        File.WriteAllBytes(chunkFilePath, chunk);
        //    }
        //}
    }
}