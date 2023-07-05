using System;
using System.Collections.Generic;

namespace Asp.netCoreApi.Models;

public partial class TblEmployee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime? DOJ { get; set; }=null!;
}
