using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace SaveToXmlOrJson
{     /// <summary>
      /// methods are being used for buttons clicks 
      /// </summary>
    public class Utility
    {
       
        public  ObservableCollection<Cat> Cats { get; set; }
        public List<Cat> tempCats;
        public Cat NewCat { get; set; }
        public Repository Repository { get; set; }

        public Utility(Repository repository)
        {
            Repository = repository;
            Cats = new ObservableCollection<Cat>(Repository.Cats);
            tempCats = new List<Cat>();
            NewCat = new Cat();
        }

        /// <summary>
        /// Saves current collection to Xml file
        /// </summary>
        public void SaveAsXML()
        {
            tempCats = new List<Cat>(Cats);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Cat>));
            FileStream fs = new FileStream("Cats.xml", FileMode.Create);
            using (fs)
            {
                formatter.Serialize(fs, tempCats);
                fs.Close();
                tempCats.Clear();
            }
        }

        /// <summary>
        /// Loads collection from Xml file and replaces current collection
        /// </summary>
        public void LoadFromXml()
        {
            
            
            XmlSerializer formatter = new XmlSerializer(typeof(List<Cat>));
            using (FileStream fs = new FileStream("Cats.xml", FileMode.OpenOrCreate))
            {
                tempCats = (List<Cat>)formatter.Deserialize(fs);
                Cats.Clear();               
                fs.Close();
                foreach (var item in tempCats)
                {
                    Cats.Add(item);
                }
            }
               
               
            
        }
        /// <summary>
        /// Saves current collection to Json file
        /// </summary>
        public void SaveAsJson()
        {
            using (StreamWriter fs = File.CreateText("Cats.json"))
            {
                tempCats = new List<Cat>(Cats);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(fs, tempCats);
                fs.Close();
            }
        }

        /// <summary>
        /// Loads collection from Json file and replaces current collection
        /// </summary>
        public void LoadFromJson()
        {
            Cats.Clear();
            using (StreamReader fs = File.OpenText("Cats.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                tempCats = (List<Cat>)serializer.Deserialize(fs, typeof(List<Cat>));
                foreach (var item in tempCats)
                {
                    Cats.Add(item);
                }
                
            }
        }
        /// <summary>
        /// randomly generates new instane of Cat and adda it to current collection
        /// </summary>
        public void GenerateRandomCat()
        {
            NewCat = new Cat();
            var rn = new Random();
            NewCat.Name = Repository.Names[rn.Next(Repository.Names.Count)];
            NewCat.Breed = Repository.Breeds[rn.Next(Repository.Breeds.Count)];
            NewCat.Color = Repository.Colors[rn.Next(Repository.Colors.Count)];
            NewCat.Age = rn.Next(1,10);
            NewCat.Weight = ((double)rn.Next(800) + 200.0) / 100.0;
            Cats.Add(NewCat);
        }
        /// <summary>
        /// adds manually entered Cat data (after validation)
        /// </summary>
        public void AddEnteredData()
        {
            if (!ValidateEnteredData(NewCat))
            {
                MessageBox.Show("Some data is missing!!!");
                return;
            }
            Cats.Add(NewCat);
        }

        /// <summary>
        /// validates entered Cat data
        /// </summary>
        /// <returns></returns>
        public bool ValidateEnteredData(Cat cat)
        {
            return !string.IsNullOrWhiteSpace(cat.Name)
                    && !string.IsNullOrWhiteSpace(cat.Breed)
                    && !string.IsNullOrWhiteSpace(cat.Color)
                    && cat.Age != 0
                    && cat.Weight != 0.0;
        }

    }
}
