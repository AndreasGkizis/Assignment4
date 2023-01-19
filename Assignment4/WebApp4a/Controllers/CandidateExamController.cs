using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;
using ModelLibrary.Models.Exams;
using System.Security.Claims;
using WebApp4a.Data;
using WebApp4a.GiannisServices;

namespace WebApp4a.Controllers
{
    public class CandidateExamController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Service _service;
        private readonly UserManager<AppUser> _userManager;

        public CandidateExamController(ApplicationDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _service = new Service(_context);
            _userManager = userManager;
        }

        public async Task<IActionResult> Results(CandidateExam candidateExam)
        {
            ViewBag.Title = "Results";
            return await Task.Run(() =>View(candidateExam));
        }


        // GET: CandidateExams
        public async Task<IActionResult> Index()
        {
            return View(await _context.CandidateExams.ToListAsync());
        }

        // GET: CandidateExams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CandidateExams == null)
            {
                return NotFound();
            }

            var candidateExam = await _context.CandidateExams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidateExam == null)
            {
                return NotFound();
            }
            //return await Task.Run(() => RedirectToAction("Exam", "Examination", candidateExam));
            return View(candidateExam);
        }

        // GET: CandidateExams/Create
        public IActionResult Create()
        {

            var list = _service.GetExamsSelectList(_service.GetAllExams());
            ViewData.Add("examsSelectList", list);
            ViewBag.List = list;
            //ViewData["examsSelectList"] = _service.GetExamsSelectList(_service.GetAllExams());
            return View();
        }

        // POST: CandidateExams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Result,MaxScore,PercentScore,ExamDate,ReportDate,CandidateScore,AssessmentCode,ExamId")] CandidateExam candidateExam
            /*[Bind("examsSelectList")] int examsSelectList,*/ /*string UserId*/)
        {

            //var candidate = _service.GetCandidateByUserId(UserId);
            
            var cands = _context.Candidates.Count();
            var candidate = _context.Candidates.Where(cand => cand.AppUserId == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();

            //int examIdFromDropDown = examsSelectList;
            candidateExam.Exam = _context.Exams.Find(candidateExam.ExamId); //me basi to id toy drop down vazei sto candidateexam to exam
            candidateExam.Candidate = candidate;
            candidateExam.CandidateId = candidate.AppUserId;
            candidateExam.ExamId = candidateExam.ExamId;


            if (ModelState.IsValid)
            {
                _context.Add(candidateExam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidateExam);
        }
    }
}
