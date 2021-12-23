using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using Serilog;
using System;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IDiagnosisRepository DiagnosisRepository;

        public DiagnosisController(IDiagnosisRepository context)
        {
            DiagnosisRepository = context;
        }

        // GET: Diagnosis/All
        [HttpGet("Get/All")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(DiagnosisRepository.GetAll());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get all Diagnosis request");
            }
        }

        [HttpGet("Get/{id}")]

        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(DiagnosisRepository.GetById(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid  Diagnosis get request");
            }
        }

        [HttpPut("Update/{id}")]

        public IActionResult Update(int id, [FromBody] Diagnosis p_diagnosis)
        {
            try
            {
                p_diagnosis.Id = id;
                DiagnosisRepository.Update(p_diagnosis);
                DiagnosisRepository.Save();
                return Ok();
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid Diagnosis Update");
            }
      }

      [HttpDelete("Delete/{id}")]

      public IActionResult Delete(int id)
      {
          try
          {
              var ToBeDeleted = DiagnosisRepository.GetById(id);
              DiagnosisRepository.Delete(ToBeDeleted);
              DiagnosisRepository.Save();
              return Ok();
          }
          catch(Exception e)
          {
              Log.Error(e.Message);
              return BadRequest("Invalid Diagnosis Delete request");


          }
      }

      [HttpGet("Get/GetPatientId/{id}")]
        public IActionResult GetByPatientIdWithNav(int id)
        {
            try
            {
                return Ok(DiagnosisRepository.GetByPatientIdWithNav(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get diagnosis by patient Id");
            }
        }

        [HttpGet("Get/GetAllPatient/{id}")]
        public IActionResult GetAllDiagnosisByPatientIdWithNav(int id)
        {
            try
            {
                return Ok(DiagnosisRepository.GetAllDiagnosisByPatientIdWithNav(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Invalid get diagnosis by patient Id");
            }
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Diagnosis p_diagnosis)
        {
            try
            {
                DiagnosisRepository.Create(p_diagnosis);
                DiagnosisRepository.Save();
                return Created("Diagnosis/Add", p_diagnosis );
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Fail to Add diagnosis ");
            }
        }


    }
}