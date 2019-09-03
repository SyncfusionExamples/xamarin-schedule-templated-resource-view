using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace TemplatedResourceView
{
    public class SchedulerPageBehavior : Behavior<ContentPage>
    {
        SfSchedule schedule;
        Random random;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.schedule = bindable.Content.FindByName<SfSchedule>("schedule");
            this.random = new Random();
            this.WireEvents();
        }

        private void WireEvents()
        {
            this.schedule.VisibleDatesChangedEvent += OnVisibleDatesChangedEvent;
        }

        private void OnVisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
        {
            var count = 5;
            for (int i = 0; i < count; i++)
            {
                (schedule.ScheduleResources[this.random.Next(schedule.ScheduleResources.Count)] as Employee).IsAvailable = false; ;
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.UnWireEvents();
        }

        private void UnWireEvents()
        {
            this.schedule.VisibleDatesChangedEvent -= OnVisibleDatesChangedEvent;
        }
    }
}
