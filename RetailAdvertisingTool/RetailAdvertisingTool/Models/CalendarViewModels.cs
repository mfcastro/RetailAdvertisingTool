﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calendar.ASP.NET.MVC5.Models
{
    /// <summary>
    /// A view model for the UpcomingEvents view.
    /// </summary>
    public class UpcomingEventsViewModel
    {
        /// <summary>
        /// Gets or sets a sequence of event groups to display.
        /// </summary>
        [Required]
        public IEnumerable<CalendarEventGroup> EventGroups { get; set; }
    }
}