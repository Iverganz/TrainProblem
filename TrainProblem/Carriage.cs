using System;

namespace TrainProblem
{
    /// <summary>
    /// Вагон поезда.
    /// </summary>
    public class Carriage
    {
        /// <summary>
        /// Включенность света.
        /// </summary>
        public bool LightOn { get; set; }
        
        /// <summary>
        /// Переход в следующий вагон.
        /// </summary>
        public Carriage Next { get; set; }
        
        /// <summary>
        /// Переход в предыдущий вагон.
        /// </summary>
        public Carriage Previous { get; set; }

        public Carriage(bool lightOn)
        {
            LightOn = lightOn;
        }
    }
}