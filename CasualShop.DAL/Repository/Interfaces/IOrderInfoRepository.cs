using CasualShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasualShop.DAL.Repository.Interfaces
{
    public interface IOrderInfoRepository
    {
        IEnumerable<OrderInfo> GetAllOrderInfos();
        OrderInfo GetOrderInfoById(int orderInfoId);
        void SaveOrderInfo(OrderInfo orderInfo);
        void DeleteOrderInfo(OrderInfo orderInfo);
    }
}
