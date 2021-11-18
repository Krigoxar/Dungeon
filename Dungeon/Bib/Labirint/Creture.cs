using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace Dungeon
{
	class Creature
	{

		public int hp = 0;
		public int[] curent_position = { 9, 0 };//добавить функционал для точек спауна
		public int[] prew_position = { 9, 0 };
		public bool is_chenged = false;
	}
	class Player : Creature
	{
		Form1 form;
		public Feeld feeld;
		public Player(Form1 form, Feeld feeld)
		{
			this.feeld = feeld;
			this.form = form;
		}
		char[] sign_under_player = { '_', '_' };
		public void Move(ArrayList list)
		{
			if(list.Count != 0)
			{
				prew_position[0] = curent_position[0]; prew_position[1] = curent_position[1];
				int is_chenged = 0;
				if ((Keys)list[0] == Keys.W && curent_position[1] != 0 && feeld.Get(curent_position[0] * 2 + 1, curent_position[1] * 2) != '-')
				{
					curent_position[1] -= 1;
					is_chenged = 1;
				}
				if ((Keys)list[0] == Keys.S && curent_position[1] != 19 && feeld.Get(curent_position[0] * 2 + 1, curent_position[1] * 2 + 2) != '-')
				{
					curent_position[1] += 1;
					is_chenged = 1;
				}
				if ((Keys)list[0] == Keys.A && curent_position[0] != 0 && feeld.Get(curent_position[0] * 2, curent_position[1] * 2 + 1) != '|')
				{
					curent_position[0] -= 1;
					is_chenged = 1;
				}
				if ((Keys)list[0] == Keys.D && curent_position[0] != 19 && feeld.Get(curent_position[0] * 2 + 2, curent_position[1] * 2 + 1) != '|')
				{
					curent_position[0] += 1;
					is_chenged = 1;
				}
				sign_under_player[0] = feeld.Get(curent_position[0] * 2 + 1, curent_position[1] * 2 + 1);
				if (prew_position[0] != curent_position[0] || prew_position[1] != curent_position[1])
				{

					feeld.Set(curent_position[0] * 2 + 1, curent_position[1] * 2 + 1, "P");
				}
				if (is_chenged == 1)
				{
					feeld.Set(prew_position[0] * 2 + 1, prew_position[1] * 2 + 1, sign_under_player[1].ToString());
					sign_under_player[1] = sign_under_player[0];
				}
			}
		}
	}
	class Player_in_labirint : Player
	{
		int[] win_pos = new int[2];
		public Player_in_labirint(Form1 form, Feeld feeld)
				: base(form, feeld)
		{
			win_pos[1] = feeld.Get_win_pos(1) / 2;
			win_pos[0] = feeld.Get_win_pos(0) / 2;
		}
		public bool win()
		{
			if (curent_position[0] == win_pos[0] && curent_position[1] == win_pos[1])
			{
				return true;
			}
			return false;
		}
	}
}
