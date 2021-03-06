﻿using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class PlatformRepository
    {
        private readonly DatingSiteContext _context;

        public PlatformRepository(DatingSiteContext context)
        {
            _context = context;
        }

        //Get all platforms to list
        public List<Platform> GetPlatforms()
        {
            return _context.Platforms.ToList();
        }

        //Get all platform names to list
        public IList<string> GetPlatformNames()
        {
            return _context.Platforms.Cast<Platform>().Select(x => x.Name).ToList();

        }

        //Add new platform to database
        public void AddPlatform(Platform platform)
        {
            _context.Platforms.Add(platform);
        }

        //Get platform by Id
        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(x => x.PlatformId.Equals(id));
        }

        //Collect platforms to list by selected genres
        public List<Platform> GetPlatformsByNames(string[] platformNames)
        {
            var platformList = new List<Platform>();
            foreach (var i in platformNames)
            {
                platformList.Add(_context.Platforms.FirstOrDefault(x => x.Name.Equals(i)));
            }

            return platformList;
        }

    }
}