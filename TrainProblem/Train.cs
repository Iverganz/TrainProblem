using System;
using System.Collections.Generic;

namespace TrainProblem
{
    /// <summary>
    /// Закольцованный поезд.
    /// </summary>
    public class Train
    {
        /// <summary>
        /// Головной вагон.
        /// </summary>
        public Carriage Head { get; set; }
        
        /// <summary>
        /// Добавить вагон.
        /// </summary>
        /// <param name="carriage"> Вагон поезда.</param>
        public void Add(Carriage carriage)
        {
            if (Head == null)
            {
                Head = carriage;
                Head.Next = carriage;
                Head.Previous = carriage;
            }
            else
            {
                carriage.Previous = Head.Previous;
                carriage.Next = Head;
                Head.Previous.Next = carriage;
                Head.Previous = carriage;
            }
        }
        
        /// <summary>
        /// Генерирует поезд заданной длины с случайно заданной включенностью света в вагонах.
        /// </summary>
        /// <param name="length"></param>
        public Train(int length)
        {
            if (length < 0)
            {
                throw  new ArgumentException(nameof(length));
            }
            var generator = new Random();

            for (int i = 0; i < length; i++)
            {
                this.Add(new Carriage(generator.Next(2)<1));
            }
        }
        
        /// <summary>
        /// Подсчет вагонов включая и выключая свет.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int CountByLights(Carriage current)
        {
            if (current == null)
            {
                return 0;
            }
            
            //выключаем свет в первом вагоне
            current.LightOn = true;
            current = current.Next;
            var count = 1;
            //идем вперед пока не зайдем в вагон с включенным светом
            while (!current.LightOn)
            {
                current = current.Next;
                count++;
            } 
            
            //выключаем в нем свет
            current.LightOn = false;
            //идем назад столько же сколько прошли
            
            for (int i = 0; i < count; i++)
            {
                current = current.Previous;
            }
            
            //если свет выключился мы замкнулись, значит посчитали вагоны
            if (!current.LightOn)
            {
                return count;
            }
            
            //если нет то повторяем
            return CountByLights(current);
        }
    }
}