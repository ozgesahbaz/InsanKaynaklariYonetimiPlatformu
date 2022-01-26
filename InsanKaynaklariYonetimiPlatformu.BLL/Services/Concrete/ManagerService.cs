using InsanKaynaklariYonetimiPlatformu.DAL.Repositories;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsanKaynaklariYonetimiPlatformu.ViewModels;
using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;

namespace InsanKaynaklariYonetimiPlatformu.BLL.Services.Concrete
{
    public class ManagerService : IManagerService
    {
        IManagerRepository managerRepository;
        public ManagerService(IManagerRepository _managerRepository)
        {
            managerRepository = _managerRepository;

        }
        public Company AddCompany(string companyName, string managerMail, MembershipType membership, string address)
        {
            string mailextension = GetMailExtension(managerMail);
            if (managerRepository.AnyMailExtension(mailextension))
            {
                throw new Exception("Bu şirket zaten kayıtlı.");
            }
            Company company = new Company()
            {
                CompanyName = companyName,
                MailExtension = mailextension,
                RegisterDate = DateTime.Now,
                Address = address
            };
            if (managerRepository.InsertCompany(company) > 0)
            {
                Membership membershipp = new Membership
                {
                    MembershipType = membership,
                    CompanyId = company.CompanyId
                };
                if (managerRepository.InsertMemberShip(membershipp) > 0)
                {
                    return company;
                }
            }
            throw new Exception("Bir hata oluştu.");
        }

        public Manager CheckLogin(LoginVM Login)
        {
            Manager manager = managerRepository.CheckLogin(Login.Email, Login.Password);
            if (manager != null)
            {
                if (manager.IsApproved && manager.IsActive)
                {
                    return manager;
                }
            }
            return null;
        }

        public Manager AddManager(ManagerRegisterVM register, Company company)
        {
            string mailextension = GetMailExtension(register.ManagerMail);
            if (managerRepository.AnyMail(register.ManagerMail))
            {
                throw new Exception("Bu kullanıcı zaten kayıtlı.");
            }
            if (mailextension != company.MailExtension)
            {
                throw new Exception("Bağlı olduğunuz şirketin mail uzantısına ait mail ile kayıt yapabilirsiniz");
            }
            Manager manager = new Manager()
            {
                FullName = register.ManagerFullName,
                CompanyId = company.CompanyId,
                //StatusType = StatusType.CompanyManager, // statustype propertisi kaldırıldı admin db olusturuldugundan 
                Password = register.ManagerPassword,
                Email = register.ManagerMail,
                IsActive = false,
                IsApproved = false
            };
            if (managerRepository.InsertManager(manager) > 0)
            {
                return manager;
            }
            else
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        public string GetMailExtension(string managerMail)
        {
            string mailextension;
            string[] mailPart = managerMail.Split('@');
            string[] mailextensionPart = mailPart[1].Split('.');
            mailextension = mailextensionPart[0];
            return mailextension;
        }

        public bool ManagerApproval(int id)
        {
            return managerRepository.managerApproval(id); //
        }

        public Company FindCompany(int companyId)
        {
            return managerRepository.FindComapny(companyId);
        }

        public Manager FindManager(int managerId)
        {
            return managerRepository.FindManager(managerId);
        }

        public Company FindCompanyByManagerID(int id)
        {
            return managerRepository.FindCompany(id);
        }

        public List<DebitVM> GetListDebit(int id)
        {
            List<Debit> debits = managerRepository.GetListDebit(id);
            List<DebitVM> debitVMs = new List<DebitVM>();
            foreach (Debit debit in debits)
            {
                DebitVM debitVM = new DebitVM()
                {
                    ID = debit.ID,
                    EmployeeName = debit.Employee.FullName,
                    DebitName = debit.DebitName,
                    StartedDate = debit.StartedDate,
                    Details = debit.Details,
                    IsAproved = debit.IsAproved,
                    DescofRejec = debit.DescofRejec

                };
                debitVMs.Add(debitVM);


            }
            return debitVMs;
        }

        public int AddPermissionEmployee(AddEmployeesPermissionVM permissionVM, int id)
        {
            //izin eklemeden önce girilen tarih değerleri kontrol edilir.
            if (permissionVM.StartDate > permissionVM.FinishDate)
            {
                throw new Exception("Bitiş tarihi başlangıç tarihinden daha ileri bir tarih olmalıdır.");
            }
            else
            {
                //Hata yok ise girilen inputlar db tarafına gönderilir.
                Permission permission = new Permission()
                {
                    EmployeeId = permissionVM.EmployeeID,
                    ManagerId = id,
                    StartDate = permissionVM.StartDate,
                    FinishDate = permissionVM.FinishDate,
                    isAproved = true,
                    PermissionType = permissionVM.PermissionType
                };
                return managerRepository.AddEmployeePermission(permission);
            }

        }

        public PermissionVM GetPermissionById(int id)
        {
            Permission permission = managerRepository.GetPermissionById(id);
            if (permission != null)
            {
                PermissionVM permissionVM = new PermissionVM()
                {
                    ID = permission.PermissionId,
                    FullName = permission.Employee.FullName,
                    StartDate = permission.StartDate,
                    FinishDate = permission.FinishDate,
                    Statu = permission.Employee.Status,
                    IsAproved = permission.isAproved,
                    PermissionType = permission.PermissionType
                };
                return permissionVM;
            }


            return null;
        }

        public int UpdatePermission(PermissionVM permissionVM)
        {
            Permission permission = managerRepository.GetPermissionById(permissionVM.ID);
            permission.isAproved = permissionVM.IsAproved;
            permission.StartDate = permissionVM.StartDate;
            permission.FinishDate = permissionVM.FinishDate;
            permission.PermissionType = permission.PermissionType;
            return managerRepository.UpdatePermission(permission);
        }

        public int RemovePermission(int id)
        {
            Permission permission = managerRepository.GetPermissionById(id);
            return managerRepository.DeletedPermission(permission);
        }

        public List<ShiftDetailsVM> GetShiftDetail(int managerID)
        {

            List<ShiftDetailsVM> shiftDetailsVms = new List<ShiftDetailsVM>();
            ShiftDetailsVM shiftDetailsVm = new ShiftDetailsVM();
           shiftDetailsVm.Employees = managerRepository.GetEmployeesByManagerId(managerID);

            foreach (Employee employee in shiftDetailsVm.Employees)
            {

                shiftDetailsVm.EmployeeID = employee.EmployeeId;
                shiftDetailsVm.EmployeeFullName = employee.FullName;

                List<Shift> Shifts = managerRepository.GetShiftbyEmployeeId(employee.EmployeeId);
                foreach (Shift item in Shifts)
                {

                    shiftDetailsVm.ShiftFinishTime = item.ShiftFinishTime;
                    shiftDetailsVm.ShiftStartTime = item.ShiftStartTime;
                    List<Respite> respites = managerRepository.GetRespitebyShiftId(item.ShiftId);
                    foreach (Respite respite in respites)
                    {
                        shiftDetailsVm.RespiteFinishTime = respite.RespiteFinishTime;
                        shiftDetailsVm.RespiteStartTime = respite.RespiteStartTime;
                    }

                }

                shiftDetailsVms.Add(shiftDetailsVm);
            }

            return shiftDetailsVms;

        }

        public bool AddShiftDetails(ShiftDetailsVM ShiftDetailsVM, int managerID)
        {
            Shift shift = new Shift();
            Respite respite = new Respite();

            shift.EmployeeID = ShiftDetailsVM.EmployeeID;
            shift.ShiftFinishTime = ShiftDetailsVM.ShiftFinishTime;
            shift.ShiftStartTime = ShiftDetailsVM.ShiftStartTime;

            if (managerRepository.addShiftDetails(shift))
            {
                int LastofAddedShiiftID = managerRepository.GetShiftOrderyBydescending();
                respite.ShiftId = LastofAddedShiiftID;
                respite.RespiteFinishTime = ShiftDetailsVM.RespiteFinishTime;
                respite.RespiteStartTime = ShiftDetailsVM.RespiteStartTime;

              bool isadded= managerRepository.addRespitebyShiftID(respite)? true: false;
                return isadded;

            }

            else
            {
                throw new Exception(" ekleme yapılamadı.");

            }



        }

        public int AddEmployeesDebit(int id, AddEmployeesDebitVM debitVM)
        { //AddEmployeesDebitVm referans alarak Debite çeviriyoruz. Db debit atabiliriz. Bu sebeple AddEmployee debite çevrilmeli
            Debit debit = new Debit()
            {
                ManagerID = id,
                EmployeeID = debitVM.EmployeeID,
                DebitName = debitVM.DebitName,
                StartedDate = debitVM.StartedDate,
                Details = debitVM.Details


            };
            //Sayfanın gitmesi gereken yer

            return managerRepository.AddEmployeeDebit(debit);
        }
        public List<ManagersPermissionVM> GetPermissionListManagers(int id)
        {
            List<Permission> permissions = managerRepository.GetPermissionByManagerId(id);
            if (permissions != null)
            {
                List<ManagersPermissionVM> permissionVMs = new List<ManagersPermissionVM>();
                foreach (Permission permission in permissions)
                {
                    ManagersPermissionVM permissionVM = new ManagersPermissionVM()
                    {
                        StartDate = permission.StartDate,
                        FinishDate = permission.FinishDate,
                        PermissionType = permission.PermissionType,
                        IsAproved = true,
                        ID = permission.PermissionId
                    };
                    permissionVMs.Add(permissionVM);
                }
                return permissionVMs;
            }


            return null;
        }

        public int AddManagersPermission(int id, ManagersPermissionVM permissionVM)
        {
            Permission permission = new Permission()
            {
                StartDate = permissionVM.StartDate,
                PermissionType = permissionVM.PermissionType,
                FinishDate = permissionVM.FinishDate,
                ManagerId = id,
                EmployeeId = null,
                isAproved = true,
            };
            return managerRepository.AddPermissionManager(permission);
        }

        public ManagersPermissionVM UpdatePermissionManager(int id)
        {
            Permission permission = managerRepository.GetPermissionById(id);
            ManagersPermissionVM permissionVM = new ManagersPermissionVM()
            {
                ID = permission.PermissionId,
                StartDate = permission.StartDate,
                FinishDate = permission.FinishDate,
                PermissionType = permission.PermissionType
            };

            return permissionVM;
        }

        public int UpdatePermissionManager(int id, ManagersPermissionVM permissionVM)
        {
            Permission permission = managerRepository.GetPermissionById(id);
            permission.PermissionType = permissionVM.PermissionType;
            permission.StartDate = permissionVM.StartDate;
            permission.FinishDate = permissionVM.FinishDate;

            return managerRepository.UpdatePermissionManager(permission);
        }

        public int RemoveDebit(int id)
        {
            Debit debit = managerRepository.GetDebitById(id);
            return managerRepository.DeletedDebit(debit);
        }


        public List<Shift> GetShiftDetailbyEmployeeId(int employeeId)
        {
            return managerRepository.GetShiftbyEmployeeId(employeeId);
        }

        public List<Respite> GetRespitebyShiftId(int shiftId)
        {
          return managerRepository.GetRespitebyShiftId(shiftId);
        }
    }
}
