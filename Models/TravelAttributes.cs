using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moment2.Models
{
    public class TravelAttributes
    {
        public int Id { get; set; }                 //Id för attribut
        public string AttributeName { get; set; }   //Attribut för resa

        //Konstruktor
        public TravelAttributes(int id, string attributeName)
        {
            this.Id = id;
            this.AttributeName = attributeName;
        }
    }

    //ViewModel med lista av id:n och reseattribut
    public class ViewModeln
    {
        public IEnumerable<TravelAttributes> TravelAttributesList { get; set; }
    }
}
