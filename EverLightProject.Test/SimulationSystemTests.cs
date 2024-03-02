using EverLightProject.Core;

namespace EverLightProject.Test
{
    public class SimulationSystemTests
    {
        [Test]
        public void InitializeGates_ReturnsDictionaryWithCorrectLength()
        {
            var containers = 5;
            var gates = SimulationSystem.InitializeGates(containers);

            Assert.That(gates.Count, Is.EqualTo(containers));
        }

        [Test]
        public void GetContainerWithoutBall_ReturnsHashSetWithCorrectLength()
        {
            var containers = 5;
            var containerWithoutBall = SimulationSystem.GetContainerWithoutBall(containers);

            Assert.That(containerWithoutBall.Count, Is.EqualTo(containers - 1));
        }

        [Test]
        public void PredictContainerWithoutBall_ReturnsCorrectContainer()
        {
            var gates = new Dictionary<int, bool>
            {
                { 0, true },
                { 1, false },
                { 2, false }
            };

            var containers = 3;

            var container = SimulationSystem.PredictContainerWithoutBall(gates, containers);

            Assert.That(container, Is.EqualTo(1));
        }

        [Test]
        public void RunBallsThroughSystem_GatesContainBallAfterRunning()
        {
            var balls = 10;
            var containers = 5;

            var gates = SimulationSystem.InitializeGates(containers);

            SimulationSystem.RunBallsThroughSystem(gates, balls);

            Assert.IsTrue(gates.ContainsValue(true));
        }

        [Test]
        public void CheckResultMatchesPrediction_ReturnsCorrectContainer()
        {
            var gates = new Dictionary<int, bool>
            {
                { 0, true },
                { 1, false },
                { 2, false }
            };

            var container = SimulationSystem.CheckResultMatchesPrediction(gates);

            Assert.That(container, Is.EqualTo(1));
        }
    }
}
