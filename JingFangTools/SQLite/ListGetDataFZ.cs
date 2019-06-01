using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class ListGetDataFZ
    {
        //查询方子存入LIST
        public void SelectYaowu(RichTextBox RichtextBox, string name1)
        {
          
            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            //查询sql语句            
            string sql = "SELECT yaowuinfo from Yaowu WHERE yaowuname='" + name1 + "'";
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
               RichtextBox.Text += reader.GetString(0) + "\n\n";

            }
            //关闭数据库
            conn.Close();
            
        }

    }
}
