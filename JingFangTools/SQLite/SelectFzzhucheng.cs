using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class SelectFzzhucheng
    {
        //查询方剂组成数据
        public void Selectfjtiaowen( string bookname,RichTextBox RichtextBox, string name1)
        {
            //Asbieming asname = new Asbieming();
            //string name1 = asname.AsNameFZ(name);
            //数据库路径
           // string dbPath = "Data Source =" + Environment.CurrentDirectory + "/DataDb.db";
            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            //查询sql语句
            // string sql = "select * from Yaowu";
            // string sql = "SELECT tiaowen from tiaowens WHERE name like '%" + name + "%' ";
            string sql = "SELECT fangzi,fzinfo from tiaowens WHERE name = '" + name1 + "' and bookname = '" + bookname + "'  group by name, fangzi";
            //实例化sql指令对象
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            //存放读取数值
            SQLiteDataReader reader = cmdQ.ExecuteReader();
            //显示数据的控件
            //RichtextBox.Text = "\n【方剂组成】\n";
            //读取每一行数据
            int num =0;
            while (reader.Read())
            {
                num++;
                //读取并赋值给控件
                RichtextBox.Text += "\n【方剂组成】\n"+ num.ToString()+"、"+reader.GetString(0) + "\n" + reader.GetString(1)+"\n";
            }
            //关闭数据库
            conn.Close();
        }

        //查询方剂对应的条文数据
        public void Selectduiyingfangjitiaowen(string bookname, RichTextBox RichtextBox, string name)
        {
            //Asbieming asname = new Asbieming();
            //string name1 = asname.AsNameFZ(name);
            //数据库路径
           // string dbPath = "Data Source =" + Environment.CurrentDirectory + "/DataDb.db";
            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            //查询sql语句
            // string sql = "select * from Yaowu";
            // string sql = "SELECT tiaowen from tiaowens WHERE name like '%" + name + "%' ";
            string sql = "SELECT tiaowen from tiaowens WHERE name = '" + name + "' and bookname = '" + bookname + "' ";
            //实例化sql指令对象
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            //存放读取数值
            SQLiteDataReader reader = cmdQ.ExecuteReader();
            //显示数据的控件
            RichtextBox.Text = "";
            RichtextBox.Text = "【主治出处】\n";
            
            int num = 0;
            //读取每一行数据
            while (reader.Read())
            {
                num++;
                //读取并赋值给控件
                RichtextBox.Text += num.ToString() + "、"+reader.GetString(0) + "\n";
            }
            //关闭数据库
            conn.Close();
        }


    }
}
