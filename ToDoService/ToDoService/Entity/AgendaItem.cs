using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoService.Entity
{
    public class AgendaItem
    {
        public int AgendaItemId { get; set; }
        public String Title { get; set; }

        public String Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> DueBy { get; set; }


        public int PriorityOrder { get; set; }

        public AgendaPicture AgendaPicture { get; set; }
    }
}
