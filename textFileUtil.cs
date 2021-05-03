using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ICE3
{
    class textFileUtil

    {
        public static void writeToFile(List<Item> items)
        {
            try
            {
                using (StreamWriter output = new StreamWriter("ToDoList.txt"))
                {
                    foreach (Item itemOutput in items)
                        output.WriteLine(itemOutput.Description + "#" + 
                                         itemOutput.Date + "#" + itemOutput.Priority);

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static List<Item> readFromFile()
        {
            List<Item> temp = new List<Item>();

            try
            {
                using (StreamReader reader = new StreamReader("ToDoList.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] lineParts = line.Split('#');

                        string desc = lineParts[0];
                        string date = lineParts[1];

                        string[] dateParts = date.Split('/');

                        int year = Convert.ToInt32(dateParts[0]);
                        int month = Convert.ToInt32(dateParts[1]);
                        int day = Convert.ToInt32(dateParts[2].Substring(0, 2));

                        DateTime d = new DateTime(year, month, day);

                        string priority = lineParts[2];
                        Item.Levels level;
                        switch (priority)
                        {
                            case "Low":
                                level = Item.Levels.Low;
                                break;
                            case "Medium":
                                level = Item.Levels.Medium;
                                break;
                            default:
                                level = Item.Levels.High;
                                break;
                        }

                        Item i = new Item(desc, d, level);
                        temp.Add(i);

                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);

            }
            return (temp);
        }
    }
}
