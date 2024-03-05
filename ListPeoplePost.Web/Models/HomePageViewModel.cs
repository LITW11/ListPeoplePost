using System;
using System.Collections.Generic;
using ListPeoplePost.Data;

namespace ListPeoplePost.Web.Models
{
    public class HomePageViewModel
    {
        public List<Person> People { get; set; }
        public string Message { get; set; }
    }
}
