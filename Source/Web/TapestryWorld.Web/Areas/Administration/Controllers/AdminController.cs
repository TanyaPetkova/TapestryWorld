﻿namespace TapestryWorld.Web.Areas.Administration.Controllers
 {
     using System.Web.Mvc;

     using TapestryWorld.Data.Common;
     using TapestryWorld.Data;
     using TapestryWorld.Web.Controllers;

     [Authorize(Roles = GlobalConstants.AdminRole)]
     public abstract class AdminController : BaseController
     {
         public AdminController(ITapestryWorldData data)
             : base(data)
         {
         }
     }
 }