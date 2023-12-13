using Newtonsoft.Json;

namespace NovemberEnd.Services.DummyApi;

public class DummyApiCreateEmployee
{
    [JsonProperty("employee_name")]
    public string EmployeeName { get; set; }

    [JsonProperty("employee_salary")]
    public decimal EmployeeSalary { get; set; }

    [JsonProperty("employee_age")]
    public int EmployeeAge { get; set; }
}