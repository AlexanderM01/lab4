using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        List<Instruments> InstrumentsList = new List<Instruments>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var laptop = new List<Laptop>();
            var tablet = new List<Tablet>();
            var phone = new List<Phone>();
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.InstrumentsList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3)
                {
                    case 0: // если 0, то ноутбук
                        this.InstrumentsList.Add(Laptop.Generate());
                        break;
                    case 1: // если 1 то планшет
                        this.InstrumentsList.Add(Tablet.Generate());
                        break;
                    case 2: // если 2 то смартфон
                        this.InstrumentsList.Add(Phone.Generate());
                        break;
                }
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            // счетчики под каждый тип
            int laptopCount = 0;
            int tabletCount = 0;
            int phoneCount = 0;
            // пройдемся по всему списку
            foreach (var instruments in this.InstrumentsList)
            {
                if (instruments is Laptop)
                {
                    laptopCount += 1;
                }
                else if (instruments is Tablet)
                {
                    tabletCount += 1;
                }
                else if (instruments is Phone)
                {
                    phoneCount += 1;
                }
            }
            txtInfo.Text = "Ноутбyков\tПланшетов\tТелефонов";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t\t{1}\t\t{2}", laptopCount, tabletCount, phoneCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.InstrumentsList.Count == 0)
            {
                txtOut.Text = "В автомате ничего нет";
                return;
            }
            var instruments = this.InstrumentsList[0];
            this.InstrumentsList.RemoveAt(0);
            txtOut.Text = instruments.GetInfo();
            ShowInfo();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для раздачи гаджетов (размер дисплея)\nНоутбуков (подсветка клавиатуры, количество ядер, объем жесткого диска)" +
                "\nПланшетов (наличие камеры, dpi экрана)\nСмартфонов (количество слотов под sim карту, количество мегапикселей у камеры, батарея)", "Задание");
        }
    }
}
