using System;
using Branch.Packages.Models.Halo4.RecentMatches;
using Newtonsoft.Json;

namespace Branch.Packages.Models.Halo4
{
	public class RecentMatchesResponse : WaypointResponse
	{
		public int DateFidelity { get; set; }

		public RecentMatch[] Games { get; set; }
	}
}
