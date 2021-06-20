using System;
using System.IO;

namespace AsyncApp
{
    public static class PostExtensions
    {
        public static async void WriteToFileAsync(this Post post, string filePath)
        {
            var textLines = new string[]
            {
                $"{post.UserId}",
                $"{post.Id}",
                post.Title,
                post.Body,
                Environment.NewLine
            };
            await File.AppendAllLinesAsync(filePath, textLines);
        }
    }
}
