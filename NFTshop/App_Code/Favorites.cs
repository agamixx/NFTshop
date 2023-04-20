using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFTshop1
{
    public class Favorites
    {
        private int id;
        private int userId;
        private int nftId;
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
        public Favorites(int ID, int USERID, int NFTID)
        {
            this.id = ID;
            this.userId = USERID;
            this.nftId = NFTID;
        }
        public Favorites(Favorites favorite)
        {
            this.id = favorite.id;
            this.userId = favorite.userId;
            this.nftId = favorite.nftId;
        }

        public Favorites() { }
    }
}