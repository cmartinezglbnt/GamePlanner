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
    public class IdeasController : Controller
    {
        private readonly IIdeaRepository ideaRepository;

        public IdeasController(IIdeaRepository ideaRepository)
        {
            this.ideaRepository = ideaRepository;
        }

        // GET: Ideas
        public IActionResult Index()
        {
            return View(ideaRepository.GetAll().OrderBy(x => x.RegistrationDate));
        }

        // GET: Ideas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = this.ideaRepository.GetByIdAsync(id.Value);

            if (idea == null)
            {
                return NotFound();
            }

            return View(idea);
        }

        // GET: Ideas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ideas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Features,RegistrationDate")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                await this.ideaRepository.CreateAsync(idea);
                return RedirectToAction(nameof(Index));
            }

            return View(idea);
        }

        // GET: Ideas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = await this.ideaRepository.GetByIdAsync(id.Value);

            if (idea == null)
            {
                return NotFound();
            }

            return View(idea);
        }

        // POST: Ideas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Features,RegistrationDate")] Idea idea)
        {
            if (id != idea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.ideaRepository.UpdateAsync(idea);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var result = await this.ideaRepository.GetByIdAsync(idea.Id);

                    if (result == null)
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

            return View(idea);
        }

        // GET: Ideas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = await this.ideaRepository.GetByIdAsync(id.Value);

            if (idea == null)
            {
                return NotFound();
            }

            return View(idea);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var idea = await this.ideaRepository.GetByIdAsync(id);

            await this.ideaRepository.DeleteAsync(idea);
            return RedirectToAction(nameof(Index));
        }
    }
}
