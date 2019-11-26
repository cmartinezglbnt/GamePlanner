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
    public class MeetingsController : Controller
    {
        private readonly IMeetingRepository meetingRepository;

        public MeetingsController(IMeetingRepository meetingRepository)
        {
            this.meetingRepository = meetingRepository;
        }

        // GET: Meetings
        public IActionResult Index()
        {
            return View(this.meetingRepository.GetAll());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await this.meetingRepository.GetByIdAsync(id.Value);

            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                await this.meetingRepository.CreateAsync(meeting);
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await this.meetingRepository.GetByIdAsync(id.Value);

            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Meeting meeting)
        {
            if (id != meeting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.meetingRepository.UpdateAsync(meeting);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var currentMeeting = await this.meetingRepository.GetByIdAsync(id);

                    if (currentMeeting == null)
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
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await this.meetingRepository.GetByIdAsync(id.Value);

            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }
    }
}
