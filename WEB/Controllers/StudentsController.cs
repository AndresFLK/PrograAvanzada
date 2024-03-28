using Aplication.Students;
using AutoMapper;
using Domain.Students;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shared;
using WEB.Extensions;

namespace WEB.Controllers
{
    
    public class StudentsController : Controller
    {
        private readonly IValidator<CreateStudent> _createValidator;
        private readonly IValidator<UpdateStudent> _updateValidator;
        private readonly IStudentClient _client;
        private readonly IMapper _mapper;

        public StudentsController(IValidator<CreateStudent> createValidator, IValidator<UpdateStudent> updateValidator ,IStudentClient client, IMapper mapper) 
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _client = client;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var students = await _client.List();
            return View(students);
        }


        [HttpGet]
        public IActionResult Create() 
        {
            return View(new CreateStudent());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudent model) 
        {
            var result = await _createValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _client.Create(model);
                if(res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }

            return View(model);
        }


        [HttpGet("/students/update/{batch}")]
        public async Task<IActionResult> Update([FromRoute]string batch)
        {
            Result<Student> result = await _client.Get(batch);
            UpdateStudent updateStudent = _mapper.Map<UpdateStudent>(result.Value);
            return View(updateStudent);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateStudent model)
        {
            var result = await _updateValidator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }
            else
            {
                var res = await _client.Update(model);
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, res.Error.description);
            }

            return View(model);
        }


    }
}
