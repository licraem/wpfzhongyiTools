using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class SeletDataGrid
    {

        //查询修改所有条文数据
        public void SelectDatagrid1(ComboBox comboBox,string str,DataGridView dgv)
        {


            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();

            switch (comboBox.SelectedItem.ToString())
            {
                case "全部":
                    
                    //查询去重复方子只显示一条，且不能为空名的
                    string sql = "select bookname,name from tiaowens";                                 
                    SQLiteDataAdapter find = new SQLiteDataAdapter(sql, conn);
                    DataSet save = new DataSet(); //创建DataSet实例
                    find.Fill(save); //  使用DataAdapter的Fill方法(填充)，调用SELECT命令      fill(对象名，"自定义虚拟表名")  
                    DataTable dtbl = save.Tables[0];
                    dgv.AutoGenerateColumns = false;//不自动生成列，从数据库可能取得很多列，使其不显示在DataGridView中            
                    dgv.DataSource = dtbl;

                    for (int i = 0; i < dtbl.Rows.Count; i++)
                    {
                        string obj1 = dtbl.Rows[i]["bookname"].ToString();
                        string obj2 = dtbl.Rows[i]["name"].ToString();
                        dgv.Rows[i].Cells["Column1"].Value = obj1;
                        dgv.Rows[i].Cells["Column2"].Value = obj2;
                    }


                    dgv.Columns["Column1"].DataPropertyName = dtbl.Columns["bookname"].ToString();
                    dgv.Columns["Column2"].DataPropertyName = dtbl.Columns["name"].ToString();
                  

                    break;
                case "":
                    break;
              


            }

            //关闭数据库
            conn.Close();

        }



        //查询修改所有条文数据
        public void SelectDatagrid2(ComboBox comboBox, string str, ListView listview1)
        {


            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            SQLiteCommand cmdQ;
           
            switch (comboBox.SelectedItem.ToString())
            {
                case "全部":

                   
                    string sql = "select bookname,zhangjie,subname,name,tiaowen,fangzi,fzinfo from tiaowens";
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
                        lt.Text = reader["bookname"].ToString();
                        lt.SubItems.Add(reader["zhangjie"].ToString());
                        lt.SubItems.Add(reader["subname"].ToString());
                        lt.SubItems.Add(reader["name"].ToString());
                        lt.SubItems.Add(reader["tiaowen"].ToString());
                        lt.SubItems.Add(reader["fangzi"].ToString());
                        lt.SubItems.Add(reader["fzinfo"].ToString());
                        //lt.SubItems.Add(reader["pwd"].ToString());
                        //将lt数据添加到listView1控件中
                        listview1.Items.Add(lt);
                    }

                  



                    break;
                case "章节信息":


                    //查询去重复方子只显示一条，且不能为空名的
                    string sql2 = "select bookname,zhangjie,subname,name,tiaowen,fangzi,fzinfo from tiaowens where subname='" + str + "'";
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
                        lt.Text = reader2["bookname"].ToString();
                        lt.SubItems.Add(reader2["zhangjie"].ToString());
                        lt.SubItems.Add(reader2["subname"].ToString());
                        lt.SubItems.Add(reader2["name"].ToString());
                        lt.SubItems.Add(reader2["tiaowen"].ToString());
                        lt.SubItems.Add(reader2["fangzi"].ToString());
                        lt.SubItems.Add(reader2["fzinfo"].ToString());
                        listview1.Items.Add(lt);
                    }


                    break;
                case "方剂名称":


                    //查询去重复方子只显示一条，且不能为空名的
                    string sql3 = "select bookname,zhangjie,subname,name,tiaowen,fangzi,fzinfo from tiaowens where name='" + str + "'";
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
                        lt.Text = reader3["bookname"].ToString();
                        lt.SubItems.Add(reader3["zhangjie"].ToString());
                        lt.SubItems.Add(reader3["subname"].ToString());
                        lt.SubItems.Add(reader3["name"].ToString());
                        lt.SubItems.Add(reader3["tiaowen"].ToString());
                        lt.SubItems.Add(reader3["fangzi"].ToString());
                        lt.SubItems.Add(reader3["fzinfo"].ToString());
                        listview1.Items.Add(lt);
                    }


                    break;
                case "条文信息":


                    //查询去重复方子只显示一条，且不能为空名的
                    string sql4 = "select bookname,zhangjie,subname,name,tiaowen,fangzi,fzinfo from tiaowens where tiaowen like '%" + str + "%'";
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
                        lt.Text = reader4["bookname"].ToString();
                        lt.SubItems.Add(reader4["zhangjie"].ToString());
                        lt.SubItems.Add(reader4["subname"].ToString());
                        lt.SubItems.Add(reader4["name"].ToString());
                        lt.SubItems.Add(reader4["tiaowen"].ToString());
                        lt.SubItems.Add(reader4["fangzi"].ToString());
                        lt.SubItems.Add(reader4["fzinfo"].ToString());
                        listview1.Items.Add(lt);
                    }


                    break;

                case "书名":

                    listview1.Items.Clear();

                    //查询去重复方子只显示一条，且不能为空名的
                    string sql5 = "select bookname,zhangjie,subname,name,tiaowen,fangzi,fzinfo from tiaowens where bookname='"+str+"'";
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
                        lt.Text = reader5["bookname"].ToString();
                        lt.SubItems.Add(reader5["zhangjie"].ToString());
                        lt.SubItems.Add(reader5["subname"].ToString());
                        lt.SubItems.Add(reader5["name"].ToString());
                        lt.SubItems.Add(reader5["tiaowen"].ToString());
                        lt.SubItems.Add(reader5["fangzi"].ToString());
                        lt.SubItems.Add(reader5["fzinfo"].ToString());
                        listview1.Items.Add(lt);
                    }
                    

                    break;

            }

            //关闭数据库
            conn.Close();

        }


    }
}
