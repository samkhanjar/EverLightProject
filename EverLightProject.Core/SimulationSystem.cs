namespace EverLightProject.Core
{
    public class SimulationSystem
    {
        static Dictionary<int, bool> gatesCache = new Dictionary<int, bool>();
        static Dictionary<int, HashSet<int>> containersWithoutBallCache = new Dictionary<int, HashSet<int>>();

        public static Dictionary<int, bool> InitializeGates(int containers)
        {
            Random random = new Random();
            Dictionary<int, bool> gates = new Dictionary<int, bool>();

            for (var i = 0; i < containers; i++)
            {
                gates[i] = random.Next(2) == 0; // Randomly initialize gate to left or right
            }

            return gates;
        }

        public static HashSet<int> GetContainerWithoutBall(int containers)
        {
            if (containersWithoutBallCache.ContainsKey(containers))
            {
                return containersWithoutBallCache[containers];
            }

            HashSet<int> containersWithoutBall = new HashSet<int>();
            var ballContainer = new Random().Next(containers);

            for (var i = 0; i < containers; i++)
            {
                if (i != ballContainer)
                {
                    containersWithoutBall.Add(i);
                }
            }

            containersWithoutBallCache[containers] = containersWithoutBall;
            return containersWithoutBall;
        }

        public static int PredictContainerWithoutBall(Dictionary<int, bool> gates, int containers)
        {
            var hash = CalculateHash(gates);

            if (gatesCache.ContainsKey(hash))
            {
                return gatesCache[hash] ? -1 : 0;
            }

            foreach (KeyValuePair<int, bool> gate in gates)
            {
                if (!gate.Value) // Left gate, move ball left
                {
                    gatesCache[hash] = false;
                    return gate.Key;
                }
            }

            gatesCache[hash] = true;
            return -1; // No prediction
        }

        public static void RunBallsThroughSystem(Dictionary<int, bool> gates, int balls)
        {
            for (var i = 0; i < balls; i++)
            {
                var container = 0;

                foreach (KeyValuePair<int, bool> gate in gates)
                {
                    if (gate.Value) // Right gate, move ball right
                    {
                        container++;
                    }
                    else // Left gate, move ball left
                    {
                        container += (int)Math.Pow(2, gate.Key / 2);
                    }
                }

                container %= gates.Count;
                gates[container] = true;
            }
        }

        public static int CheckResultMatchesPrediction(Dictionary<int, bool> gates)
        {
            foreach (KeyValuePair<int, bool> gate in gates)
            {
                if (!gate.Value) // Left gate, the ball didn't pass through
                {
                    return gate.Key;
                }
            }

            return -1; // No result
        }

        static int CalculateHash(Dictionary<int, bool> gates)
        {
            var hash = 17;
            foreach (var kvp in gates)
            {
                hash = hash * 31 + kvp.Key.GetHashCode();
                hash = hash * 31 + kvp.Value.GetHashCode();
            }
            return hash;
        }
    }
}
