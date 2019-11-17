using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamePlanner.Web.Data.Entities;
using GamePlanner.Web.Data;

namespace GamePlanner.Web.Controllers
{
    public class TechnologiesController : Controller
    {
        private readonly ITechnologyRepository technologyRepository;

        public TechnologiesController(ITechnologyRepository technologyRepository)
        {
            this.technologyRepository = technologyRepository;
        }

        // GET: Technologies
        public IActionResult Index()
        {
            return View(technologyRepository.GetAll().OrderBy(t => t.Type));
        }

        // GET: Technologies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technology = await this.technologyRepository.GetByIdAsync(id.Value);
            if (technology == null)
            {
                return NotFound();
            }

            return View(technology);
        }

        // GET: Technologies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Technologies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Technology technology)
        {
            if (ModelState.IsValid)
            {
                await this.technologyRepository.CreateAsync(technology);
                return RedirectToAction(nameof(Index));
            }
            return View(technology);
        }

        // GET: Technologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technology = await this.technologyRepository.GetByIdAsync(id.Value);
            if (technology == null)
            {
                return NotFound();
            }
            return View(technology);
        }

        // POST: Technologies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Technology technology)
        {
            if (id != technology.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.technologyRepository.UpdateAsync(technology);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.technologyRepository.ExistAsync(technology.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(technology);
        }

        // GET: Technologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technology = await this.technologyRepository.GetByIdAsync(id.Value);
            if (technology == null)
            {
                return NotFound();
            }

            await this.technologyRepository.DeleteAsync(technology);
            return RedirectToAction(nameof(Index));
        }
    }
}
