using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

namespace AsyncApp
{
    class Program
    {
        public static readonly string FilePath = @"c:\temp\posts.txt";
        public static readonly int FromId = 4;
        public static readonly int CountIds = 10;

        static async Task Main(string[] args)
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            var ids = Enumerable.Range(FromId, CountIds);

            var posts = await PostService.GetPosts(ids.ToArray());

            Console.WriteLine($"{posts.Count} of {CountIds} posts were got.");

            posts.ForEach(p => p.WriteToFileAsync(FilePath));

            Console.WriteLine("All Done");

            try
            {
                Process.Start("notepad.exe", FilePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Couldn't open the file ({FilePath})");
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
