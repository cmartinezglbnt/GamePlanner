﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamePlanner.Web.Data.Entities;
using GamePlanner.Web.Data;
using GamePlanner.Web.Models;

namespace GamePlanner.Web.Controllers
{
    public class IdeasController : Controller
    {
        private readonly IIdeaRepository ideaRepository;
        private readonly IGenderRepository genderRepository;
        private readonly IPublicRepository publicRepository;

        public IdeasController(IIdeaRepository ideaRepository, IGenderRepository genderRepository, IPublicRepository publicRepository)
        {
            this.ideaRepository = ideaRepository;
            this.genderRepository = genderRepository;
            this.publicRepository = publicRepository;
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
            var ideaModel = new IdeasViewModel();
            ideaModel.Genders = this.GetComboGenders();
            ideaModel.Publics = this.GetComboPublic();

            return View(ideaModel);
        }

        // POST: Ideas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdeasViewModel idea)
        {
            if (ModelState.IsValid)
            {
                Idea ideaToSave = new Idea()
                {
                    Description = idea.Description,
                    Features = idea.Features,
                    GenderId = idea.GenderId,
                    PublicId = idea.PublicId
                };

                await this.ideaRepository.CreateAsync(ideaToSave);
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
        public async Task<IActionResult> Edit(int id, Idea idea)
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

            await this.ideaRepository.DeleteAsync(idea);
            return RedirectToAction(nameof(Index));
        }

        private IEnumerable<SelectListItem> GetComboGenders()
        {
            List<Gender> genderList = this.genderRepository.GetAll().ToList();

            var list = genderList.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).OrderBy(l => l.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select...)",
                Value = "0"
            });

            return list;
        }

        private IEnumerable<SelectListItem> GetComboPublic()
        {
            List<Public> publicList = this.publicRepository.GetAll().ToList();

            var list = publicList.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).OrderBy(l => l.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select...)",
                Value = "0"
            });

            return list;
        }
    }
}
