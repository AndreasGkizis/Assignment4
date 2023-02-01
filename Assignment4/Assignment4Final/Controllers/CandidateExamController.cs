﻿using Assignment4Final.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models;
using ModelLibrary.Models.DTO.CandidateExam;
using ModelLibrary.Models.DTO.Exams;
using ModelLibrary.Models.Exams;

namespace Assignment4Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateExamController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly CandidateExamService _candExamService;
        private readonly ExamService _examService;
        public CandidateExamController(UserManager<AppUser> userManager, CandidateExamService candExamService, ExamService examService)
        {
            _userManager = userManager;
            _candExamService = candExamService;
            _examService = examService;

        }


        [HttpPost("{examDto}")] //Get : when the candidate picks an exam it makes a candidate exam for this candidate and the exam he picked
        public async Task<ActionResult<CandidateExam>> GetCandidateExamFromPickedExam([FromBody] ExamDto examDto)
        {
            var exam = _examService.GetExamFromExamDto(examDto);

            var userId = _userManager.GetUserId(User);
            var candidateExam = await _candExamService.GetCandidateExamByExam(exam, userId);
            await Task.Run(() => _candExamService.AddCandidateExam(ref candidateExam));
            var candidateExamDto = _candExamService.GetCandidateExamDtoFromCandidateExam(candidateExam);

            return Ok(candidateExamDto);
        }


        [HttpGet]
        public async Task<ActionResult<List<CandidateExamDto>>> GetAllCandidateExamsOfCandidate()
        {

            var candidate = await _candExamService.GetCandidateByUserId(_userManager.GetUserId(User));
            var candidateExamsList = await _candExamService.GetAllCandidateExamsOfCandidateAsync(candidate);
            return Ok(await Task.Run(() => _candExamService.GetListOfCandidateExamDtosFromListOfCandidateExam(candidateExamsList)));

        }

        [HttpGet("notTaken")]
        public async Task<ActionResult<List<CandidateExamDto>>> GetTakenCandidateExamsOfCandidate() //Not Debuged all the candidate exams in Seed are Taken . Should i checke if taken by ExamDate?
        {
            var candidate = await _candExamService.GetCandidateByUserId(_userManager.GetUserId(User));
            var candidatesTakenExams = await _candExamService.GetTakenCandidateExamsOfCandidateAsync(candidate);
            return Ok(_candExamService.GetListOfCandidateExamDtosFromListOfCandidateExam(candidatesTakenExams));

        }
    }
}