﻿using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class PostRepository
    {
        private readonly DatingSiteContext _context;
        private UserRepository userRepository;

        public PostRepository(DatingSiteContext context)
        {
            _context = context;
            userRepository = new UserRepository(_context);
        }

        //Get all posts
        public List<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        //Create new user-post in database
        public void CreatePost(User reciever, User sender, string content)
        {
            _context.Posts.Add(new Post
            {
                Receiver = reciever,
                ReceiverId = reciever.UserId,
                Sender = sender,
                SenderId = sender.UserId,
                TimeStamp = DateTime.Now,
                Content = content
            });
            _context.SaveChanges();
        }

        //Get post by mail, order by latest post/date
        public List<Post> GetPostsByMailOrderedByLatestDate(string mail)
        {
            var list = _context.Posts
                .Include(u => u.Sender)
                .Include(u => u.Receiver)
                .OrderByDescending(z => z.TimeStamp)
                .Where(x => x.ReceiverId.Equals(userRepository.getUserByMail(mail).UserId) && x.Sender.Active == true)
                .ToList();
            return list;
        }

        //Delete post from database by Id
        public void DeletePost(int id)
        {
            var post = _context.Posts.Find(id);
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}