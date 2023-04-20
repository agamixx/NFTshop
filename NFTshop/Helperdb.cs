using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;


namespace NFTshop1
{
    public class Helperdb
    {
        #region general
        public static OleDbConnection GenerateConnection()
        {
            string stcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("App_Data/NFTshop1.mdb");
            OleDbConnection con = new OleDbConnection(stcon);
            con.Open();
            return con;
        }
        public static DataTable ReturnTable(string Sql)
        {
            OleDbConnection con = Helperdb.GenerateConnection();
            OleDbDataAdapter da = new OleDbDataAdapter(Sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int UpdateTable(string sql)
        {
            OleDbConnection obj =Helperdb.GenerateConnection();
            OleDbCommand cmd = new OleDbCommand(sql, obj);
            int value = cmd.ExecuteNonQuery();
            obj.Close();
            return value;
        }
        #endregion
        #region Users
        public static bool AddAccounts(Users user)
        {
            string sql = string.Format("insert into [Users] ([userName] , [userEmail], [userPassword], [isArtist] ) values ('{0}', '{1}', #{2}#, {3})", user.Name, user.Email, user.Password, user.IsArtist);
            return Helperdb.UpdateTable(sql) == 1;
        }
        public static bool IsExist(string email, string password)
        {
            string sql = string.Format("select * from [Users] where [userEmail]= '{0}' and [userPassword]= '{1}'", email, password);
            DataTable dt = new DataTable();
            dt = Helperdb.ReturnTable(sql);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        public static Users GetSummary_Email_Password(string email, string password)
        {
            string sql = string.Format("select * from [Users] where [userEmail] = '{0}' and [userPassword] = '{1}'", email, password);
            DataRow dr;
            try
            {
                dr = Helperdb.ReturnTable(sql).Rows[0];
            }
            catch
            {
                return null;
            }
            return new Users
            {
                Name = (dr["userName"].ToString()),
                IsArtist = bool.Parse(dr["isArtist"].ToString())
            };
        }
        public static List<Users> Return_all_accounts()
        {
            string sql = string.Format("select * from [Users]");
            List<Users> l = new List<Users>();
            DataTable dt = new DataTable();
            dt = Helperdb.ReturnTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                l.Add(new Users
                {

                    Name = (dr["userName"].ToString()),
                    Email = (dr["userEmail"].ToString()),
                    Password = (dr["userPassword"].ToString()),
                    
                    
                });
            }
            return l;
        }
        public static bool Delete_Users(string email)
        {
            string sql = string.Format("Delete from [Users] where [userEmail] = '{0}'", email);
            return Helperdb.UpdateTable(sql) == 1;
        }
        public static bool Delete_UsersID(int iduser)
        {
            string sql = string.Format("Delete from [Users] where [userId] = '{0}'", iduser);
            return Helperdb.UpdateTable(sql) == 1;
        }
        public static bool Update_Accounts(Users u)
        {
            OleDbCommand cmd = new OleDbCommand();
            string sql = String.Format("Update [Users] set [userEmail] = '{0}', [userPassword] = '{1}'", u.Email, u.Password);
            return Helperdb.UpdateTable(sql) == 1;
        }

        public static bool IsExistemail(string email)
        {
            string sql = string.Format("select * from [Users] where [userEmail]= '{0}' ", email);
            DataTable dt = new DataTable();
            dt = Helperdb.ReturnTable(sql);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        #endregion
        #region Favorites
        public static bool AddFavorites(Favorites f)
        {
            string sql = string.Format("insert into [Favorites] ([UserId], [NFTid]" + "values ({0}, {1})", f.UserId, f.NftId);
            return Helperdb.UpdateTable(sql) == 1;
        }
        public static bool IsExistFav(int iduser, int nftId)
        {
            string sql = string.Format("select * from [Favorites] where [UserId]= {0} and [NFTid]= {1}", iduser, nftId);
            DataTable dt = new DataTable();
            dt = Helperdb.ReturnTable(sql);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        public static Favorites GetSummary_Iduser_NFTid(int iduser, int nftId)
        {
            string sql = string.Format("select * from [Favorite] where [UserId]= {0} and [NFTid]= {1}", iduser, nftId);
            DataRow dr;
            try
            {
                dr = Helperdb.ReturnTable(sql).Rows[0];
            }
            catch
            {
                return null;
            }
            return new Favorites
            {
                UserId = int.Parse(dr["UserId"].ToString()),
                NftId = int.Parse(dr["NFTid"].ToString())
            };
        }
        public static List<Favorites> Return_all_Favorites()
        {
            string sql = string.Format("select * from [Favorite]");
            List<Favorites> l = new List<Favorites>();
            DataTable dt = new DataTable();
            dt = Helperdb.ReturnTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                l.Add(new Favorites
                {
                    UserId = int.Parse(dr["UserId"].ToString()),
                    NftId = int.Parse(dr["NFTid"].ToString()),
                });
            }
            return l;
        }
        public static bool Delete_Favorites(int NFTid)
        {
            string sql = string.Format("Delete from [Favorites] where [NFTid] = {0}", NFTid);
            return Helperdb.UpdateTable(sql) == 1;
        }
        public static bool Delete_FavoritesID(int iduser)
        {
            string sql = string.Format("Delete from [Favorites] where [UserId] = '{0}'", iduser);
            return Helperdb.UpdateTable(sql) == 1;
        }


        public static bool Update_Favorites(Favorites l1)
        {
            OleDbCommand cmd = new OleDbCommand();
            string sql = String.Format("Update [Favorites] set [UserId] = {0}, [NFTid] = {1}", l1.UserId, l1.NftId);
            return Helperdb.UpdateTable(sql) == 1;
        }


        public static bool IsExistNFTid(int NFTid)
        {
            string sql = string.Format("select * from [Favorites] where [NFTid]= {0} ", NFTid);
            DataTable dt = new DataTable();
            dt = Helperdb.ReturnTable(sql);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        #endregion

        #region NFT
        public static bool AddNFT(NFTs nft)
        {
            string sql = string.Format("insert into [NFTs] ([NFTname],  [NFTdescription], [nFTowneruserid], [NFTprice], [imgnft])  values ('{0}', '{1}', '{2}', '{3}', '{4}')", nft.Name, nft.Description, nft.OwnerId, nft.Price, nft.Image);
            return Helperdb.UpdateTable(sql) == 1;
        }
        public static bool AddNFT(string name, string description, int ownerId, int price, string image)
        {
            string sql = string.Format("insert into [NFTs] ([NFTname],  [NFTdescription], [nFTowneruserid], [NFTprice], [imgnft])  values ('{0}', '{1}', '{2}', '{3}', '{4}')", name, description, ownerId, price, image);
            return Helperdb.UpdateTable(sql) == 1;
        }
        public static bool IsExistNft(int id)
        {
            string sql = string.Format("select * from [NFTs] where [NFTid]= '{0}' ", id);
            DataTable dt = new DataTable();
            dt = Helperdb.ReturnTable(sql);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        public static NFTs GetSummary_NFT(int id)
        {
            string sql = string.Format("select * from [NFTs] where [NFTid]= '{0}'", id);
            DataRow dr;
            try
            {
                dr = Helperdb.ReturnTable(sql).Rows[0];
            }
            catch
            {
                return null;
            }
            return new NFTs
            {
                Name = (dr["NFTname"].ToString()),
                Description = (dr["NFTdescription"].ToString()),
                OwnerId = int.Parse(dr["nFTowneruserid"].ToString()),
                Price = int.Parse(dr["NFTprice"].ToString()),
                Image = (dr["imgnft"].ToString())
            };
        }
        public static List<NFTs> Return_all_NFTs()
        {
            string sql = string.Format("select * from [NFTs]");
            List<NFTs> l = new List<NFTs>();
            DataTable dt = new DataTable();
            dt = Helperdb.ReturnTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                l.Add(new NFTs
                {
                    Id = int.Parse(dr["NFTid"].ToString()),
                    Name = (dr["NFTname"].ToString()),
                    Description = (dr["NFTdescription"].ToString()),
                    OwnerId = int.Parse(dr["nFTowneruserid"].ToString()),
                    Price = int.Parse(dr["NFTprice"].ToString()),
                    Image = (dr["imgnft"].ToString())
                });
            }
            return l;
        }
        public static List<NFTs> Return_all_NFTs_byOwner(int ownerId)
        {
            string sql = string.Format("select * from [NFTs] where [nFTowneruserid] ='{0}'", ownerId);
            List<NFTs> l = new List<NFTs>();
            DataTable dt = new DataTable();
            dt = Helperdb.ReturnTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                l.Add(new NFTs
                {
                    Id = int.Parse(dr["codes"].ToString()),
                    Name = (dr["songname"].ToString()),
                    Description = (dr["codes"].ToString()),
                    OwnerId = int.Parse(dr["nFTowneruserid"].ToString()),
                    Price = int.Parse(dr["NFTprice"].ToString()),
                    Image = (dr["imgnft"].ToString())
                });
            }
            return l;
        }
        public static bool Delete_NFTs(string nftName)
        {
            string sql = string.Format("Delete from [NFTs] where [NFTname] = '{0}'", nftName);
            return Helperdb.UpdateTable(sql) == 1;
        }
        public static bool Delete_NFTs_ID(int idNFT)
        {
            string sql = string.Format("Delete from [NFTs] where [NFTid] = '{0}'", idNFT);
            return Helperdb.UpdateTable(sql) == 1;
        }
        public static bool Update_NFT(NFTs l1)
        {
            OleDbCommand cmd = new OleDbCommand();
            string sql = String.Format("Update [NFTs] set [NFTname] = '{0}', [NFTdescription] = '{1}'", l1.Name, l1.Description);
            return Helperdb.UpdateTable(sql) == 1;
        }


        public static bool IsExistNFTname(string name)
        {
            string sql = string.Format("select * from [NFTs] where [NFTname] = '{0}'", name);
            DataTable dt = new DataTable();
            dt = Helperdb.ReturnTable(sql);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        #endregion
    }



}
