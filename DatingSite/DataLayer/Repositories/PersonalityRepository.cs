﻿using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class PersonalityRepository
    {
        private readonly DatingSiteContext _context;
        private GameRepository gameRepository;

        public PersonalityRepository(DatingSiteContext context)
        {
            _context = context;
            gameRepository = new GameRepository(_context);
        }

        public List<string> getAll()
        {
            var list = new List<string>();
            var games = gameRepository.GetGames();
            foreach (var d in games)
            {
                _context.Entry(d).Collection(x => x.Users).Load();
                foreach (User c in d.Users)
                {
                    list.Add(d.Name + " + " +c.FirstName);
                }
            }
            return list;
        }

        public List<Personality> GetPersonalities()
        {
            return _context.Personalities.ToList();
        }

        public void AddPersonality(Personality personality)
        {
            _context.Personalities.Add(personality);
        }

        public Personality GetPersonalityById(int id)
        {
            return _context.Personalities.FirstOrDefault(x => x.PersonalityId.Equals(id));
        }

        public int GetPersonalityIdByName(string name)
        {
            return _context.Personalities.FirstOrDefault(i => i.Description == name).PersonalityId;
        }
    }
}