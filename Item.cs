using System;
using System.Collections.Generic;
using System.Text;

namespace ICE3
{
    public class Item
    {
        public enum Levels
        {
            Low,
            Medium,
            High
        }

        public Item(string description, DateTime date, Levels priority)
        {
            Description = description;
            Date = date;
            Priority = priority;
        }

        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Levels Priority { get; set; }

        public override string ToString()
        {
            return this.Date + " - " + this.Description + " (" + this.Priority + ")";

        }



    }
}
