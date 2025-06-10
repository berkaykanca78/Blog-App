using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string EnglishName { get; set; }

        [Required]
        [StringLength(200)]
        public string Slug { get; set; }

        [StringLength(200)]
        public string EnglishSlug { get; set; }

        public string Description { get; set; }

        public string EnglishDescription { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Category()
        {
            Posts = new HashSet<Post>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
} 