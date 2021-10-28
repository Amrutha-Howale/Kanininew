using EmployeeFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmployeeFrontEnd.Services
{
    public class LoginServices
    {
        public EmployeeDTO Register(EmployeeDTO empDTO)
        {
            EmployeeDTO employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:32991/api/");
                var postTask = client.PostAsJsonAsync<EmployeeDTO>("Employee", empDTO);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<EmployeeDTO>();
                    data.Wait();
                    employee = data.Result;
                }
            }
            return employee;
        }
        public EmployeeDTO Login(EmployeeDTO empDTO)
        {
            EmployeeDTO employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:32991/api/");
                var postTask = client.PostAsJsonAsync<EmployeeDTO>("Employee/Login", empDTO);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<EmployeeDTO>();
                    data.Wait();
                    employee = data.Result;
                }
            }
            return employee;
        }
        public string CallEmployee(string token)
        {
            string employeeData = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:39011/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = client.GetAsync("Employee");
                getTask.Wait();
                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync();
                    data.Wait();
                    employeeData = data.Result;

                }
            }
            return employeeData;
        }
        public EmployeeAddDTO EmployeeAdd(EmployeeAddDTO empDto)
        {
            EmployeeAddDTO emplDTO = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:39011/api/");
                var postTask = client.PostAsJsonAsync<EmployeeAddDTO>("Employee", empDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<EmployeeAddDTO>();
                    data.Wait();
                    emplDTO = data.Result;



                }
            }
            return emplDTO;
        }
    }
}
