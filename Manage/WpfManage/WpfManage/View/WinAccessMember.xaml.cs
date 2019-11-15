using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfManage.DAL;

namespace WpfManage.View
{
    /// <summary>
    /// Interaction logic for WinAccessMember.xaml
    /// </summary>
    public partial class WinAccessMember : Window
    {
        public WinAccessMember()
        {
            InitializeComponent();
            TextBoxRfid.Focus();
            
        }

        private void TextBoxRfid_SelectionChanged(object sender, RoutedEventArgs e)
        
        {
            //// عملیات نمایش اطلاعات کاربر ثبت شده
            //try
            //{
            //    using (var dbs = new WpfManage.DAL.Contex())
            //    {

            //        var s = dbs.memberMap.Where(x => x.RfidCard == TextBoxRfid.Text).FirstOrDefault();

            //        //Manage mem = new Manage();
            //        //  mem.Image = Image.Text;
            //        if (TextBoxRfid.Text == s.RfidCard)
            //        {


            //            TextBlockFullName.Text = s.FullName;
            //            TextBlockNCode.Text = s.NCode;
            //            TextBlockNameFather.Text = s.NameFather;
            //            TextBlockNoPersonel.Text = s.PersonelNumber;
            //            TextBlockTellephone.Text = s.Tellephone;
            //            TextBlockAddress.Text = s.Address;
            //            // TextBoxRfId.Text = s.Image;

            //            byte[] binaryData = Convert.FromBase64String(s.Image);

            //            BitmapImage bi = new BitmapImage();
            //            bi.BeginInit();
            //            bi.StreamSource = new MemoryStream(binaryData);
            //            bi.EndInit();

            //            ImagePersonel.Source = bi;
            //            // TextBoxRfid.Focus();

            //        }

            //    }


            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show("خطا در ارتباط");
            //}
        }
        public static WpfManage.Setting.Setting GetSetting()
        {
            //خواندن محتوای فایل سیتینگ ذخیره شده در سیستم
            var setting = new WpfManage.Setting.Setting();
            using (var fs = File.OpenRead("d://setting"))
                setting = Serializer.Deserialize<WpfManage.Setting.Setting>(fs);

            return setting;
        }
        private static bool Ceckdbstatus()
        {



            //اگر ساخته شد متد دیتابیس
            //  var entityConnectionString = Contex.BuildEntityConnection (@"Data Source=192.168.0.17\sql2014;Initial Catalog=Personel;User ID=sa;Password=@110;Connection Timeout=60;");
            var setting = GetSetting();
            var entityConnectionString = Contex.BuildEntityConnection(setting.DataSource, setting.Instance, setting.InitialCatalog, setting.UserId, setting.Password);
            using (var db = new Contex())
            {



                if (db.Database.Exists())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private void ButtonShowProperty_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxRfid.Text==string.Empty)
            {
                MessageBox.Show("ثبت کارت ناموفق بوده است لطفا دوباره کارت را روی دستگاه کارت خوان قرار دهید");
                TextBoxRfid.Focus();
                return;
            }
            try
            {
              //  var entityConnectionString = Contex.BuildEntityConnection(@"Data Source=192.168.0.17\sql2014;Initial Catalog=Personel;User ID=sa;Password=@110;Connection Timeout=60;");
               //string entityConnectionString="Data Source=192.168.0.17\\sql2014;Initial Catalog=Personel;User ID=sa;Password=@110;Connection Timeout=60;";
               var setting = GetSetting();
               var entityConnectionString = Contex.BuildEntityConnection(setting.DataSource, setting.Instance, setting.InitialCatalog, setting.UserId, setting.Password);
               using (var dbs = new WpfManage.DAL.Contex())
                {

                    var s = dbs.memberMap.Where(x => x.RfidCard == TextBoxRfid.Text).FirstOrDefault();

                    
                    if (TextBoxRfid.Text == s.RfidCard)
                    {


                        TextBlockFullName.Text = s.FullName;
                        TextBlockNCode.Text = s.NCode;
                        TextBlockNameFather.Text = s.NameFather;
                        TextBlockNoPersonel.Text = s.PersonelNumber;
                        TextBlockTellephone.Text = s.Tellephone;
                        TextBlockAddress.Text = s.Address;
                        // TextBoxRfId.Text = s.Image;

                        byte[] binaryData = Convert.FromBase64String(s.Image);

                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.StreamSource = new MemoryStream(binaryData);
                        bi.EndInit();

                        ImagePersonel.Source = bi;
                        ImagePlay.Visibility = Visibility.Hidden;
                        // TextBoxRfid.Focus();
                      //  TextBoxRfid.Clear();


                        //  dbs.ProjectmemberMap.Add(s);
                    }

                }


            }
            catch (Exception exception)
            {
              //  MessageBox.Show("خطا در ارتباط");
            }
        //   TextBoxRfid.Clear();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFullName.Text = "";
            TextBlockNCode.Text = "";
            TextBlockNameFather.Text = "";
            TextBlockNoPersonel.Text = "";
            TextBlockTellephone.Text = "";
            TextBlockAddress.Text ="";
            //ImagePersonel.Source = null;
            TextBoxRfid.Text =string.Empty;
            TextBoxRfid.Focus();
            ImagePlay.Visibility = Visibility.Visible;
            // TextBoxRfId.Text = s.Image;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //متد عبارات منظم که این متد فقط عدد میگیرد
        private static bool IsNumberAllowed(string text)
        {
            Regex regex = new Regex("[^ 0[1-9]|1[0-2]]+");
            return !regex.IsMatch(text);
        }
        //میگیرد متد عبارات منظم که این متدهر چیزی به جز عددو کاراکتر های خاص 

        private static bool IsTextAllowed(string text)
        {
            //$^&*()_+
            Regex regex = new Regex("^[<>.!$@&*()_+=^#%~`/0-9.-]");
            return !regex.IsMatch(text);
        }

        private void TextBlockFullName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //اعتبار سنجی نام و نام خانوادگی
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void TextBlockNameFather_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //اعتبار سنجی نام پدر
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void TextBlockNoPersonel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //اعتبار سنجی کد پرسنلی 
            e.Handled = !IsNumberAllowed(e.Text);
        }

        private void TextBlockTellephone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //اعتبار سنجی تلفن
            e.Handled = !IsNumberAllowed(e.Text);
        }

        private void TextBlockNCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //اعتبار سنجی کدپرسنلی
            e.Handled = !IsNumberAllowed(e.Text);
        }

        private void TextBoxRfid_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //کارن اعتبار سنجی
            e.Handled = !IsNumberAllowed(e.Text);
        }

        private void WinAccessMember1_Loaded(object sender, RoutedEventArgs e)
        {

            if (Ceckdbstatus()==false)
            {
                MessageBox.Show("تنظیمات وارد شده پایگاه داده صحیح نمی باشد");
            }
        }
    }
}
