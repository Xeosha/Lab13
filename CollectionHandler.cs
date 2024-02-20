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
        public object ChaingedObj { get; }

        public CollectionHandlerEventArgs(string NameOfCollection, string TypeOfChange, object? ChaingedObj)
        {
            this.NameOfCollection = NameOfCollection;
            this.TypeOfChange = TypeOfChange;
            this.ChaingedObj = ChaingedObj ?? " ";
        }

        public override string ToString() => $"Name of collection = {NameOfCollection}, Type of change = {TypeOfChange}";
    }
}
