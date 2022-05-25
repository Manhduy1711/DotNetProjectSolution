using System.ComponentModel;

namespace DotNetProject.Models
{
    public class DataModel
    {
        [DisplayName("Chương")]
        public string Chuong { get; set; }
        [DisplayName("Nội dung chương")]
        public string NoiDungChuong { get; set; }
        [DisplayName("Mục")]
        public int? Muc { get; set; }
        [DisplayName("Nội dung mục")]
        public string? NoiDungMuc { get; set; }
        [DisplayName("Điều")]
        public int Dieu { get; set; }
        [DisplayName("Nội dung điều")]
        public string NoiDungDieu { get; set; }
        [DisplayName("Khoản")]
        public int? Khoan { get; set; }
        [DisplayName("Nội dung khoản")]
        public string NoiDung { get; set; }
        [DisplayName("Mức phạt dưới")]
        public int? MucPhatDuoi { get; set; }
        [DisplayName("Mức phạt trên")]
        public int? MucPhatTren { get; set; }
        public int Id { get; set; }
        public DataModel()
        {
        }
        public DataModel(string chuong, string noiDungChuong, int? muc, string? noiDungMuc, int dieu, string noiDungDieu, int? khoan, string noiDung, int? mucPhatDuoi, int? mucPhatTren, int id)
        {
            Id = id;
            Chuong = chuong;
            NoiDungChuong = noiDungChuong;
            Muc = muc;
            NoiDungMuc = noiDungMuc;
            Dieu = dieu;
            NoiDungDieu = noiDungDieu;
            Khoan = khoan;
            NoiDung = noiDung;
            MucPhatDuoi = mucPhatDuoi;
            MucPhatTren = mucPhatTren;
        }
    }
}
