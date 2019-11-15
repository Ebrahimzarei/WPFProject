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
using WpfManage.Model;

namespace WpfManage.View
{
    /// <summary>
    /// Interaction logic for WinEditMember.xaml
    /// </summary>
    public partial class WinEditMember : Window
    {
        string _Fullname, _Ncode, _NameFather, _PersonelNumber, _Tellephone, _Address, _Rfid, _Image, ConvertImageToString;
        int _Id, Flag;
        public static int StatuseCode=0;
        public static int StatuseCode1;
        public static int Error;
        public WinEditMember(int id, string FullName,string NCode,string NameFather,string PersonelNumber,string Tellephone,string Address,string RfidCard,string Image)
        {
            InitializeComponent();
       //اگر تصویر ارسالی وجود نداشت
            if (Image==null)
            {
                _Id = id;
                _Fullname = FullName;
                _Ncode = NCode;
                _NameFather = NameFather;
                _PersonelNumber = PersonelNumber;
                _Tellephone = Tellephone;
                _Address = Address;
                _Rfid = RfidCard;
                TextBoxFullName.Text = _Fullname;
                TextBoxNCode.Text = _Ncode;
                TextBoxNameFather.Text = _NameFather;
                TextBoxNoPersonel.Text = _PersonelNumber;
                TextBoxTellephone.Text = _Tellephone;
                TextBoxAddress.Text = _Address;
                TextBoxRfid.Text = _Rfid;
            }
            if (Image!=null)
            {
                _Id = id;
                _Fullname = FullName;
                _Ncode = NCode;
                _NameFather = NameFather;
                _PersonelNumber = PersonelNumber;
                _Tellephone = Tellephone;
                _Address = Address;
                _Rfid = RfidCard;
                TextBoxFullName.Text = _Fullname;
                TextBoxNCode.Text = _Ncode;
                TextBoxNameFather.Text = _NameFather;
                TextBoxNoPersonel.Text = _PersonelNumber;
                TextBoxTellephone.Text = _Tellephone;
                TextBoxAddress.Text = _Address;
                TextBoxRfid.Text = _Rfid;
                _Image = Image;
                //

                //گرفتن عکس و تبدیل آن از بیس 64 به ایمیج

                byte[] binaryData = Convert.FromBase64String(_Image);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                ImagePersonel.Source = bi;  
            }
       


            //

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
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (Ceckdbstatus()==false)
            {
                MessageBox.Show("تنظیمات پایگاه داده صحیح نمی باشد");
                return;
            }
        }
        public static WpfManage.Setting.Setting GetSetting()
        {
            //خواندن محتوای فایل سیتینگ ذخیره شده در سیستم
            var setting = new WpfManage.Setting.Setting();
            using (var fs = File.OpenRead("d://setting"))
                setting = Serializer.Deserialize<WpfManage.Setting.Setting>(fs);

            return setting;
        }

        private void ButtonEdite_Click(object sender, RoutedEventArgs e)
        {
     

       //     Validate(TextBoxNCode.Text);
            if (Error == 1)
            {
                TextBoxNCode.Focus();
                MessageBox.Show("مقادیر کد ملی صحیح نمی باشد");
                return;

            }

         //   Validate(TextBoxNoPersonel.Text);
            if (Error == 1)
            {
                TextBoxNoPersonel.Focus();
                MessageBox.Show("مقادیر کد پرسنلی صحیح نمی باشد");
                return;
            }
          //  Validate(TextBoxRfid.Text);
            if (Error == 1)
            {
                TextBoxRfid.Focus();
                MessageBox.Show("مقادیر کد کارت صحیح نمی باشد");
                return;
            }
         //   Validate(TextBoxTellephone.Text);
            if (Error == 1)
            {
                TextBoxTellephone.Focus();
                MessageBox.Show("مقادیر شماره تلفن نمی باشد");
                return;
            }
            else
            {
                string FullName = TextBoxFullName.Text;

                if (FullName == "")
                {
                    MessageBox.Show("پر کردن فیلد نام و نام خانوادگی الزامی است");
                    TextBoxFullName.Focus();
                    return;
                }
                if (TextBoxNCode.Text == "")
                {
                    MessageBox.Show("پر کردن فیلد شماره ملی الزامی است");
                    TextBoxNCode.Focus();
                    return;
                }
                if (TextBoxNoPersonel.Text == string.Empty)
                {
                    MessageBox.Show("پر کردن فیلدشماره پرسنلی الزامی است");
                    TextBoxNoPersonel.Focus();
                    return;
                }
                if (TextBoxNCode.Text.Trim().Length <= 9)
                {
                    MessageBox.Show("شماره ملی می بایست ده رقم باشد");
                    TextBoxNCode.Focus();
                    return;
                }


                if (TextBoxNCode.Text.Length != 10)
                {
                    MessageBox.Show("شماره ملی می بایست ده رقم باشد");
                    TextBoxNCode.Focus();
                    return;



                }
                //if (TextBoxRfid.Text.Length == 9 || TextBoxRfid.Text.Length == 8 || TextBoxRfid.Text.Length == 7
                //    || TextBoxRfid.Text.Length == 6 || TextBoxRfid.Text.Length == 5 || TextBoxRfid.Text.Length == 4 || TextBoxRfid.Text.Length == 3 || TextBoxRfid.Text.Length == 2 || TextBoxRfid.Text.Length == 1)
                //{
                //    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                //    TextBoxRfid.Focus();
                //    return;

                //}
                if (TextBoxRfid.Text.Length >10)
                {
                     MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                     return;
                }
              
                if (TextBoxRfid.Text.Length == 9)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    return;

                }
                if (TextBoxRfid.Text.Length == 8)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    return;

                }
                if (TextBoxRfid.Text.Length == 7)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    return;

                }
                if (TextBoxRfid.Text.Length == 6)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    return;

                }
                if (TextBoxRfid.Text.Length == 5)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    return;

                }
                if (TextBoxRfid.Text.Length == 4)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    return;

                }
                if (TextBoxRfid.Text.Length == 3)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    return;

                }
                if (TextBoxRfid.Text.Length == 2)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    return;

                }
                if (TextBoxRfid.Text.Length == 1)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    return;

                }

                if (TextBoxRfid.Text.Length == 0 || TextBoxRfid.Text.Length == 10)
                {
                    StatuseCode1 = 0;

                    if (StatuseCode1 == 0)
                    {
                        MethodCheckData(StatuseCode1, TextBoxNCode.Text.Trim(), TextBoxRfid.Text.Trim(), TextBoxNoPersonel.Text.Trim());
                    }
                    if (StatuseCode1 == 4)
                    {
                        return;
                    }
                    if (StatuseCode1 == 1)
                    {
                        return;

                        //  MethodCheckData(StatuseCode);
                    }
                    if (StatuseCode1 == 2)
                    {
                        MessageBox.Show("خطا در ارتباط");
                        return;

                        //  MethodCheckData(StatuseCode);
                    }
                    if (StatuseCode == 5)
                    {
                        if (StatuseCode1 == 0)
                        {
                            //عملیات ویرایش در دیتا بیس
                            MethodEdit();
                            return;

                            //  MethodCheckData(StatuseCode);
                        }
                        //  MethodCheckData(StatuseCode);
                    }




                  
                }
                if (TextBoxRfid.Text.Length != 10)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxNCode.Focus();
                    return;



                }

            }

            //دکمه ویرایش
        }
        private void MethodEdit()
        {

            try
            {
             //   var entityConnectionString = Contex.BuildEntityConnection(@"Data Source=192.168.0.17\sql2014;Initial Catalog=Personel;User ID=sa;Password=@110;Connection Timeout=60;");
                    //string entityConnectionString=@"Data Source=192.168.0.17\sql2014;Initial Catalog=Personel;User ID=sa;Password=@110;Connection Timeout=60;";
                    var setting = GetSetting();
                    var entityConnectionString = Contex.BuildEntityConnection(setting.DataSource, setting.Instance, setting.InitialCatalog, setting.UserId, setting.Password);
                    using (var dbs = new WpfManage.DAL.Contex())
                {
                    var s = dbs.memberMap.ToList();
                    WpfManage.Model.Personel Personel = new Personel();
               

                        //ویرایش


                        var id = _Id ;
                        Personel = (from x in dbs.memberMap
                               where x.Id == _Id
                               select x).FirstOrDefault();
                        //   dbs.Entry(Log).State = EntityState.Modified;
                        //
                        dbs.memberMap.Attach(Personel);
                        var entry = dbs.Entry(Personel);
 
               
                      
                        Personel.FullName = TextBoxFullName.Text.Trim();
                        Personel.NCode = TextBoxNCode.Text.Trim();
                        Personel.NameFather = TextBoxNameFather.Text.Trim();
                        Personel.PersonelNumber = TextBoxNoPersonel.Text.Trim();
                        Personel.Tellephone = TextBoxTellephone.Text.Trim();
                        Personel.Address = TextBoxAddress.Text.Trim();
                        Personel.RfidCard = TextBoxRfid.Text.Trim();



              

               


                        try
                        {
                        //اگر عکس توسط کاربر انتخاب نشده بود
                            if (ConvertImageToString==null)
                            {
                           
                            if (Flag == 0)
                            {

                                dbs.SaveChanges();
                                MessageBox.Show("اطلاعات با موفقیت ویرایش گردید");
                                this.Close();

                            }
                            if (Flag == 1)
                            {
                                dbs.SaveChanges();
                                MessageBox.Show("اطلاعات با موفقیت ویرایش گردید");
                                this.Close();
                            }
                            //
                            Personel.RfidCard = TextBoxRfid.Text.Trim();
                            }
                            if (ConvertImageToString != null)
                            {
                       
                                //اگر عکس توسط کاربر انتخاب شده بود
                                byte[] imageArr = System.IO.File.ReadAllBytes(ConvertImageToString);
                               string base64ImageRepresentation2 = Convert.ToBase64String(imageArr);
                                //    Personel.Image = base64ImageRepresentation;
                                Personel.Image = base64ImageRepresentation2;
                                //
                                Personel.RfidCard = TextBoxRfid.Text.Trim();
                            //
                            if (Flag == 0)
                            {

                                dbs.SaveChanges();
                                MessageBox.Show("اطلاعات با موفقیت ویرایش گردید");
                                this.Close();
                               
                            }
                            if (Flag == 1)
                            {
                                dbs.SaveChanges();
                                MessageBox.Show("اطلاعات با موفقیت ویرایش گردید");
                                this.Close();
                            }
                            //
                        }
                       
                        }
                        catch 
                        {
                            MessageBox.Show("اطلاعات با موفقیت ثبت گردید");
                         
                        }






                   
                      

                }





            }
            catch
            {
               //
                MessageBox.Show("خطا در ارتباط ");



            }


        }
        private int MethodCheckData(int Statuse, string NationalCode, string RFIDCard, string PersonelNUmber)
        {
            //متد چک کردن دیتا اگر در دیتا بیس از قبل ذخیره شده بود

            try
            {
                //   var entityConnectionString = Contex.BuildEntityConnection (@"Data Source=192.168.0.17\sql2014;Initial Catalog=Personel;User ID=sa;Password=@110;Connection Timeout=60;");
                    //string entityConnectionString=@"Data Source=192.168.0.17\sql2014;Initial Catalog=Personel;User ID=sa;Password=@110;Connection Timeout=60;";
                var setting = GetSetting();
                var entityConnectionString = Contex.BuildEntityConnection(setting.DataSource, setting.Instance, setting.InitialCatalog, setting.UserId, setting.Password);
                    using (var dbs = new WpfManage.DAL.Contex())
                {

                    WpfManage.Model.Personel Personel = new Personel();




                    try
                    {
                      //  var Rfid = dbs.memberMap.FirstOrDefault(x => x.RfidCard==);
                        var query =
    (from c in dbs.memberMap
     where (c.NCode == NationalCode.Trim()) &&( c.Id != _Id)
     select new { c.NCode }).Count();
                       // var query1 = dbs.memberMap.Select(x => x.RfidCard).Count;
                        var xt = dbs.memberMap.Where(x => x.Id == _Id).FirstOrDefault();
                       // var xg = dbs.memberMap.SelectMany(x => x.Id == _Id);
                     // IEnumerable<string> query1 = dbs.memberMap.SelectMany(petOwner => petOwner.NCode.ToChar());
                        if (query >=1)
                        {
                            MessageBox.Show("شماره ملی در دیتابیس موجود است");

                            Statuse = 1;
                            StatuseCode = 4;
                            // Flag = 1;
                            return Statuse;
                        }
                        if (query==0||query==1)
                        {
                            StatuseCode = 5;
                            // Flag = 1;
                           // return Statuse; 
                        }
                        else
                        {
                            Statuse = 3;
                            StatuseCode = 5;
                            
                        }
                    }
                    catch

                    {
                        // Flag = 1;
                        MessageBox.Show("شماره ملی در دیتابیس موجود است");
                        Statuse = 1;
               
                        return Statuse;
                    }
                  



                    try
                    {
                        //    var Rfid = dbs.memberMap.FirstOrDefault(x => x.RfidCard );
                     
//                        var PersonelNo =
//(from c in dbs.memberMap
// where c.PersonelNumber == PersonelNUmber.Trim()
// select new { c.PersonelNumber }).Count();

                        var PersonelNo =
 (from c in dbs.memberMap
  where (c.PersonelNumber == PersonelNUmber.Trim()) && (c.Id != _Id)
  select new { c.PersonelNumber }).Count();

                        if (PersonelNo >=1)
                        {
                            MessageBox.Show("شماره پرسنلی قبلا در دیتا بیس ذخیره شده است");
                            // Flag = 1;
                            Statuse = 1;
                            StatuseCode = 4;
                            return Statuse;
                        }
                        if (PersonelNo == 0 || PersonelNo == 1)
                        {
                            StatuseCode = 5;
                            StatuseCode = 5;
                        }
                        else
                        {
                            Statuse = 3;
                            StatuseCode = 5;
                            // Flag = 1;
                          //  return Statuse;
                        }
                    }
                    catch
                    {
                        // Flag = 1;
                        MessageBox.Show("شماره پرسنلی قبلا در دیتابیس ذخیره شده است");
                        //Flag2 = 1;
                        Statuse = 1;
                        //StatuseCode = 4;
                        return Statuse;
                    }
                    try
                    {
                        //    var Rfid = dbs.memberMap.FirstOrDefault(x => x.RfidCard );




                        var xt = dbs.memberMap.ToList().Where(x => x.Id != _Id);

                        var query =
    (from c in dbs.memberMap
     where (c.RfidCard == RFIDCard.Trim()) && (c.Id != _Id)
     select new { c.RfidCard }).Count();

                        if (query == 0)
                        {

                            Statuse = 3;
                            StatuseCode = 5;
                            return Statuse;

                        }
                        if (query == 1)
                        {
                            MessageBox.Show("این کارت  قبلا برای عضو دیگری اختصاص یافته است ");
                            //  Flag = 1;
                            Statuse = 1;
                            StatuseCode = 4;
                            return Statuse;

                        }
                        if (query >= 1)
                        {

                            MessageBox.Show("این کارت  قبلا برای عضو دیگری اختصاص یافته است ");
                            //  Flag = 1;
                            Statuse = 1;
                            StatuseCode = 4;
                            return Statuse;

                        }

                        //if (xt.RfidCard != RFIDCard)
                        //{
                        //    MessageBox.Show("این کارت  قبلا برای عضو دیگری اختصاص یافته است ");
                        //    //  Flag = 1;
                        //    Statuse = 1;
                        //    StatuseCode = 4;
                        //    return Statuse;

                        //    //Statuse = 3;
                        //    //StatuseCode = 5;
                        //}
                        //if (xt.RfidCard == string.Empty)
                        //{

                        //    //  MessageBox.Show("این کارت  قبلا برای عضو دیگری اختصاص یافته است ");
                        //    //  Flag = 1;
                        //    Statuse = 3;
                        //    StatuseCode = 5;
                        //    return Statuse;

                        //}

                    




                        else
                        {
                            Statuse = 3;
                            StatuseCode = 5;

                            // Flag = 1;
                            //   return Statuse;
                        }
                    }
                    catch
                    {
                        //  Flag = 1;
                        MessageBox.Show("این کارت  قبلا برای عضو دیگری اختصاص یافته است ");
                        // Flag2 = 1;
                        Statuse = 1;

                        return Statuse;

                    }


                }


            }
            catch
            {
                //
             //   MessageBox.Show("خطا در ارتباط ");
                return 2;


            }

            //صحت اطلاعات
            Statuse = 3;
        
          
            // Flag = 1;
            return Statuse;


        }
        //    private void MethodCheckDataOlD()
        //    {
        //        //متد چک کردن دیتا اگر در دیتا بیس از قبل ذخیره شده بود
        //        try
        //        {
        //            using (var dbs = new WpfManage.DAL.Contex())
        //            {

        //                WpfManage.Model.Personel Personel = new Personel();




        //                try
        //                {
        //                    //    var Rfid = dbs.memberMap.FirstOrDefault(x => x.RfidCard );
        //                    var query =
        //(from c in dbs.memberMap
        // where c.NCode == TextBoxNCode.Text
        // select new { c.NCode }).FirstOrDefault();



        //                    if (query != null)
        //                    {
        //                        MessageBox.Show("شماره ملی در دیتابیس موجود است");
        //                       // Flag = 1;
        //                        return;
        //                    }
        //                }
        //                catch

        //                {
        //                   // Flag = 1;
        //                    MessageBox.Show("شماره ملی در دیتابیس موجود است");
        //                    return;
        //                }
        //                try
        //                {
        //                    //    var Rfid = dbs.memberMap.FirstOrDefault(x => x.RfidCard );
        //                    var RFID =
        //(from c in dbs.memberMap
        // where c.RfidCard == TextBoxRfid.Text
        // select new { c.RfidCard }).FirstOrDefault();



        //                    if (RFID != null)
        //                    {
        //                        MessageBox.Show("این کارت قبلا در پایگاه داده ذخیره شده است لطفا نسبت به ثبت کارت جدید اقدام نمایید ");
        //                      //  Flag = 1;
        //                        return;
        //                    }
        //                }
        //                catch
        //                {
        //                  //  Flag = 1;
        //                    MessageBox.Show("این کارت قبلا در پایگاه داده ذخیره شده است لطفا نسبت به ثبت کارت جدید اقدام نمایید");
        //                    return;
        //                }



        //                try
        //                {
        //                    //    var Rfid = dbs.memberMap.FirstOrDefault(x => x.RfidCard );
        //                    var PersonelNo =
        //(from c in dbs.memberMap
        // where c.PersonelNumber == TextBoxNoPersonel.Text
        // select new { c.PersonelNumber }).FirstOrDefault();



        //                    if (PersonelNo != null)
        //                    {
        //                        MessageBox.Show("شماره پرسنلی قبلا در دیتا بیس ذخیره شده است");
        //                       // Flag = 1;
        //                        return;
        //                    }
        //                }
        //                catch
        //                {
        //                   // Flag = 1;
        //                    MessageBox.Show("شماره پرسنلی قبلا در دیتابیس ذخیره شده است");
        //                    return;
        //                }

        //            }


        //        }
        //        catch
        //        {
        //            //
        //            MessageBox.Show("خطا در ارتباط ");


        //        }


        //    }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //نمایش عکس و نشان دادن آن در  کنترل Image
            //     نشان دادن تصویر


            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();


            dlg.FileName = "pic-file-name"; // Default file name 
            dlg.DefaultExt = ".jpg"; // Default file extension 
            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png"; // Filter files by extension 

            Nullable<bool> result = dlg.ShowDialog();


            if (result == true)
            {
                ImagePersonel.Source = new BitmapImage(new Uri(dlg.FileName));
                ConvertImageToString = dlg.FileName;

            }
        }

        private void TextBoxNCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //اعتبار سنجی
            e.Handled = !IsNumberAllowed(e.Text);
        }
        //متد عبارات منظم که این متد فقط عدد میگیرد
        private static bool IsNumberAllowed(string text)
        {
            Regex regex = new Regex("[^ 0[1-9]|1[0-2]]+");
            return !regex.IsMatch(text);
        }

        private void TextBoxNCode_KeyDown(object sender, KeyEventArgs e)
        {
            ////چلوگیری از وارد شدن براکت
            //if (e.Key == Key.Oem4)
            //{
            //    //  e.Key = Key.Back;
            //    TextBoxNCode.Undo();
            //}
        }
        public void Validate(string input)
        {
            int myNumber;

            var s = int.TryParse(input, out myNumber);

           // var s = int32.TryParse(input, out myNumber);
            if (s != true)
            {
              //  MessageBox.Show("مفادیر عددی به درستی وارد نشده است");
                Error = 1;
                return;
            }
            Error = 0;
        }

        private void TextBoxNoPersonel_KeyDown(object sender, KeyEventArgs e)
        {
            ////چلوگیری از وارد شدن براکت
            //if (e.Key == Key.Oem4)
            //{
            //    //  e.Key = Key.Back;
            //    TextBoxNoPersonel.Undo();
            //}
        }

        private void TextBoxTellephone_KeyDown(object sender, KeyEventArgs e)
        {
            ////چلوگیری از وارد شدن براکت
            //if (e.Key == Key.Oem4)
            //{
            //    //  e.Key = Key.Back;
            //    TextBoxTellephone.Undo();
            //}
        }

        private void TextBoxRfid_KeyUp(object sender, KeyEventArgs e)
        {
            //چلوگیری از وارد شدن براکت
            if (e.Key == Key.Oem4)
            {
                //  e.Key = Key.Back;
                TextBoxRfid.Undo();
            }
        }

        private void TextBoxTellephone_KeyUp(object sender, KeyEventArgs e)
        {
            ////چلوگیری از وارد شدن براکت
            //if (e.Key == Key.Oem4)
            //{
            //    //  e.Key = Key.Back;
            //    TextBoxTellephone.Undo();
            //}
        }

        private void TextBoxNoPersonel_KeyUp(object sender, KeyEventArgs e)
        {
            ////چلوگیری از وارد شدن براکت
            //if (e.Key == Key.Oem4)
            //{
            //    //  e.Key = Key.Back;
            //    TextBoxNoPersonel.Undo();
            //}
        }

        private void TextBoxNCode_KeyUp(object sender, KeyEventArgs e)
        {
            ////چلوگیری از وارد شدن براکت
            //if (e.Key == Key.Oem4)
            //{
            //    //  e.Key = Key.Back;
            //    TextBoxNCode.Undo();
            //}
        }

        //میگیرد متد عبارات منظم که این متدهر چیزی به جز عددو کاراکتر های خاص 

        private static bool IsTextAllowed(string text)
        {
           
            Regex regex = new Regex(@"^[a-zA-Zآ-ی]+$");

            var m = regex.Match(text);

            return m.Success;
        }

        private void TextBoxNoPersonel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //اعتبار سنجی
            e.Handled = !IsNumberAllowed(e.Text);
        }

        private void TextBoxTellephone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //اعتبار سنجی
            e.Handled = !IsNumberAllowed(e.Text);
        }

        private void TextBoxRfid_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //اعتبار سنجی
            e.Handled = !IsNumberAllowed(e.Text);
        }

        private void TextBoxFullName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //اعتبار سنجی
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void TextBoxNameFather_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //اعتبار سنجی
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            //بسته شدن
            this.Close();
        }

        private void TextBoxRfid_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (TextBoxRfid.Text.Length > 10)
            {


                //  MessageBox.Show("کارت بیشتر از یک بارر بر روی سیستم قرار گرفته است لطفا دوباره سعی کنید");
                TextBoxRfid.Text = "";
            }
        }

        private void TextBoxRfid_KeyDown(object sender, KeyEventArgs e)
        {
            //چلوگیری از وارد شدن براکت
            if (e.Key == Key.Oem4)
            {
                //  e.Key = Key.Back;
                TextBoxRfid.Undo();
            }
            if (e.Key == Key.NumPad0)
            {

                e.Handled = true;
            }
            if (e.Key == Key.NumPad1)
            {

                e.Handled = true;
            }
            if (e.Key == Key.NumPad2)
            {

                e.Handled = true;
            }
            if (e.Key == Key.NumPad3)
            {

                e.Handled = true;
            }
            if (e.Key == Key.NumPad4)
            {

                e.Handled = true;
            }
            if (e.Key == Key.NumPad5)
            {

                e.Handled = true;
            }
            if (e.Key == Key.NumPad6)
            {

                e.Handled = true;
            }
            if (e.Key == Key.NumPad7)
            {

                e.Handled = true;
            }
            if (e.Key == Key.NumPad8)
            {

                e.Handled = true;
            }
            if (e.Key == Key.NumPad9)
            {

                e.Handled = true;
            }
            
            if (e.Key == Key.NumPad9)
            {

                e.Handled = true;
            }
        }

    }
}
