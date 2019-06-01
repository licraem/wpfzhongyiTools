using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class bindbookFangzi
    {

        //查询方剂条文数据
        public void Bangfangzi(ComboBox comboBox)
        {

            try
            {
                //创建数据库实例，指定文件位置 
                SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
                //打开数据库，若文件不存在会自动创建 
                conn.Open();

                //查询去重复方子只显示一条，且不能为空名的
                string sql = "select bookname,name from tiaowens  where name <>'' and name is not null group by name,bookname, fangzi  ";
                //实例化sql指令对象
                SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
                //存放读取数值
                SQLiteDataReader reader = cmdQ.ExecuteReader();
                //显示数据的控件
                comboBox.Items.Clear();
                comboBox.Items.Add("");
                comboBox.SelectedText = "";


                //读取每一行数据
                while (reader.Read())
                {
                    //读取并赋值给控件
                    comboBox.Items.Add(reader.GetString(1) + "\n" + "\n" + "(" + reader.GetString(0) + ")");
                }

                //关闭数据库
                conn.Close();
            }catch
            {

            }
        }

    }
}
