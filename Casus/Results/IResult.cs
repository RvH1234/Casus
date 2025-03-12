namespace Casus.Results
{
    /// <summary>
    /// Contract for indicating a result
    /// </summary>
    public interface IResult
    {
        string? ErrorMessage { get;  }
        bool Succeeded { get;  }
    }
    /// <summary>
    /// Contract for indicating a result of type T
    /// </summary>
    public interface IResult<out T> : IResult
    { 
        T Value { get;  }
    }
}