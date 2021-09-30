﻿using CharlieBackend.Core.DTO.Homework;
using CharlieBackend.Core.DTO.HomeworkStudent;
using CharlieBackend.Core.DTO.Visit;
using CharlieBackend.Core.Models.ResultModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharlieBackend.Business.Services.Interfaces
{
    public interface IHomeworkService
    {
        Task<Result<HomeworkDto>> CreateHomeworkAsync(HomeworkRequestDto homeworkDto);

        Task<Result<HomeworkDto>> GetHomeworkByIdAsync(long homeworkId);

        Task<Result<HomeworkDto>> UpdateHomeworkAsync(long homeworkId, HomeworkRequestDto updateHomeworkDto);

        Task<Result<IList<HomeworkDto>>> GetHomeworksByLessonId(long studentGroupId);

        Task<Result<VisitDto>> UpdateMarkAsync(UpdateMarkRequestDto request);
    }
}
