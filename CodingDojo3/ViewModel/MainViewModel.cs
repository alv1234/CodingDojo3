using CodingDojo3.DataSimulation;
using GalaSoft.MvvmLight;
using Shared.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodingDojo3.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public List<ItemVM> modelItems = new List<ItemVM>();

        public ObservableCollection<ItemVM> SensorList = new ObservableCollection<ItemVM>();
        public ObservableCollection<ItemVM> ActorList = new ObservableCollection<ItemVM>();


        public MainViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            Simulator sim = new Simulator(modelItems);
            foreach (var item in sim.Items)
            {
                if (item.ItemType.Equals(typeof(ISensor)))
                    SensorList.Add(item);
                else if (item.ItemType.Equals(typeof(IActuator)))
                    ActorList.Add(item);
            }

        }
    }
}