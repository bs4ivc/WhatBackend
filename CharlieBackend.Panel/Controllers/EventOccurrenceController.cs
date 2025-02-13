﻿using AutoMapper;
using CharlieBackend.Core.DTO.Schedule;
using CharlieBackend.Panel.Models.EventOccurrence;
using CharlieBackend.Panel.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharlieBackend.Panel.Controllers
{
    [Authorize(Roles = "Admin, Secretary")]
    [Route("[controller]/[action]")]
    public class EventOccurrenceController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public EventOccurrenceController(IScheduleService scheduleService, IMapper mapper)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> AllEventOccurrences()
        {
            var allEventOccurences = await _scheduleService.GetAllEventOccurrences();

            var result = new List<EventOccurrenceViewModel>();

            foreach (var item in allEventOccurences)
            {
                result.Add(EventOccurrenceViewModel.FromEventOccurrenceDTO(item));
            }

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEventOccurrenceById(long id)
        {
            var eventOccurence = await _scheduleService.GetEventOccurrenceById(id);

            return View(EventOccurrenceViewModel.FromEventOccurrenceDTO(eventOccurence));
        }

        [HttpGet]
        public async Task<IActionResult> CreateEventOccurrence()
        {
            var eventOccurrenceData = await _scheduleService.PrepareStudentGroupAddAsync();

            ViewBag.EventOccurrence = eventOccurrenceData;

            return View("AddEventOccurrence");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PrepareEventOccurrenceForUpdate(long id)
        {
            var eventOccurrenceData = await _scheduleService.PrepareStudentGroupAddAsync();

            ViewBag.EventOccurrence = eventOccurrenceData;
            ViewBag.CurrentId = id;

            return View("UpdateEventOccurrence");
        }

        [HttpPost]
        public async Task<IActionResult> AddEventOccurrence(CreateScheduleDto scheduleDTO)
        {
            await _scheduleService.CreateScheduleAsync(scheduleDTO);

            return RedirectToAction("AllEventOccurrences", "EventOccurrence");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateEventOccurrence(long id, CreateScheduleDto scheduleDTO)
        {
            await _scheduleService.UpdateScheduleByIdAsync(id, scheduleDTO);

            return RedirectToAction("AllEventOccurrences", "EventOccurrence");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteEventOccurrence(long id)
        {
            await _scheduleService.DeleteScheduleByIdAsync(id);

            return RedirectToAction("AllEventOccurrences", "EventOccurrence");
        }
    }
}
