using Newtonsoft.Json;

namespace NovemberEnd.Services.DummyApi;

public class DummyApiEmployee
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("employee_name")]
    public string EmployeeName { get; set; }

    [JsonProperty("employee_salary")]
    public decimal EmployeeSalary { get; set; }

    [JsonProperty("employee_age")]
    public int EmployeeAge { get; set; }

    [JsonProperty("profile_image")]
    public string ProfileImage { get; set; }
}