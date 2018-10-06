using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoService.Entity
{
    public class AgendaPicture
    {
        public int AgendaPictureId { get; set; }

        public byte[] BinaryPictureData { get; set; }

        public AgendaItem AgendaItem { get; set; }
        public int AgendaItemId { get; set; }

    }
}
