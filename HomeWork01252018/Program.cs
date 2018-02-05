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
                
                DirectoryInfo dr = new
                    DirectoryInfo(@"C:\Users\Евгений\Desktop\AdoLesson4\AdoLesson4\bin\Debug\Areas\" + item.Name+"("+item.AreaId+")");
               dr.Create();
                    XDocument xDoc = new XDocument(
                        new XElement("Area",
                        new XElement("AreaId", item.AreaId),
                        new XElement("Name", item.Name),
                        new XElement("IP", item.IP)));
                    xDoc.Save(dr.FullName+  @"\" + item.Name.Replace(@"\","").Replace("/","") + ".xml");

            }

         
                
        }
         public static void Task3()
         {
         
            d.	Выгрузить из таблицы Timer, 
            данные только для зон у которых есть IP адрес, 
            при этом в XML файл должны войти следующие поля: 
            UserId, Area Name (name из Талицы Area), DateStart
                
            var timer = 
                from t in db.Timer
                where t.IP != null & t.IP != ""
                select t;
             var timer2 = db.Timer
                 .Where(t => t.IP != null & t.IP != "")
                 .Join(db.Area, a => a.AreaID, t.AreaID,(a,t)=> new{ a,t });
             
        foreach (Timer item in timer)
            {
                XDocument xDoc = new XDocument(
                    new XElement("Area",
                    new XElement("AreaId", item.t.AreaID),
                    new XElement("Name", item.a.Name),
                    new XElement("Date", item.t.DateStart),
                    new XElement("IP", item.a.IP)));
                xDoc.Save(item.AreaId+ ".xml");
            }
         public static void Task4()
         {
            // e.	Выгрузить в XML файл, данные из таблицы Timer, у которых нет даты завершения работы DateFinish =null
                var timer = 
                from t in db.Timer
                where t.DateFinish == null 
                select t;
             
                      
        foreach (Timer item in timer)
            {
                XDocument xDoc = new XDocument(
                    new XElement("Area",
                    new XElement("AreaId", item.t.AreaID),
                    new XElement("Name", item.a.Name),
                    new XElement("Date", item.t.DateStart),
                    new XElement("IP", item.a.IP)));
                xDoc.Save(item.AreaId+ ".xml");
            }
             
         } 
             
              public static void Task4()
         {
                 // f.	Выгрузить весь список выполненных работ из таблицы Timer
                   var timer = 
                from t in db.Timer
                where t.DateFinish != null
                select t;
                  
                   foreach (Timer item in timer)
            {
                XDocument xDoc = new XDocument(
                    new XElement("Area",
                    new XElement("AreaId", item.t.AreaID),
                    new XElement("Name", item.a.Name),
                    new XElement("Date", item.t.DateStart),
                    new XElement("IP", item.a.IP)));
                xDoc.Save(item.AreaId+ ".xml");
            }
              }
             
                    public static void Task4()
         {
            // g.	Выгрузить данные с таблицы Area в переменную,
           //  на основе данных в этой переменной создать XML файл имеющим Xmlns = «area», 
           //  а также namespace - http://logbook.itstep.org/
                        
                 XNameSpace s = new  XNameSpace("http://logbook.itstep.org/");
                        
                           foreach (Area item in db.Area)
            {
                    XDocument xDoc = new XDocument(s,
                        new XElement("Area",
                        new XElement("AreaId", item.t.AreaID),
                        new XElement("Name", item.a.Name),
                        new XElement("Date", item.t.DateStart),
                        new XElement("IP", item.a.IP)));
                    xDoc.Save(item.AreaId+ ".xml");
            }
                        
                public static void Task7()
               {
                     //a.	Вывести на экран поля UserId, AreaId, DocumentId из XML файла пункта F   
                     XDocument xdoc = new XDocument();
                    xdoc.Load("//myfile.xml");
                    
       foreach (var item in xdoc)
            {
              cw(item.element("UserID")) ;     
             cw(item.element("AreaId")) ;  
             cw(item.element("DocumentId")) ;  
             
            }
                    
                }
                    public static void Task7()
               {     
                      //  b.	Выгрузить все данные из XML пункта F,
                      //  заменить при этом в XML файла DateFinish =текущая дата 
                       //   и сохранить данный XML файл с наименованием – 
                       //  «TimeChangeToday_10.27.2017»
                            
                            
                        
                     XDocument xdoc = new XDocument();
                    xdoc.Load("//myfile.xml");
                      
                        var rt = xdoc.First();
                        rt.element("DateFinish") == Date.Now;
                        xdoc.Save(rt);
                        
                        
                            
                    }
                        
                    }
         }
    }
}
