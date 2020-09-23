using CasualShop.BLL.DtoModels;
using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.BLL.Services
{
    public class OrderInfoService
    {
        private DataManager _dataManager;

        public OrderInfoService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<OrderInfoDto> GetOrderInfosList()
        {
            var _orders = _dataManager.OrderInfos.GetAllOrderInfos();
            List<OrderInfoDto> _modelsList = new List<OrderInfoDto>();
            foreach (var item in _orders)
            {
                _modelsList.Add(OrderInfoDBToViewModelById(item.Id));
            }
            return _modelsList;
        }

        public OrderInfoDto OrderInfoDBToViewModelById(int orderInfoId)
        {
            var _orders = _dataManager.OrderInfos.GetOrderInfoById(orderInfoId);

            return new OrderInfoDto()
            {
                Id = _orders.Id,
                FirstName = _orders.FirstName,
                LastName = _orders.LastName,
                PhoneNum = _orders.PhoneNum,
                Email = _orders.Email                
            };
        }

        public void SaveOrderInfoDtoToDb(OrderInfoDto orderInfoDto)
        {
            OrderInfo _orderInfoDbModel;
            _orderInfoDbModel = new OrderInfo();
            _orderInfoDbModel.FirstName = orderInfoDto.FirstName;
            _orderInfoDbModel.LastName = orderInfoDto.LastName;
            _orderInfoDbModel.PhoneNum = orderInfoDto.PhoneNum;
            _orderInfoDbModel.Email = orderInfoDto.Email;

            _dataManager.OrderInfos.SaveOrderInfo(_orderInfoDbModel);
        }
         
        public void DeleteOrderInfoById(int orderInfoId)
        {
            OrderInfo _orderInfoModel;
            _orderInfoModel = _dataManager.OrderInfos.GetOrderInfoById(orderInfoId);
            _dataManager.OrderInfos.DeleteOrderInfo(_orderInfoModel);
        }        
    }
}
