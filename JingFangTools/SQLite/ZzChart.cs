using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JingFangTools.SQLite
{
    class ZzChart
    {

        //查询方剂对应的条文数据
        public static string SeltwData(string bookname, string name)
        {
            string str = "";
            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            //查询sql语句           
            string sql = "SELECT tiaowen from tiaowens WHERE name = '" + name + "' and bookname = '" + bookname + "' ";
            //实例化sql指令对象
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            //存放读取数值
            SQLiteDataReader reader = cmdQ.ExecuteReader();


            //读取每一行数据
            while (reader.Read())
            {

                //读取并赋值给控件
                str += reader.GetString(0) + "\n";
            }
            //关闭数据库
            conn.Close();
            return str;
        }



        //查询症状对应数据
        public static ArrayList SelZZData(string str, string str2)
        {
            ArrayList arr = new ArrayList();

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();

            string sql = "select sub1 from zhengzhuang where name='" + str + "' and bookname='" + str2 + "'";
            //实例化sql指令对象
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            //存放读取数值
            SQLiteDataReader reader = cmdQ.ExecuteReader();


            //读取每一行数据
            while (reader.Read())
            {

                //读取并赋值给控件
                arr.Add(reader.GetString(0));

            }
            //关闭数据库
            conn.Close();


            return arr;
        }

        public static int getCount(string strSQL)
        {
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();


            //实例化sql指令对象
            SQLiteCommand cmdQ = new SQLiteCommand(strSQL, conn);
            //存放读取数值
            int count = Convert.ToInt32(cmdQ.ExecuteScalar());

            //关闭数据库
            conn.Close();
            return count;
        }




    }
}
