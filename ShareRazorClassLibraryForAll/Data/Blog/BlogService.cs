using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ShareRazorClassLibraryForAll.Data.Blog
{
    public class BlogService : IBlogService
    {
        private readonly List<Blog> _blogList;
        public BlogService()
        {
            _blogList = new List<Blog>()
            {
              new Blog()
              {
                  Id=1,Name="C#",Title="C# .NET",
                  Description="Introdução a linguagem de programação C#", Author="Reinaldo Mendes",
                  Url="https://images.pexels.com/photos/6613599/pexels-photo-6613599.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
              } ,
              new Blog()
              {
                  Id=2, Name="PHP", Title="PHP Fundamentos",
                  Description="Fundamentos de programação em linguagem PHP", Author="Reinaldo Mendes",
                  Url="https://images.pexels.com/photos/13514352/pexels-photo-13514352.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
              },
                new Blog()
              {
                  Id=2, Name="Java", Title="Java FullStack Fundamentos",
                  Description="Fundamentos de programação em linguagem Java, JEE, Spring", Author="Reinaldo Mendes",
                  Url="https://images.pexels.com/photos/7188801/pexels-photo-7188801.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
              }
            };
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
           blog.Id=_blogList.Count+1;
            _blogList.Add(blog);
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var existingBlogPost = _blogList.FirstOrDefault(f => f.Id == id);
            if (existingBlogPost != null)
            {
                _blogList.Remove(existingBlogPost);
                id = existingBlogPost.Id;
            }
            return id > 0 ? id : 0;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return _blogList;
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return   _blogList.Where(f=>f.Id==id).FirstOrDefault();
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
           var existingBlogPost = _blogList.FirstOrDefault(f=>f.Id==id);    
            if(existingBlogPost!= null)
            {
                existingBlogPost.Name= blog.Name;
                existingBlogPost.Description= blog.Description;
            
            id = existingBlogPost.Id;
        }
            return id > 0 ? id : 0;
        }
    }
}
