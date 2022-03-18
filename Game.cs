using System;
using Cars;
using System.Collections.Generic;
using System.Threading;
using FUNS;

namespace GameCycle
{

	public class Game
	{
		private delegate void Message(string message);
		private event Message? Display; //событие

		private List<ICar> CarsList = new List<ICar>(); //список учавствующих машин

		private const int finish = 100; //расстояние до финиша(магические числа низя)

		public Game(params ICar[] carsArray)
		{
			Display += PrintMessage; //добавляет обработчик

			foreach(ICar car in carsArray) //формирует список
            {
				CarsList.Add(car); 
            }
		}

		private void PrintMessage(string message) => Console.WriteLine(message); //тут можно сделать чет красивое для победителя,
                                                                                 //но у меня уже сил нету

		public void Start() 
        {
			while(CarsList.Count > 0)
            {
				List<ICar> CarsToDelete = new List<ICar>(); //это прришлось сделать для того,
                                         //чтобы удалять машину из списка после цикла

				foreach (ICar car in CarsList) //каждая машина проезжает свой путь за секунду
                {
					if(car.Move() < finish)
                    {
						Display?.Invoke($"{car.Name} is on {car.coord} coordinate"); //вот это я хотел сделать в функции
                                                                                     //Move у машины, но низя
                    } else
                    {
						CarsToDelete.Add(car); //добавляет машину в список удаления
					}
                }

				Functions.SortList(CarsToDelete); //сортирует машины по пройденному расстоянию,
                                                  //если за эту секунду они обе финишировали

				foreach(ICar car in CarsToDelete) //удаляются машины, которые завершили гонку
                {
					Display?.Invoke($"{car.Name} had finished on {ICar.place} place with {car.coord} coordinate");
					ICar.place++; //для следующего места
					CarsList.Remove(car);
                }
				CarsToDelete.Clear();

				for (int i = 0; i < 3; i++) //просто красивое ожидание
				{
					Thread.Sleep(500);
					Console.Write(". ");
					Thread.Sleep(500);
				}
				Console.WriteLine();
			}
        }
	}
}

