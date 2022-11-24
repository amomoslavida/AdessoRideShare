using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdessoRideShare.Models;

namespace AdessoRideShare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelplansController : ControllerBase
    {
        private readonly travelPlanContext _context;

        public TravelplansController(travelPlanContext context)
        {
            _context = context;
        }


        [HttpGet("~/GetAll")]
        public async Task<ActionResult<IEnumerable<travelPlan>>> GettravelPlans()
        {
            if (_context.travelPlans == null)
            {
                return NotFound();
            }
            return await _context.travelPlans.ToListAsync();
        }

        [HttpPost("~/AddTravelPlan")]
        public async Task<ActionResult<travelPlan>> AddTravelPlan(travelPlan travelPlan)
        {
            if (_context.travelPlans == null)
            {
                return Problem("Entity set 'travelPlanContext.travelPlans'  is null.");
            }
            _context.travelPlans.Add(travelPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddTravelPlan), new { id = travelPlan.ID }, travelPlan);
        }
        [HttpPost("~/publishTravelPlan/{id}")]
        public async Task<ActionResult<travelPlan>> publishTravelPlan(int id)
        {
            if (_context.travelPlans == null)
            {
                return NotFound();
            }
            var travelPlan = await _context.travelPlans.FindAsync(id);

            if (travelPlan == null)
            {
                return NotFound();
            }
            else
            {
                travelPlan.isPublished = true;
                await _context.SaveChangesAsync();
                return travelPlan;
            }


        }

        [HttpPost("~/unPublishTravelPlan/{id}")]
        public async Task<ActionResult<travelPlan>> unPublishTravelPlan(int id)
        {
            if (_context.travelPlans == null)
            {
                return NotFound();
            }
            var travelPlan = await _context.travelPlans.FindAsync(id);

            if (travelPlan == null)
            {
                return NotFound();
            }
            else
            {
                travelPlan.isPublished = false;
                await _context.SaveChangesAsync();
                return travelPlan;
            }


        }

        [HttpGet("~/searchTravelPlanByFrom/{From}")]
        public async Task<ActionResult<List<travelPlan>>> searchTravelPlanByFrom(string From)
        {
            var travelPlanList = new List<travelPlan>();
            if (_context.travelPlans == null)
            {
                return NotFound();
            }

            //   var travelPlan = await _context.travelPlans.FirstOrDefaultAsync(travelPlan => travelPlan.To == To);
            var travelPlan = await _context.travelPlans.Where(travelPlan => travelPlan.From == From).ToListAsync();

            foreach (var i in travelPlan)
            {
                
                if (i == null)
                {
                    return NotFound();
                }
                if (i.isPublished == true)
                {
                    travelPlanList.Add(i);
                }
                else
                {
                    return Problem("No published travel plan exist to that city");
                }
            }
            return travelPlanList;

        }

        [HttpGet("~/searchTravelPlanByTo/{To}")]
        public async Task<ActionResult<List<travelPlan>>> searchTravelPlanByTo(string To)
        {
            var travelPlanList = new List<travelPlan>();
            if (_context.travelPlans == null)
            {
                return NotFound();
            }

            //   var travelPlan = await _context.travelPlans.FirstOrDefaultAsync(travelPlan => travelPlan.To == To);
            var travelPlan = await _context.travelPlans.Where(travelPlan => travelPlan.To == To).ToListAsync();

            foreach (var i in travelPlan)
            {
                
                if (i == null)
                {
                    return NotFound();
                }
                if (i.isPublished == true)
                {
                    travelPlanList.Add(i);
                }
                else
                {
                    return Problem("No published travel plan exist to that city");
                }
            }
            return travelPlanList;
                
        }

        [HttpPost("~/JoinTravel/{id}")]
        public async Task<ActionResult<travelPlan>> JoinTravel(int id)
        {
            if (_context.travelPlans == null)
            {
                return NotFound();
            }
            var travelPlan = await _context.travelPlans.FindAsync(id);

            if (travelPlan == null)
            {
                return NotFound();
            }

            if (travelPlan.NumberOfTravelers < travelPlan.maxSeats && travelPlan.isPublished == true)
            {

                travelPlan.NumberOfTravelers++;
                await _context.SaveChangesAsync();
                return travelPlan;
            }
            else return Problem("All seats are Taken");


        }

    }
}
