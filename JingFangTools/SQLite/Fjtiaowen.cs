using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class Fjtiaowen
    {

        //查询方剂条文数据
        public void Selectfjtiaowen( RichTextBox RichtextBox, string name1)
        {
          
            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
           
            string sql = "SELECT bookname,subname,tiaowen from tiaowens WHERE name = '" + name1 + "' ";
            //实例化sql指令对象
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            //存放读取数值
            SQLiteDataReader reader = cmdQ.ExecuteReader();
            //显示数据的控件
            RichtextBox.Text = "";
            //读取每一行数据
            while (reader.Read())
            {
                //读取并赋值给控件
                RichtextBox.Text += "【" + reader.GetString(0) + "·" + reader.GetString(1) + "】" + reader.GetString(2) + "\n\n";
            }
            //关闭数据库
            conn.Close();
        }

        
    }
}
