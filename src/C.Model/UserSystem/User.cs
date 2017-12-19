using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.Model.UserSystem
{
    public class User : BaseModel
    {
        /// <summary>
        /// 登陆账号
        /// </summary>
        public string LoginName { get; set; }

        public List<Text> UserInfo { get; set; }
    }
}
