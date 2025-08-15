using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhamKieuTrang_2023602849_LuyenTapV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<CongNhan> congnhans;
        public MainWindow()
        {
            InitializeComponent();
            congnhans = new ObservableCollection<CongNhan>();
            congnhans.Add(new CongNhan("nv1", "Trần Long", "02/07/2004", "Nam", "Hà Nội", 25000));
            congnhans.Add(new CongNhan("nv2", "Trần Nam", "06/07/2004", "Nam", "Hà Nội", 35000));
            dg.ItemsSource = congnhans;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            string MaCN = txtMa.Text.Trim();
            string HoTen = txtHoTen.Text.Trim();
            string NgaySinh = dpNgaySinh.Text.Trim();
            string GioiTinh = rbNam.IsChecked == true ? "Nam" : "Nữ";
            string DiaChi = cboDiaChi.Text.Trim();
            string Luong = txtLuong.Text.Trim();
            bool isvalid = true;
            if (string.IsNullOrEmpty(MaCN))
            {
                errMa.Content = "Không để trống mã";
                isvalid = false;
            }
            else if (congnhans.Any(cn => cn.MaCN == txtMa.Text))
            {
                errMa.Content = "Trùng mã nhân viên";

                isvalid = false;
            }
            else
            {
                errMa.Content = "";
            }
            if (string.IsNullOrEmpty(HoTen))
            {
                errHoTen.Content = "Không để trống họ tên";
                isvalid = false;
            }
            else
            {
                errHoTen.Content = "";
            }
            if (string.IsNullOrEmpty(NgaySinh))
            {
                errNgaySinh.Content = "Không để trống ngày sinh";
            }
            else
            {
                if (DateTime.TryParse(NgaySinh, out DateTime dt))
                {
                    if (dt > DateTime.Now)
                    {
                        errNgaySinh.Content = "Ngày sinh không được lớn hơn ngày hiện tại";
                    }
                    else
                    {
                        errNgaySinh.Content = "";
                    }
                }
                else
                {
                    errNgaySinh.Content = "Ngày sinh không hợp lệ";
                }
            }
            if (string.IsNullOrEmpty(GioiTinh))
            {
                errGioiTinh.Content = "Không để trống giới tính";
            }
            else
            {
                errGioiTinh.Content = "";
            }
            if (!float.TryParse(txtLuong.Text, out float luong) || luong < 0 || luong > 100000)
            {
                errLuong.Content = "0<luong<100000 va khoong de trong";
            }
            else
            {
                errLuong.Content = "";
            }
            if (isvalid)
            {
                congnhans.Add(new CongNhan(MaCN, HoTen, NgaySinh, GioiTinh, DiaChi, luong));
                /* sapxep()*/
                
                clear();
                txtMa.Focus();
            }
        }

        private void clear()
        {
            txtMa.Clear();
            txtHoTen.Clear();
            dpNgaySinh.SelectedDate = null;
            rbNam.IsChecked = false;
            cboDiaChi.SelectedIndex = -1;
            txtLuong.Clear();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = dg.SelectedItem as CongNhan;
            if (selected != null)
            {
                txtMa.Text = selected.MaCN;
                txtHoTen.Text = selected.HoTen;
                if (DateTime.TryParse(selected.NgaySinh, out DateTime ngaysinh))
                {
                    dpNgaySinh.SelectedDate = ngaysinh;
                }
                else
                {
                    dpNgaySinh.SelectedDate = null;
                }
                if (selected.GioiTinh == "Nam")
                {
                    rbNam.IsChecked = true;
                }
                if (selected.GioiTinh == "Nữ")
                {
                    rbNu.IsChecked = true;
                }
                cboDiaChi.Text = selected.DiaChi;
                txtLuong.Text = selected.Luong.ToString();
            }
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            var selcted = dg.SelectedItem as CongNhan;
            if (!float.TryParse(txtLuong.Text, out float luong) || luong < 0 || luong > 100000)
            {
                errLuong.Content = "0<luong<100000 va khong de trong";
            }
            else
            {
                errLuong.Content = "";
            }
            if (selcted != null)
            {
                selcted.MaCN = txtMa.Text.Trim();
                selcted.HoTen = txtHoTen.Text.Trim();
                //selcted.NgaySinh = dpNgaySinh.Text.Trim();
                if (dpNgaySinh.SelectedDate.HasValue)
                {
                    DateTime dt = dpNgaySinh.SelectedDate.Value;
                    if (dt > DateTime.Now)
                    {
                        errNgaySinh.Content = "Ngày sinh không được lớn hơn ngày hiện tại";
                        return;
                    }
                    else
                    {
                        errNgaySinh.Content = "";
                        selcted.NgaySinh = dt.ToString("dd/MM/yyyy"); 
                    }
                }
                selcted.GioiTinh = rbNam.IsChecked == true ? "Nam" : "Nữ";
                selcted.Luong = luong;
                dg.Items.Refresh();
                clear();
            }
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            //var selcted = dg.SelectedItem as CongNhan;
            //var ch = MessageBox.Show("Bạn có chắc muốn xóa không", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //if (ch==MessageBoxResult.Yes)
            //{
            //    congnhans.Remove(selcted);
            //}
            string maNhap = txtMa.Text.Trim();

            if (!string.IsNullOrEmpty(maNhap))
            {
                var cn = congnhans.FirstOrDefault(x => x.MaCN == maNhap);

                if (cn != null)
                {
                    var ch = MessageBox.Show(
                        $"Bạn có chắc muốn xóa công nhân có mã {maNhap} không?",
                        "Xác nhận xóa",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question
                    );

                    if (ch == MessageBoxResult.Yes)
                    {
                        congnhans.Remove(cn);
                        txtMa.Clear();
                        txtHoTen.Clear();
                        dpNgaySinh.SelectedDate = null;
                        rbNam.IsChecked = false;
                        rbNu.IsChecked = false;
                        txtLuong.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy công nhân có mã này!", "Thông báo",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã công nhân để xóa!", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_View(object sender, RoutedEventArgs e)
        {
            //if (nhanviens.Count == 0) return;

            //double maxTien = nhanviens.Max(nv => nv.Tien);

            //List<NhanVien> li = nhanviens.Where(nv => nv.Tien == maxTien).ToList();
            List<CongNhan> li = congnhans.Where(cn => cn.Luong > 10000).ToList();
            Window1 obj = new Window1(li);
            obj.ShowDialog();
        }
    }
}
        //private void sapxep()
        //{
        //    var view = CollectionViewSource.GetDefaultView(dg.ItemsSource);
        //    if (view != null)
        //    {
        //        view.SortDescriptions.Clear();
        //        view.SortDescriptions.Add(new SortDescription("HoTen", ListSortDirection.Ascending));
        //        view.Refresh();
        //    }
        //}

        //private void Button_View(object sender, RoutedEventArgs e)
        //{
        //if (dgDanhSach.SelectedItem is NguoiDung nd)
        //{
        //    Window2 wd2 = new Window2(nd); // Truyền dữ liệu sang Window2
        //    wd2.ShowDialog(); // Hiển thị dưới dạng cửa sổ con
        //}
        //else
        //{
        //MessageBox.Show("Vui lòng chọn 1 dòng!");
        //}
        //public Window2(NguoiDung nd)
        //{
        //    InitializeComponent();
        //    txtHoTen.Text = "Tên: " + nd.HoTen;
        //    txtSoDien.Text = "Số điện: " + nd.SoDien;
        //    txtdiachi.Text = "Địa điểm: " + nd.DiaChi;
        //    txtNgay.Text = "Ngày: " + nd.Ngay;

        //}

        //}
    