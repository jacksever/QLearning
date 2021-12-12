namespace QLearning
{
    // Интерфейс для постановки задач
    public interface IQLearningProblem
    {
        // Количество состояний (комнат)
        int NumberOfStates { get; }

        // Количество действий (переходов)
        int NumberOfActions { get; }

        // Возвращает возможные действия
        int[] GetValidActions(int currentState);

        // Возвращает вознаграждение
        double GetReward(int currentState, int action);

        // Достигли ли цели?
        bool GoalStateIsReached(int currentState);
    }
}