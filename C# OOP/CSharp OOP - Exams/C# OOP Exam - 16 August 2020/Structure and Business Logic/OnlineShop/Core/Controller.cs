namespace OnlineShop.Core
{
    using System.Linq;
    using System.Collections.Generic;
    using System;


    using Common.Enums;
    using OnlineShop.Common.Constants;
    using OnlineShop.Models.Products.Components;
    using OnlineShop.Models.Products.Computers;
    using OnlineShop.Models.Products.Peripherals;

    public class Controller : IController
    {
        private  List<IComputer> computers;
        private  List<IComponent> components;
        private  List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType,
            string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if (computer.Components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = default;
            if (componentType == ComponentType.CentralProcessingUnit.ToString())
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.Motherboard.ToString())
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.PowerSupply.ToString())
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.RandomAccessMemory.ToString())
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.SolidStateDrive.ToString())
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.VideoCard.ToString())
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            computer.AddComponent(component);
            components.Add(component);
            string result = string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            return result;
        }

        //WARNING
        public string AddComputer(string computerType, int id, string manufacturer,
            string model, decimal price)
        {
            IComputer computer = default;
            if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidComputerType));
            }

            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComputerId));
            }

            this.computers.Add(computer);

            string result = string.Format(SuccessMessages.AddedComputer, id);

            return result;
        }

        public string AddPeripheral(int computerId, int id, string peripheralType,
            string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            IPeripheral peripheral = default;
            if (peripheralType == PeripheralType.Headset.ToString())
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Keyboard.ToString())
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Monitor.ToString())
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Mouse.ToString())
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            this.peripherals.Add(peripheral);
            computer.AddPeripheral(peripheral);
            string result = string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
            return result;
        }

        public string BuyBest(decimal budget)
        {
            var computer = this.computers
              .OrderByDescending(x => x.OverallPerformance)
              .FirstOrDefault(x => x.Price <= budget);

            if (this.computers.Count == 0 || this.computers.All(x => x.Price > budget))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if (!this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            IComponent component = computer.Components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, computer.GetType().Name, computerId));
            }
            computer.RemoveComponent(componentType);
            this.components.Remove(component);
            string format = string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
            return format;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            IPeripheral peripheral = computer.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, computer.GetType().Name, computerId));
            }
            computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);
            string format = string.Format(SuccessMessages.RemovedComponent, peripheralType, peripheral.Id);
            return format;
        }
    }
}
