using System;

namespace NovemberEnd.Services.DummyApi;

public class DummyApiException : Exception
{
    public DummyApiException(string message)
        : base(message)
    {
        
    }
}