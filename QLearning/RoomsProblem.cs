using System.Collections.Generic;

namespace QLearning
{
    // Класс реализующий фасад Q алгоритма для задачи выхода из комнаты
    class RoomsProblem : IQLearningProblem
    {
        // Матрица вознаграждения 
        private double[][] rewards = new double[16][]
        {
            new double[] {-1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
            new double[] {0, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
            new double[] {-1, 0, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1},
            new double[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
            new double[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
            new double[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
            new double[] {-1, -1, 0, -1, -1, -1, -1, 0, -1, -1, 0, -1, -1, -1, -1, -1},
            new double[] {-1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, 0, -1, -1, -1, -1},
            new double[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
            new double[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, 0, -1, -1},
            new double[] {-1, -1, -1, -1, -1, -1, 0, -1, -1, 0, -1, 0, -1, -1, -1, -1},
            new double[] {-1, -1, -1, -1, -1, -1, -1, 0, -1, -1, 0, -1, -1, -1, -1, 100},
            new double[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1},
            new double[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, 0, -1, -1, -1},
            new double[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
            new double[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1}
        };

        // Количество состояний (комнат)
        public int NumberOfStates => 16;

        // Количество действий (переходов)
        public int NumberOfActions => 16;

        // Возвращает вознаграждение
        public double GetReward(int currentState, int action)
        {
            return rewards[currentState][action];
        }

        // Возвращает возможные действия
        public int[] GetValidActions(int currentState)
        {
            List<int> validActions = new List<int>();
            for (int i = 0; i < rewards[currentState].Length; i++)
            {
                if (rewards[currentState][i] != -1)
                    validActions.Add(i);
            }

            return validActions.ToArray();
        }

        // Достигли ли цели?
        public bool GoalStateIsReached(int currentState)
        {
            return currentState == 15;
        }
    }
}