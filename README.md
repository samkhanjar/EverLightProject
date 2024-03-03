# EverLight Project
EverLight Technical Test

# Problem
Create a tree structure based on a given depth of n.
Initialize the state of each gate randomly to left or right.
Build two features, with the user specifying the depth:
a. Write an algorithm that predicts which container will not receive a ball.
b. Run all the balls through the system, check which container did not get a ball, and check whether this result matches the prediction.

1. The dynamic model describes a system of branches and balls with a depth of n, and gate direction set randomly.
2. At each intersection is a gate. When a ball passes a gate, it will pass down the open side, but then the gate will move to the other side.
3. There are (n pow of 2 - 1) balls and (n pow 2) containers. Which container will not receive a ball when all balls have passed through the system?

# Solution  
In this solution, I have utilized the memoization technique to optimize performance by avoiding redundant computations. Memoization improves efficiency by caching computation results. This means that if a computation is performed multiple times with the same inputs, the result is stored in memory and reused when needed again. This eliminates the need to recalculate the same result multiple times, reducing overall computational overhead.

In the context of the problem, certain computations, such as predicting the container without a ball or determining the configuration of gates, may be repeated multiple times as the simulation progresses. Memoization ensures that these computations are executed only once for each unique set of inputs, and their results are stored for future use.

By reducing redundant computations, memoization helps optimize the performance of the simulation system, particularly for larger depths where the number of possible configurations and computations increases significantly. This can lead to faster execution times and better scalability of the solution.

The solution provided is a class called SimulationSystem, which contains methods to simulate the behavior of a system with gates and containers according to the requirements specified in the problem section above.

Here's a description of each method in the SimulationSystem class:

1. InitializeGates
    - This method initializes the gates in the system.
    - It takes the number of containers as input.
    - For each container, it randomly assigns a direction (left or right) to its gate and stores this information in a dictionary.
    - Finally, it returns the dictionary containing the gate configurations.

2. GetContainerWithoutBall
    - This method simulates the scenario where one container won't receive a ball.
    - It takes the number of containers as input.
    - It randomly selects a container index (ballContainer) that won't receive the ball.
    - It iterates over each container index and adds it to a hash set called containersWithoutBall, except for the container identified by ballContainer.
    - Finally, it returns the hash set containing the indices of containers without the ball.

3. PredictContainerWithoutBall
    - This method predicts the container without a ball based on the gate configurations.
    - It takes the dictionary of gate configurations and the number of containers as input.
    - It calculates a hash value based on the gate configurations to check if the prediction has been cached.
    - If the prediction has been cached, it returns the cached result.
    - If the prediction has not been cached, it iterates over each gate in the dictionary.
    - If it finds a gate pointing left (i.e., !gate.Value), it returns the index of that container.
    - If no gate is found pointing left, it returns -1 indicating no prediction.

4. RunBallsThroughSystem
    - This method simulates running the balls through the system.
    - It takes the dictionary of gate configurations and the number of balls as input.
    - It iterates over each ball.
    - For each ball, it determines the destination container by following the gate configurations.
    - It updates the gate state corresponding to the destination container to indicate that a ball has passed through it.

5. CheckResultMatchesPrediction
    - This method checks if the result matches the prediction by finding the container without a ball after running the balls through the system.
    - It takes the dictionary of gate configurations and the number of containers as input.
    - It iterates over each gate in the dictionary.
    - If it finds a gate pointing left (i.e., !gate.Value), it returns the index of that container.
    - If no gate is found pointing left, it returns -1 indicating that the result does not match the prediction.

6. CalculateHash
    - This is a helper method to calculate a hash value based on the gate configurations.
    - It takes the dictionary of gate configurations as input.
    - It iterates over each gate and calculates a hash value based on the gate index and its corresponding direction.
    - The calculated hash value is used to uniquely identify the gate configurations and cache the prediction result.

# Running the project
Clone the project and open the solution in your preferred compiler/editor. Then, run the EverLightProject.UI project. You should be presented with the following console application.

![image](https://github.com/samkhanjar/EverLightProject/assets/15098247/94c97d2e-f830-443d-8110-67e9603bbb88)

![image](https://github.com/samkhanjar/EverLightProject/assets/15098247/d0a7826e-8787-4206-a0a3-3dbd2fcf1e56)

The project consists of the following projects and files:

1. EverLightProject.sln -> Solution file
2. EverLightProject.Core -> Business logic
3. EverLightProject.UI -> Console application
4. EverLightProject.Test -> Test project
5. README file

# Future Improvements 
Future work involves adding more unit tests to cover additional edge cases. Additionally, implementing error handling and logging is necessary. Due to time constraints, I could have chosen to implement the solution using stacks instead of memoization for better performance and efficiency.

