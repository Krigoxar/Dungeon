using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon
{
	class Feeld
	{

		public char[,] _feeld;
		public string[] feeld = new string[41];
		public int[] player_pos = { 9, 7 };
		public int[] win_pos = new int[2];
		public Feeld(Maps map_from_maps)
		{
			for (int i = 0; i < 41; i++)
			{
				feeld[i] = map_from_maps.import_map(i);
				if (feeld[i].IndexOf('W') != -1)
				{
					win_pos[0] = feeld[i].IndexOf('W');
					win_pos[1] = i;
				}
			}
		}
		public int Get_win_pos(int i)
		{
			return win_pos[i];
		}
		public void Set(int x, int y, string Char)
		{
			feeld[y] = feeld[y].Remove(x, 1);
			feeld[y] = feeld[y].Insert(x, Char);
		}
		public char Get(int x, int y)
		{
			return feeld[y][x];
		}
		public string[] Get_feeld()
		{
			return feeld;
		}
	}
	class Feeld_with_cam : Feeld
	{
		string[] view;

		void get_view()
		{
			for (int i = 0; i < 41; i++)
			{
				if (feeld[i].IndexOf('P') != -1)
				{
					if (feeld[i].IndexOf('P') < 34 && feeld[i].IndexOf('P') > 6)
					{
						player_pos[0] = feeld[i].IndexOf('P');
					}
					if (i > 6 && i < 34)
					{
						player_pos[1] = i;
					}




				}
			}
			for (int i = -7; i < 8; i++)
			{
				view[i + 7] = feeld[player_pos[1] + i].Substring(player_pos[0] - 7, 15);
			}
		}
		public Feeld_with_cam(Maps map_from_maps)
			: base(map_from_maps)
		{/*
		  for (int i = 0; i < 41; i++)
			{

				feeld[i] = map_from_maps.import_map(i);
				if (feeld[i].IndexOf('W') != -1)
				{
					win_pos[0] = feeld[i].IndexOf('W');
					win_pos[1] = i;
				}
			}
		  */

		}
		void print()
		{
			/*
			get_view();
			foreach (string String in view)
			{
				for (int i = 0; i < 15; i++)
				{
					if (String.Compare(i, 1, "#") == 0)
					{
						cout << "#";
					}
					else if (String.compare(i, 1, "-") == 0)
					{
						cout << "---";
					}
					else if (String.compare(i, 1, " ") == 0 && i % 2 == 0)
					{
						cout << " ";
					}
					else if (String.compare(i, 1, " ") == 0 && i % 2 == 1)
					{
						cout << "   ";
					}
					else if (String.compare(i, 1, "|") == 0)
					{
						cout << "|";
					}
					else
					{
						cout << " " << String.substr(i, 1) << " ";
					}
				}
				cout << endl;
			}*/

		}
	}
	class Feeld_with_tuman : Feeld_with_cam
	{
		public string[] feeld_of_tuman;
		string feeld_of_tuman1;
		void get_feeld_of_tuman()
		{
			for (int i = 0; i < 41; i++)
			{
				if (feeld[i].IndexOf('P') != -1)
				{
					if (feeld[i].IndexOf('P') < 34 && feeld[i].IndexOf('P') > 6)
					{
						player_pos[0] = feeld[i].IndexOf('P');
					}
					if (i > 6 && i < 34)
					{
						player_pos[1] = i;
					}
				}
			}

			for (int k = -7; k < 8; k++)
			{
				for (int j = -7; j < 8; j++)
				{
					feeld_of_tuman[player_pos[1] + k].Remove(player_pos[0] + j);
					feeld_of_tuman[player_pos[1] + k].Insert(player_pos[0] + j, "1");
				}
			}
		}
		public Feeld_with_tuman(Maps map_from_maps)
			: base(map_from_maps)
		{
			/*
			 for (int i = 0; i < 41; i++)
			{

				feeld[i] = map_from_maps.import_map(i);
				if (feeld[i].IndexOf('W') != -1)
				{
					win_pos[0] = feeld[i].IndexOf('W');
					win_pos[1] = i;

				}
			}
			 */
			for (int k = 0; k < 41; k++)
			{

				feeld_of_tuman[k] = "000000000000000000000000000000000000000000";

			}
		}

		void print()
		{
			/*
			  get_feeld_of_tuman();
	int j = -1;
	for (string String : feeld)
		{
	j++;
	for (int i = 0; i < 41; i++)
	{
		if (feeld_of_tuman[j].compare(i, 1, "1") == 0)
		{
			if (String.compare(i, 1, "#") == 0)
			{
				cout << "#";
			}
			else if (String.compare(i, 1, "-") == 0)
			{
				cout << "---";
			}
			else if (String.compare(i, 1, " ") == 0 && i % 2 == 0)
			{
				cout << " ";
			}
			else if (String.compare(i, 1, " ") == 0 && i % 2 == 1)
			{
				cout << "   ";
			}
			else if (String.compare(i, 1, "|") == 0)
			{
				cout << "|";
			}
			else
			{
				cout << " " << String.substr(i, 1) << " ";
			}
		}
		else if (String.compare(i, 1, "#") == 0)
		{
			cout << " ";
		}
		else if (String.compare(i, 1, "-") == 0)
		{
			cout << "   ";
		}
		else if (String.compare(i, 1, " ") == 0 && i % 2 == 0)
		{
			cout << " ";
		}
		else if (String.compare(i, 1, " ") == 0 && i % 2 == 1)
		{
			cout << "   ";
		}
		else if (String.compare(i, 1, "|") == 0)
		{
			cout << " ";
		}
		else
		{
			cout << "   ";
		}

	}
	cout << endl;
}
			*/

		}
	}
}
