using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class ListSelectzhi
    {
        public static void ListString(string str,string book,string zhangjie,string subname,string name,string tiaowen,string fangzi,string fzinfo )
        {

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();

            //查询去重复方子只显示一条，且不能为空名的
             string sql = "select bookname,zhangjie,subname,name,tiaowen,fangzi,fzinfo from tiaowens  where tiaowen='"+str+"'";
            //string sql = "select bookname,zhangjie,subname,name,tiaowen,fangzi,fzinfo from tiaowens  where tiaowen='1、太阳之为病，脉浮，头项强痛而恶寒。'";
            //实例化sql指令对象
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            //存放读取数值
            SQLiteDataReader reader = cmdQ.ExecuteReader();
            //显示数据的控件
            //读取每一行数据
            while (reader.Read())
            {
                //读取并赋值给控件
                book = reader.GetString(0);
            }
            
           // MessageBox.Show(book);
            //关闭数据库
            conn.Close();


        }


    }
}
