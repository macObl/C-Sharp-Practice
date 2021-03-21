using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab6.Models.DataAccess;
using Lab6.Models.ViewModels;

namespace Lab6.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly StudentRecordContext _context;

        public EmployeesController(StudentRecordContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            EmployeeRoleSelections employeeRoleSelections = new EmployeeRoleSelections();
            return View(employeeRoleSelections);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeRoleSelections employeeRoleSelections)
        {
            if (!employeeRoleSelections.roleSelections.Any(m => m.Selected))
            {
                ModelState.AddModelError("roleSelections", "You must select at least one role!");
            }
            if (_context.Employee.Any(e => e.UserName == employeeRoleSelections.employee.UserName))
            {
                ModelState.AddModelError("employee.UserName", "This username already exists!");
            }
            if (ModelState.IsValid)
            {
                _context.Add(employeeRoleSelections.employee);
                _context.SaveChanges();

                foreach (RoleSelection roleSelection in employeeRoleSelections.roleSelections)
                {
                    if (roleSelection.Selected)
                    {
                        EmployeeRole employeeRole = new EmployeeRole
                        {
                            RoleId = roleSelection.role.Id,
                            EmployeeId = employeeRoleSelections.employee.Id
                        };
                        _context.EmployeeRole.Add(employeeRole);
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeRoleSelections);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            List<EmployeeRole> employeeRoles = (_context.EmployeeRole.Where(m => m.EmployeeId == id)).ToList();

            EmployeeRoleSelections employeeRoleSelections = new EmployeeRoleSelections();
            employeeRoleSelections.employee = employee;
            for (int i = 0; i < employeeRoleSelections.roleSelections.Count; i++)
            {
                if (employeeRoles.Exists(m => m.RoleId == employeeRoleSelections.roleSelections[i].role.Id))
                {
                    employeeRoleSelections.roleSelections[i].Selected = true;
                }
            }
            return View(employeeRoleSelections);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeRoleSelections employeeRoleSelections)
        {
            if (!employeeRoleSelections.roleSelections.Any(mbox => mbox.Selected))
            {
                ModelState.AddModelError("roleSelections", "You must select one role!");
            }
            if (id != employeeRoleSelections.employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeRoleSelections.employee);
                    _context.SaveChanges();

                    var rolesSelected = _context.EmployeeRole.Where(e => e.EmployeeId == employeeRoleSelections.employee.Id).ToList();
                    _context.RemoveRange(rolesSelected);

                    foreach (RoleSelection roleSelection in employeeRoleSelections.roleSelections)
                    {
                        if (roleSelection.Selected)
                        {
                            EmployeeRole employeeRole = new EmployeeRole
                            {
                                RoleId = roleSelection.role.Id,
                                EmployeeId = employeeRoleSelections.employee.Id
                            };
                            _context.EmployeeRole.Add(employeeRole);
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employeeRoleSelections.employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeRoleSelections);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            List<EmployeeRole> employeeRoles = (_context.EmployeeRole.Where(m => m.EmployeeId == id)).ToList();
            EmployeeRoleSelections employeeRoleSelections = new EmployeeRoleSelections();
            employeeRoleSelections.employee = employee;

            for (int i = 0; i < employeeRoleSelections.roleSelections.Count; i++)
            {
                if (employeeRoles.Exists(m => m.RoleId == employeeRoleSelections.roleSelections[i].role.Id))
                {
                    employeeRoleSelections.roleSelections[i].Selected = true;
                }

            }

            //EmployeeRoleSelections employeeRoleSelections = new EmployeeRoleSelections { employee = employee, roleSelections = roleSelections };
            return View(employeeRoleSelections);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolesSelected = _context.EmployeeRole.Where(e => e.EmployeeId == id).ToList();
            _context.RemoveRange(rolesSelected);

            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
