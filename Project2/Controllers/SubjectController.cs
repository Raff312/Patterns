using Microsoft.AspNetCore.Mvc;
using Project2.Models;

namespace Project2.Controllers {
    [Route("subjects")]
    public class SubjectController : Controller {
        [HttpGet]
        public List<Subject> List() {
            return new List<Subject> {
                new Subject()
            };
        }
    }
}
