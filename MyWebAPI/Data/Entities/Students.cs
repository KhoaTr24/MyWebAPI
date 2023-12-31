﻿using MyWebAPI.Data.Contexts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI.Data.Entities
{
    [Table("SinhVien")]
    public class Students
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? HoTen { get; set; }
        public int? MSSV { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? NTNS { get; set; }
        [MaxLength(100)]
        public string DiaChi { get; set; }
        public int SDT { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public Diem Diem { get; set; }
    }
    [Table("Diem")]
    public class Diem
    {
        Students s = new Students();
        public int Id { get; set; }
        [MaxLength(50)]
        public string? HoTen { get; set; }
        public int? MSSV { get { return s.MSSV; } }
        [MaxLength(50)]
        public string? TenHocPhan { get; set; }
        [Range(3,3)]
        public int STC { get; set; }
        [Range(0, 10)]
        public double DiemGiuaKy { get; set; }
        [Range(0, 10)]
        public double DiemCuoiKy { get; set; }
        [Range(0, 10)]
        public double DiemTrungBinh { get { return (DiemGiuaKy + DiemCuoiKy) / 2; } }
    }
}
