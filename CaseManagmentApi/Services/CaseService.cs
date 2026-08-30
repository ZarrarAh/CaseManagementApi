using CaseManagementApi.Models;

namespace CaseManagementApi.Services
{

	// Denne klassen holder styr på sakene våre i minnet
	// (midlertidig løsning før vi bruker ekte database)
	public class CaseService
	{
		// En privat liste som lagrer alle sakene så lenge applikasjonen kjører
		private readonly List<Case> _cases = new List<Case>();
		private int _nextId = 1;
		public List<Case> GetAllCases()
		{
			return _cases;
		}

		// Henter én sak basert på id, returnerer null hvis den ikke finnes
		public Case? GetCaseById(int id)
		{
			return _cases.FirstOrDefault(c => c.Id == id);
		}

		// Oppretter en ny sak og legger den til i listen
		public Case CreateCase(Case newCase){
			newCase.Id = _nextId;
			newCase.CreatedAt = DateTime.Now;
			_nextId++;

			_cases.Add(newCase);
			return newCase;
		}

		// Oppdaterer status på en eksisterende sak
		public Case? UpdateCaseStatus(int id, string newStatus)
		{
			var existingCase = GetCaseById(id);
			if (existingCase == null)
			{
				return null; //Saken finnes ikke
			}

			existingCase.Status = newStatus;
			return existingCase;
		}
	}
}
