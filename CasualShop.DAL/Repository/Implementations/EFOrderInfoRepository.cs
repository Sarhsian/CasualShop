using CasualShop.DAL.Entities;
using CasualShop.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasualShop.DAL.Repository.Implementations
{
    public class EFOrderInfoRepository : IOrderInfoRepository
    {
        EFDBContext context;

        public EFOrderInfoRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteOrderInfo(OrderInfo orderInfo)
        {
            context.OrderInfos.Remove(orderInfo);
            context.SaveChanges();
        }

        public IEnumerable<OrderInfo> GetAllOrderInfos()
        {
            return context.OrderInfos.ToList();
        }

        public OrderInfo GetOrderInfoById(int orderInfoId)
        {
            return context.OrderInfos.FirstOrDefault(x => x.Id == orderInfoId);
        }

        public void SaveOrderInfo(OrderInfo orderInfo)
        {
            context.Entry(orderInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
