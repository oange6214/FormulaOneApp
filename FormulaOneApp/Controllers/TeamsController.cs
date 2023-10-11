
using FormulaOneApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOneApp.Controllers;

[Route("api/[controller]")] // api/teams
[ApiController]
public class TeamsController : ControllerBase
{
    // fake data
    private static List<Team> teams = new List<Team>()
    {
        new Team()
        {
            Country = "Germany",
            Id = 1,
            Name = "Mercedes AMG F1",
            TeamPrinciple = "Toto Wolf"
        },
        new Team()
        {
            Country = "Italy",
            Id = 2,
            Name = "Ferrari",
            TeamPrinciple = "Mattia Binotto"
        },
        new Team()
        {
            Country = "Swiss",
            Id = 3,
            Name = "Alpha Romeo",
            TeamPrinciple = "Frédéric Vasseur"
        },
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(teams);    // return 200
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var team = teams.FirstOrDefault(x => x.Id == id);

        if (team == null)
        {
            return BadRequest("Invalid Id");
        }

        return Ok(team);    // return 200
    }

    [HttpPost]
    public IActionResult Post(Team team)
    {
        teams.Add(team);

        return CreatedAtAction("Get", team.Id, team);   // return 201
    }

    [HttpPatch]
    public IActionResult Patch(int id, string country)
    {
        var team = teams.FirstOrDefault(x => x.Id == id);

        if (team == null)
        {
            return BadRequest("Invalid Id");
        }

        team.Country = country;

        return NoContent(); // return 204
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var team = teams.FirstOrDefault(x => x.Id == id);

        if (team == null)
        {
            return BadRequest("Invalid Id");
        }

        teams.Remove(team);

        return NoContent();
    }
}