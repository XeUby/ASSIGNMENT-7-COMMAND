namespace ASSIGNMENT-7-COMMAND
{
    public class Program
    {
        // Class representing the remote controller
        class RemoteController
        {
            // List of commands to be executed
            private List<Command> commands = new List<Command>();

            // Method to add a command to the list
            public void setCommand(Command newCommand)
            {
                this.commands.Add(newCommand);
            }

            // Method to execute the command based on the provided key
            public void buttonPressed(int key)
            {
                commands[key].execute();
            }

            // Method to display the list of commands and their corresponding keys
            public void setOfCommandDisplay()
            {
                int i = 0;
                foreach (Command command in commands)
                {
                    Console.WriteLine("Key {0} - {1}", i++, command.get_command_info());
                }

                Console.WriteLine("Press Ctrl+C to exit");
            }
        }

        // Interface defining the command behavior
        interface Command
        {
            // Method to execute the command
            void execute();

            // Method to get the command description
            string get_command_info();
        }

        // Class representing the command to turn on lights
        class LightOnCommand : Command
        {
            // Reference to the light object
            private Light light;

            // Description of the command
            private string command_info = "Turn on lights";

            // Method to get the command description
            public override string get_command_info()
            {
                return command_info;
            }

            // Constructor to initialize the light object
            public LightOnCommand(Light light)
            {
                this.light = light;
            }

            // Method to turn on the lights
            private void turnOn()
            {
                light.on();
            }

            // Method to execute the command
            public override void execute()
            {
                turnOn();
            }
        }

        // Class representing the command to turn off lights
        class LightOffCommand : Command
        {
            // Reference to the light object
            private Light light;

            // Description of the command
            private string command_info = "Turn off lights";

            // Method to get the command description
            public override string get_command_info()
            {
                return command_info;
            }

            // Constructor to initialize the light object
            public LightOffCommand(Light light)
            {
                this.light = light;
            }

            // Method to turn off the lights
            private void turnOff()
            {
                light.off();
            }

            // Method to execute the command
            public override void execute()
            {
                turnOff();
            }
        }

        // Class representing the command to increase thermostat temperature
        class IncreaseThermostat : Command
        {
            // Reference to the thermostat object
            private Thermostat thermostat;

            // Description of the command
            private string command_info = "Increase thermostat temperature";

            // Method to get the command description
            public override string get_command_info()
            {
                return command_info;
            }

            // Constructor to initialize the thermostat object
            public IncreaseThermostat(Thermostat thermostat)
            {
                this.thermostat = thermostat;
            }

            // Method to increase the thermostat temperature
            private void increase()
            {
                thermostat.increase();
            }

            // Method to execute the command
            public override void execute()
            {
                increase();
            }
        }

        // Class representing the command to decrease thermostat temperature
        class DecreaseThermostat : Command
        {
            // Reference to the thermostat object
            private Thermostat thermostat;
             string command_info = "Decrease thermostat temperature";
            public string get_command_info() => command_info;
            public DecreaseThermostat(Thermostat thermostat) => this.thermostat = thermostat;
            void decrease() => this.thermostat.decrease();
            public void execute() => decrease();
        }
        class Light
        {
            string state = "OFF" ;
            public Light() { }
            public void display() => Console.WriteLine("Light's state is {0}",state);
           
            }

            // Method to turn on the light
            public void on()
            {
                this.state = "ON";
                this.display();
            }

            // Method to turn off the light
            public void off()
            {
                this.state = "OFF";
                this.display();
            }
        }

        // Class representing the thermostat object
        class Thermostat
        {
            // Current temperature setting
            private int temperature = 10;

            // Method to display the current temperature setting
            public void display()
            {
                Console.WriteLine("Thermostat's state is {0}", temperature);
            }

            // Method to increase the temperature
            public void increase()
            {
                this.temperature++;
                this.display();
            }

            // Method to decrease the temperature
            public void decrease()
            {
                this.temperature--;
                this.display();
            }
        }

        // Main entry point of the program
        static void Main(string[] args)
        {
            // Create instances of the light and thermostat objects
            Light bedroomLights = new Light();
            Thermostat bedroomThermostat = new Thermostat();

            // Create commands for controlling the light and thermostat
            LightOnCommand turnOnLight = new LightOnCommand(bedroomLights);
            LightOffCommand turnOffLight = new LightOffCommand(bedroomLights);
            IncreaseThermostat increaseThermostat = new IncreaseThermostat(bedroomThermostat);
            DecreaseThermostat decreaseThermostat = new DecreaseThermostat(bedroomThermostat);

            // Create a remote controller and add the commands
            RemoteController controller = new RemoteController();
            controller.setCommand(turnOnLight);
            controller.setCommand(turnOffLight);
            controller.setCommand(increaseThermostat);
            controller.setCommand(decreaseThermostat);

            // Display the list of commands and corresponding keys
            controller.setOfCommandDisplay();

            // Continuously take input from the user and execute the corresponding command
            while (true)
            {
                Console.Write("Press button on remote controller: ");
                string key = Console.ReadLine();

                try
                {
                    int buttonKey = int.Parse(key);
                    controller.buttonPressed(buttonKey);
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
