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
        public static readonly int ToId = 13;

        static async Task Main(string[] args)
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            var countIds = Math.Abs(ToId - FromId) + 1;

            var ids = Enumerable.Range(Math.Min(FromId, ToId), countIds);

            var posts = await PostService.GetPosts(ids.ToArray());

            Console.WriteLine($"Posts Count: {posts.Count}");
            Console.WriteLine($"Post Ids which were wrote to file: ");

            foreach (var post in posts)
            {
                post.WriteToFileAsync(FilePath);
                Console.Write($"{post.Id} ");
            }

            Console.WriteLine();
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
