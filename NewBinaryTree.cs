using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree;
using Lab_10lib;

namespace Lab13
{
    public class NewBinaryTree<T> : BinaryTree<T>
        where T : IComparable, ICloneable
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

        public override void Add(T product)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Added", product));
            base.Add(product);
        }

        public override void Add(IEnumerable<T> collection)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Added", collection));
            base.Add(collection);
        }

        public override bool Remove(T data)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Removed", base.Find(data)));
            return base.Remove(data);
        }
        public virtual T this[int index]
        {
            get 
            {
                if (index > this.Count - 1)
                    throw new IndexOutOfRangeException("Index greater than possible!");
                else if (index < 0)
                    throw new IndexOutOfRangeException("Index lower than possible!");
                else
                {
                    T outElem = default!;
                    int count = 0;

                    foreach (T item in this)
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
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, "changed", this[index]));
                if (index > this.Count - 1)
                    throw new IndexOutOfRangeException("Index greater than possible!");
                else if (index < 0)
                    throw new IndexOutOfRangeException("Index lower than possible!");
                else
                {
                    T outElem = default!;
                    int count = 0;

                    foreach (T item in this)
                    {
                        outElem = item;
                        if (count == index)
                            break;
                        count++;
                    }

                    var inElem = this.FindNode(outElem, this.RootNode);
                    inElem.Data = value;

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
    