using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TemplatedResourceView
{
    public class ResourceTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AvailableResourceTemplate { get; set; }
        public DataTemplate UnavailableResourceTemplate { get; set; }

        public ResourceTemplateSelector()
        {
            AvailableResourceTemplate = new DataTemplate(typeof(AvailableResourceTemplate));
            UnavailableResourceTemplate = new DataTemplate(typeof(UnavailableResourceTemplate));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if ((item as Employee).IsAvailable)
                return AvailableResourceTemplate;
            else
                return UnavailableResourceTemplate;
        }
    }
}
