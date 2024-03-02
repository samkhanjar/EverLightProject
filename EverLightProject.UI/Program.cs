using EverLightProject.Core;

namespace EverLightProject.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter desired depth (n): ");
            var depth = int.Parse(Console.ReadLine());
            int containers = (int)Math.Pow(2, depth);
            int balls = (int)Math.Pow(2, depth) - 1;

            Dictionary<int, bool> gates = SimulationSystem.InitializeGates(containers);
            HashSet<int> containersWithoutBall = SimulationSystem.GetContainerWithoutBall(containers);

            int predictedContainer = SimulationSystem.PredictContainerWithoutBall(gates, containers);

            Console.WriteLine($"Predicted empty container is: {predictedContainer}");

            SimulationSystem.RunBallsThroughSystem(gates, balls);
            int resultContainer = SimulationSystem.CheckResultMatchesPrediction(gates);

            Console.WriteLine($"Actualt empty container is: {resultContainer}");

            if (predictedContainer == resultContainer)
            {
                Console.WriteLine("Prediction successful!");
            }
            else
            {
                Console.WriteLine("Prediction failed!");
            }
        }
    }    
}