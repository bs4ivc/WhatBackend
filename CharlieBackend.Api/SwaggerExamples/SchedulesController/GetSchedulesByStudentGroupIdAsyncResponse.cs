﻿using CharlieBackend.Core.DTO.Schedule;
using CharlieBackend.Core.Entities;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieBackend.Api.SwaggerExamples.SchedulesController
{
    internal class GetSchedulesByStudentGroupIdAsyncResponse : IExamplesProvider<IList<EventOccurenceDTO>>
    {
        public IList<EventOccurenceDTO> GetExamples()
        {
            return new List<EventOccurenceDTO>()
            {
                new EventOccurenceDTO
                {
                    Id = 14,
                    StudentGroupId = 24,
                    EventStart = new DateTime(2020, 10, 12, 10, 15, 00),
                    EventFinish = new DateTime(2020, 10, 12, 10, 15, 00),
                    Pattern = PatternType.Daily
                },
                new EventOccurenceDTO
                {
                    Id = 15,
                    StudentGroupId = 24,
                    EventStart = new DateTime(2020, 10, 12, 10, 15, 00),
                    EventFinish = new DateTime(2020, 10, 12, 10, 15, 00),
                    Pattern = PatternType.Weekly
                }
            };
        }
    }
}
