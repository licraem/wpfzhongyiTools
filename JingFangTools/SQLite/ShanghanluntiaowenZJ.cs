using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class ShanghanluntiaowenZJ
    {
        //条文显示在listview上
        public static void Selectzhujie(ListView listview1)
        {
            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);

           
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            //查询去重复方子只显示一条，且不能为空名的
            string sql = "select bookname,tiaowen from shlbook";
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            //存放读取数值
            SQLiteDataReader reader = cmdQ.ExecuteReader();
            //显示数据的控件

          
            //读取每一行数据
            while (reader.Read())
            {
                //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                ListViewItem lt = new ListViewItem();
                //将数据库数据转变成ListView类型的一行数据
                lt.Text = reader["tiaowen"].ToString();
                //lt.SubItems.Add(reader["zhangjie"].ToString());
                //lt.SubItems.Add(reader["subname"].ToString());
                //lt.SubItems.Add(reader["name"].ToString());
                //lt.SubItems.Add(reader["tiaowen"].ToString());
                //lt.SubItems.Add(reader["fangzi"].ToString());
                //lt.SubItems.Add(reader["fzinfo"].ToString());
                //lt.SubItems.Add(reader["pwd"].ToString());
                //将lt数据添加到listView1控件中
                listview1.Items.Add(lt);
            }
            //建立组0-9 伤寒论篇
            listview1.Groups.Add(new ListViewGroup("辨太阳病脉证并治（上）", HorizontalAlignment.Center));          
            listview1.Groups.Add(new ListViewGroup("辨太阳病脉证并治（中）", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("辨太阳病脉证并治（下）", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("辨阳明病脉证并治", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("辨少阳病脉证并治", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("辨太阴病脉证并治", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("辨少阴病脉证并治", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("辨厥阴病脉证并治", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("辨霍乱病脉证并治", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("辨阴阳易差后劳复病脉证并治", HorizontalAlignment.Center));
            //建立组10-29 金匮要略篇

            listview1.Groups.Add(new ListViewGroup("痉湿暍病脉证第二", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("百合狐惑阴阳毒病证治第三", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("疟病脉证并治第四", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("中风历节病脉证并治第五", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("血痹虚劳病脉证并治第六", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("肺痿肺痈咳嗽上气病脉证治第七", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("奔豚气病脉证治第八", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("胸痹心痛短气病脉证治第九", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("腹满寒疝宿食病脉证治第十", HorizontalAlignment.Center));

            listview1.Groups.Add(new ListViewGroup("痰饮咳嗽病脉证并治第十二", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("消渴小便不利淋病脉证并治第十三", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("水气病脉证并治第十四", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("黄疸病脉证并治第十五", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("惊悸吐血下血胸满瘀血病脉证治第十六", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("呕吐哕下利病脉证治第十七", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("疮痈肠痈浸淫病脉证并治第十八", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("趺蹶手指臂肿转筋阴狐疝蛔虫病脉证治第十九", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("妇人妊娠病脉证并治第二十", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("妇人产后病脉证治第二十一", HorizontalAlignment.Center));
            listview1.Groups.Add(new ListViewGroup("妇人杂病脉证治第二十二", HorizontalAlignment.Center));

            for (int i = 0; i < 30; i++)
            {
                listview1.Items[i].Group= listview1.Groups[0];//太阳上
            }
            for (int i = 30; i < 127; i++)
            {
                listview1.Items[i].Group = listview1.Groups[1];//太阳中
            }
            for (int i = 127; i < 178; i++)
            {
                listview1.Items[i].Group = listview1.Groups[2];//太阳下
            }
            for (int i = 178; i < 262; i++)
            {
                listview1.Items[i].Group = listview1.Groups[3];//阳明篇
            }
            for (int i = 262; i <= 271; i++)
            {
                listview1.Items[i].Group = listview1.Groups[4];//少阳篇
            }
            for (int i = 272; i <= 279; i++)
            {
                listview1.Items[i].Group = listview1.Groups[5];//太阴篇
            }
            for (int i = 280; i < 325; i++)
            {
                listview1.Items[i].Group = listview1.Groups[6];//少阴篇
            }
            for (int i = 325; i < 381; i++)
            {
                listview1.Items[i].Group = listview1.Groups[7];//厥阴篇
            }
            for (int i = 381; i < 391; i++)
            {
                listview1.Items[i].Group = listview1.Groups[8];//霍乱篇
            }
            for (int i = 391; i <= 397; i++)
            {
                listview1.Items[i].Group = listview1.Groups[9];//阴阳易篇
            }



            for (int i = 398; i <= 423; i++)
            {
                listview1.Items[i].Group = listview1.Groups[10];//痉湿暍病脉证篇
            }
            for (int i = 424; i <= 438; i++)
            {
                listview1.Items[i].Group = listview1.Groups[11];//百合狐惑阴阳毒病证治篇
            }
            for (int i = 439; i <= 446; i++)
            {
                listview1.Items[i].Group = listview1.Groups[12];//疟病脉证并治证篇
            }
            for (int i = 447; i <= 462; i++)
            {
                listview1.Items[i].Group = listview1.Groups[13];//中风历节病脉证并治篇
            }
            for (int i = 463; i <= 482; i++)
            {
                listview1.Items[i].Group = listview1.Groups[14];//血痹虚劳病脉证并治证篇
            }
            for (int i = 483; i <= 502; i++)
            {
                listview1.Items[i].Group = listview1.Groups[15];//肺痿肺痈咳嗽上气病脉证治篇
            }
            for (int i = 503; i <= 507; i++)
            {
                listview1.Items[i].Group = listview1.Groups[16];//奔豚气病脉证治篇
            }
            for (int i = 508; i <= 516; i++)
            {
                listview1.Items[i].Group = listview1.Groups[17];//胸痹心痛短气病脉证治篇
            }
            for (int i = 517; i <= 545; i++)
            {
                listview1.Items[i].Group = listview1.Groups[18];//腹满寒疝宿食病脉证治篇
            }

            for (int i = 546; i <= 586; i++)
            {
                listview1.Items[i].Group = listview1.Groups[19];//痰饮咳嗽病脉证并治篇
            }
            for (int i = 587; i <= 599; i++)
            {
                listview1.Items[i].Group = listview1.Groups[20];//消渴小便不利淋病脉证并治篇
            }
            for (int i = 600; i <= 632; i++)
            {
                listview1.Items[i].Group = listview1.Groups[21];//水气病脉证并治篇
            }
            for (int i = 633; i <= 656; i++)
            {
                listview1.Items[i].Group = listview1.Groups[22];//黄疸病脉证并治篇
            }
            for (int i = 657; i <= 673; i++)
            {
                listview1.Items[i].Group = listview1.Groups[23];//惊悸吐血下血胸满瘀血病脉证篇
            }
            for (int i = 674; i <= 722; i++)
            {
                listview1.Items[i].Group = listview1.Groups[24];//呕吐哕下利病脉证治篇
            }
            for (int i = 723; i <= 730; i++)
            {
                listview1.Items[i].Group = listview1.Groups[25];//疮痈肠痈浸淫病脉证并治证篇
            }
            for (int i = 731; i <= 738; i++)
            {
                listview1.Items[i].Group = listview1.Groups[26];//趺蹶手指臂肿转筋阴狐疝蛔虫病脉证治篇
            }
            for (int i = 739; i <= 749; i++)
            {
                listview1.Items[i].Group = listview1.Groups[27];//妇人妊娠病脉证并治篇
            }
            for (int i = 750; i <= 762; i++)
            {
                listview1.Items[i].Group = listview1.Groups[28];//妇人产后病脉证治篇
            }
            for (int i = 763; i <= 785; i++)
            {
                listview1.Items[i].Group = listview1.Groups[29];//妇人杂病脉证治篇
            }





        }

        //查询条文注解，双击listview方法
        public static void SelectListview(RichTextBox RichtextBox,string author,string tiaowen)
        {
            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            //查询去重复方子只显示一条，且不能为空名的
            string sql = "select "+author+" from shlbook where tiaowen='"+tiaowen+"'";
           // string sql1 = "select huxishubook from shlbook  where tiaowen='"+ tiaowen + "'";
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            //存放读取数值
            SQLiteDataReader reader = cmdQ.ExecuteReader();
            //显示数据的控件
            RichtextBox.Text = "";
            //读取每一行数据
            while (reader.Read())
            {
                try
                {
                    if (reader.GetString(0) == "")
                        return;

                    //读取并赋值给控件
                    RichtextBox.Text += reader.GetString(0) + "\n";
                }
                catch
                {
                  
                }
               
            }
            //关闭数据库
            conn.Close();

        }

       
        public static void UpdateShl(string tiaowen,string author,string content)
        {
            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            string sqlupdate = "update shlbook set "+author+"='" + content + "' where tiaowen='" + tiaowen + "'";
             //实例化sql指令对象
            SQLiteCommand cmdQ = new SQLiteCommand(sqlupdate, conn);
            cmdQ.ExecuteNonQuery();
            MessageBox.Show("更新成功！");


        }




    }
}
