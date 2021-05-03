using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE3
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            listUtil.toDoList = textFileUtil.readFromFile();
            loadListBox();
        }

       

        private void loadListBox()
        {
           lstItems.Items.Clear();
            foreach(Item t in listUtil.toDoList.OrderByDescending(l => l.Priority))
            {
                lstItems.Items.Add(t.ToString());
            }
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string desc = txtInput.Text;

            DateTime d = DateTime.Now;

            Item.Levels level;
            switch(cmbPriority.SelectedItem.ToString())
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

            Item newItems = new Item(desc, d, level);

            listUtil.toDoList.Add(newItems);

            textFileUtil.writeToFile(listUtil.toDoList);
            loadListBox();

            txtInput.Clear();
        }

        
    }
}
