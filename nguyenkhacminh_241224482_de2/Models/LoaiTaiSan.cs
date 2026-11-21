using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace nguyenkhacminh_241224482_de2.Models;

public partial class LoaiTaiSan
{
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<TaiSan> TaiSans { get; set; } = new List<TaiSan>();
}
