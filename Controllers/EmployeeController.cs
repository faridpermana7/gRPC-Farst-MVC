using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcFarstMvc.Models;
using GrpcFarstMvc.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace GrpcFarstMvc.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController()
        {

        }
        //private List<SelectListItem> PageSizeList = new Pagination().PageSizeList;

        // GET: EmployeeController
        public ActionResult Index(string sortOrder, string sortDir, string currentFilter, string keyword, int? pageSize, int page = 1)
        { 
            //set default sort and direction
            ViewBag.CurrentSort = sortOrder = string.IsNullOrEmpty(sortOrder) == true ? "EmployeeID" : sortOrder;
            sortDir = string.IsNullOrEmpty(sortDir) == true ? "asc" : sortDir; 

            var listPaged = GetPaged(sortOrder, sortDir, currentFilter, keyword, pageSize, page);
            ViewBag.Employees = listPaged;

            return View();
        }


        protected IPagedList<EmployeeDTO> GetPaged(string sortOrder, string sortDir, string currentFilter, string keyword, int? pageSize, int? page)
        {
            // return a 404 if user browses to before the first page
            if (page.HasValue && page < 1)
                return null;

            // retrieve list from database/whereverand
            var listUnpaged = new List<EmployeeDTO> {
                new EmployeeDTO {
                    EmployeeID = 1,
                    Name = "Farid Permana",
                    NIK = "10000000",
                    Address ="South Jakarta City",
                    Occupation = "Programmer"
                },
                new EmployeeDTO {
                    EmployeeID = 2,
                    Name = "Julian Noor",
                    NIK = "10000001",
                    Address ="South Jakarta City",
                    Occupation = "UX Designer"
                },
                new EmployeeDTO {
                    EmployeeID = 3,
                    Name = "Julian Noor",
                    NIK = "10000001",
                    Address ="South Jakarta City",
                    Occupation = "UX Designer"
                },
                new EmployeeDTO {
                    EmployeeID = 4,
                    Name = "Julian Noor",
                    NIK = "10000001",
                    Address ="South Jakarta City",
                    Occupation = "UX Designer"
                },
                new EmployeeDTO {
                    EmployeeID = 5,
                    Name = "Julian Noor",
                    NIK = "10000001",
                    Address ="South Jakarta City",
                    Occupation = "UX Designer"
                },
                new EmployeeDTO {
                    EmployeeID = 6,
                    Name = "Julian Noor",
                    NIK = "10000001",
                    Address ="South Jakarta City",
                    Occupation = "UX Designer"
                },
                new EmployeeDTO {
                    EmployeeID = 7,
                    Name = "Julian Noor",
                    NIK = "10000001",
                    Address ="South Jakarta City",
                    Occupation = "UX Designer"
                }
            };

            var query = listUnpaged.AsQueryable();


            if (string.IsNullOrEmpty(keyword))
            {
                keyword = currentFilter;
            }
            else
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(s => s.NIK.ToLower().Contains(keyword) ||
                    s.Name.ToLower().Contains(keyword)
                );
            }


            query = query.SortBy(sortOrder, sortDir);

            //reverse direction
            ViewBag.CurrentSortDir = sortDir == "asc" ? "desc" : "";
            //var pageIndex = page.HasValue ? (int)page : 1;
            //int defaSize = (pageSize ?? 5);
            //ViewBag.psize = defaSize;
            //ViewBag.PageSize = PageSizeList;

            // page the list
            pageSize ??= 5;
            var listPaged = query.ToPagedList(page ?? 1, (int)pageSize);

            // return a 404 if user browses to pages beyond last page. special case first page if no items exist
            if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                return null;

            return listPaged;
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
