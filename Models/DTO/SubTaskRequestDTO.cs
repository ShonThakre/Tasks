namespace TasksAPI.Models.DTO
{
    public class SubTaskRequestDTO
    {
        public int MainTaskId { get; set; }

        public string Title { get; set; }

        public bool Status { get; set; } = true;

    }
}
