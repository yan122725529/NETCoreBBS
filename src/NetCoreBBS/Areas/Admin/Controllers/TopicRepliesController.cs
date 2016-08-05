using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreBBS.Models;
using Microsoft.AspNetCore.Authorization;

namespace NetCoreBBS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class TopicRepliesController : Controller
    {
        private readonly DataContext _context;

        public TopicRepliesController(DataContext context)
        {
            _context = context;    
        }

        // GET: TopicReplies
        public async Task<IActionResult> Index()
        {
            return View(await _context.TopicReplys.ToListAsync());
        }
        // GET: TopicReplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicReply = await _context.TopicReplys.SingleOrDefaultAsync(m => m.Id == id);
            if (topicReply == null)
            {
                return NotFound();
            }

            return View(topicReply);
        }
    }
}
