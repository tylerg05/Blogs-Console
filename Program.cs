﻿using NLog;
using BlogsConsole.Models;
using System;
using System.Linq;

namespace BlogsConsole
{
    class MainClass
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            var db = new BloggingContext();
            var userInput = "1";
            while (userInput.Equals("1") || userInput.Equals("2") || userInput.Equals("3"))
            {
                Console.WriteLine("1. Display all blogs");
                Console.WriteLine("2. Add blog");
                Console.WriteLine("3. Create post");
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    // Display all Blogs from the database
                    var query = db.Blogs.OrderBy(b => b.Name);

                    Console.WriteLine("All blogs in the database:");
                    foreach (var item in query)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
                else if (userInput == "2")
                {
                    // Create and save a new Blog
                    Console.Write("Enter a name for a new Blog: ");
                    var name = Console.ReadLine();

                    var blog = new Blog { Name = name };

                    db.AddBlog(blog);
                    logger.Info("Blog added - {name}", name);
                }
                else if (userInput == "3")
                {
                    var query = db.Blogs.OrderBy(b => b.Name);

                    var counter = 1;
                    foreach (var item in query)
                    {
                        Console.WriteLine(counter + ". " + item.Name);
                        counter++;
                    }
                    Console.WriteLine("Select the blog you are posting to: ");
                    var blogSelection = Console.ReadLine();
                    int x = Int32.Parse(blogSelection);
                    var selectedBlog = db.Blogs.Find(x);
                    Console.WriteLine("Add post title: ");
                    Post newPost = new Post();
                    newPost.Title = Console.ReadLine();
                    Console.WriteLine("Add post content: ");
                    newPost.Content = Console.ReadLine();
                    Console.WriteLine("Enter post ID: ");
                    newPost.PostId = Int32.Parse(Console.ReadLine());
                    db.AddPost(selectedBlog, newPost);
                }
                else
                {
                    Console.WriteLine("The program will now close");
                }
            }
        }
    }
}
