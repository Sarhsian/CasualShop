using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasualShop.DAL.Repository.Implementations
{
    public class EFTagsRepository : ITagsRepository
    {
        private EFDBContext context;

        public EFTagsRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteClothes(Tag tags)
        {
            context.Tags.Remove(tags);
            context.SaveChanges();
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return context.Tags.ToList();
        }

        public Tag GetTagById(int tagId)
        {
            return context.Tags.FirstOrDefault(x => x.Id == tagId);
        }

        public void SaveTags(Tag tags)
        {
            context.Entry(tags).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
