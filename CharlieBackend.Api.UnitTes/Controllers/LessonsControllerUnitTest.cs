﻿using System.Collections.Generic;
using Xunit;
using System.Threading.Tasks;
using Moq;
using CharlieBackend.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CharlieBackend.Api.Controllers;
using CharlieBackend.Core.Models.Lesson;

namespace CharlieBackend.Api.UnitTest.Controllers
{
    public class LessonsControllerUnitTest
    {
        [Fact]
        public async Task GetAllLessons()
        {
            var lessonServiceMock = new Mock<ILessonService>();
            lessonServiceMock.Setup(repo => repo.GetAllLessonsAsync()).Returns(getLessons);
            LessonsController controller = new LessonsController(lessonServiceMock.Object);
            var GetResult = controller.GetAllLessons();
            var objectResult = GetResult.Result.Result as ObjectResult;
            var toCompare = objectResult.Value as List<LessonModel>;
            var actualResult = await getLessons();
            Assert.Equal(toCompare.Count, actualResult.Count);
        }

        public async Task<List<LessonModel>> getLessons() 
        {
            List<LessonModel> less = new List<LessonModel>()
            {
                new LessonModel { Id = 1, ThemeName = "Testst1", LessonDate = "TestSt1" },
                new LessonModel { Id = 13, ThemeName = "Testst2", LessonDate = "TestSt2" },
                new LessonModel { Id = 14, ThemeName = "Testst3", LessonDate = "TestSt3" }
            };
            return less;
        }
    }
}
