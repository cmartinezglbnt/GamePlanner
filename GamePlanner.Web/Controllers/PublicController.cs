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
    public class PublicController : Controller
    {
        private readonly IPublicRepository publicRepository;

        public PublicController(IPublicRepository publicRepository)
        {
            this.publicRepository = publicRepository;
        }

        // GET: Publics
        public IActionResult Index()
        {
            return View(this.publicRepository.GetAll().OrderBy(x => x.Name));
        }

        // GET: Publics/Details/5
        public async Task<IActionResult >Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentPublic = await this.publicRepository.GetByIdAsync(id.Value);

            if (currentPublic == null)
            {
                return NotFound();
            }

            return View(currentPublic);
        }

        // GET: Publics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Public currentPublic)
        {
            if (ModelState.IsValid)
            {
                await this.publicRepository.CreateAsync(currentPublic);

                return RedirectToAction(nameof(Index));
            }
            return View(currentPublic);
        }

        // GET: Publics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentPublic = await this.publicRepository.GetByIdAsync(id.Value);

            if (currentPublic == null)
            {
                return NotFound();
            }

            return View(currentPublic);
        }

        // POST: Publics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Public currentPublic)
        {
            if (id != currentPublic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.publicRepository.UpdateAsync(currentPublic);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var tempPublic = this.publicRepository.GetByIdAsync(currentPublic.Id);

                    if (tempPublic == null)
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

            return View(currentPublic);
        }

        // GET: Publics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentPublic = await this.publicRepository.GetByIdAsync(id.Value);

            if (currentPublic == null)
            {
                return NotFound();
            }

            await this.publicRepository.DeleteAsync(currentPublic);
            return RedirectToAction(nameof(Index));
        }
    }
}
