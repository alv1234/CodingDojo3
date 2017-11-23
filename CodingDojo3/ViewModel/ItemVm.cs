//diese Klasse wird unser Model der Shared-Properties

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.BaseModels; //importieren der Shared Klassen
using GalaSoft.MvvmLight;

namespace CodingDojo3.ViewModel
{
    public class ItemVm : ViewModelBase
    {
        //man muss hier das ItemBase-Objekt benutzen, weil es das Model ist. 
        public ItemBase baseItem;

        public int Id {
            get { return Id; }
            set { this.Id = value; RaisePropertyChanged(); } //Raiseprop... weil die Info an die GUI weitergegeben werden soll
        }



        public ItemVm(int id, string name, string description, string room, int posX, int posY)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Room = room;
            this.PosX = posX;
            this.PosY = posY;

        }

    }
}
