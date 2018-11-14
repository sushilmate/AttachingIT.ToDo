using System;
using System.Collections.Generic;

namespace AttachingITToDo.WebUI.Models
{
    public partial class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public bool Complete { get; set; }
    }
}
