using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.DTO.Questions;
using ModelLibrary.Models.Questions;
using WebApp4a.Data;

namespace WebApp4a.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpPost]
        public ActionResult UploadImage(List<IFormFile> files)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions 
            {
                    ContentRootPath = Directory.GetCurrentDirectory()            
            });



            var filepath = "";




            foreach (IFormFile photo in Request.Form.Files )
            {
                string serverMapPath = Path.Combine(builder.Environment.WebRootPath, "Image", photo.FileName);
                using (var stream = new FileStream(serverMapPath,FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                filepath = "https://localhost:7258/"+"Image/"+photo.FileName;

                

            }
                return Json(new {Url = filepath });


        }



        private DifficultyLevel? GetDifficultyLevel(Question question)
        {
            // TODO:(akotro) This belongs to a QuestionsRepository

            // NOTE:(akotro) Using enums means that whenever a DifficultyLevel is edited or created,
            // a new row in the database is always created. Therefore, we use a switch to find the
            // difficulty level from the database and return it.

            DifficultyLevel? result = null;

            switch (question.DifficultyLevel.Difficulty)
            {
                case DifficultyEnum.None:
                    result = _context.DifficultyLevels.FirstOrDefault(
                        d => d.Difficulty == DifficultyEnum.None
                    );
                    break;
                case DifficultyEnum.EASY:
                    result = _context.DifficultyLevels.FirstOrDefault(
                        d => d.Difficulty == DifficultyEnum.EASY
                    );
                    break;
                case DifficultyEnum.MEDIUM:
                    result = _context.DifficultyLevels.FirstOrDefault(
                        d => d.Difficulty == DifficultyEnum.MEDIUM
                    );
                    break;
                case DifficultyEnum.HARD:
                    result = _context.DifficultyLevels.FirstOrDefault(
                        d => d.Difficulty == DifficultyEnum.HARD
                    );
                    break;
            }

            return result;
        }

        private List<SelectListItem>? GetTopicSelectList(Question? question)
        {
            var topics = _context.Topics.ToList();
            if (topics == null || topics.Count <= 0)
                return null;

            var result = new List<SelectListItem>();
            var group = new SelectListGroup();

            foreach (var topic in topics)
            {
                var selectListItem = new SelectListItem()
                {
                    Disabled = false,
                    Group = group,
                    Selected = false,
                    Text = $@"{topic.Name}",
                    Value = topic.Id.ToString()
                };

                if (question?.Topic == topic)
                {
                    selectListItem.Selected = true;
                }

                result.Add(selectListItem);
            }

            if (question == null)
            {
                result.ElementAt(0).Selected = true;
            }

            return result;
        }

        private void PopulateQuestion(
            Question question,
            int topicId,
            Dictionary<string, bool> optionsDict
        )
        {
            if (optionsDict != null && question.Options.Any(o => o.Id == 0))
            {
                question.Options = new List<Option>();
                foreach (var pair in optionsDict)
                {
                    question.Options.Add(new Option() { Text = pair.Key, Correct = pair.Value });
                }
            }

            question.DifficultyLevel = GetDifficultyLevel(question);
            question.Topic = _context.Topics.Find(topicId);
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            return _context.Questions != null
                ? View(
                    await _context.Questions
                        .Include(q => q.DifficultyLevel)
                        .Include(q => q.Topic)
                        .ToListAsync()
                )
                : Problem("Entity set 'ApplicationDbContext.Questions'  is null.");
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.DifficultyLevel)
                .Include(q => q.Topic)
                .Include(q => q.Options)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            var questionDto = new QuestionDto()
            {
                Options = new List<OptionDto>()
                {
                    new OptionDto(),
                    new OptionDto(),
                    new OptionDto(),
                    new OptionDto()
                }
            };

            ViewBag.Topics = _context.Topics.Select(
                t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() }
            );
            ViewBag.DifficultyLevels = _context.DifficultyLevels.Select(
                d => new SelectListItem { Text = d.Difficulty.ToString(), Value = d.Id.ToString() }
            );

            return View(questionDto);
        }

        // POST: Questions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionDto questionDto)
        {
            if (ModelState.IsValid)
            {
                var question = new Question
                {
                    Text = questionDto.Text,
                    TopicId = questionDto.TopicId,
                    DifficultyLevelId = questionDto.DifficultyLevelId,
                    Options = questionDto.Options
                        .Select(o => new Option { Text = o.Text, Correct = o.Correct })
                        .ToList()
                };

                _context.Questions.Add(question);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(questionDto);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int id)
        {
            var question = _context.Questions
                .Include(q => q.Options)
                .FirstOrDefault(q => q.Id == id);

            // TODO:(akotro) Add null checks

            var questionDto = new QuestionDto
            {
                Id = question.Id,
                Text = question.Text,
                TopicId = question.TopicId,
                DifficultyLevelId = question.DifficultyLevelId,
                Options = question.Options
                    .Select(
                        o =>
                            new OptionDto
                            {
                                Id = o.Id,
                                Text = o.Text,
                                Correct = o.Correct
                            }
                    )
                    .ToList()
            };

            ViewBag.Topics = _context.Topics.Select(
                t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() }
            );
            ViewBag.DifficultyLevels = _context.DifficultyLevels.Select(
                d => new SelectListItem { Text = d.Difficulty.ToString(), Value = d.Id.ToString() }
            );

            return View(questionDto);
        }

        // POST: Questions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, QuestionDto questionDto)
        {
            if (ModelState.IsValid)
            {
                var question = _context.Questions
                    .Include(q => q.Options)
                    .FirstOrDefault(q => q.Id == id);

                // TODO:(akotro) Add null checks

                question.Text = questionDto.Text;
                question.TopicId = questionDto.TopicId;
                question.DifficultyLevelId = questionDto.DifficultyLevelId;

                var optionsToDelete = question.Options
                    .Where(o => !questionDto.Options.Any(odto => odto.Id == o.Id))
                    .ToList();
                foreach (var option in optionsToDelete)
                {
                    _context.Remove(option);
                }

                foreach (var optionDto in questionDto.Options)
                {
                    var option = question.Options.FirstOrDefault(o => o.Id == optionDto.Id);
                    if (option != null)
                    {
                        option.Text = optionDto.Text;
                        option.Correct = optionDto.Correct;
                    }
                    else
                    {
                        question.Options.Add(
                            new Option
                            {
                                Text = optionDto.Text,
                                Correct = optionDto.Correct,
                                QuestionId = question.Id
                            }
                        );
                    }
                }

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(questionDto);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Question'  is null.");
            }

            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
