using System;
using Cars;
using System.Collections.Generic;

namespace FUNS
{
	public class Functions //я вынес эти функции в другой класс чтобы не загрязнять класс Game
	{
		public static void SortList(List<ICar> CarsLST) //сортировка пузырьком
		{
			for (int i = 1; i < CarsLST.Count; i++)
			{
				for (int j = 0; j < CarsLST.Count - i; j++)
				{
					if (CarsLST[j].coord > CarsLST[j + 1].coord)
					{
						var temp = CarsLST[j];
						CarsLST[j] = CarsLST[j + 1];
						CarsLST[j + 1] = temp;
					}
				}
			}
		}
	}
}

