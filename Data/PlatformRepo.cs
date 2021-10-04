using System;
using System.Collections.Generic;
using System.Linq;
using platformService.Models;

namespace platformService.Data{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDataContext _context;
        public PlatformRepo(AppDataContext context)
        {
            _context=context;
        }
        public void CreatePlatForm(Platform platform)
        {
            if(platform==null){
                throw new ArgumentNullException(nameof(platform));
            }
             _context.platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
           return _context.platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.platforms.FirstOrDefault(p=>p.Id==id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges()>=0);
        }
    }
}