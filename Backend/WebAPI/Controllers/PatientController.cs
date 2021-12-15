﻿using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Diagnosis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("Patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {


        //Dependency injection
        private readonly IPatientRepository _repo;
        private readonly IAllergyRepository _allergy;

        public PatientController(IPatientRepository p_repo, IAllergyRepository p_allergy)
        {
            _repo = p_repo;
            _allergy = p_allergy;
        }
        // GET: Patient/All
        [HttpGet("All")] //("All") Will give and endpoint that ends with All
        public IActionResult GetAllPatient()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {

                //Log.Error(e.Message);
                return BadRequest("Nothing returned");
            }
            
            
        }

        // GET Patient/Id
        [HttpGet("{p_id}")]
        public IActionResult GetPatientById(int p_id)
        {
            try
            {
                return Ok(_repo.GetByPrimaryKey(p_id));
            }
            catch (Exception e)
            {
                //Log.Error(e.Message);
                return BadRequest("Not a valid search id");
            }
        }

        // POST Patient/Add
        [HttpPost("add")]
        public IActionResult AddPatient([FromBody] Patient p_patient)
        {

            try
            {
                _repo.Create(p_patient);
                _repo.Save();
                return Created("patient/add", p_patient);

            }
            catch (Exception e)
            {

                //Log.Error(e.Message);
                return BadRequest("Not a valid search id");
            }
            
        }

        // PUT Patient/Edit
        [HttpPut("edit/{id}")]
        public IActionResult UpdatePatient([FromBody] Patient p_patient)
        {
            try
            {
            _repo.Update(p_patient);
            _repo.Save();
            return Ok();
            }
            catch
            {
                //Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
            
        }

        // DELETE Patient/Id
        [HttpDelete("delete/{id}")]
        public IActionResult DeletePatient([FromBody] Patient p_patient)
        {
            try
            {
                _repo.Delete(p_patient);
                _repo.Save();
                return Ok();

            }
            catch (Exception e)
            {

                //Log.Error(e.Message);
                return BadRequest("Failed to update");
            }
            
        }

      

      

        
    }
}