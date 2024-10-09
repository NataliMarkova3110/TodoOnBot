using TodoOnBot.Common.Models;

namespace TodoOnBot.Data.Models
{
    public class Todo
    {
        public long TodoId { get; set; }

        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public Priority Priority { get; set; }

        public long UserId { get; set; }
    }
}