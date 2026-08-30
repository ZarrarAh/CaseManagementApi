using Microsoft.AspNetCore.Mvc;
using CaseManagementApi.Models;
using CaseManagementApi.Services;

namespace CaseManagementApi.Controllers
{
	// [ApiController] gir oss automatisk validering og bedre feilmeldinger
	[ApiController]
	// [Route] bestemmer URL-en til dette API-et, "api/cases"
	[Route("api/[controller]")]
	public class CasesController : ControllerBase
	{
		// Dependency injection: ASP.NET Core gir oss automatisk samme CaseService-instans
		// som vi registrerte i Program.cs (AddSingleton)
		private readonly CaseService _caseService;

		// Konstruktør: kjører når kontrolleren opprettes, her mottar vi CaseService
		public CasesController(CaseService caseService)
		{
			_caseService = caseService;
		}

		// GET api/cases
		// Henter alle saker
		[HttpGet]
		public ActionResult<List<Case>> GetAllCases()
		{
			var cases = _caseService.GetAllCases();
			return Ok(cases); // Ok() gir HTTP 200 med dataen i responsen
		}

		// GET api/cases/5
		// Henter én sak basert på id
		[HttpGet("{id}")]
		public ActionResult<Case> GetCaseById(int id)
		{
			var foundCase = _caseService.GetCaseById(id);

			if (foundCase == null)
			{
				return NotFound(); // HTTP 404 hvis saken ikke finnes
			}

			return Ok(foundCase);
		}

		// POST api/cases
		// Oppretter en ny sak
		[HttpPost]
		public ActionResult<Case> CreateCase([FromBody] Case newCase)
		{
			var createdCase = _caseService.CreateCase(newCase);

			// CreatedAtAction gir HTTP 201 og en Location-header som peker til den nye ressursen
			return CreatedAtAction(nameof(GetCaseById), new { id = createdCase.Id }, createdCase);
		}

		// PUT api/cases/5/status
		// Oppdaterer status på en eksisterende sak
		[HttpPut("{id}/status")]
		public ActionResult<Case> UpdateCaseStatus(int id, [FromBody] string newStatus)
		{
			var updatedCase = _caseService.UpdateCaseStatus(id, newStatus);

			if (updatedCase == null)
			{
				return NotFound();
			}

			return Ok(updatedCase);
		}
	}
}