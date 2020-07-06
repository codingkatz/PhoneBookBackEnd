using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using phonebookCollectionService.Models;
using phonebookCollectionService.Services;

namespace phonebookCollectionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IEntriesService _entriesService;
        public PhoneBookController(IEntriesService entriesService)
        {
            _entriesService = entriesService;
        }

        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        [HttpGet]
        [Route("Entries")]
        public async Task<IActionResult> GetAllEntries()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");

            var entries = await _entriesService.GetAllEntries();
            return Ok(entries);
        }

        [HttpGet]
        [Route("GetEntry")]
        public async Task<IActionResult> GetEntry(string entry)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");

            var entries = await _entriesService.GetEntry(entry);
            return Ok(entries);
        }

        [HttpGet]
        [Route("SaveEntry")]
        public async Task<IActionResult> SaveEntry(string name, string phonenumber)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");

            var entries = await _entriesService.SaveEntry(name, phonenumber);
            return Ok(entries);
        }
    }
}