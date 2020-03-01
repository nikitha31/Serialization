using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Serialization
{
    class Program
    {
        public static GenreEnum Romance { get; set; }

        static void Main(string[] args)
        {
            string x = "byyhgbuyhda";
            Books b = new Books("1234", "abc", "scfdf", "jnjn", GenreEnum.Romance, "dcd", new DateTime(2020, 12, 31), "byuyuhhj ", new DateTime(2020, 12, 21));
            Books b2 = new Books("1234", "abc", "scfdf", "jnjn", GenreEnum.Romance, "dcd", new DateTime(2020, 12, 31), "byuyuhhj ", new DateTime(2020, 12, 21));
            Books[] b1 = new Books[2] { b, b2 };
            Catalog c = new Catalog(x, b1);

            // Serialize the object data to a file
            Stream stream = File.Open("BookOpen.xml", FileMode.Create);
            XmlSerializer bf = new XmlSerializer(typeof(Catalog));

            // Send the object data to the file
            bf.Serialize(stream, c);
            stream.Close();


            Catalog catalog = null;
            FileStream stream1 = File.Open("books1.xml", FileMode.Open);
            //XmlRootAttribute xRoot = new XmlRootAttribute();
            //xRoot.ElementName = "catalog";
            XmlSerializer xs = new XmlSerializer(typeof(Catalog));
            catalog = (Catalog)xs.Deserialize(stream1);
            int k = catalog.book.Length;
            int i = 0;
            Console.WriteLine("Catalog");
            Console.WriteLine("Catalog Date:" + catalog.date);
            while (i < k)
            {
                Console.WriteLine("\t" + "Book ID : " + catalog.book[i].id);
                Console.WriteLine("\t" + "Author : " + catalog.book[i].Author);
                Console.WriteLine("\t" + "Title : " + catalog.book[i].Title);
                Console.WriteLine("\t" + "Genre : " + catalog.book[i].Genre);
                Console.WriteLine("\t" + "Publisher : " + catalog.book[i].Publisher);
                Console.WriteLine("\t" + "Publish Date : " + catalog.book[i].Publish_Date);
                Console.WriteLine("\t" + "Description : " + catalog.book[i].Description);
                Console.WriteLine("\t" + "Registration Date : " + catalog.book[i].Registration_Date);
                Console.WriteLine();
                i++;
            }
            JsonSerializer jsonSerializer = new JsonSerializer();
           // Stream sw = File.Open("Boo.json", FileMode.Create);
            using (var sw = new StreamWriter(@"C:\Users\JEVANI NIKITHA\source\repos\Serialization\Serialization\bin\Debug\boo.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                jsonSerializer.Serialize(writer, catalog);
            }
            FileStream s1 = File.Open("boo.json", FileMode.Open);
            Console.WriteLine(s1.ToString());
           // Stream SS = new NetworkStream(S);
            StreamReader reader = new StreamReader(s1);
            string MSG = reader.ReadLine();
           // Console.WriteLine(MSG);
            JObject parsed = JObject.Parse(MSG);

            foreach (var pair in parsed)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
            Console.ReadKey();
        }


public IEnumerator<Catalog> GetEnumerator()
{
    return (IEnumerator<Catalog>)this;
}

public void Reset()
{
    throw new NotImplementedException();
}
    }
}
