﻿using CharlieBackend.Panel.Models.Mentor;
using CharlieBackend.Panel.Models.StudentGroups;
using CharlieBackend.Panel.Models.Theme;
using System;
using System.Collections.Generic;

namespace CharlieBackend.Panel.Models.EventOccurrence
{
    public class EventOccurrenceEditViewModel
    {
        public long? Id { get; set; }

        public long StudentGroupId { get; set; }

        public DateTime? EventStart { get; set; }

        public DateTime? EventFinish { get; set; }

        public long Storage { get; set; }

        public IList<MentorViewModel> AllMentors { get; set; }

        public IList<StudentGroupViewModel> AllStudentGroups { get; set; }

        public IList<ThemeViewModel> AllThemes { get; set; }
    }
}
