using CasualShop.BLL.DtoModels;
using CasualShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.Services
{
    public class TagService
    {
        private DataManager _dataManager;
        public TagService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<TagDto> GetTagsList()
        {
            var _tags = _dataManager.Tags.GetAllTags();
            List<TagDto> _modelsList = new List<TagDto>();
            foreach (var item in _tags)
            {
                _modelsList.Add(GetTagModelById(item.Id));
            }
            return _modelsList;
        }


        public TagDto GetTagModelById(int tagId)
        {
            var _tags = _dataManager.Tags.GetTagById(tagId);

            return new TagDto()
            {
                Id = _tags.Id,
                Name = _tags.Name
            };
        }
    }
}
