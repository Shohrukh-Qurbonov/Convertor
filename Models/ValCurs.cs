using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Convertor.Models
{
    public class ValCurs
    {
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "Date")]
		public string Date { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Valute")]
		public virtual List<Valute> Valute { get; set; }
	}
}
