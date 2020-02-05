using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace moment2.Models
{
    public class Travel
    {
        //Properties med egenskaper såsom required (måste fyllas i), display (svensk översättning), maxlength (antal tecken) och datatype (specificerar datatyp)
        [Required]
        [Display (Name = "Land")]
        public string Country { get; set; }         //Landet som man har åkt till

        [Required]
        [Display(Name = "Stad")]
        public string City { get; set; }            //Staden som man har åkt till

        [Required]
        [Display(Name = "Kostnad flyg")]
        public double CostOfFlight { get; set; }    //Kostnad av flyg

        [Required]
        [Display(Name = "Kostnad hotell")]
        public double CostOfHotel { get; set; }     //Kostnad av hotell

        [MaxLength(30)]
        [Required]
        [Display (Name = "Beskrivning")]
        public string Description { get; set; }     //Kort beskrivning av resan

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Resedatum")]
        public DateTime Date { get; set; }          //Resedatum
        
        [Display(Name = "Total kostnad")]
        public double TotalCost { get; set; }       //Totala kostnaden av resan

        [Required]
        [Display(Name = "Enskild resa")]
        public bool TravelAlone { get; set; }    //Om resan gjordes på egen hand eller med någon annan
 
        //Konstruktor
        public Travel() {
            TotalCost = 1000;    //En grundavgift på 1000 kr för varje resa
        }

        //Räknar ut total kostnad för flyg och hotell av resan där grundavgiften är inräknad
        public void CalcCost()
        {
            TotalCost = TotalCost + CostOfFlight + CostOfHotel;
        }
    }
}
