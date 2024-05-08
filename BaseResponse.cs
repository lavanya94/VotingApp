using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
  public class BaseResponse
  {
    public BaseResponse()
    {
      Success = true;
    }

    public BaseResponse(string message = null)
    {
      Success = true;
      Message = message;
    }

    public BaseResponse(string message, bool success)
    {
      Success = success;
      Message = message;
    }

    /// <summary>
    /// Indicates whether request was successful
    /// </summary>
    public bool Success { get; set; }
    /// <summary>
    /// Response message if needed
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// List of validation error messages if any
    /// </summary>
    public List<string> ValidationErrors { get; set; } = new();
  }
}
