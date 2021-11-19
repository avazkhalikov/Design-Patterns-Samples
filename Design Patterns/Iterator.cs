using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns
{
    /// <summary>
    /// A collection item
    /// </summary>
    public class Item
    {
        string name;
        // Constructor
        public Item(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
    }
    /// <summary>
    /// The 'Aggregate' interface
    /// </summary>
    public interface IAbstractCollection
    {
        Iterator CreateIterator();
    }
    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    public class Collection : IAbstractCollection
    {
        List<Item> items = new List<Item>();
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
        // Gets item count
        public int Count
        {
            get { return items.Count; }
        }
        // Indexer
        public Item this[int index]
        {
            get { return items[index]; }
            set { items.Add(value); }
        }
    }
    /// <summary>
    /// The 'Iterator' interface
    /// </summary>
    public interface IAbstractIterator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
    }
    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    public class Iterator : IAbstractIterator
    {
        Collection collection;
        int current = 0;
        int step = 1;
        // Constructor
        public Iterator(Collection collection)
        {
            this.collection = collection;
        }
        // Gets first item
        public Item First()
        {
            current = 0;
            return collection[current] as Item;
        }
        // Gets next item
        public Item Next()
        {
            current += step;
            if (!IsDone)
                return collection[current] as Item;
            else
                return null;
        }
        // Gets or sets stepsize
        public int Step
        {
            get { return step; }
            set { step = value; }
        }
        // Gets current iterator item
        public Item CurrentItem
        {
            get { return collection[current] as Item; }
        }
        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return current >= collection.Count; }
        }
    }

}
