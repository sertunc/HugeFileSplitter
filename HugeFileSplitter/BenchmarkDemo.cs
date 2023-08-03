using BenchmarkDotNet.Attributes;

namespace HugeFileSplitter
{
    public class BenchmarkDemo
    {
        private string folderPath = "D:\\KecUpdate\\MilkoKec";

        private int chunkSizeInBytes = 1024 * 1024; // Örnek olarak her parça 256 KB boyutunda olacak

        [Benchmark]
        public void ArrayCopyBenchmark()
        {
            string largeFileName = "1682582813.upgrade";
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
        }

        [Benchmark]
        public void BufferBlockCopyBenchmark()
        {
            string largeFileName = "1682582813 - Copy.upgrade";
            string filePath = Path.Combine(folderPath, largeFileName);
            byte[] data = File.ReadAllBytes(filePath);

            for (int i = 0; i < data.Length; i += chunkSizeInBytes)
            {
                int chunkSize = Math.Min(chunkSizeInBytes, data.Length - i);
                byte[] chunk = new byte[chunkSize];
                Buffer.BlockCopy(data, i, chunk, 0, chunkSize);

                string chunkFileName = $"chunk_{i / chunkSizeInBytes}.upgrade";
                string chunkFilePath = Path.Combine(folderPath, chunkFileName);

                File.WriteAllBytes(chunkFilePath, chunk);
            }
        }
    }
}