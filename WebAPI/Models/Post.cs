using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Post
    {
        [Key]

        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int UserId { get; set; } //post krny wly user ki id
    }
}

