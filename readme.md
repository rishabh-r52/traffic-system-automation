# Traffic System Simulation with Intelligent Signal Control

This project is a simulation of a traffic system created using Unity, designed to mimic real-world traffic with signals, intersections, and over a hundred vehicles. The simulation is enhanced with a vehicle detection model built using OpenCV and TensorFlow. This model tracks the number of vehicles at each intersection and dynamically adjusts the signal timings based on traffic density, ensuring a more efficient flow of traffic.

## Table of Contents

- [Features](#features)
- [Tools and Technologies](#tools-and-technologies)
- [Installation](#installation)
- [Usage](#usage)
- [Future Scope](#future-scope)
- [Contributing](#contributing)
- [Contact](#contact)

## Features

- **Realistic Traffic Simulation:** Over a hundred vehicles, intersections, and signals.
- **Intelligent Signal Control:** Dynamic adjustment of signal timings based on real-time traffic density.
- **Vehicle Detection:** Uses OpenCV and TensorFlow for accurate vehicle tracking at intersections.
- **Efficient Traffic Flow:** Reduces congestion and optimizes wait times at signals.

## Tools and Technologies

- **Unity:** Traffic simulation with signals, intersections, and vehicles.
- **OpenCV:** Vehicle detection and tracking.
- **TensorFlow:** Machine learning for vehicle detection.
- **Python:** Scripting for the detection model.
- **C#:** Scripting within Unity.
- **Machine Learning Algorithms:** For accurate vehicle detection and prediction.

## Installation

1. **Clone the repository:**
    ```bash
    git clone https://github.com/rishabh-r52/traffic-system-simulation.git
    cd traffic-system-simulation
    ```

2. **Install the required dependencies for the detection model:**
    ```bash
    pip install -r requirements.txt
    ```

3. **Open the Unity project:**
    - Navigate to the `UnityProject` folder and open it in Unity.

4. **Set up the Python environment for OpenCV and TensorFlow:**
    - Ensure Python and the necessary libraries are installed. You can use a virtual environment for this.

## Usage

1. **Run the Unity Simulation:**
    - Open the project in Unity and press the play button to start the simulation.
    - Observe the vehicles moving through intersections with dynamically adjusting signals.

2. **Integrate the Vehicle Detection Model:**
    - The detection model will run alongside the simulation, continuously analyzing traffic density and adjusting signal timings in real-time.

3. **Modify the Simulation:**
    - Customize the number of vehicles, intersections, and signal timing logic according to your needs.

## Future Scope

- **Enhanced Detection Algorithms:** Implement more advanced machine learning algorithms to improve vehicle detection accuracy.
- **Real-time Data Integration:** Use live traffic data from actual cameras to enhance the simulation’s realism.
- **Scalability:** Expand the simulation to cover larger areas or more complex traffic scenarios.
- **User Interface Improvements:** Develop a more intuitive UI for easy monitoring and interaction.
- **Integration with IoT Devices:** Link with IoT devices for real-time traffic management in smart cities.
- **Predictive Analytics:** Apply predictive analytics to forecast traffic and adjust signals proactively.

## Contributing

Contributions are welcome! Please fork this repository and submit a pull request if you'd like to help improve the project.

## Contact

If you have any questions or suggestions, feel free to reach out:

- **Name:** Rishabh Ranjan
- **Email:** [rishabh9050@gmail.com](mailto:rishabh9050@gmail.com)
- **GitHub:** [rishabh-r52](https://github.com/rishabh-r52)
