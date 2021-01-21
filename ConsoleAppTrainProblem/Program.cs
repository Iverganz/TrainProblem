using System;
using TrainProblem;

namespace ConsoleAppTrainProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var len = 459;
            var Train = new Train(len);
            var count = 0;
            var car = Train.Head;
            Console.WriteLine("Состав поезда: ");
            for (int i = 0; i < len; i++)
            {
                Console.Write(car.LightOn.ToString() + ' ');
                car = car.Next;
            }
            
            Console.WriteLine("В поезде: " + Train.CountByLights(Train.Head).ToString() + " вагонов.");
            Console.ReadLine();
        }
    }
}