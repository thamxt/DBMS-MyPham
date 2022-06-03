using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DTO_ACC
    {
        private string _userId;
        private string _passWord;
        private int _role;

        public DTO_ACC()
        { }
        public DTO_ACC(string userId,string pass,int role)
        {
            this._passWord = pass;
            this._userId = userId;
            this._role = role;
        }
        public string UseId { get => _userId; set => _userId = value; }
        public string Pass { get => _passWord; set => _passWord = value; }
        public int role { get => _role; set => _role = value; }


    }
}
