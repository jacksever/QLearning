using System.Text;

namespace QLearning
{
    // Объект содержащий информацию о прогоне по игре обученного агента
    public class QLearningStats
    {
        public int InitialState { get; set; }
        public int EndState { get; set; }
        public int Steps { get; set; }
        public int[] Actions { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Агенту необходимо {Steps} шагов чтобы достичь цели");
            sb.AppendLine($"Текущее состояние агента: {InitialState}");
            foreach (var action in Actions)
                sb.AppendLine($"Действие: {action}");
            sb.AppendLine($"Агент достиг цели: {EndState}");
            return sb.ToString();
        }
    }
}