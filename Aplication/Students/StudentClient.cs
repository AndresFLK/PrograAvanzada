using Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.Options;
using Domain.Configuration;
using Shared;

namespace Aplication.Students
{
    public sealed class StudentClient : IStudentClient
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _client;
        private readonly IMapper _mapper;
        public StudentClient(IOptions<List<EndpointConfiguration>> options, HttpClient client, IMapper mapper)
        {
            _endpoints = options.Value.Where(w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Endpoints.ToList();
            _client = client;
            _mapper = mapper;
        }

        public async Task<Result> Create(CreateStudent createStudent)
        {
            var content = new StringContent(JsonSerializer.Serialize(createStudent), Encoding.UTF8, "application/json");
            var result = await _client.PostAsync
                (_endpoints.Where(w => w.Name.Equals("Students", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Created
                ? Result.Success()
                : Result.Failure(StudentErrors.NotCreated());
        }

        public async Task<List<StudentDTO>> List()
        {
            var content = await _client.GetStringAsync(_endpoints.Where(w => w.Name.Equals("Students", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
            var students = JsonSerializer.Deserialize<List<Student>>(content);

            return _mapper.Map<List<StudentDTO>>(students);
        }

        public async Task<Result> Update(UpdateStudent updateStudent)
        {
            var content = new StringContent(JsonSerializer.Serialize(updateStudent), Encoding.UTF8, "application/json");
            var result = await _client.PutAsync
                (_endpoints.Where(w => w.Name.Equals("Students", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Accepted
                ? Result.Success()
                : Result.Failure(StudentErrors.NotUpdated());
        }

        public async Task<Result<Student>> Get(string batch)
        {
            var content = await _client.GetStringAsync
                (_endpoints.Where(w => w.Name.Equals("Students", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + batch);
            var student = JsonSerializer.Deserialize<Student>(content);

            return Result.Success(student);
        }
    }
}
