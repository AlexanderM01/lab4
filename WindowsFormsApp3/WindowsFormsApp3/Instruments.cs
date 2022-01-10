using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Instruments
    {
        public static Random rnd = new Random();
        public virtual String GetInfo()
        {
            return "Техника";
        }
    }
    
    //Класс ноутбук
    public class Laptop : Instruments
    {
        public int HDDCapacity = 0; // Объём жёсткого диска
        public int Cores = 0; // Количество ядер
        public bool KeyboardBacklight = false; // Подсветка клавиатуры
        public override String GetInfo()
        {
            var str = "";
            str = "Ноутбук Acer Nitro 5";
            str += String.Format("\nКоличество ядер: {0}", this.Cores);
            str += String.Format("\nОбъём Жёсткого диска: {0}", this.HDDCapacity);
            str += String.Format("\nПодсветка клавиатуры: {0}", this.KeyboardBacklight);
            return str;
        }
        public static Laptop Generate()
        {
            int[] arrHDD = new int[4] { 120, 512, 256, 1024 };
            int[] arrCores = new int[3] { 4, 8, 16 };
            return new Laptop
            {
                HDDCapacity = arrHDD[rnd.Next() % 4],
                Cores = arrCores[rnd.Next() % 3],
                KeyboardBacklight = Convert.ToBoolean(rnd.Next() % 2),
            };
        }
    }
    //Класс планшет
    public class Tablet : Instruments
    {
        public bool Camera = false; // Наличие камеры
        public int Dpi = 0; // dpi экрана
        public override String GetInfo()
        {
            var str =  "Планшет Apple Ipad Pro 2021";
            str += String.Format("\nНаличие камеры: {0}", this.Camera);
            str += String.Format("\ndpi экрана: {0}", this.Dpi);
            return str;
        }
        public static Tablet Generate()
        {
            int[] arrDPI = new int[3] { 275, 280, 260 };
            return new Tablet
            {
                Camera = Convert.ToBoolean(rnd.Next() % 2),
                Dpi = arrDPI[rnd.Next() % 2],
            };
        }
    }
    //Класс смартфон
    public class Phone : Instruments
    {
        public int SIMCards = 0; // Количество слотов под сим карту
        public int Megapixels = 0; // Количество мегапикселей камеры
        public int battery = 0; // Батарея
        public override String GetInfo()
        {
            var str =  "Смартфон Apple Iphone 13";
            str += String.Format("\nКоличество слотов под сим карту: {0}", this.SIMCards);
            str += String.Format("\nКоличество мегапикселей камеры: {0}", this.Megapixels);
            str += String.Format("\nБатарея: {0}", this.battery);
            return str;
        }
        public static Phone Generate()
        {
            int[] arrSIM = new int[2] { 1, 2 };
            int[] arrPix = new int[3] { 64, 128, 32 };
            int[] arrBat = new int[3] { 4000, 3600, 4200 };
            return new Phone
            {
                SIMCards = arrSIM[rnd.Next() % 2],
                Megapixels = arrPix[rnd.Next() % 3],
                battery = arrBat[rnd.Next() % 3],
            };
        }
    }
}