using System;
using Shared.BaseModels;
using Shared.Interfaces;
using Shared.Models;
using GalaSoft.MvvmLight;

namespace CodingDojo3.ViewModel
{
    public class ItemVM : ViewModelBase
    {
        private ItemBase baseItem; //parent class of sensors and actors

        private int id;

        public int Id
        {
            get { return baseItem.Id; }
            
        }

        private string name;

        public string Name
        {
            get { return baseItem.Name; }
            set { baseItem.Name = value; }
        }

        private string description;

        public string Description
        {
            get { return baseItem.Description; }
            set { baseItem.Description = value; }
        }

        private string room;

        public string Room
        {
            get { return baseItem.Room; }
            set { baseItem.Room = value; }
        }

        private int posX;

        public int PosX
        {
            get { return baseItem.PosX; }
            set { baseItem.PosX = value; }
        }

        private int posY;

        public int PosY
        {
            get { return baseItem.PosY; }
            set { baseItem.PosY = value; }
        }

        private string valueType;

        public string ValueType //child classes need to be evaluated
        {
            get {
                if (baseItem is IActuator) //if base class implemented actor-interface it has the actor-property
                {
                    return (baseItem as BaseActuator).ActuatorValueType.Name;
                }
                else if (baseItem is ISensor)
                {
                    return (baseItem as BaseSensor).SensorValueType.Name;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        private string itemType;

        public Type ItemType //Type because it can be IActuator or ISensor type
        {
            get {
                if (baseItem is IActuator)
                {
                    return typeof(IActuator);  //to get the run-time type
                }
                else if (baseItem is ISensor)
                {
                    return typeof(ISensor);
                }
                else
                {
                    throw new NotImplementedException();
                } }
        }

        private string mode;

        public string Mode //Mode is a string value in an enum list
        {
            get
            {
                if (baseItem is IActuator)
                    return (baseItem as BaseActuator).ActuatorMode.ToString();
                else if (baseItem is ISensor)
                    return (baseItem as BaseSensor).SensorMode.ToString();
                else
                    throw new NotImplementedException();
            }
            set
            {
                if (baseItem is IActuator)
                    (baseItem as BaseActuator).ActuatorMode = (ModeType)Enum.Parse(typeof(ModeType), value, false); //parse to correct type - actor or sensor mode - enum
                else if (baseItem is ISensor)
                    (baseItem as BaseSensor).SensorMode = (SensorModeType)Enum.Parse(typeof(ModeType), value, false);
                else
                    throw new NotImplementedException();
            }
        }

        private object value;

        public object Value //because sensorValue and actuatorValue are of type object
        {
            get {
                if (baseItem is ISensor)
                    return (baseItem as BaseSensor).SensorValue;
                else if (baseItem is IActuator)
                    return (baseItem as BaseActuator).ActuatorValue;
                else
                    throw new NotImplementedException();
            }
            set {
                if (baseItem is ISensor)
                    (baseItem as BaseSensor).SensorValue = value;
                else if (baseItem is IActuator)
                    (baseItem as BaseActuator).ActuatorValue = value;
                else
                    throw new NotImplementedException();
            }
        }

        //2 constructors, one for ISensor object, 1 for IActuator object
        public ItemVM(ISensor sensor)
        {
            baseItem = sensor as ItemBase;
        }

        public ItemVM(IActuator actuator)
        {
            baseItem = actuator as ItemBase;
        }
    }
}
