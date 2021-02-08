using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jm.Core.Mir2.Helper.Models
{
    /// <summary>
    /// 挂机设置
    /// </summary>
    public class MirSetting
    {
        /// <summary>
        /// 挂机回城地图
        /// </summary>
        public MapInfo CityMap { get; set; }
        /// <summary>
        /// 挂机打怪地图
        /// </summary>
        public MapInfo FireMap { get; set; }
        /// <summary>
        /// 红药水回城底限
        /// </summary>
        public int MinHPPotion { get; set; } = 1;
        /// <summary>
        /// 蓝药水回城底限
        /// </summary>
        public int MinMPPotion { get; set; } = 1;
        /// <summary>
        /// 包裹空格底限
        /// </summary>
        public int FreePackage { get; set; } = 1;
        /// <summary>
        /// 护身符底限
        /// </summary>
        public int MinAmulet { get; set; } = 0;
        /// <summary>
        /// 装备信息
        /// <para>目前只是临时使用，以后需要参考 Mir2 服务端的装备物品来实现</para>
        /// </summary>
        public WeaponryInfo Weaponry { get; set; }
        /// <summary>
        /// 挂机巡逻点
        /// <para>这个是通过读取配置获得的</para>
        /// </summary>
        public List<Point> PatrolPoints { get; set; } = new List<Point>();
        /// <summary>
        /// 仓库商人
        /// </summary>
        public NPCInfo StorageNPC { get; set; }
        /// <summary>
        /// 药水商人
        /// </summary>
        public NPCInfo PotionNPC { get; set; }
        /// <summary>
        /// 杂货铺商人
        /// </summary>
        public NPCInfo AmuletNPC { get; set; }
        /// <summary>
        /// 武器店商人
        /// </summary>
        public NPCInfo WeaponNPC { get; set; }
        /// <summary>
        /// 头盔商人
        /// </summary>
        public NPCInfo HelmetNPC { get; set; }
        /// <summary>
        /// 手镯商人
        /// </summary>
        public NPCInfo BraceletNPC { get; set; }
        /// <summary>
        /// 衣服商人
        /// </summary>
        public NPCInfo ArmourNPC { get; set; }
        /// <summary>
        /// 戒指商人
        /// </summary>
        public NPCInfo RingNPC { get; set; }
        /// <summary>
        /// 项链商人
        /// </summary>
        public NPCInfo NecklaceNPC { get; set; }
    }
}
