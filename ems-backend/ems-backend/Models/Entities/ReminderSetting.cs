namespace ems_backend.Models.Entities
{
    public class ReminderSetting
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public int DaysBeforeReminder { get; set; }
    }
}
