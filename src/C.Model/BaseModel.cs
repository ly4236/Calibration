using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C.Model.UserSystem;
namespace C.Model
{
    public class BaseModel : Base
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string ShortName { get; set; }

    }
}
