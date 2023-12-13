using Newtonsoft.Json;

namespace NovemberEnd.Services.DummyApi;

public class DummyApiResult<TPayload>
{
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("data")]
    public TPayload Data { get; set; }
    
    [JsonProperty("message")]
    public string Message { get; set; }
}