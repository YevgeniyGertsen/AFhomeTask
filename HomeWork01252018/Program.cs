using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork01252018.Model;
using System.Xml.Linq;
using System.IO;
namespace HomeWork01252018
{
    class Program
    {
        static MyDataBase db = new MyDataBase();
        static void Main(string[] args)
        {
            //Task1();
            Task2();


        }

        public static void Task1()
        {
            //a.	Все зоны/участки которые принадлежат PavilionId = 1, 
            var query =
                db.Areas
                    .Where(w => w.PavilionId == 1);

            foreach (Area item in query)
            {
                XDocument xDoc = new XDocument(
                    new XElement("Area",
                    new XElement("AreaId", item.AreaId),
                    new XElement("Name", item.Name),
                    new XElement("IP", item.IP)));
                xDoc.Save(item.AreaId+ ".xml");
            }

        }

        public static void Task2()
        {
            //b.Используя Directory класс, 
            //создать папки с название зон / участков, 
            //в каждую папку выгрузить XML файл на основе данных их таблицы.

            foreach (var item in db.Areas)
            {
                DirectoryInfo dr = new DirectoryInfo(@"C:\Users\Евгений\Desktop\AdoLesson4\AdoLesson4\bin\Debug\Areas\" + item.Name+"("+item.AreaId+")");
               dr.Create();
                    XDocument xDoc = new XDocument(
                        new XElement("Area",
                        new XElement("AreaId", item.AreaId),
                        new XElement("Name", item.Name),
                        new XElement("IP", item.IP)));
                    xDoc.Save(dr.FullName+  @"\" + item.Name.Replace(@"\","").Replace("/","") + ".xml");

            }


          




        }
    }
}
