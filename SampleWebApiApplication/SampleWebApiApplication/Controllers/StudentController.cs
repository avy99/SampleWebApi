using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.DataAccess.Repository;
using WebApp.Models.Dto;
using WebApp.Models.Models;

namespace SampleWebApiApplication.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StudentController : Controller
    {
        private readonly IMapper _studentMapper;
        private readonly IUnitofWork _unitofWork;

        public StudentController(IUnitofWork unitofWork, IMapper studentMapper)
        {
            _unitofWork = unitofWork;
            _studentMapper = studentMapper;
        }


        [HttpGet]
        public async Task<IEnumerable<StudentDto>> GetAllStudent()
        {
            var result = await _unitofWork.Students.GetAll(includeProperties: "Department");
            return _studentMapper.Map<StudentDto[]>(result);
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int studentId)
        {
            try
            {
                var student = await _unitofWork.Students.Get(studentId, "Department");
                if (student != null)
                    return _studentMapper.Map<StudentDto>(student);
                return NotFound("No object with such Id in database");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{studentId}")]
        public async Task<ActionResult<StudentDto>> DeleteStudent(int studentId)
        {
            try
            {
                var student = await _unitofWork.Students.Get(studentId, "Department");
                if (student != null)
                    await _unitofWork.Students.Remove(student);
                else
                    return NotFound("No object with mentioned Student Id");
                _unitofWork.Save();
                return _studentMapper.Map<StudentDto>(student);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> AddStudent([FromBody] StudentDto student)
        {
            try
            {
                var x = int.Parse("1");
                var result = _studentMapper.Map<Student>(student);
                await _unitofWork.Students.Add(result);
                _unitofWork.Save();
                return StatusCode(StatusCodes.Status202Accepted, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}