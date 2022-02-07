using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class EmployeePermissionListViewComponent:ViewComponent
    {
        IEmployeeService employeeService;

        public EmployeePermissionListViewComponent(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                List<Permission> permissions = employeeService.GetPermissionListEmployees(id);

                if (permissions != null)
                {
                    List<PermissionVM> permissionVMs = new List<PermissionVM>();
                    foreach (Permission permission in permissions)
                    {
                        PermissionVM permissionVM = new PermissionVM()
                        {
                            ID = permission.PermissionId,
                            FullName = permission.Employee.FullName.Trim(),
                            Statu = permission.Employee.Status.Trim(),
                            PermissionType = permission.PermissionType,
                            StartDate = permission.StartDate,
                            FinishDate = permission.FinishDate,
                            IsAproved = permission.isAproved
                        };
                        permissionVMs.Add(permissionVM);

                    }
                    return View(permissionVMs);
                }
                else
                {
                    throw new Exception("İzin isteği yok.");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }
    }
}

