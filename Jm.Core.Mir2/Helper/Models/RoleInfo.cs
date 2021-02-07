using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Models
{
    /// <summary>
    /// 角色信息
    /// </summary>
    public class RoleInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 服务器名称
        /// </summary>
        public string ServerName { get; set; }
    }
}
