using System.Data.Entity;

namespace BlogsConsole.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext() : base("name=BlogContext") { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public void AddBlog(Blog blog)
        {
            this.Blogs.Add(blog);
            this.SaveChanges();
        }

        public void AddPost(Blog blog, Post post)
        {
            blog.Posts.Add(post);
            this.SaveChanges();
        }

        public void DeleteBlog(Blog blog)
        {
            this.Blogs.Remove(blog);
            this.SaveChanges();
        }

        public void DeletePost(Post post)
        {
            this.Posts.Remove(post);
            this.SaveChanges();
        }

        public void EditBlog(Blog oldBlog, Blog newBlog)
        {
            var old = this.Blogs.Find(oldBlog);
            old.Name = newBlog.Name;
            this.SaveChanges();
        }

        public void EditPost(Post oldPost, Post newPost)
        {
            var old = this.Posts.Find(oldPost);
            old.Title = newPost.Title;
            old.Content = newPost.Content;
            this.SaveChanges();
        }
    }
}
