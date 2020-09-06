using CasualShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.DAL.Repository.Interfaces
{
    public interface ITagsRepository
    {
        IEnumerable<Tag> GetAllTags();
        Tag GetTagById(int tagId);
        void SaveTags(Tag tags);
        void DeleteClothes(Tag tags);
    }
}
