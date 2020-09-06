using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xero.NetStandard.OAuth2.Api;
using Xero.NetStandard.OAuth2.Client;
using Xero.NetStandard.OAuth2.Model;
using Xero.NetStandard.OAuth2.Token;

namespace mytemplate
{
    public class XeroEmployeeService : IEmployeeService
    {
        public static IXeroToken Token { get; set; }
        public static IXeroClient Client;
        private readonly IAccountingApi _accountingApi;
        private readonly ILogger<XeroEmployeeService> _logger;
        private readonly List<EmployeeModel> _employees = new List<EmployeeModel>();
        // private readonly List<EmployeeModel> _internalEmployee = new List<EmployeeModel>();


        public XeroEmployeeService(IAccountingApi accountingApi, ILogger<XeroEmployeeService> logger)
        {
            _accountingApi = accountingApi;
            _logger = logger;
        }

        public IList<EmployeeModel> GetAll()
        {
            _logger.LogInformation("call GetAll()");
            
            if(!_employees.Any())
                InitEmployee();
            
            return _employees;
        }
        

        public EmployeeModel GetById(int id) => _employees.ToList().FirstOrDefault(q => q.Id == id);

        public int Add(EmployeeModel record)
        {
            _employees.Add(record);
            // _internalEmployee.Add(record);
            return record.Id;
        }

        public void Update(EmployeeModel record)
        {
            if (record.ContactId == null) return;
            
            var contact = GetContact(record.ContactId.Value);

            var employee = _employees.FirstOrDefault(q => q.ContactId == record.ContactId.Value);

            if (employee != null)
            {
                employee.FirstName = contact._Contacts.First().FirstName;
                employee.LastName = contact._Contacts.First().LastName;
            }
            
            // _internalEmployee.Add(employee);
        }

        private Contacts GetContact(Guid contactId)
        {
            if (Token == null)
                return null;

            var connections = Client.GetConnectionsAsync(Token).Result;

            var contact = _accountingApi.GetContactAsync(Token.AccessToken, connections[0].TenantId.ToString()
                , contactId).Result;
            return contact;
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        private void InitEmployee()
        {
            if (Token == null)
                return;
            
            var connections =  Client.GetConnectionsAsync(Token).Result;
            
            var contacts = _accountingApi.GetContactsAsync(Token.AccessToken, connections[0].TenantId.ToString()).Result;
            var id = 0;
            
            _employees.AddRange(
                contacts._Contacts.Select(s => 
                    new EmployeeModel
                    {
                        Id = ++id,
                        ContactId = s.ContactID,
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    }));
        }
    }
}