using System;
using System.Collections.Generic;

namespace nguyenkhacminh__241224482_de2026.Models;

public partial class TheLoai
{
    public int MaTl { get; set; }

    public string TenTl { get; set; } = null!;

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
