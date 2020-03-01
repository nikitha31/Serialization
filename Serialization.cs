using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
	public enum GenreEnum
	{
		Computer,
		Fantasy,
		Romance,
		Horror,
		ScienceFiction
	}
	[Serializable()]
	[XmlRoot(ElementName = "catalog", Namespace = "http://library.by/catalog")]
	public class Catalog : ISerializable
	{
		[XmlAttribute]
		public string date { get; set; }
		
		//[XmlArrayItem("book")]
		[XmlElement(ElementName ="book")]
		public Books[] book { get; set; }


		public Catalog()
		{
			
		}
		
		public Catalog(string Date,Books[] Book)
		{
			date=Date;
			book = Book;
		}
		public Catalog(SerializationInfo info, StreamingContext context)
		{
			
			date = (string)info.GetValue("date", typeof(string));
			book = (Books[])info.GetValue("book", typeof(Books[]));
			
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
				throw new System.ArgumentNullException("info");
			info.AddValue("Date", date);
			info.AddValue("Book",book);
		}



	}
	[Serializable()]
	public class Books : ISerializable
	{
		[XmlAttribute]
		public string id { get; set; }
		[XmlElement(ElementName = "isbn")]
		public string Isbn { get; set; }
		[XmlElement(ElementName = "author")]
		public string Author { get; set; }
		[XmlElement(ElementName = "title")]
		public string Title { get; set; }
		[XmlElement(ElementName = "genre")]
		public GenreEnum Genre { get; set; }
		[XmlElement(ElementName = "publisher")]
		public string Publisher { get; set; }
		[XmlElement(ElementName = "publish_date")]
		public DateTime Publish_Date { get; set; }
		[XmlElement(ElementName = "description")]
		public string Description { get; set; }
		[XmlElement(ElementName = "registration_date")]
		public DateTime Registration_Date { get; set; }
		public Books() { }
		public Books(string id1, string isbn, string author, string title, GenreEnum genre, string publisher, DateTime publishDate, string description, DateTime registrationDate)
		{
			id = id1;
			Isbn = isbn;
			Author = author;
			Title = title;
			Genre = genre;
			Publisher = publisher;
			Publish_Date = publishDate;
			Description = description;
			Registration_Date = registrationDate;
		}
		public Books(SerializationInfo info, StreamingContext context)
		{
			id = (string)info.GetValue("id", typeof(string));
			Isbn = (string)info.GetValue("Isbn", typeof(string));
			Author = (string)info.GetValue("Author", typeof(string));
			Title = (string)info.GetValue("Title", typeof(string));
			Genre = (GenreEnum)info.GetValue("Genre", typeof(GenreEnum));
			Publisher = (string)info.GetValue("Publisher", typeof(string));
			Publish_Date = (DateTime)info.GetValue("Publish_Date", typeof(DateTime));
			Description = (string)info.GetValue("Description", typeof(string));
			Registration_Date = (DateTime)info.GetValue("Registration_Date", typeof(DateTime));
		}
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("id", id);
			info.AddValue("Isbn", Isbn);
			info.AddValue("Author", Author);
			info.AddValue("Title", Title);
			info.AddValue("Genre", Genre);
			info.AddValue("Publisher", Publisher);
			info.AddValue("Description", Description);
			info.AddValue("Registration_Date", Registration_Date);
		}
	}
}
