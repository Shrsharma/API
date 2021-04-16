using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Model;

namespace Application.Controllers
{
    public class ClassController : BaseController<ClassController, ClassModel>
    {
        public ClassController(IBaseRepo<ClassModel> repo) : base(repo)
        {

        }
    }
}
