using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFTshop1
{
    public class Users
    {

        private int userid;
        private string name;
        private string email;
        private string password;
        private bool isArtist;

        public int Userid
        {
            get { return this.userid; }
            set { this.userid = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public bool IsArtist
        {
            get { return this.isArtist; }
            set { this.isArtist = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }


        public Users(int USERID,string NAME, string PASSWORD, string EMAIL, bool ARTIST)
        {
            this.userid = USERID;
            this.name = NAME;
            this.password = PASSWORD;
            this.email = EMAIL;
            this.isArtist = ARTIST;
        }
        public Users(Users u)
        {
            this.userid = u.userid;
            this.name = u.name;
            this.password = u.password;
            this.email = u.email;
            this.isArtist = u.isArtist;
        }

        public Users() {}
        


    }
}