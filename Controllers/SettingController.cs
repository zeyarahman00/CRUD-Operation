using LPInfotech.Data;
using LPInfotech.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LPInfotech.Controllers
{
    public class SettingController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SettingController(ApplicationDbContext context)
        {
            _context = context;
        }
        #region Setting

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Settings()
        {
            var results = _context.Settings.Where(x => x.IsDeleted == false).ToList();
            return Json(new { data = results });
        }

        [HttpPost]
        public IActionResult AddSetting(Setting setting)
        {
            ServiceResponse cr = new ServiceResponse();
            if (ModelState.IsValid)
            {
                try
                {
                    if (setting.Id == 0)
                    {
                        setting.Created = DateTime.Now;
                        setting.IsDeleted = false;
                        _context.Settings.Add(setting);
                        _context.SaveChanges();
                        cr.Message = "Details successfully add!";
                        cr.Status = 1;
                    }
                    else
                    {

                        var model = _context.Settings.Find(setting.Id);
                        if (model != null)
                        {
                            model.Key = setting.Key;
                            model.Value = setting.Value;
                            model.Value2 = setting.Value2;
                            model.Description = setting.Description;
                            model.LastModified = DateTime.Now;
                            _context.Settings.Update(model);
                            _context.SaveChanges();
                            cr.Message = "Details successfully Update!";
                            cr.Status = 1;
                        }
                    }
                }catch(Exception ex)
                {
                    cr.Status = 0;
                    cr.Message = ex.Message;
                    ex.Data.Clear();
                }
                
            }
            else
            {
                cr.Status = 0;
                cr.Message = "All Fields are required.";
            }
            return Json(cr);
        }


        [HttpPost]
        public JsonResult EditSetting(Int64 id)
        {
            ServiceResponse cr = new ServiceResponse();
            if (id == 0 || _context.Settings == null)
            {
               
                cr.Status = 0;
                cr.Message = "Record Not Found";
                return Json(cr);
            }

            var results = _context.Settings.Find(id);
            if (results == null)
            {
                cr.Status = 0;
                cr.Message = "Record Not Found";
                return Json(cr);
            }

            return Json(results);
        }

        [HttpDelete]
        public JsonResult DeleteSetting(Int64 Id)
        {
            ServiceResponse cr = new ServiceResponse();
            if (_context.Settings != null && Id != 0)
            {
                try
                {
                    var model = _context.Settings.Find(Id);
                    if (model != null)
                    {
                        model.IsDeleted = true;
                        _context.Update(model);
                        _context.SaveChanges();
                        cr.Message = "Record Delete Successfully!";
                        cr.Status = 1;
                    }
                    else
                    {
                        cr.Message = "Record Not Found!";
                        cr.Status = 0;
                    }
                }
                catch(Exception ex)
                {
                    cr.Status = 0;
                    cr.Message = ex.Message;
                    ex.Data.Clear();
                }
               
                
            }
            else
            {
                cr.Message = "Id must be required, please try again!";
                cr.Status = 0;
            }
            return Json(cr);
        }
        #endregion

    }
}
