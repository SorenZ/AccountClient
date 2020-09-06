using System;
using System.Collections.Generic;
using System.Linq;
using DotNetify;
using DotNetify.Routing;
using DotNetify.Security;
using mytemplate;

namespace MyTemplate.server.Services
{
   [Authorize]
   public class ContactVm : BaseVM
   {
      private readonly IEmployeeService _employeeService;

      public class EmployeeInfo
      {
         public int Id { get; set; }
         public string Name { get; set; }
         public Route Route { get; set; }
      }

      public class SavedEmployeeInfo
      {
         public int Id { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
      }

      public RoutingState RoutingState { get; set; }

      public IEnumerable<EmployeeInfo> Employees =>
          _employeeService
              .GetAll()
              .OrderBy(i => i.LastName)
              .Select(i => new EmployeeInfo
              {
                 Id = i.Id,
                 Name = i.FullName,
              });

      public int Id
      {
         get => Get<int>();
         set => Set(value);
      }

      public string FirstName
      {
         get => Get<string>();
         set => Set(value);
      }

      public string LastName
      {
         get => Get<string>();
         set => Set(value);
      }

      public Action<int> Cancel => id => LoadEmployee(id);

      public Action<SavedEmployeeInfo> Save => changes =>
      {
         var record = _employeeService.GetById(changes.Id);
         if (record != null)
         {
            record.FirstName = changes.FirstName;
            record.LastName = changes.LastName;
            _employeeService.Update(record);
            Changed(nameof(Employees));
         }
      };

      public ContactVm(IEmployeeService employeeService)
      {
         _employeeService = employeeService;
      }

      private void LoadEmployee(int id)
      {
         var record = _employeeService.GetById(id);
         if (record != null)
         {
            FirstName = record.FirstName;
            LastName = record.LastName;
            Id = record.Id;
         }
      }
   }
}