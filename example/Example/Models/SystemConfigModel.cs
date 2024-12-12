using PureCode.Core.Models;

namespace Example.Models
{
  public class SystemConfigModel : GlobalSettings
  {
    public DateTime OpenStartDate { get; set; }
    public DateTime OpenEndDate { get; set; }
  }
}
