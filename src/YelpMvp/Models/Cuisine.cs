using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace YelpMvp.Models
{
    [Table("Cuisines")]
    public class Cuisine
    {
        [Key]
        public int CuisineId { get; set; }
        public string Name { get; set; }
    }
}