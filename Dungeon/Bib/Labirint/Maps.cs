using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon
{
	class Maps
	{
		bool end = true;
		int[] start_pos = { 9, 0 };
		int map_size = 41;
		int[] curent_position_of_gen = { 9, 0 };
		int[] prew_position_of_gen = { 9, 0 };
		int[,] list_of_sticks = new int[2, 10000];
		int sticknumer = -1;
		string[] bufer = new string[42];
		bool is_chenged;
		string[] sign_under_gen = { "_", "_" };
		string[,] map = {
	{
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	},
	{
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	"                                         ",
	}
	};
		/*
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
	"                                         ",
	"# # # # # # # # # # # # # # # # # # # # #",
		*/
		char Get(int x, int y)
		{
			return map[0, y].ToCharArray()[x];
		}
		void Set(int x, int y, string Char)
		{
			string a = map[0, y].Remove(x, 1);
			map[0, y] = a;
			map[0, y] = map[0, y].Insert(x, Char);
		}
		bool zastral()
		{
			if (curent_position_of_gen[1] != 0 && this.Get(curent_position_of_gen[0] * 2 + 1, (curent_position_of_gen[1] - 1) * 2 + 1) != '_' && this.Get(curent_position_of_gen[0] * 2 + 1, (curent_position_of_gen[1] - 1) * 2 + 1) != 'W')
			{
				return false;
			}
			if (curent_position_of_gen[1] != 19 && this.Get(curent_position_of_gen[0] * 2 + 1, (curent_position_of_gen[1] + 1) * 2 + 1) != '_' && this.Get(curent_position_of_gen[0] * 2 + 1, (curent_position_of_gen[1] + 1) * 2 + 1) != 'W')
			{
				return false;
			}
			if (curent_position_of_gen[0] != 0 && this.Get((curent_position_of_gen[0] - 1) * 2 + 1, curent_position_of_gen[1] * 2 + 1) != '_' && this.Get((curent_position_of_gen[0] - 1) * 2 + 1, curent_position_of_gen[1] * 2 + 1) != 'W')
			{
				return false;
			}
			if (curent_position_of_gen[0] != 19 && this.Get((curent_position_of_gen[0] + 1) * 2 + 1, curent_position_of_gen[1] * 2 + 1) != '_' && this.Get((curent_position_of_gen[0] + 1) * 2 + 1, curent_position_of_gen[1] * 2 + 1) != 'W')
			{
				return false;
			}
			return true;

		}
		void map_set_start()
		{
			for (int i = 0; i < map_size; i++)
			{
				map[0, i] = map[1, i];
			}
		}
		void do_qbe(char Char)
		{

			this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2 + 1, "_");
			switch (Char)
			{
				case 'u':
					{
						this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2 + 2, "_");
						this.Set(curent_position_of_gen[0] * 2 + 2, curent_position_of_gen[1] * 2 + 1, "|");
						this.Set(curent_position_of_gen[0] * 2, curent_position_of_gen[1] * 2 + 1, "|");
						this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2, "-");
						this.Set(curent_position_of_gen[0] * 2, curent_position_of_gen[1] * 2, "#");
						this.Set(curent_position_of_gen[0] * 2 + 2, curent_position_of_gen[1] * 2, "#");
						break;
					}
				case 'd':
					{
						this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2 + 2, "-");
						this.Set(curent_position_of_gen[0] * 2 + 2, curent_position_of_gen[1] * 2 + 1, "|");
						this.Set(curent_position_of_gen[0] * 2, curent_position_of_gen[1] * 2 + 1, "|");
						this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2, "_");
						this.Set(curent_position_of_gen[0] * 2, curent_position_of_gen[1] * 2 + 2, "#");
						this.Set(curent_position_of_gen[0] * 2 + 2, curent_position_of_gen[1] * 2 + 2, "#");
						break;
					}
				case 'l':
					{
						this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2 + 2, "-");
						this.Set(curent_position_of_gen[0] * 2 + 2, curent_position_of_gen[1] * 2 + 1, "_");
						this.Set(curent_position_of_gen[0] * 2, curent_position_of_gen[1] * 2 + 1, "|");
						this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2, "-");
						this.Set(curent_position_of_gen[0] * 2, curent_position_of_gen[1] * 2 + 2, "#");
						this.Set(curent_position_of_gen[0] * 2, curent_position_of_gen[1] * 2, "#");
						break;
					}
				case 'r':
					{
						this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2 + 2, "-");
						this.Set(curent_position_of_gen[0] * 2 + 2, curent_position_of_gen[1] * 2 + 1, "|");
						this.Set(curent_position_of_gen[0] * 2, curent_position_of_gen[1] * 2 + 1, "_");
						this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2, "-");
						this.Set(curent_position_of_gen[0] * 2 + 2, curent_position_of_gen[1] * 2 + 2, "#");
						this.Set(curent_position_of_gen[0] * 2 + 2, curent_position_of_gen[1] * 2, "#");
						break;
					}
				default:
					{

						this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2 + 2, "-");
						this.Set(curent_position_of_gen[0] * 2 + 2, curent_position_of_gen[1] * 2 + 1, "|");
						this.Set(curent_position_of_gen[0] * 2, curent_position_of_gen[1] * 2 + 1, "|");
						this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2, "-");
						this.Set(curent_position_of_gen[0] * 2, curent_position_of_gen[1] * 2 + 2, "#");
						this.Set(curent_position_of_gen[0] * 2 + 2, curent_position_of_gen[1] * 2 + 2, "#");
						this.Set(curent_position_of_gen[0] * 2, curent_position_of_gen[1] * 2, "#");
						this.Set(curent_position_of_gen[0] * 2 + 2, curent_position_of_gen[1] * 2, "#");


						break;
					}
			}
		}
		void rand_turn()
		{

			int randnum1 = rnd.Next() % 4 + 1;
			// бля сдесь может быть баг
			switch (randnum1)
			{
				case 1:
					{
						if (curent_position_of_gen[1] != 0 && this.Get(curent_position_of_gen[0] * 2 + 1, (curent_position_of_gen[1] - 1) * 2 + 1) == ' ')
						{

							curent_position_of_gen[1] -= 1;
							is_chenged = true;

							do_qbe('u');
						}
						break;
					}
				case 2:
					{
						if (curent_position_of_gen[1] != 19 && this.Get(curent_position_of_gen[0] * 2 + 1, (curent_position_of_gen[1] + 1) * 2 + 1) == ' ')
						{

							curent_position_of_gen[1] += 1;
							is_chenged = true;

							do_qbe('d');
						}
						break;
					}
				case 3:
					{
						if (curent_position_of_gen[0] != 0 && this.Get((curent_position_of_gen[0] - 1) * 2 + 1, curent_position_of_gen[1] * 2 + 1) == ' ')
						{

							curent_position_of_gen[0] -= 1;
							is_chenged = true;

							do_qbe('l');
						}
						break;
					}
				case 4:
					{
						if (curent_position_of_gen[0] != 19 && this.Get((curent_position_of_gen[0] + 1) * 2 + 1, curent_position_of_gen[1] * 2 + 1) == ' ')
						{

							curent_position_of_gen[0] += 1;
							is_chenged = true;

							do_qbe('r');
						}
						break;
					}
				default:
					break;
			}
		}
		int stranno = 0;
		void gen_main_tunel()
		{
			do_qbe('v');
			while (curent_position_of_gen[1] != 19)
			{
				rand_turn();
				int randnum2 = rnd.Next() % 5 + 1;
				if (randnum2 == 1 && curent_position_of_gen[1] != 19)
				{
					sticknumer++;
					list_of_sticks[0, sticknumer] = curent_position_of_gen[0];
					list_of_sticks[1, sticknumer] = curent_position_of_gen[1];
				}
				if (zastral())
				{
					for (int i = sticknumer; i > -1; i--)
					{
						list_of_sticks[0, i] = 0;
						list_of_sticks[1, i] = 0;
					}
					sticknumer = -1;
					curent_position_of_gen[0] = start_pos[0];
					curent_position_of_gen[1] = start_pos[1];
					map_set_start();
					do_qbe('v');
				}
			}
		}
		void gen_stick(int stick_num, int u)
		{
			curent_position_of_gen[0] = list_of_sticks[0, stick_num];
			curent_position_of_gen[1] = list_of_sticks[1, stick_num];
			for (int i = rnd.Next() % u + 1; 0 < i; i--)
			{
				if (!zastral())
				{
					end = true;
					rand_turn();
					int randnum2 = rnd.Next() % 5 + 1;
					if (randnum2 == 1)
					{
						sticknumer++;
						list_of_sticks[0, sticknumer] = curent_position_of_gen[0];
						list_of_sticks[1, sticknumer] = curent_position_of_gen[1];
					}
				}
			}
		}
		/*void rand_turn_test()
		{
			print_test();
			char key = ' ';
			key = _getch();
			int randnum1 = rand() % 4 + 1;
			switch (randnum1)
			{
				case 1:
					{
						if (curent_position_of_gen[1] != 0 && this.Get(curent_position_of_gen[0] * 2 + 1, (curent_position_of_gen[1] - 1) * 2 + 1) != '_')
						{

							curent_position_of_gen[1] -= 1;
							is_chenged = 1;
							do_qbe('u');
						}
						break;
					}
				case 2:
					{
						if (curent_position_of_gen[1] != 19 && this->Get(curent_position_of_gen[0] * 2 + 1, (curent_position_of_gen[1] + 1) * 2 + 1) != '_')
						{

							curent_position_of_gen[1] += 1;
							is_chenged = 1;
							do_qbe('d');
						}
						break;
					}
				case 3:
					{
						if (curent_position_of_gen[0] != 0 && this->Get((curent_position_of_gen[0] - 1) * 2 + 1, curent_position_of_gen[1] * 2 + 1) != '_')
						{

							curent_position_of_gen[0] -= 1;
							is_chenged = 1;
							do_qbe('l');
						}
						break;
					}
				case 4:
					{
						if (curent_position_of_gen[0] != 19 && this->Get((curent_position_of_gen[0] + 1) * 2 + 1, curent_position_of_gen[1] * 2 + 1) != '_')
						{

							curent_position_of_gen[0] += 1;
							is_chenged = 1;
							do_qbe('r');
						}
						break;
					}
				default:
					break;
			}
		}
		void print_test()
{
	system("cls");
	char key = ' ';
	key = _getch();
	for (string String : map[0])
		{
	for (int i = 0; i < 41; i++)
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
	cout << endl;
}
	}*/
		Random rnd = new Random();
		public Maps(int i)
		{
			gen_map();
			for (int j = 0; 41 > j; j++)
			{

				bufer[j] = map[i, j];
			}
		}

		int count = 0;
		void gen_map()
		{
			rnd.Next();
			gen_main_tunel();
			int[] sticknumnum = { 0, 0 };
			this.Set(curent_position_of_gen[0] * 2 + 1, curent_position_of_gen[1] * 2 + 1, "W");


			while (end)
			{
				sticknumnum[0] = sticknumer;
				end = false;
				for (int i = sticknumer; i >= sticknumnum[1]; i--)
				{
					count++;
					prew_position_of_gen = (int[])curent_position_of_gen.Clone();
					gen_stick(i, 45);
					if (prew_position_of_gen[0] == curent_position_of_gen[0] && prew_position_of_gen[1] == curent_position_of_gen[1])
					{
						stranno++;
					}
				}
				//cout << "вот столько кординат палок:" << sticknumer << endl;
				sticknumnum[1] = sticknumnum[0];
			}



			this.Set(start_pos[0] * 2 + 1, start_pos[1] * 2 + 1, "P");

		}
		public string import_map(int i)
		{
			return bufer[i];
		}

	}
}
