using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Summary { get; set; }

        public string Image { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        public int CommentCount { get; set; }

        public int LikeCount { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Comments = new HashSet<Comment>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            CommentCount = 0;
            LikeCount = 0;
        }
    }
} 