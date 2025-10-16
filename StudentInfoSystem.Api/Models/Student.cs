using System;
using System.ComponentModel.DataAnnotations;

namespace StudentInfoSystem.Api.Models
{
	public class Student
	{
		[Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [Range(100,999)]
        public int Number { get; set; }

        [Required]
        [MaxLength(1)]
        public string Class { get; set; }

	}
}

