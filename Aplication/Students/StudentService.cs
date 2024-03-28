using AutoMapper;
using Domain.Students;
using Shared;
using System.Reflection.Metadata.Ecma335;

namespace Aplication.Students
{
    public class StudentService : IStudentService
    {
        private  static IStudentRepository _repository;

        private readonly IMapper _mapper;     


        public StudentService(IStudentRepository repository, IMapper mapper)
        {

            _repository = repository;

                _mapper = mapper;
            
        }

        public Result<IList<Student>> List(bool includeCourses = false)
        {
            return
            includeCourses
                ? Result.Success<IList<Student>>(_repository.GetAll(i => i.Courses))
                : Result.Success<IList<Student>>(_repository.GetAll());
        }

        public Result<Student> Get(string batch, bool includeCourses = false)
        {

            var student =
                includeCourses
                    ? _repository.Get(s => s.Batch == batch, i => i.Courses)
                    : _repository.Get(s => s.Batch == batch);



                if (student == null)
                {
                    return Result.Failure<Student>(StudentErrors.NotFound(batch));
                }

                return Result.Success(student);

        }

        public Result<Student> Get(int id, bool includeCourses = false)
        {
            
                var student =
                includeCourses
                    ? _repository.Get(s => s.Id == id, i => i.Courses)
                    : _repository.Get(s => s.Id == id); 

                if (student is null)
                {
                    return Result.Failure<Student>(StudentErrors.NotFound());
                }

                return Result.Success(student);
           

        }

        public Result Create(CreateStudent createStudent)
        {
            var student = _mapper.Map<CreateStudent, Student>(createStudent);
            _repository.Insert(Student.Create(0, student));
            _repository.Save();
            return Result.Success(student);
        }

        public Result Update(UpdateStudent updateStudent)
        {
            var result = Get(updateStudent.Id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var student = result.Value;
            _mapper.Map<UpdateStudent, Student>(updateStudent, student);
            _repository.Update(student);
            _repository.Save();
            return Result.Success(student);
        }

        public Result Delete(int id)
        {
            var result = Get(id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var student = result.Value;
            _repository.Delete(student);
            _repository.Save();
            return Result.Success();
        }
    }
}
