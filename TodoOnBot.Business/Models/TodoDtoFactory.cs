using TodoOnBot.Common.Models;

namespace TodoOnBot.Business.Models
{
    public static class TodoDtoFactory
    {
        public static TodoDto Create(long userId, string name, string dueDateInText, string priorityInText)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name is required!");

            var isParsingSuccessed = DateTime.TryParseExact(dueDateInText, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dueDate);

            if (!isParsingSuccessed)
                throw new Exception("Due date has incorrect format");

            var priority = Enum.Parse<Priority>(priorityInText);

            return new TodoDto
            {
                UserId = userId,
                Name = name,
                DueDate = dueDate,
                Priority = priority,
                IsCompleted = false
            };
        }
    }
}