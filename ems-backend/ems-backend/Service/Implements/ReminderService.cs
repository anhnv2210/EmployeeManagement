using ems_backend.Data.DataContext;
using ems_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ems_backend.Service.Implements
{
    public class ReminderService
    {
        private readonly AppDbContext _context;

        public ReminderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reminder>> GetAllRemindersAsync()
        {
            var reminderSettings = await _context.ReminderSettings.ToListAsync();
            var employees = await _context.NhanViens.ToListAsync();

            var reminders = new List<Reminder>();

            foreach (var employee in employees)
            {
                foreach (var setting in reminderSettings)
                {
                    DateTime eventDate = GetEventDate(employee, setting.EventType);
                    DateTime reminderDate = CalculateReminderDate(eventDate, setting.DaysBeforeReminder);

                    if (reminderDate >= DateTime.Now.Date)
                    {
                        reminders.Add(new Reminder
                        {
                            NhanVienId = employee.Id,
                            HoTenNhanVien = employee.Hoten,
                            LoaiSuKien = setting.EventType,
                            NgayCuThe = reminderDate
                        });
                    }
                }
            }

            return reminders;
        }

        private DateTime GetEventDate(NhanVien employee, string eventType)
        {
            switch (eventType)
            {
                case "Birthday":
                    return employee.NgaySinh;

                case "ContractExpiration":
                    return (DateTime) employee.NgayKetThucLamViec;

                case "ProbationEnd":
                    return (DateTime)employee.NgayKetThucLamViec;

                default:
                    throw new ArgumentException("Invalid event type", nameof(eventType));
            }
        }

        private DateTime CalculateReminderDate(DateTime eventDate, int daysBeforeReminder)
        {
            int maxDaysToSubtract = (eventDate - DateTime.MinValue).Days;
            int daysBeforeReminderToUse = Math.Min(daysBeforeReminder, maxDaysToSubtract);
            return eventDate.AddDays(-daysBeforeReminderToUse);
        }
    }
}
