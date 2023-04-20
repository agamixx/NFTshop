using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFTshop1
{
    public class NFTs
    {
        private int id;
        private string name;
        private string description;
        private int ownerId;
        private int price;
        private string image;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public int OwnerId
        {
            get { return this.ownerId; }
            set { this.ownerId = value; }
        }
        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public string Image
        {
            get { return this.image; }
            set { this.image = value; }
        }

        public NFTs(int ID, string NAME, string DESCRIPTION, int OWNERID, int PRICE, string IMAGE)
        {
            this.id = ID;
            this.name = NAME;
            this.description = DESCRIPTION;
            this.ownerId = OWNERID;
            this.price = PRICE;
            this.image = IMAGE;
        }
        public NFTs(NFTs nft)
        {
            this.id = nft.id;
            this.name = nft.name;
            this.description = nft.description;
            this.ownerId = nft.ownerId;
            this.price = nft.price;
            this.image = nft.image;
        }

        public NFTs() { }
    }
}