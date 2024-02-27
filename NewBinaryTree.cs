using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree;
using Lab_10lib;

namespace Lab13
{
    public class NewBinaryTree<T> : BinaryTree<Goods>
    {
        public string Name { get; } = "NewBinaryTree";

        public event CollectionHandler? CollectionCountChanged;
        public event CollectionHandler? CollectionReferenceChanged;
        
        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs e)
        {
            CollectionCountChanged?.Invoke(source, e);
        }
        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs e)
        {
            CollectionReferenceChanged?.Invoke(source, e);
        }

        public override void Add(Goods product)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Added", product));
            base.Add(product);
        }

        public override void Add(IEnumerable<Goods> collection)
        {
            foreach (var value in collection)
                Add(value);
        }


        private bool CheckIndex(int index)
        {
            if (index > this.Count - 1)
                return false;
            else if (index < 0)
                return false;
            return true;
        }

        public bool Remove(int index)
        {
            if(!CheckIndex(index)) 
                return false;

            var findElem = this[index];
            Remove(findElem);
            return true;
        }

        public override bool Remove(Goods data)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Removed", base.Find(data)));
            return base.Remove(data);
        }
        public virtual Goods this[int index]
        {
            get 
            {
                if(!CheckIndex(index))
                {
                    throw new IndexOutOfRangeException("Index lower/bigger than possible!");
                }
                else
                {
                    Goods outElem = default!;
                    int count = 0;

                    foreach (Goods item in this)
                    {
                        outElem = item;
                        if (count == index)
                            break;
                        count++;
                    }

                    return outElem;
                }
            }
            set 
            {
                if(!CheckIndex(index))
                {
                    throw new IndexOutOfRangeException("Index lower/bigger than possible!");
                }
                else
                {
                    var findItem = this[index];
                    OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, "changed", value));

                    var inElem = this.FindNode(findItem, this.RootNode);
                    inElem.Data.Name = value.Name;

                }
            }
        }

        public override void Clear()
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Clear", null));
            base.Clear();
        }

    }
}
    