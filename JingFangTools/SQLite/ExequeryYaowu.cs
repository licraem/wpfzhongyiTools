using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class ExequeryYaowu
    {
        //查询药物数据
        public static  void ExequeryYaowu1(string str ,RichTextBox RichtextBox,TextBox textbox1, TextBox textbox2, TextBox textbox3, TextBox textbox4, TextBox textbox5, TextBox textbox6,ComboBox combobox1,ComboBox combobox2)
        {

            try
            {

          
          
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            //查询sql语句
            // string sql = "select * from Yaowu";
            string sql = "SELECT yaowuinfo,subname1,subname2,subname3,subname4,subname5,subname6,pingji,wuzhong from yaowu WHERE yaowuname='"+str+"' or subname1='"+str+ "' or subname2='" + str + "' or subname3='" + str + "' or subname4='" + str + "' or subname5='" + str + "' or subname6='" + str + "'";
            //实例化sql指令对象
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            //存放读取数值
            SQLiteDataReader reader = cmdQ.ExecuteReader();
            //显示数据的控件
            RichtextBox.Text = "";
            textbox1.Text ="";
            textbox2.Text = "";
            textbox3.Text = "";
            textbox4.Text = "";
            textbox5.Text = "";
            textbox6.Text = "";
            combobox1.Text = "";
            combobox2.Text = "";
            //读取每一行数据
            while (reader.Read())
            {
                //读取并赋值给控件
                RichtextBox.Text += reader.GetString(0) + "\n";
                textbox1.Text = reader.GetString(1);
                textbox2.Text = reader.GetString(2);
                textbox3.Text = reader.GetString(3);
                textbox4.Text = reader.GetString(4);
                textbox5.Text = reader.GetString(5);
                textbox6.Text = reader.GetString(6);
                combobox1.Text = reader.GetString(7);
                combobox2.Text = reader.GetString(8);
            }
            //关闭数据库
            conn.Close();
            }catch
            {

            }
        }

        //添加和更新药物数据
        public static void AddDataYW(string str,string pingji,string wuzhong,string sub1,string sub2,string sub3,string sub4,string sub5,string sub6 ,string strinfo)
        {

            try
            {
                //创建数据库实例，指定文件位置 
                SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
                //打开数据库，若文件不存在会自动创建 
                conn.Open();

                string sql = "SELECT count(yaowuname) from yaowu WHERE yaowuname='" + str + "' or subname1='" + str + "' or subname2='" + str + "' or subname3='" + str + "' or subname4='" + str + "' or subname5='" + str + "' or subname6='" + str + "'";

                SQLiteCommand selcmd = new SQLiteCommand(sql, conn);
                int o = Convert.ToInt32(selcmd.ExecuteScalar());
                if (o == 0)
                {


                    string sqlins = "INSERT INTO yaowu(yaowuname,pingji,wuzhong,subname1,subname2,subname3,subname4,subname5,subname6,yaowuinfo) VALUES ('" + str + "','" + pingji + "','" + wuzhong + "','" + sub1 + "','" + sub2 + "','" + sub3 + "','" + sub4 + "','" + sub5 + "','" + sub6 + "','" + strinfo + "');";

                    //实例化sql指令对象
                    SQLiteCommand cmdQ = new SQLiteCommand(sqlins, conn);
                    cmdQ.ExecuteNonQuery();
                    MessageBox.Show("药物数据已添加成功");
                }
                else
                {


                    string sqlupdate = "update yaowu set yaowuinfo='" + strinfo + "',pingji='" + pingji + "',wuzhong='" + wuzhong + "', subname1='" + sub1 + "', subname2='" + sub2 + "',subname3='" + sub3 + "',subname4='" + sub4 + "',subname5='" + sub5 + "',subname6='" + sub6 + "'  WHERE yaowuname='" + str + "' or subname1='" + str + "' or subname2='" + str + "' or subname3='" + str + "' or subname4='" + str + "' or subname5='" + str + "' or subname6='" + str + "'";

                    //实例化sql指令对象
                    SQLiteCommand cmdQ = new SQLiteCommand(sqlupdate, conn);
                    cmdQ.ExecuteNonQuery();
                    MessageBox.Show("药物数据已更新成功");
                }

                //关闭数据库
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //删除药物
        public static void Delyaowu(string yaowuname)
        {

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();

            if (MessageBox.Show("您真的要删除吗？", "此删除不可恢复", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sqlselect = "delete from yaowu where yaowuname='" + yaowuname + "'";
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

        public static void SelectYaowuList(ListView listview1)
        {

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            SQLiteCommand cmdQ;


            try
            {
                string sql = "select yaowuname,pingji,wuzhong,subname1,subname2,subname3,subname4,subname5,subname6,yaowuinfo from yaowu ORDER  BY pingji";
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
                    lt.Text = reader["yaowuname"].ToString();
                    lt.SubItems.Add(reader["pingji"].ToString());
                    lt.SubItems.Add(reader["wuzhong"].ToString());
                    lt.SubItems.Add(reader["subname1"].ToString());
                    lt.SubItems.Add(reader["subname2"].ToString());
                    lt.SubItems.Add(reader["subname3"].ToString());
                    lt.SubItems.Add(reader["subname4"].ToString());
                    lt.SubItems.Add(reader["subname5"].ToString());
                    lt.SubItems.Add(reader["subname6"].ToString());
                    lt.SubItems.Add(reader["yaowuinfo"].ToString());
                    //lt.SubItems.Add(reader["pwd"].ToString());
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
