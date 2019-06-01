using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JingFangTools.SQLite
{
    class Asbieming
    {

        /// <summary>
        /// 定义本草药物别名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string AsNameYaowu(string name)
        {

            if (name == "桂心" || name == "肉桂" || name == "牡桂")
            {
                return name = "桂枝";

            } else if (name == "苍术" || name == "山蓟" || name == "山姜" || name == "山连" || name == "于术" || name == "冬术")
            {
                return name = "白术";
            }
            else if (name == "黄耆" || name == "戴糁" || name == "戴椹" || name == "独椹" || name == "芰草" || name == "蜀脂" || name == "百本")
            {
                return name = "黄芪";
            }
            else if (name == "法夏" || name == "水玉" || name == "姜半夏" || name == "法半夏" || name == "清半夏")
            {
                return name = "半夏";
            }




            return name;
            
        }


        /// <summary>
        /// 定义经方名称别名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string AsNameFZ(string name)
        {

            if (name == "阳旦汤")
            {
                return name = "桂枝汤";
            }
            else if (name == "麻黄附子细辛汤")
            {
                return name = "麻黄细辛附子汤";
            }
            return name;

        }

        /// <summary>
        /// 定义药物组合
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string  AsNameYaowuZH(string  name)
        {

            if (name == "桂心" || name == "肉桂" || name == "牡桂")
            {
                return name = "桂枝";
            }
            else if (name == "苍术" || name == "山蓟" || name == "山姜" || name == "山连" || name == "于术" || name == "冬术")
            {
                return name = "白术";
            }
            return name;

        }


        /// <summary>
        /// 定义症状组合
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string AsNameZZ(string name)
        {

            if (name == "桂心" || name == "肉桂" || name == "牡桂")
            {
                return name = "桂枝";
            }
            else if (name == "苍术" || name == "山蓟" || name == "山姜" || name == "山连" || name == "于术" || name == "冬术")
            {
                return name = "白术";
            }
            return name;

        }

    }
}
