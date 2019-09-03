using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TemplatedResourceView
{
    public class Employee
    {
        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets id
        /// </summary>
        public object Id { get; set; }

        /// <summary>
        /// Gets or sets Color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets display picture
        /// </summary>
        public string DisplayPicture { get; set; }

        /// <summary>
        /// Gets or sets whether available or not
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
