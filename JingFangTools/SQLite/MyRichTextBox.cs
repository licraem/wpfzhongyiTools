using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JingFangTools.SQLite
{
    class MyRichTextBox: RichTextBox
    {
        System.Timers.Timer timer;
        int cout = 0;
        Point pt = new Point();
        ToolTip tooltip = new ToolTip();
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 500;
            timer.Enabled = false;

        }
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            timer.Enabled = true;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            timer.Enabled = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!timer.Enabled)
                timer.Enabled = true;
            cout = 0;
            pt.X = e.Location.X;
            pt.Y = e.Location.Y;
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (cout >= 1000)
            {
                timer.Enabled = false;
                func();
            }
            else
                cout += 500;
        }
        void func()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                int index = this.GetCharIndexFromPosition(pt);
                string ret = "";
                for (int i = index; i < this.Text.Length; i++)
                {
                    char c = this.Text[i];
                    if ((c > 64 && c < 91) || (c > 96 && c < 123) || (c > 47 && c < 58))
                    {
                        ret += c.ToString();
                    }
                    else
                        break;
                }
                for (int i = index; i - 1 > 0; i--)
                {
                    char c = this.Text[i - 1];
                    if ((c > 64 && c < 91) || (c > 96 && c < 123) || (c > 47 && c < 58))
                    {
                        ret = c.ToString() + ret;
                    }
                    else
                        break;
                }
                if (ret.Length > 0)
                {
                    //textBox1.Text = ret;
                    tooltip.Show("当前停留的文本内容是:" + ret, this, pt, 5000);
                }
            }));
        }


    }
}
