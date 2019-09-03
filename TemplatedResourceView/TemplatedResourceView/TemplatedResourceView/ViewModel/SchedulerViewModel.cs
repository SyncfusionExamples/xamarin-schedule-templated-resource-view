using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TemplatedResourceView
{
    public class SchedulerViewModel
    {
        /// <summary>
        /// current day meetings 
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// minimum time meetings
        /// </summary>
        private List<string> minTimeMeetings;

        /// <summary>
        /// color collection
        /// </summary>
        private List<Color> colorCollection;

        /// <summary>
        /// list of meeting
        /// </summary>
        private ObservableCollection<Event> events;

        /// <summary>
        /// name collection
        /// </summary>

        internal List<string> nameCollection;

        /// <summary>
        /// resources
        /// </summary>
        private ObservableCollection<object> employees;

        /// <summary>
        /// selected Resources
        /// </summary>
        private ObservableCollection<object> selectedEmployees;

        public SchedulerViewModel()
        {
            this.events = new ObservableCollection<Event>();
            employees = new ObservableCollection<object>();
            selectedEmployees = new ObservableCollection<object>();
            this.InitializeDataForBookings();
            this.InitializeResources();
            this.BookingAppointments();
        }

        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region ListOfMeeting

        /// <summary>
        /// Gets or sets list of meeting
        /// </summary>
        public ObservableCollection<Event> Events
        {
            get
            {
                return this.events;
            }

            set
            {
                this.events = value;
                this.RaiseOnPropertyChanged("Events");
            }
        }
        #endregion

        public ObservableCollection<object> Employees
        {
            get
            {
                return employees;
            }

            set
            {
                employees = value;
                this.RaiseOnPropertyChanged("Employees");
            }
        }


        public ObservableCollection<object> SelectedEmployees
        {
            get
            {
                return selectedEmployees;
            }

            set
            {
                selectedEmployees = value;
                this.RaiseOnPropertyChanged("SelectedEmployees");
            }
        }

        private void InitializeResources()
        {
            Random random = new Random();
            for (int i = 0; i < 15; i++)
            {
                Employees.Add(new Employee()
                {
                    Name = nameCollection[random.Next(0, 14)],
                    Color = Color.FromRgb(random.Next(0, 255), random.Next(10, 255), random.Next(100, 255)),
                    Id = "560" + i.ToString(),
                    IsAvailable = true
                });
            }

            for (int i = 0; i < 10; i++)
            {
                SelectedEmployees.Add(Employees[random.Next(Employees.Count)]);
            }
        }

        #region BookingAppointments

        /// <summary>
        /// Method for booking appointments.
        /// </summary>
        private void BookingAppointments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();

            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-80);
            DateTime dateTo = DateTime.Now.AddDays(80);
            DateTime dateRangeStart = DateTime.Now.AddDays(-70);
            DateTime dateRangeEnd = DateTime.Now.AddDays(70);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                {
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 3; additionalAppointmentIndex++)
                    {
                        Event meeting = new Event();
                        int hour = randomTime.Next((int)randomTimeCollection[additionalAppointmentIndex].X, (int)randomTimeCollection[additionalAppointmentIndex].Y);
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 14), 0, 0);
                        meeting.To = meeting.From.AddHours(randomTime.Next(1, 3));
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.colorCollection[randomTime.Next(9)];
                        meeting.IsAllDay = false;
                        meeting.StartTimeZone = string.Empty;
                        meeting.EndTimeZone = string.Empty;
                        meeting.Resources = new ObservableCollection<object>
                        {
                            (employees[randomTime.Next(Employees.Count)] as Employee).Id
                        };

                        this.Events.Add(meeting);
                    }
                }
                else
                {
                    Event meeting = new Event();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    meeting.To = meeting.From.AddDays(2).AddHours(1);
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.Color = this.colorCollection[randomTime.Next(9)];
                    meeting.IsAllDay = true;
                    meeting.StartTimeZone = string.Empty;
                    meeting.EndTimeZone = string.Empty;
                    var coll = new ObservableCollection<object>
                    {
                        (employees[randomTime.Next(Employees.Count)] as Employee).Id
                    };
                    meeting.Resources = coll;

                    this.Events.Add(meeting);
                }
            }
        }

        #endregion BookingAppointments

        #region GettingTimeRanges

        /// <summary>
        /// Method for get timing range.
        /// </summary>
        /// <returns>return time collection</returns>
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }

        #endregion GettingTimeRanges

        #region InitializeDataForBookings

        /// <summary>
        /// Method for initialize data bookings.
        /// </summary>
        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");
            this.currentDayMeetings.Add("Yoga Therapy");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");

            // MinimumHeight Appointment Subjects
            this.minTimeMeetings = new List<string>();
            this.minTimeMeetings.Add("Work log alert");
            this.minTimeMeetings.Add("Birthday wish alert");
            this.minTimeMeetings.Add("Task due date");
            this.minTimeMeetings.Add("Status mail");
            this.minTimeMeetings.Add("Start sprint alert");

            this.colorCollection = new List<Color>();
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));

            this.nameCollection = new List<string>();
            this.nameCollection.Add("Brooklyn");
            this.nameCollection.Add("James William");
            this.nameCollection.Add("Sophia");
            this.nameCollection.Add("Stephen");
            this.nameCollection.Add("Zoey Addison");
            this.nameCollection.Add("Daniel");
            this.nameCollection.Add("Emilia");
            this.nameCollection.Add("Adeline Ruby");
            this.nameCollection.Add("Kinsley Elena");
            this.nameCollection.Add("Danial William");
            this.nameCollection.Add("Stephen Addison");
            this.nameCollection.Add("Kinsley Ruby");
            this.nameCollection.Add("Adeline Elena");
            this.nameCollection.Add("Emilia William");
            this.nameCollection.Add("Danial Addison");
        }

        #endregion InitializeDataForBookings

        #region Property Changed Event

        /// <summary>
        /// Invoke method when property changed
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
