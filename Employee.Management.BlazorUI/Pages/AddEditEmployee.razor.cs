using Employee.Management.BlazorUI.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Employee.Management.BlazorUI.Pages
{
    public class AddEditEmployeeBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int empID { get; set; }

        protected string Title = "Add";
        public Employee1 emp = new();
       // protected List<City> cityList = new();
        protected List<string> cityList = new();

        string apiUrl = "https://localhost:44392/api/Employee"; // Replace with your API endpoint


        protected override async Task OnInitializedAsync()
        {
            await GetCityList();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (empID != 0)
            {
                Title = "Edit";
               // emp = await Http.GetFromJsonAsync<Employee1>("api/Employee/" + empID);

                var response = await Http.GetAsync(apiUrl + "/" + empID);
                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<Employee1>(jsonContent);
            }
        }

        protected async Task GetCityList()
        {
            //cityList = await Http.GetFromJsonAsync<List<City>>("api/Employee/GetCityList");

            cityList.Add("Indore");
        }

        protected async Task SaveEmployee()
        {
            if (emp.Id != 0)
            {
                await Http.PutAsJsonAsync("api/Employee", emp);
            }
            else
            {
                await Http.PostAsJsonAsync("api/Employee", emp);
            }
            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/fetchemployee");
        }
    }
}
