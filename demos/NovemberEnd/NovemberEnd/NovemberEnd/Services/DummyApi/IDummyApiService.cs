using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovemberEnd.Services.DummyApi;

/// <summary>
/// These are fake online REST APIs for testing and prototyping sample applications that use rest calls to display listings and crud features. This rest api tutorials, faking a server, and sharing code examples can all be used.
/// </summary>
public interface IDummyApiService
{
    /// <summary>
    /// Get all employee data.
    /// </summary>
    /// <returns></returns>
    Task<DummyApiResult<IEnumerable<DummyApiEmployee>>> GetAllEmployeesAsync();

    /// <summary>
    /// Get a single employee data.
    /// </summary>
    /// <returns></returns>
    Task<DummyApiResult<DummyApiEmployee>> GetSingleEmployeeAsync(long id);

    /// <summary>
    /// Create new record in database.
    /// </summary>
    /// <returns></returns>
    Task<DummyApiResult<DummyApiEmployee>> CreateAsync(DummyApiCreateEmployee employee);
}