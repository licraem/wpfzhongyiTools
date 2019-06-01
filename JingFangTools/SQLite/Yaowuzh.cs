using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class Yaowuzh
    {
        public void SelectYaowuzh(RichTextBox RichtextBox, string name1)
        {
           // Asbieming asname = new Asbieming();
            //string name1 = asname.AsNameYaowu(name);

            //数据库路径
           // string dbPath = "Data Source =" + Environment.CurrentDirectory + "/DataDb.db";
            //创建数据库实例，指定文件位置 
            SQLiteConnection conn = new SQLiteConnection(SqliteConn.dbPath);
            //打开数据库，若文件不存在会自动创建 
            conn.Open();
            //查询sql语句
            // string sql = "select * from Yaowu";


            string sql = "";
            string[] names = name1.Trim().Split('+');
            int num = names.Length;
            if (num > 6)
                return;

            switch (num)
            {
                case 1:
                    sql = "SELECT bookname,subname,tiaowen from tiaowens WHERE fangzi like '%" + names[0] + "%'";
                    break;
                case 2:
                    sql = "SELECT bookname,subname,tiaowen from tiaowens WHERE fangzi like '%" + names[0] + "%' AND fangzi like '%" + names[1] + "%'";
                    break;
                case 3:
                    sql = "SELECT bookname,subname,tiaowen from tiaowens WHERE fangzi like '%" + names[0] + "%' AND fangzi like '%" + names[1] + "%' AND fangzi like '%" + names[2] + "%'";
                    break;
                case 4:
                    sql = "SELECT bookname,subname,tiaowen from tiaowens WHERE fangzi like '%" + names[0] + "%' AND fangzi like '%" + names[1] + "%' AND fangzi like '%" + names[2] + "%' AND fangzi like '%" + names[3] + "%'";
                    break;
                case 5:
                    sql = "SELECT bookname,subname,tiaowen from tiaowens WHERE fangzi like '%" + names[0] + "%' AND fangzi like '%" + names[1] + "%' AND fangzi like '%" + names[2] + "%' AND fangzi like '%" + names[3] + "%' AND fangzi like '%" + names[4] + "%'";
                    break;
                case 6:
                    sql = "SELECT bookname,subname,tiaowen from tiaowens WHERE fangzi like '%" + names[0] + "%' AND fangzi like '%" + names[1] + "%' AND fangzi like '%" + names[2] + "%' AND fangzi like '%" + names[3] + "%' AND fangzi like '%" + names[4] + "%' AND fangzi like '%" + names[5] + "%'";
                    break;
            }

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
                RichtextBox.Text += "【" + reader.GetString(0) + "·" + reader.GetString(1) + "】" + reader.GetString(2) + "\n\n";
            }
            //关闭数据库
            conn.Close();
        }
    }
}
