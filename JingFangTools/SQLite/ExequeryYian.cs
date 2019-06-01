using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class ExequeryYian
    {
        //添加和更新医案数据
        public static void Addyian(string id,string fzname, string hefangname, string binming, string author, string biaoqian ,string yainfo)
        {

            try
            {
                //创建数据库实例，指定文件位置 
                SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
                //打开数据库，若文件不存在会自动创建 
                conn.Open();

                string sql = "SELECT count(id) from yian WHERE id='" + id + "'";

                SQLiteCommand selcmd = new SQLiteCommand(sql, conn);
                int o = Convert.ToInt32(selcmd.ExecuteScalar());
                if (o == 0)
                {


                    string sqlins = "INSERT INTO yian(fzname,hefangname,binming,author,biaoqian,yainfo) VALUES ('" + fzname + "','" + hefangname + "','" + binming + "','" + author + "','" + biaoqian + "','" + yainfo + "');";

                    //实例化sql指令对象
                    SQLiteCommand cmdQ = new SQLiteCommand(sqlins, conn);
                    cmdQ.ExecuteNonQuery();
                    MessageBox.Show("医案已添加成功");
                }
                else
                {


                    string sqlupdate = "update yian set hefangname='" + hefangname + "',binming='" + binming + "',author='" + author + "', biaoqian='" + biaoqian + "', yainfo='" + yainfo + "'  WHERE id='" + id + "' ";

                    //实例化sql指令对象
                    SQLiteCommand cmdQ = new SQLiteCommand(sqlupdate, conn);
                    cmdQ.ExecuteNonQuery();
                    MessageBox.Show("医案已更新成功");
                }

                //关闭数据库
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //查询最近医案列表
        public static void SelectyianList(ListView listview1)
        {

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            SQLiteCommand cmdQ;


            try
            {
                string sql = "select * from yian order by id desc limit 0,300";
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
                    lt.SubItems.Add(reader["fzname"].ToString());
                    lt.SubItems.Add(reader["hefangname"].ToString());
                    lt.SubItems.Add(reader["binming"].ToString());
                    lt.SubItems.Add(reader["author"].ToString());
                    lt.SubItems.Add(reader["biaoqian"].ToString());
                    lt.SubItems.Add(reader["yainfo"].ToString());                  
                  
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


        //删除医案
        public static void Delyian(string id)
        {

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();

            if (MessageBox.Show("您真的要删除吗？", "此删除不可恢复", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sqlselect = "delete from yian where id='" + id + "'";
                SQLiteCommand delcmd = new SQLiteCommand(sqlselect, conn);
                delcmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("删除成功!");
            }
            else
            {
                return;
            }


        }





        //条件查询医案数据
        public static void SelectYianData(ComboBox comboBox, string str, ListView listview1)
        {


            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            SQLiteCommand cmdQ;

            switch (comboBox.SelectedItem.ToString())
            {
                case "全部":


                    string sql = "select id,fzname,hefangname,binming,author,biaoqian,yainfo from yian";
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
                        lt.SubItems.Add(reader["fzname"].ToString());
                        lt.SubItems.Add(reader["hefangname"].ToString());
                        lt.SubItems.Add(reader["binming"].ToString());
                        lt.SubItems.Add(reader["author"].ToString());
                        lt.SubItems.Add(reader["biaoqian"].ToString());
                        lt.SubItems.Add(reader["yainfo"].ToString());
                        //将lt数据添加到listView1控件中
                        listview1.Items.Add(lt);
                    }





                    break;
                case "方剂名称":


                    //查询去重复方子只显示一条，且不能为空名的
                    string sql2 = "select * from yian where fzname='" + str + "' order by id desc";
                    cmdQ = new SQLiteCommand(sql2, conn);
                    //存放读取数值
                    SQLiteDataReader reader2 = cmdQ.ExecuteReader();
                    //显示数据的控件


                    listview1.Items.Clear();

                    //读取每一行数据
                    while (reader2.Read())
                    {
                        //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                        ListViewItem lt = new ListViewItem();
                        //将数据库数据转变成ListView类型的一行数据
                        lt.Text = reader2["id"].ToString();
                        lt.SubItems.Add(reader2["fzname"].ToString());
                        lt.SubItems.Add(reader2["hefangname"].ToString());
                        lt.SubItems.Add(reader2["binming"].ToString());
                        lt.SubItems.Add(reader2["author"].ToString());
                        lt.SubItems.Add(reader2["biaoqian"].ToString());
                        lt.SubItems.Add(reader2["yainfo"].ToString());
                        listview1.Items.Add(lt);
                    }


                    break;
                case "病名":


                    //查询去重复方子只显示一条，且不能为空名的
                    string sql3 = "select * from yian where binming='" + str + "' order by id desc";
                    cmdQ = new SQLiteCommand(sql3, conn);
                    //存放读取数值
                    SQLiteDataReader reader3 = cmdQ.ExecuteReader();
                    //显示数据的控件


                    listview1.Items.Clear();

                    //读取每一行数据
                    while (reader3.Read())
                    {
                        //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                        ListViewItem lt = new ListViewItem();
                        //将数据库数据转变成ListView类型的一行数据
                        lt.Text = reader3["id"].ToString();
                        lt.SubItems.Add(reader3["fzname"].ToString());
                        lt.SubItems.Add(reader3["hefangname"].ToString());
                        lt.SubItems.Add(reader3["binming"].ToString());
                        lt.SubItems.Add(reader3["author"].ToString());
                        lt.SubItems.Add(reader3["biaoqian"].ToString());
                        lt.SubItems.Add(reader3["yainfo"].ToString());
                        listview1.Items.Add(lt);
                    }


                    break;
                case "作者":


                    //查询去重复方子只显示一条，且不能为空名的
                    string sql4 = "select * from yian where author='" + str + "' order by id desc";
                    cmdQ = new SQLiteCommand(sql4, conn);
                    //存放读取数值
                    SQLiteDataReader reader4 = cmdQ.ExecuteReader();
                    //显示数据的控件


                    listview1.Items.Clear();

                    //读取每一行数据
                    while (reader4.Read())
                    {
                        //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                        ListViewItem lt = new ListViewItem();
                        //将数据库数据转变成ListView类型的一行数据
                        lt.Text = reader4["id"].ToString();
                        lt.SubItems.Add(reader4["fzname"].ToString());
                        lt.SubItems.Add(reader4["hefangname"].ToString());
                        lt.SubItems.Add(reader4["binming"].ToString());
                        lt.SubItems.Add(reader4["author"].ToString());
                        lt.SubItems.Add(reader4["biaoqian"].ToString());
                        lt.SubItems.Add(reader4["yainfo"].ToString());
                        listview1.Items.Add(lt);
                    }


                    break;

                case "症状标签":

                    listview1.Items.Clear();

                    //查询去重复方子只显示一条，且不能为空名的
                    string sql5 = "select * from yian where biaoqian like '%" + str + "%' order by id desc ";
                    cmdQ = new SQLiteCommand(sql5, conn);
                    //存放读取数值
                    SQLiteDataReader reader5 = cmdQ.ExecuteReader();
                    //显示数据的控件



                    //读取每一行数据
                    while (reader5.Read())
                    {
                        //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                        ListViewItem lt = new ListViewItem();
                        //将数据库数据转变成ListView类型的一行数据
                        lt.Text = reader5["id"].ToString();
                        lt.SubItems.Add(reader5["fzname"].ToString());
                        lt.SubItems.Add(reader5["hefangname"].ToString());
                        lt.SubItems.Add(reader5["binming"].ToString());
                        lt.SubItems.Add(reader5["author"].ToString());
                        lt.SubItems.Add(reader5["biaoqian"].ToString());
                        lt.SubItems.Add(reader5["yainfo"].ToString());
                        listview1.Items.Add(lt);
                    }


                    break;

                case "医案内容":

                    listview1.Items.Clear();

                    //查询去重复方子只显示一条，且不能为空名的
                    string sql6 = "select * from yian where yainfo like '%" + str + "%' order by id desc";
                    cmdQ = new SQLiteCommand(sql6, conn);
                    //存放读取数值
                    SQLiteDataReader reader6 = cmdQ.ExecuteReader();
                    //显示数据的控件



                    //读取每一行数据
                    while (reader6.Read())
                    {
                        //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                        ListViewItem lt = new ListViewItem();
                        //将数据库数据转变成ListView类型的一行数据
                        lt.Text = reader6["id"].ToString();
                        lt.SubItems.Add(reader6["fzname"].ToString());
                        lt.SubItems.Add(reader6["hefangname"].ToString());
                        lt.SubItems.Add(reader6["binming"].ToString());
                        lt.SubItems.Add(reader6["author"].ToString());
                        lt.SubItems.Add(reader6["biaoqian"].ToString());
                        lt.SubItems.Add(reader6["yainfo"].ToString());
                        listview1.Items.Add(lt);
                    }


                    break;

            }

            //关闭数据库
            conn.Close();

        }




    }
}
