using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class AddInsdata
    {

        //添加和更新方剂条文数据
        public void AddDataTw(string bookname, string juanname, string zhenname, string fangjiname, string tiaowen, string fjzhuchen, string jianfa)
        {

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            string sqlselect = "select count(tiaowen) from tiaowens where tiaowen='" + tiaowen + "'";
            SQLiteCommand selcmd = new SQLiteCommand(sqlselect, conn);
            int o =Convert.ToInt32(selcmd.ExecuteScalar());
            if (o ==0)
            {


                string sqlins = "INSERT INTO tiaowens(bookname, zhangjie, subname, name, tiaowen, fangzi, fzinfo) VALUES ('" + bookname + "','" + juanname + "','" + zhenname + "','" + fangjiname + "','" + tiaowen + "','" + fjzhuchen + "','" + jianfa + "');";

                //实例化sql指令对象
                SQLiteCommand cmdQ = new SQLiteCommand(sqlins, conn);
                cmdQ.ExecuteNonQuery();
                MessageBox.Show("数据已添加成功");
            }
            else
            {


                string sqlupdate = "update tiaowens set bookname='" + bookname + "',zhangjie='" + juanname + "',subname='" + zhenname + "',name='" + fangjiname + "',fangzi='" + fjzhuchen + "',fzinfo='" + jianfa + "' where tiaowen='" + tiaowen + "'";

                //实例化sql指令对象
                SQLiteCommand cmdQ = new SQLiteCommand(sqlupdate, conn);
                cmdQ.ExecuteNonQuery();
                MessageBox.Show("数据已更新成功");
            }

            //关闭数据库
            conn.Close();
        }


        public static void Deltiaowen(string tiaowen)
        {

            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();

            if (MessageBox.Show("您真的要删除吗？", "此删除不可恢复", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sqlselect = "delete from tiaowens where tiaowen='" + tiaowen + "'";
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

    }
}
