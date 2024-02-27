using Lab_10lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{

    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string NameOfCollection { get; set; }
        public string TypeOfChange { get; set; }
        public Goods ChaingedObj { get; }

        public CollectionHandlerEventArgs(string NameOfCollection, string TypeOfChange, Goods? ChaingedObj)
        {
            this.NameOfCollection = NameOfCollection;
            this.TypeOfChange = TypeOfChange;
            this.ChaingedObj = ChaingedObj ?? default!;
        }

        public override string ToString() => $"Name of collection = {NameOfCollection}, Type of change = {TypeOfChange}";
    }
}
