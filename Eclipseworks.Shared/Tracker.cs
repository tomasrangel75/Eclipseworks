namespace Eclipseworks.Shared
{
    public class ChangeLog
    {
        public string? PropertyName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
    }


    public static class Tracker
    {

        public static List<ChangeLog> GetChanges(object oldEntry, object newEntry)
        {
            List<ChangeLog> logs = new();

            var oldType = oldEntry.GetType();
            var newType = newEntry.GetType();

            var oldProperties = oldType.GetProperties();
            var newProperties = newType.GetProperties();

            var className = oldEntry.GetType().Name;

            foreach (var item in oldProperties)
            {
                var matchingProperty = newProperties.Where(x => x.Name == item.Name && x.PropertyType == item.PropertyType).FirstOrDefault();
                if (matchingProperty == null) continue;

                var oldValue = item.GetValue(oldEntry)?.ToString();
                var newValue = matchingProperty.GetValue(newEntry)?.ToString();

                if (matchingProperty != null && oldValue != newValue)
                {
                    logs.Add(new ChangeLog()
                    {
                        PropertyName = matchingProperty.Name,
                        OldValue = item.GetValue(oldEntry)?.ToString(),
                        NewValue = matchingProperty.GetValue(newEntry)?.ToString()
                    });
                }
            }

            return logs;
        }




    }

}
