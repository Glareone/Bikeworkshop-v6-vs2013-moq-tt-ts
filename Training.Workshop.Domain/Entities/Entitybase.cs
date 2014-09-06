using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Training.Workshop.Domain.Entities
{
    [XmlInclude(typeof(User))]
    [XmlInclude(typeof(Bike))]
    [XmlInclude(typeof(Sparepart))]
    [Serializable]
    public abstract class Entitybase
    {
    }
}
