using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace JingFangTools
{
    public partial class Form1 : Form
    {
        int num = 0;
        private List<string> listCombobox;//Combobox的最初Item项

        #region 控件大小变化
        //------------------------------------------------------  控件大小随窗体大小变化
        private float X;
        private float Y;

        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }

        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                //con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }

        }

        void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = this.Height / Y;
            setControls(newx, newy, this);
            // this.Text = this.Width.ToString() + " " + this.Height.ToString();

        }
        //--------------------------------------------------------------------------   控件大小随窗体大小变化结束
        #endregion



        public Form1()
        {
            InitializeComponent();
            //SQLiteHelper.SqLiteHelper sqlconn = new SQLiteHelper.SqLiteHelper("Data Source=DataDb.db;Version=3;");
            cbbleibie.SelectedIndex = 0;
            comboBox2.SelectedIndex = 2;
            comboBox3.SelectedIndex = 0;
            SQLite.bindbookFangzi bd = new SQLite.bindbookFangzi();
            bd.Bangfangzi(comboBox1);
            SQLite.ShanghanluntiaowenZJ.Selectzhujie(listView2);



        }




        private void Form1_Load(object sender, EventArgs e)
        {
            //设置注解文本信息显示
            // richTextBox2.SelectionBullet = true;
            richTextBox2.SelectionIndent = 50;
            richTextBox2.SelectionRightIndent = 3;
            richTextBox2.SelectionHangingIndent = -40;//首行

            //设置药物文本修改信息显示
            // richTextBox2.SelectionBullet = true;
            rtbyaowus.SelectionIndent = 30;
            rtbyaowus.SelectionRightIndent = 3;
            rtbyaowus.SelectionHangingIndent = -25;//首行

            //设置医案录入文本修改信息显示
            // richTextBox2.SelectionBullet = true;
            rtbyianinfo.SelectionIndent = 30;
            rtbyianinfo.SelectionRightIndent = 3;
            rtbyianinfo.SelectionHangingIndent = -25;//首行

            //设置条文阅读信息显示
            // richTextBox2.SelectionBullet = true;
            rtbinfo.SelectionIndent = 5;
            rtbinfo.SelectionRightIndent = 5;
            rtbinfo.SelectionHangingIndent = 40;//首行

            //设置医案阅读信息显示
            // richTextBox2.SelectionBullet = true;
            richTextBox4.SelectionIndent = 50;
            richTextBox4.SelectionRightIndent = 5;
            richTextBox4.SelectionHangingIndent = -40;//首行

            SQLite.CSetLineSpace.SetLineSpace(richTextBox2, 600);//设置行间距注解版
            SQLite.ExequeryYaowu.SelectYaowuList(lvyaowu);//显示药物列表
            SQLite.ExequeryYian.SelectyianList(lvyian);//显示医案数据
            SQLite.ExeyianRead.SelectReadfzname(listView4);

            listCombobox = getComboboxItems(this.comboBox1);//获取Item 


            //listview默认第一项光标选中
            if (this.listView2.Items.Count > 0)
            {
                this.listView2.Focus();
                this.listView2.Items[0].Selected = true;
                //this.lsvSortingHeadList.HideSelection = false;
                //this.lsvSortingHeadList.FocusedItem = this.lsvSortingHeadList.Items[0];
                //this.lsvSortingHeadList.Items[0].Focused = true;
            }


            #region 控件大小变化
            //--------------------------------控件大小随窗体大小变化
            this.Resize += new EventHandler(Form1_Resize);

            X = this.Width;
            Y = this.Height;

            setTag(this);
            Form1_Resize(new object(), new EventArgs());
            //---------------------------------控件大小随窗体大小变化

            #endregion

            //调试控件属性开始



        }


        //条文阅读查询条件方法
        public void ExetiaowenRead()
        {





            switch (cbbleibie.SelectedItem.ToString())
            {
                case "方剂条文":
                    if (txtinfo.Text == "")
                        return;
                    try
                    {

                        SQLite.Fjtiaowen fz = new SQLite.Fjtiaowen();
                        fz.Selectfjtiaowen(rtbinfo, txtinfo.Text);


                       



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    break;

                case "症状条文":
                    if (txtinfo.Text == "")
                        return;
                    try
                    {

                        SQLite.Zztiaowen zz = new SQLite.Zztiaowen();
                        zz.Selectzztiaowen3(rtbinfo, txtinfo.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    break;

                case "药物本草":
                    if (txtinfo.Text == "")
                        return;
                    try
                    {

                        SQLite.Yaowu yaowu = new SQLite.Yaowu();
                        yaowu.SelectYaowu(rtbinfo, txtinfo.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    break;

                case "药物组合":
                    if (txtinfo.Text == "")
                        return;
                    try
                    {
                        SQLite.Yaowuzh yaowu = new SQLite.Yaowuzh();
                        yaowu.SelectYaowuzh(rtbinfo, txtinfo.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    break;

                case "章节条文":
                    if (txtinfo.Text == "")
                        return;
                    try
                    {
                        SQLite.zangjietiaowen zj = new SQLite.zangjietiaowen();
                        zj.Selectzangjietiaowen(rtbinfo, txtinfo.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    break;

                default:

                    break;

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            ExetiaowenRead();


            // Gaoliang();
            //gaoliang2();
            gaoliang3();

        }


        /// <summary>
        /// 高亮显示关键词
        /// </summary>
        public void gaoliang3()
        {

            // string strnames = txtinfo.Text.Trim();
            string[] str = txtinfo.Text.Trim().Split('+');
            int start = 0;
            int end = this.rtbinfo.Text.Length;

            int index = 0;

            // index = rtbinfo.Find(str[0], start, end, RichTextBoxFinds.None);

            try
            {
                while (index != -1)
                {
                    start = index + txtinfo.Text.Length;
                    for (int i = 0; i < str.Length; i++)
                    {

                        index = rtbinfo.Find(str[i], start, end, RichTextBoxFinds.None);
                        rtbinfo.SelectionFont = new Font(rtbinfo.SelectionFont, FontStyle.Underline | FontStyle.Bold);
                        rtbinfo.SelectionColor = Color.Red;
                    }
                }
            }
            catch
            {

            }
        }






        /// <summary>
        /// 查找方子组成和煎药方法
        /// </summary>
        public void FangjiSelect()
        {
            SQLite.SelectFzzhucheng fz = new SQLite.SelectFzzhucheng();

            //提取括号外的字符串
            string majorname = comboBox1.Text.Replace("（", "(").Replace("）", ")");
            majorname = Regex.Replace(majorname.Replace("（", "(").Replace("）", ")"), @"\([^\(]*\)", "");


            //提取括号内字符串
            string str = comboBox1.Text;
            string pattern = @"\(.*?\)";//匹配模式
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(str);
            StringBuilder sb = new StringBuilder();//存放匹配结果

            foreach (Match match in matches)
            {
                string value = match.Value.Trim('(', ')');
                sb.AppendLine(value);
            }
            fz.Selectduiyingfangjitiaowen(sb.ToString().Trim(), rtbfangzi, majorname.Trim());
            fz.Selectfjtiaowen(sb.ToString().Trim(), rtbfangzi, majorname.Trim());

            GetCountZZ(sb.ToString().Trim(), majorname.Trim());


        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            FangjiSelect();

        }


        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FangjiSelect();
                }
            }
            catch
            {

            }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {

            try
            {
                selectCombobox(comboBox1, listCombobox);
            }
            catch
            {

            }


        }

        #region 设置Combobox的方法
        //得到Combobox的数据，返回一个List
        public List<string> getComboboxItems(ComboBox cb)
        {
            //初始化绑定默认关键词
            List<string> listOnit = new List<string>();
            //将数据项添加到listOnit中
            for (int i = 0; i < cb.Items.Count; i++)
            {
                listOnit.Add(cb.Items[i].ToString());
            }
            return listOnit;
        }
        //模糊查询Combobox
        public void selectCombobox(ComboBox cb, List<string> listOnit)
        {
            //输入key之后返回的关键词
            List<string> listNew = new List<string>();
            //清空combobox
            cb.Items.Clear();
            //清空listNew
            listNew.Clear();
            //遍历全部备查数据
            foreach (var item in listOnit)
            {
                if (item.Contains(cb.Text))
                {
                    //符合，插入ListNew
                    listNew.Add(item);
                }
            }
            //combobox添加已经查询到的关键字
            cb.Items.AddRange(listNew.ToArray());
            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            cb.SelectionStart = cb.Text.Length;
            //保持鼠标指针原来状态，有时鼠标指针会被下拉框覆盖，所以要进行一次设置
            Cursor = Cursors.Default;
            //自动弹出下拉框
            cb.DroppedDown = true;
        }


        #endregion

        private void btnadd_Click(object sender, EventArgs e)
        {
            SQLite.AddInsdata add = new SQLite.AddInsdata();

            num++;
            try
            {

                if (txtbookname.Text == "")
                {
                    MessageBox.Show("书名没有填写");
                }
                else if (txtjuanname.Text == "")
                {
                    MessageBox.Show("卷名没有填写");
                }
                else if (txtzhenname.Text == "")
                {
                    MessageBox.Show("病证标题或病名纲题没填写");
                }
                else if (rtbtiaowen1.Text == "")
                {
                    MessageBox.Show("条文没写");
                }
                else
                {
                    add.AddDataTw(txtbookname.Text.Trim(), txtjuanname.Text.Trim(), txtzhenname.Text.Trim(), txtfjname.Text.Trim(), rtbtiaowen1.Text.Trim(), rtbyaowu.Text.Trim(), rtbjianfa.Text.Trim());
                    //MessageBox.Show("数据已添加成功");
                    rtbtiaowen1.Clear();
                    rtbyaowu.Clear();
                    rtbjianfa.Clear();
                    txtfjname.Clear();
                    labnum.Text = "本次添加：" + num.ToString() + "条";
                    btndel.Enabled = true;

                }




            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            SQLite.SeletDataGrid data = new SQLite.SeletDataGrid();
            data.SelectDatagrid2(comboBox2, textBox1.Text.Trim(), listView1);



        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            txtbookname.Text = listView1.SelectedItems[0].Text.ToString();
            txtjuanname.Text = listView1.SelectedItems[0].SubItems[1].Text.ToString();
            txtzhenname.Text = listView1.SelectedItems[0].SubItems[2].Text.ToString();
            txtfjname.Text = listView1.SelectedItems[0].SubItems[3].Text.ToString();
            rtbtiaowen1.Text = listView1.SelectedItems[0].SubItems[4].Text.ToString();
            rtbyaowu.Text = listView1.SelectedItems[0].SubItems[5].Text.ToString();
            rtbjianfa.Text = listView1.SelectedItems[0].SubItems[6].Text.ToString();
            // rtbtiaowen1.ReadOnly = true;
            btndel.Enabled = true;



            //MessageBox.Show(str);
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            SQLite.AddInsdata.Deltiaowen(rtbtiaowen1.Text);
            rtbyaowu.Clear();
            rtbtiaowen1.Clear();
            rtbjianfa.Clear();
            txtzhenname.Clear();
            txtbookname.Clear();
            txtfjname.Clear();
            txtjuanname.Clear();
            btndel.Enabled = false;


        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            SelectListView2();


        }

        private void rbhxs_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "huxishubook", listView2.SelectedItems[0].Text.ToString());
        }

        private void rbtangben_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "tangbenqiuzhenbook", listView2.SelectedItems[0].Text.ToString());
        }

        private void rbtjxr_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "taijibook", listView2.SelectedItems[0].Text.ToString());
        }



        //根据RB注家选中项显示各家的注解论
        public void SelectListView2()
        {
            try
            {
                richTextBox3.Text = listView2.SelectedItems[0].Text.ToString();
                string str = "";
                if (rbhxs.Checked == true)
                {
                    str = "huxishubook";

                }
                else if (rbtangben.Checked == true)
                {
                    str = "tangbenqiuzhenbook";

                }
                else if (rbtjxr.Checked == true)
                {
                    str = "taijibook";

                }
                else if (rbcustom.Checked == true)
                {
                    str = "custombook";
                }
                else if (rbdazuo.Checked == true)
                {
                    str = "dazuobook";
                }
                else if (rbfengsl.Checked == true)
                {
                    str = "fengslbook";
                }
                else if (radioButton1.Checked == true)
                {
                    str = "book001";
                }
                else if (radioButton2.Checked == true)
                {
                    str = "book002";
                }
                else if (radioButton3.Checked == true)
                {
                    str = "book003";
                }
                else if (radioButton4.Checked == true)
                {
                    str = "book004";
                }
                else if (radioButton5.Checked == true)
                {
                    str = "book005";
                }
                else if (radioButton6.Checked == true)
                {
                    str = "book006";
                }
                else if (radioButton7.Checked == true)
                {
                    str = "book007";
                }
                else if (radioButton8.Checked == true)
                {
                    str = "book008";
                }
                else if (radioButton9.Checked == true)
                {
                    str = "book009";
                }
                else if (radioButton10.Checked == true)
                {
                    str = "book010";
                }
                SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, str, listView2.SelectedItems[0].Text.ToString());
            }
            catch
            {

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text == "打开编辑模式")
            {
                btnupdateshl.Visible = true;
                richTextBox2.ReadOnly = false;
                linkLabel1.Text = "关闭编辑模式";
            }
            else if (linkLabel1.Text == "关闭编辑模式")
            {
                btnupdateshl.Visible = false;
                richTextBox2.ReadOnly = true;
                linkLabel1.Text = "打开编辑模式";
            }
        }

        private void btnupdateshl_Click(object sender, EventArgs e)
        {
            string str = "";

            if (rbhxs.Checked == true)
            {
                str = "huxishubook";

            }
            else if (rbtangben.Checked == true)
            {
                str = "tangbenqiuzhenbook";

            }
            else if (rbtjxr.Checked == true)
            {
                str = "taijibook";

            }
            else if (rbcustom.Checked == true)
            {
                str = "custombook";
            }
            else if (rbdazuo.Checked == true)
            {
                str = "dazuobook";
            }
            else if (rbfengsl.Checked == true)
            {
                str = "fengslbook";
            }
            else if (radioButton1.Checked == true)
            {
                str = "book001";
            }
            else if (radioButton2.Checked == true)
            {
                str = "book002";
            }
            else if (radioButton3.Checked == true)
            {
                str = "book003";
            }
            else if (radioButton4.Checked == true)
            {
                str = "book004";
            }
            else if (radioButton5.Checked == true)
            {
                str = "book005";
            }
            else if (radioButton6.Checked == true)
            {
                str = "book006";
            }
            else if (radioButton7.Checked == true)
            {
                str = "book007";
            }
            else if (radioButton8.Checked == true)
            {
                str = "book008";
            }
            else if (radioButton9.Checked == true)
            {
                str = "book009";
            }
            else if (radioButton10.Checked == true)
            {
                str = "book010";
            }
            SQLite.ShanghanluntiaowenZJ.UpdateShl(richTextBox3.Text, str, richTextBox2.Text);
        }

        private void rbcustom_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "custombook", listView2.SelectedItems[0].Text.ToString());
        }

        private void btnyaowusel_Click(object sender, EventArgs e)
        {
            SQLite.ExequeryYaowu.ExequeryYaowu1(txtyaowu.Text.Trim(), rtbyaowus, txtsubname1, txtsubname2, txtsubname3, txtsubname4, txtsubname5, txtsubname6, cbpingji, cbwuzhong);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (txtyaowu.Text != "")
            {
                SQLite.ExequeryYaowu.AddDataYW(txtyaowu.Text.Trim(), cbpingji.Text, cbwuzhong.Text, txtsubname1.Text, txtsubname2.Text, txtsubname3.Text, txtsubname4.Text, txtsubname5.Text, txtsubname6.Text, rtbyaowus.Text);

            }
            else
            {
                MessageBox.Show("中药名称没有填写");
            }
            SQLite.ExequeryYaowu.SelectYaowuList(lvyaowu);//显示药物列表
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLite.ExequeryYaowu.Delyaowu(txtyaowu.Text.Trim());
        }

        private void lvyaowu_DoubleClick(object sender, EventArgs e)
        {
            txtyaowu.Text = lvyaowu.SelectedItems[0].Text.ToString();
            cbpingji.Text = lvyaowu.SelectedItems[0].SubItems[1].Text.ToString();
            cbwuzhong.Text = lvyaowu.SelectedItems[0].SubItems[2].Text.ToString();
            txtsubname1.Text = lvyaowu.SelectedItems[0].SubItems[3].Text.ToString();
            txtsubname2.Text = lvyaowu.SelectedItems[0].SubItems[4].Text.ToString();
            txtsubname3.Text = lvyaowu.SelectedItems[0].SubItems[5].Text.ToString();
            txtsubname4.Text = lvyaowu.SelectedItems[0].SubItems[6].Text.ToString();
            txtsubname5.Text = lvyaowu.SelectedItems[0].SubItems[7].Text.ToString();
            txtsubname6.Text = lvyaowu.SelectedItems[0].SubItems[8].Text.ToString();
            rtbyaowus.Text = lvyaowu.SelectedItems[0].SubItems[9].Text.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtyianfj.Text != "" || txtyianbiaoqian.Text != "")
            {
                SQLite.ExequeryYian.Addyian(labid.Text.Trim(), txtyianfj.Text.Trim(), txtyianhefang.Text.Trim(), txtyianbinming.Text.Trim(), txtyianauthor.Text.Trim(), txtyianbiaoqian.Text.Trim(), rtbyianinfo.Text.Trim());
                SQLite.ExequeryYian.SelectyianList(lvyian);//显示医案数据
            }
            else
            {
                MessageBox.Show("输入错误");

            }
        }

        private void lvyian_DoubleClick(object sender, EventArgs e)
        {
            labid.Text = lvyian.SelectedItems[0].Text.ToString();
            txtyianfj.Text = lvyian.SelectedItems[0].SubItems[1].Text.ToString();
            txtyianhefang.Text = lvyian.SelectedItems[0].SubItems[2].Text.ToString();
            txtyianbinming.Text = lvyian.SelectedItems[0].SubItems[3].Text.ToString();
            txtyianauthor.Text = lvyian.SelectedItems[0].SubItems[4].Text.ToString();
            txtyianbiaoqian.Text = lvyian.SelectedItems[0].SubItems[5].Text.ToString();
            rtbyianinfo.Text = lvyian.SelectedItems[0].SubItems[6].Text.ToString();
            button6.Enabled = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SQLite.ExequeryYian.Delyian(labid.Text.Trim());
            button6.Enabled = false;
            SQLite.ExequeryYian.SelectyianList(lvyian);//显示医案数据
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLite.ExequeryYian.SelectYianData(comboBox3, textBox2.Text.Trim(), lvyian);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SQLite.ExequeryYian.SelectYianData(comboBox3, textBox2.Text.Trim(), lvyian);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SQLite.SeletDataGrid data = new SQLite.SeletDataGrid();
                data.SelectDatagrid2(comboBox2, textBox1.Text.Trim(), listView1);
            }


        }

        private void txtyaowu_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.Enter)
            {
                SQLite.ExequeryYaowu.ExequeryYaowu1(txtyaowu.Text.Trim(), rtbyaowus, txtsubname1, txtsubname2, txtsubname3, txtsubname4, txtsubname5, txtsubname6, cbpingji, cbwuzhong);
            }
        }

        private void txtinfo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

           

            if (e.KeyCode == Keys.Enter)
            {
                ExetiaowenRead();

                gaoliang3();
            }
            }
            catch
            {

            }

        }

        private void listView4_Click(object sender, EventArgs e)
        {
            SQLite.ExeyianRead.SubSelectReadzz(listView3, listView4.SelectedItems[0].Text.ToString());
        }

        private void listView3_Click(object sender, EventArgs e)
        {
            SQLite.ExeyianRead.SubSelectReadInfo(richTextBox4, listView3.SelectedItems[0].Text.ToString());
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            SQLite.ExeyianRead.SelectFz(listView4, textBox3.Text.Trim());
        }

        private void rbdazuo_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "dazuobook", listView2.SelectedItems[0].Text.ToString());
        }

        private void rbfengsl_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "fengslbook", listView2.SelectedItems[0].Text.ToString());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "book001", listView2.SelectedItems[0].Text.ToString());
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "book002", listView2.SelectedItems[0].Text.ToString());
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "book003", listView2.SelectedItems[0].Text.ToString());
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "book004", listView2.SelectedItems[0].Text.ToString());
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "book005", listView2.SelectedItems[0].Text.ToString());
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "book006", listView2.SelectedItems[0].Text.ToString());
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "book007", listView2.SelectedItems[0].Text.ToString());
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "book008", listView2.SelectedItems[0].Text.ToString());
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "book009", listView2.SelectedItems[0].Text.ToString());
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            SQLite.ShanghanluntiaowenZJ.SelectListview(richTextBox2, "book010", listView2.SelectedItems[0].Text.ToString());
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "方剂名称,症状,病名,医案作者")
            {
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            if (textBox3.Text == "")
            {
                textBox3.Text = "方剂名称,症状,病名,医案作者";
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        public void GetCountZZ(string bookname, string fangjiname)
        {
            string str = SQLite.ZzChart.SeltwData(bookname, fangjiname);//获取方剂条文信息
            ArrayList str_arr = SQLite.ZzChart.SelZZData(fangjiname, bookname);
            int count = 0;
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

            //清除默认的series
            chart1.Series.Clear();
            //new 一个叫做【Strength】的系列
            Series Strength = new Series(fangjiname + "-症状比例");
            //设置chart的类型，这里为柱状图
            Strength.ChartType = SeriesChartType.Pie;
            //chart1.ChartAreas[0].AxisY.IsLabelAutoFit = true;//设置是否自动调整轴标签
            foreach (var item in str_arr)
            {

                //  string strSql = "select COUNT(1) from tiaowens where tiaowen like '%" + item+ "%' and bookname='" + bookname+"' and name='"+fangjiname+"'";

                string strSql = "select sub2 from zhengzhuang where sub1='" + item + "' and bookname='" + bookname + "' and name='" + fangjiname + "'";

                count = SQLite.ZzChart.getCount(strSql);

                //string str1=    SQLite.ZzChart.SelZZData2(item.ToString());

                //给系列上的点进行赋值，分别对应横坐标和纵坐标的值
                if (count != 0)
                {
                    Strength.Points.AddXY(item, count);
                }
            }

            //把series添加到chart上
            chart1.Series.Add(Strength);
            //chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧 
            chart1.Series[0].CustomProperties = "PieLabelStyle=side, MinimumRelative" + "PieSize=60";    //设置饼图的参数 //PieDrawingStyle=SoftEdge,DoughnutRadius=70,  CollectedLabel=Other,

            chart1.Series[0].Label = "#VALX";
            chart1.Series[0].LegendText = "#VALX:#PERCENT{P}";
            chart1.Series[0].LegendToolTip = "#SERIESNAME";
            chart1.Series[0].Sort(PointSortOrder.Descending);//排序

            if (bookname == "伤寒论" || bookname == "金匮要略")
            {
                chart1.Titles[0].Text = fangjiname + "症状饼图";
            }
            else
            {

            }




        }

        private void chart1_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
