using System;
using System.Collections.Generic;
using System.Linq;
using QLearning.Utils;

namespace QLearning
{
    // Класс, реализующий алгоритм Q Learning
    public class QLearning
    {
        private Random _random = new Random();

        // Коэффициент дисконтирования 
        private double _gamma;

        public double Gamma
        {
            get => _gamma;
        }

        // Q таблица зубчатая матрица (строки разной длины)
        private double[][] _qTable;

        public double[][] QTable
        {
            get => _qTable;
        }

        // Постановка задачи
        private IQLearningProblem _qLearningProblem;

        // Получаем коэффициент и постановку задачи
        public QLearning(double gamma, IQLearningProblem qLearningProblem)
        {
            _qLearningProblem = qLearningProblem;
            _gamma = gamma;
            _qTable = new double[qLearningProblem.NumberOfStates][];
            for (int i = 0; i < qLearningProblem.NumberOfStates; i++)
                _qTable[i] = new double[qLearningProblem.NumberOfActions];
        }

        // Старт обучения, обучение повторится numberOfIterations раз
        public void TrainAgent(int numberOfIterations)
        {
            for (int i = 0; i < numberOfIterations; i++)
            {
                int initialState = SetInitialState(_qLearningProblem.NumberOfStates);
                InitializeEpisode(initialState);
            }
        }

        // Само обучение (1 эпизод - 1 обучение)
        // Стартуем эпизод, каждый раз взяв новое действие (TakeAction) для перехода в новое состояние
        private void InitializeEpisode(int initialState)
        {
            int currentState = initialState;
            while (true)
            {
                currentState = TakeAction(currentState);
                if (_qLearningProblem.GoalStateIsReached(currentState))
                    break;
            }
        }

        // Переход в новое состояние, корректировка Q таблицы
        private int TakeAction(int currentState)
        {
            var validActions = _qLearningProblem.GetValidActions(currentState);
            int randomIndexAction = _random.Next(0, validActions.Length);

            int action = validActions[randomIndexAction];
            Console.WriteLine($"State: {currentState}");
            Console.WriteLine($"Action: {action}");

            double saReward = _qLearningProblem.GetReward(currentState, action);
            double nsReward = _qTable[action].Max();
            double qCurrentState = saReward + (_gamma * nsReward);
            _qTable[currentState][action] = qCurrentState;
            Console.WriteLine(_qTable.Print());
            int newState = action;
            return newState;
        }

        // Проход по "обученной" Q таблице для демонстрации оптимальных шагов
        public QLearningStats Run(int initialState)
        {
            if (initialState < 0 || initialState > _qLearningProblem.NumberOfStates)
                throw new ArgumentException(
                    $"Начальное состояние должно быть в промежутке [0-{_qLearningProblem.NumberOfStates}",
                    nameof(initialState));

            var result = new QLearningStats();
            result.InitialState = initialState;
            int state = initialState;
            List<int> actions = new List<int>();
            while (true)
            {
                result.Steps += 1;
                int action = _qTable[state].ToList().IndexOf(_qTable[state].Max());
                state = action;
                actions.Add(action);
                if (_qLearningProblem.GoalStateIsReached(action))
                {
                    result.EndState = action;
                    break;
                }
            }

            result.Actions = actions.ToArray();
            return result;
        }

        private int SetInitialState(int numberOfStates)
        {
            return _random.Next(0, numberOfStates);
        }
    }
}