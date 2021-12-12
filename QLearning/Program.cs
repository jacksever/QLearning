using System;
using QLearning.Utils;

namespace QLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            var qLearning = new QLearning(0.8, new RoomsProblem());
            Console.WriteLine("Обучение Агента...");
            qLearning.TrainAgent(2000);

            Console.WriteLine("Обучение завершено!");
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadLine();
            do
            {
                Console.WriteLine($"Введите начальное состояние (комнату). Нажмите 'q' для выхода...");
                int initialState = 0;
                if (!int.TryParse(Console.ReadLine(), out initialState)) break;

                try
                {
                    var qLearningStats = qLearning.Run(initialState);
                    Console.WriteLine(qLearningStats.ToString());
                    var normalizedMatrix = qLearning.QTable.NormalizeMatrix();
                    Console.Write(normalizedMatrix.Print());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            } while (true);
        }
    }
}