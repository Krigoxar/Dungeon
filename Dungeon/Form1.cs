using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace Dungeon
{
    public partial class Form1 : Form
    {
        MyRender myRender;
        Thread Render_Thread;
        Thread Fiz_Thread;
        Feeld feeld;
        Player_in_labirint player;
        public Form1()
        {
            InitializeComponent();
        }

        public bool Is_all_good = true;
        void Do_Render()
        {
            myRender.Get_data_for_printing(feeld.Get_feeld());
            myRender.Render();
        }
        void Do_Fiz()
        {
            player.Move(keys);
        }
        void Go_fuck_youre_self()
        {
            myRender.Set_State_Of_Render(-1);
            this.label1.Visible = true;
            this.label1.Location = new Point((this.Width - this.label1.Width) / 2 - 25, this.label1.Location.Y);
        }
        private void do_win()
        {
            myRender.Set_State_Of_Render(-1);


            this.label2.Visible = true;
            this.label2.Location = new Point((this.Width - this.label1.Width) / 2 - 10, this.label1.Location.Y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Render_Thread = new Thread(Do_Render);
            Render_Thread.Start();
            pictureBox1.Image = myRender.Get_Frame();
            if (player.win())
            {
                do_win();
            }
        }

        void All_Is_good()
        {
            this.label1.Visible = false;
            this.label2.Visible = false;
        }
        void control()
        {
            if (keys.IndexOf(Keys.C) != -1 && keys.IndexOf(Keys.U) != -1 && keys.IndexOf(Keys.M) != -1)
            {
                Go_fuck_youre_self();
                myRender.Set_State_Of_Render(-1);
            }
            else
            {
                All_Is_good();
                myRender.Set_State_Of_Render(0);
            }
        }
        ArrayList keys = new ArrayList();
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (keys.IndexOf(e.KeyCode) != -1)
            {
                keys.Remove(e.KeyCode);
            }
            if (keys.IndexOf(e.Modifiers) != -1)
            {
                keys.Remove(e.Modifiers);
            }
            control();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (keys.IndexOf(e.KeyCode) == -1)
            {
                keys.Add(e.KeyCode);
            }
            if (keys.IndexOf(e.Modifiers) != -1)
            {
                keys.Remove(e.Modifiers);
            }
            control();
            Fiz_Thread = new Thread(Do_Fiz);
            Fiz_Thread.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            myRender = new MyRender(this);

            feeld = new Feeld(new Maps(0));

            player = new Player_in_labirint(this, feeld);
            Do_Render();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            this.timer1.Enabled = true;
        }
    }
}
