using System;
using System.Threading.Tasks;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using dotnetapi.Data;

namespace dotnetapi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class GraphqlController : ControllerBase
  {
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
    {
      var schema = new DiscussionSchema();
      var inputs = query.Variables.ToInputs();

      var result = await new DocumentExecuter().ExecuteAsync(_ =>
      {
        _.Schema = schema.GraphQLSchema;
        _.Query = query.Query;
        _.OperationName = query.OperationName;
        _.Inputs = inputs;
      });

      if (result.Errors?.Count > 0)
      {
        Console.WriteLine(result.Errors[0]);
        return BadRequest();
      }

      return Ok(result);
    }
  }
}