using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class ExeyianRead
    {

        //查询医案方子
        public static void SelectReadfzname(ListView listview1)
        {

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            SQLiteCommand cmdQ;


            try
            {
                string sql = "select fzname ,COUNT(binming) from yian GROUP BY fzname  order by count(binming) desc limit 0,300";
                cmdQ = new SQLiteCommand(sql, conn);
                //存放读取数值
                SQLiteDataReader reader = cmdQ.ExecuteReader();
                //显示数据的控件

                listview1.Items.Clear();

                //读取每一行数据
                while (reader.Read())
                {
                    //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                    ListViewItem lt = new ListViewItem();
                    //将数据库数据转变成ListView类型的一行数据
                    lt.Text = reader["fzname"].ToString();
                    lt.SubItems.Add(reader["COUNT(binming)"].ToString());

                    //将lt数据添加到listView1控件中
                    listview1.Items.Add(lt);
                }

            }
            catch
            {

            }
            //关闭数据库
            conn.Close();

        }


        //查询医案病名
        public static void SubSelectReadzz(ListView listview1,string str)
        {

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            SQLiteCommand cmdQ;


            try
            {
                string sql = "select id,binming,author from yian  where fzname='"+str+"'";
                cmdQ = new SQLiteCommand(sql, conn);
                //存放读取数值
                SQLiteDataReader reader = cmdQ.ExecuteReader();
                //显示数据的控件

                listview1.Items.Clear();

                //读取每一行数据
                while (reader.Read())
                {
                    //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                    ListViewItem lt = new ListViewItem();
                    //将数据库数据转变成ListView类型的一行数据
                    
                    lt.Text = reader["id"].ToString();
                    lt.SubItems.Add(reader["binming"].ToString());
                    lt.SubItems.Add(reader["author"].ToString());

                    //将lt数据添加到listView1控件中
                    listview1.Items.Add(lt);
                }

            }
            catch
            {

            }
            //关闭数据库
            conn.Close();

        }

        //查询医案详细
        public static void SubSelectReadInfo(RichTextBox richTextBox, string str)
        {

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            SQLiteCommand cmdQ;


            try
            {
                string sql = "select id,fzname,hefangname,binming,author,biaoqian,yainfo from yian  where id='" + str + "'";
                cmdQ = new SQLiteCommand(sql, conn);
                //存放读取数值
                SQLiteDataReader reader = cmdQ.ExecuteReader();
                //显示数据的控件

                richTextBox.Clear();

                //读取每一行数据
                while (reader.Read())
                {
                    //读取并赋值给控件
                    string str1= "方剂:\t" + reader.GetString(1) + "\t\t" + "病名:\t" + reader.GetString(3) + "\t\t" + "医案作者:\t" + reader.GetString(4) + "\n\n";
                    richTextBox.Text += str1;

                    richTextBox.Text += "症状标签:\t"+reader.GetString(5) + "\n\n";
                    richTextBox.Text += reader.GetString(6) + "\n";
                }

            }
            catch
            {

            }
            //关闭数据库
            conn.Close();

        }

        //查询医案方子
        public static void SelectFz(ListView listview1, string str)
        {

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            SQLiteCommand cmdQ;


            try
            {
                string sql = "select fzname,COUNT(binming) from yian  where fzname  like '%" + str + "%' or binming like '%" + str + "%' or author like '%" + str + "%' or biaoqian like '%" + str + "%'   GROUP BY fzname  order by count(binming) desc ";
                cmdQ = new SQLiteCommand(sql, conn);
                //存放读取数值
                SQLiteDataReader reader = cmdQ.ExecuteReader();
                //显示数据的控件

                listview1.Items.Clear();

                //读取每一行数据
                while (reader.Read())
                {
                    //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                    ListViewItem lt = new ListViewItem();
                    //将数据库数据转变成ListView类型的一行数据
                    lt.Text = reader["fzname"].ToString();
                    lt.SubItems.Add(reader["COUNT(binming)"].ToString());
                    //将lt数据添加到listView1控件中
                    listview1.Items.Add(lt);
                }

            }
            catch
            {

            }
            //关闭数据库
            conn.Close();

        }

    }
}
