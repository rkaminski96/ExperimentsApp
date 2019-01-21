using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ExperimentsApp.API.Controllers
{
    [Authorize]
    [Route("api/user/{userId}/experiment")]
    public class ExperimentController : Controller
    {

    }
}
