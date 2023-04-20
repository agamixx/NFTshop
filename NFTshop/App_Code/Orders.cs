using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFTshop1
{
    public class Orders
    {
        private int id;
        private int userId;
        private int nftId;
        private string orderDate;
        private int quantity;
        private int totalPrice;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int UserId
        {
            get { return this.userId; }
            set { this.userId = value; }
        }
        public int NftId
        {
            get { return this.nftId; }
            set { this.nftId = value; }
        }
        public string OrderDate
        {
            get { return this.orderDate; }
            set { this.orderDate = value; }
        }
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }
        public int TotalPrice
        {
            get { return this.totalPrice; }
            set { this.totalPrice = value; }
        }

        public Orders(int USERID, int NFTID, string DATE, int QUANTITY, int TOTALPRICE)
        {
            this.id++;
            this.userId = USERID;
            this.nftId = NFTID;
            this.orderDate = DATE;
            this.quantity = QUANTITY;
            this.totalPrice = TOTALPRICE;
        }
        public Orders(Orders order)
        {
            this.id = order.id;
            this.userId = order.userId;
            this.nftId = order.nftId;
            this.orderDate = order.orderDate;
            this.quantity = order.quantity;
            this.totalPrice = order.totalPrice;
        }

        public Orders() { }

    }
}