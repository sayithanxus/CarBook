﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        [Column(TypeName ="Date")]
        public DateOnly PickUpDate { get; set; }
        [Column(TypeName = "Time")]
        public TimeOnly PickUpTime { get; set; }
        [Column(TypeName = "Date")]
        public DateOnly DropOffDate { get; set; }
        [Column(TypeName = "Time")]
        public TimeOnly DropOffTime { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public string PickUpDescription { get; set; }
        public string DropOffDescription { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
