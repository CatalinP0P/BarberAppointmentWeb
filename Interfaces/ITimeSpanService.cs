namespace BarberApp.Interfaces
{
    public interface ITimeSpanService
    {
        List<string> GetTimeSpan(int StartHour, int EndHour, int interval);
    }


    public class TimeSpanService : ITimeSpanService
    {
        public List<string> GetTimeSpan(int StartHour, int EndHour, int interval)
        {
            List<string> TimeSpan = new List<string>();

            DateTime StartDate = DateTime.Parse($"1/1/2023 {StartHour}:00");
            DateTime EndDate = DateTime.Parse($"1/1/2023 {EndHour}:00");


            for ( DateTime date = StartDate; date<=EndDate; date = date.AddMinutes(interval) )
            {
                string time;
                if ( date.Minute >= 10 )
                    time = $"{date.Hour}:{date.Minute}";
                else
                {
                    time = $"{date.Hour}:0{date.Minute}";
                }
                TimeSpan.Add(time);
            }

            return TimeSpan;
        }
    }

}