using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class RoomDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        public int Number { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
