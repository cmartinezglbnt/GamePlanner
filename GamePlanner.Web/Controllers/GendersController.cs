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
    public class GendersController : Controller
    {
        private readonly IGenderRepository genderRepository;

        public GendersController(IGenderRepository genderRepository)
        {
            this.genderRepository = genderRepository;
        }

        // GET: Genders
        public async Task<IActionResult> Index()
        {
            return View(this.genderRepository.GetAll().OrderBy(x => x.Name));
        }

        // GET: Genders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gender = await this.genderRepository.GetByIdAsync(id.Value);

            if (gender == null)
            {
                return NotFound();
            }

            return View(gender);
        }

        // GET: Genders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gender gender)
        {
            if (ModelState.IsValid)
            {
                await this.genderRepository.CreateAsync(gender);
                return RedirectToAction(nameof(Index));
            }
            return View(gender);
        }

        // GET: Genders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gender = await this.genderRepository.GetByIdAsync(id.Value);
            if (gender == null)
            {
                return NotFound();
            }
            return View(gender);
        }

        // POST: Genders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Gender gender)
        {
            if (id != gender.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.genderRepository.UpdateAsync(gender);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var currentGender = this.genderRepository.GetByIdAsync(id);

                    if (currentGender == null)
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
            return View(gender);
        }

        // GET: Genders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gender = await this.genderRepository.GetByIdAsync(id.Value);

            if (gender == null)
            {
                return NotFound();
            }

            await this.genderRepository.DeleteAsync(gender);

            return RedirectToAction(nameof(Index));
        }
    }
}
