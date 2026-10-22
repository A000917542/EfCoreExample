using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// using var db = new BloggingContext();

// // Note: This sample requires the database to be created before running.
// Console.WriteLine($"Database path: {db.DbPath}.");

// var b1 = new Blog { Url = "http://blogs.msdn.com/adonet" };

// Console.WriteLine($"B1.Id = {b1.BlogId}");
// Console.WriteLine($"B1.Url = {b1.Url}");
// Console.WriteLine($"B1.Posts = {b1.Posts.Count}");

// // Create
// Console.WriteLine("Inserting a new blog");
// db.Add(b1);
// await db.SaveChangesAsync();

// Console.WriteLine($"B1.Id = {b1.BlogId}");
// Console.WriteLine($"B1.Url = {b1.Url}");
// Console.WriteLine($"B1.Posts = {b1.Posts.Count}");

// // Read
// Console.WriteLine("Querying for a blog");
// var blog = await db.Blogs
//     .OrderBy(b => b.BlogId)
//     .FirstAsync();

// Console.WriteLine($"blog.Id = {blog.BlogId}");
// Console.WriteLine($"blog.Url = {blog.Url}");
// Console.WriteLine($"blog.Posts = {blog.Posts.Count}");

// // Update
// Console.WriteLine("Updating the blog and adding a post");
// blog.Url = "https://devblogs.microsoft.com/dotnet";
// blog.Posts.Add(
//     new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
// await db.SaveChangesAsync();

// var blog2 = await db.Blogs
//     .OrderBy(b => b.BlogId)
//     .FirstAsync();

// Console.WriteLine($"blog2.Id = {blog2.BlogId}");
// Console.WriteLine($"blog2.Url = {blog2.Url}");
// Console.WriteLine($"blog2.Posts = {blog2.Posts.Count}");

// // Delete
// Console.WriteLine("Delete the blog");
// db.Remove(blog);
// await db.SaveChangesAsync();

using var db = new BloggingContext();

List<Blog> Blogs = new();

Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet1" });
Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet2" });
Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet3" });
Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet4" });
Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet5" });

Stopwatch st = new();

st.Start();
foreach (var b in Blogs)
{
    db.Add(b);
}

await db.SaveChangesAsync();

st.Stop();

Console.WriteLine(st.ElapsedMilliseconds);

var queryResult = db.Blogs
    .Where(b => b.Url.Contains("adonet5") && b.BlogId < 30)
    .ToList();

foreach(var b in queryResult)
{
    Console.WriteLine($"Blog: {b.BlogId} - {b.Url}");
}

// Console.WriteLine($"Count of Blogs: {queryResult}");