using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quickTask.Models;
using Microsoft.AspNetCore.Authorization;
using quickTask.Contracts;
using Microsoft.AspNetCore.SignalR;
using quickTask.Hubs;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace quickTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private IUnitOfWork _unitOfWork;
        ClaimsPrincipal currentUser;
        public HomeController(IUnitOfWork unitOfWork,IHubContext<NotificationHub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
            currentUser = this.User;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Paitents.GetAll());
        }

        // GET: Patient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient =  await _unitOfWork.Paitents.Get(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,City")] Patient patient)
        {
            if (ModelState.IsValid)
            {

                await _unitOfWork.Paitents.Add(patient);
                _unitOfWork.Complete();
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", "admin", "Paitent added");
                return RedirectToAction(nameof(Index));

            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var patient = await _unitOfWork.Paitents.Get(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,City")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Paitents.Update(patient);
                    _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
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
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _unitOfWork.Paitents.Get(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _unitOfWork.Paitents.Get(id);
            await _unitOfWork.Paitents.Delete(patient.Id);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _unitOfWork.Paitents.GetAll().Result.Any(e => e.Id == id);

        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
