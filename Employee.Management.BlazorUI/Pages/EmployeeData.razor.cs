using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Employee.Management.BlazorUI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Employee.Management.BlazorUI.Pages
{
    public class EmployeeDataBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        protected List<Employee1> empList = new();
        protected List<Employee1> searchEmpData = new();
        protected Employee1 emp = new();
        protected string SearchString { get; set; } = string.Empty;

            string apiUrl = "https://localhost:44392/api/Employee"; // Replace with your API endpoint


        protected override async Task OnInitializedAsync()
        {
            await GetEmployee();
        }




        // private readonly HttpClient _httpClient;



        //public async Task<List<Employee1>> GetEmployees()
        //{
        //    var apiUrl = "https://localhost:44392/api/Employee"; // Replace with your API endpoint

        //    try
        //    {
        //        var response = await _httpClient.GetAsync(apiUrl);
        //        response.EnsureSuccessStatusCode();

        //        var jsonContent = await response.Content.ReadAsStringAsync();
        //        var employees = JsonSerializer.Deserialize<List<Employee1>>(jsonContent);

        //        return employees;
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        // Handle request errors
        //        // ...
        //        throw;
        //    }
        //    catch (JsonException ex)
        //    {
        //        // Handle JSON deserialization errors
        //        // ...
        //        throw;
        //    }
        //}








        protected async Task GetEmployee()
        {


         
                var response = await Http.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<List<Employee1>>(jsonContent);

            empList = employees;
            searchEmpData = empList;
        }

        protected void FilterEmp()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                empList = searchEmpData
                    .Where(x => x.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }
            else
            {
                empList = searchEmpData;
            }
        }

        protected void DeleteConfirm(int empID)
        {
            emp = empList.FirstOrDefault(x => x.Id == empID);
        }

        protected async Task DeleteEmployee(int empID)
        {

            var response = await Http.DeleteAsync(apiUrl + "/"+ empID);
            response.EnsureSuccessStatusCode();
            await GetEmployee();
        }


        public void ResetSearch()
        {
            SearchString = string.Empty;
            empList = searchEmpData;
        }
    }
}
