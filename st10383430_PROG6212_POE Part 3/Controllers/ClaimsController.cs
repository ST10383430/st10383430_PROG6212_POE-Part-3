using Microsoft.AspNetCore.Mvc;
using st10383430_PROG6212_POE.Data;
using st10383430_PROG6212_POE.Models;

namespace st10383430_PROG6212_POE.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Submit()
        {
            return View(new Claim());
        }

        [HttpPost]
        public IActionResult Submit(Claim claim, IFormFile UploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (UploadedFile != null && UploadedFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    Directory.CreateDirectory(uploadsFolder); // Ensure the folder exists
                    string filePath = Path.Combine(uploadsFolder, UploadedFile.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        UploadedFile.CopyTo(stream);
                    }

                    claim.UploadedFilePath = "/uploads/" + UploadedFile.FileName;
                }

                claim.TotalPayment = claim.HoursWorked * claim.HourlyRate;
                claim.SubmissionDate = DateTime.Now;
                _context.Claims.Add(claim);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            return View(claim);
        }


        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Verify()
        {
            var pendingClaims = _context.Claims.Where(c => c.Status == "Pending").ToList();
            return View(pendingClaims);
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                claim.Status = "Approved";
                _context.SaveChanges();
            }
            return RedirectToAction("Verify");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                claim.Status = "Rejected";
                _context.SaveChanges();
            }
            return RedirectToAction("Verify");
        }

    }



}
