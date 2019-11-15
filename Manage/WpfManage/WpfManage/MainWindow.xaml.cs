using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfManage.DAL;
using WpfManage.Model;
using WpfManage.Properties;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.Data.Entity.Core.EntityClient;
using ProtoBuf;

namespace WpfManage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ConvertImageToString,Connection;
        public static int StauseMethod = 0;
        public static int Statuses=0;
        public static int Error = 0;

        public MainWindow()
        {

            // Initialize the connection string builder for the
       
         
         //   CheckingSource(Connection);


            if (Ceckdbstatus())
            {
                InitializeComponent();
            }
            if (Ceckdbstatus()==false)
            {
                MessageBox.Show("تنظیمات پایگاه داده صحیح نمی باشد");
                InitializeComponent();
            }
         
               
       


            //    //  مقادیر دیتا بیس  هنگام اجرای برنامه
            //    //در جایگذاری  اول نام 
//                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
//                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(
//                                                             "Contexu",
//@"Data Source=192.168.0.17\sql2014;Initial Catalog=APersonel;User ID=sa;Password=@110;Connection Timeout=60;", "System.Data.SqlClient"));
//                // Configuration config = ConfigurationManager.(ConfigurationUserLevel.None);





//                //// config.AssemblyStringTransformer(ConfigurationSaveMode.Full, true);
//                ConfigurationManager.RefreshSection("connectionStrings");

//                config.Save(ConfigurationSaveMode.Full, true);
//                config.SaveAs("App.Config");
                //پر کردن دیتا گرید
                MethodFillGrid();
              

         //   }
            //else
            //{
            //    MessageBox.Show("ارتباط با پایگاه داده بر قرار نمی باشد");
            //    return;
            //}
       




        }


        public int Flag = 0;
        public static int StatuseCode = 0;

        public string Image;
        public static string RFID;

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

    

        private void CheckingSource(string constr)
        {
            var config = ConfigurationManager.OpenExeConfiguration(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\WpfManage.exe");
            config.ConnectionStrings.ConnectionStrings["con"].ConnectionString = constr; //CONCATINATE YOUR FIELDS TOGETHER HERE
           
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    
   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         
            //پر کردن دیتا گرید
              MethodFillGrid();
        }

       


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
//نمایش پنجره شناسایی کاربر
            new WpfManage.View.WinAccessMember().ShowDialog();
        }

        private void MenuEditPersonel_Click(object sender, RoutedEventArgs e)
        {

            //ویرایش کاربر
            try
            {

                // DataGridLogin.SelectedIndex = -1;
                if (((WpfManage.Model.Personel) DataGridPersonel.SelectedItem) != null)
                {
                    var ID = ((WpfManage.Model.Personel) DataGridPersonel.SelectedItem).Id;
                    var FullName = ((WpfManage.Model.Personel) DataGridPersonel.SelectedItem).FullName;
                    var NCode = ((Personel) DataGridPersonel.SelectedItem).NCode;
                    var NameFather = ((Personel) DataGridPersonel.SelectedItem).NameFather;
                    var PersonelNumber = ((Personel) DataGridPersonel.SelectedItem).PersonelNumber;
                    var Tellephone = ((Personel) DataGridPersonel.SelectedItem).Tellephone;
                    var Address = ((Personel) DataGridPersonel.SelectedItem).Address;
                    //  RFID = ((Personel)DataGridPersonel.SelectedItem).RfidCard;
                    var RFID = ((Personel) DataGridPersonel.SelectedItem).RfidCard;

                    try
                    {
                        Image = ((Personel) DataGridPersonel.SelectedItem).Image;
                        if (Image != null)
                        {
                            //  MethodFillGrid();
                            //ویرایش کاربر و ارسال اطلاعات به فرم ویرایش
                            //    new WpfManage.View.WinEditMember(ID, FullName, NCode, NameFather, PersonelNumber, Tellephone, Address, RFID, Image).ShowDialog();
                            new WpfManage.View.WinEditMember(ID, FullName, NCode, NameFather, PersonelNumber, Tellephone,
                                Address, RFID, Image).ShowDialog();
                            MethodFillGrid();
                        }
                        if (Image == null)
                        {
                            //  MethodFillGrid();
                            //ویرایش کاربر و ارسال اطلاعات به فرم ویرایش
                            new WpfManage.View.WinEditMember(ID, FullName, NCode, NameFather, PersonelNumber, Tellephone,
                                Address, RFID, Image).ShowDialog();
                            MethodFillGrid();
                        }
                    }
                    catch (Exception)
                    {
                        //ویرایش کاربر و ارسال اطلاعات به فرم ویرایش
                        // new WpfManage.View.WinEditMember(ID, FullName, NCode, NameFather, PersonelNumber, Tellephone, Address, RfidCard, Image).ShowDialog();
                    }

                    //    new WpfManage.View.WinEditMember(ID,FullName, NCode, NameFather, PersonelNumber, Tellephone, Address, RfidCard, Image).ShowDialog();

                    MethodFillGrid();









                }

            }
            catch
            {
                MethodFillGrid();
                MessageBox.Show("لطفا یک گزینه را انتخاب نمایید");

            }



        }

        private void ButtonShowImage_Click(object sender, RoutedEventArgs e)
        {
            //نمایش عکس و نشان دادن آن در  کنترل Image
            //     نشان دادن تصویر


            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();


            dlg.FileName = "pic-file-name"; // Default file name 
            dlg.DefaultExt = ".jpg"; // Default file extension 
            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                         "Portable Network Graphic (*.png)|*.png"; // Filter files by extension 

            Nullable<bool> result = dlg.ShowDialog();


            if (result == true)
            {
                Image_SnapShot.Source = new BitmapImage(new Uri(dlg.FileName));
                ConvertImageToString = dlg.FileName;
                Image_Play.Visibility = Visibility.Hidden;

            }

        }
        private int MethodCheckData( int Statuse,string NationalCode,string RFIDCard,string PersonelNUmber)
        {
     
            //متد چک کردن دیتا اگر در دیتا بیس از قبل ذخیره شده بود
            
            try
            {
                var setting = GetSetting();
                      //var entityConnectionString = Contex.BuildEntityConnection(@"Data Source=192.168.0.17\sql2014;Initial Catalog=Personel;User ID=sa;Password=@110;Connection Timeout=60;");
                    string entityConnectionString0=@"Data Source=192.168.0.17\sql2014;Initial Catalog=Personel;User ID=sa;Password=@110;Connection Timeout=60;";
                    var entityConnectionString = Contex.BuildEntityConnection(setting.DataSource, setting.Instance, setting.InitialCatalog, setting.UserId, setting.Password);
                    using (var dbs = new WpfManage.DAL.Contex())
                {

                //    WpfManage.Model.Personel Personel = new Personel();

                    try
                    {
                        //    var Rfid = dbs.memberMap.FirstOrDefault(x => x.RfidCard );
                  

                    
                        var query =
                  (from c in dbs.memberMap
                   where c.NCode == NationalCode.Trim()
                   select new { c.NCode }).Count();
                        if (query >= 1)
                        {
                            MessageBox.Show("شماره ملی به شخص دیگری اختصاص یافته است ");

                            Statuse = 1;
                            StatuseCode = 4;
                            // Flag = 1;
                            return Statuse;
                        }
                        if (query == 0 || query == 1)
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
                        //

                        //
                    catch

                    {
                        // Flag = 1;
                        MessageBox.Show("شماره ملی به شخص دیگری اختصاص یافته است ");
                        Statuses = 5;
                        Statuse = 1;
                        return Statuse;
                    }
                



                    try
                    {
                       
                        var PersonelNo =
                                    (from c in dbs.memberMap
                              where c.PersonelNumber == PersonelNUmber.Trim()
                                     select new { c.PersonelNumber}).Count();

                        if (PersonelNo >= 1)
                        {
                            MessageBox.Show("شماره پرسنلی به شخص دیگری اختصاص یافته است");

                            Statuse = 1;
                            StatuseCode = 4;
                            // Flag = 1;
                            return Statuse;
                        }
                        if (PersonelNo == 0 || PersonelNo == 1)
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
                        MessageBox.Show("شماره پرسنلی به شخص دیگری اختصاص یافته است");
                        //Flag2 = 1;
                        Statuse = 1;
                        Statuses = 5;
                        Statuse = StauseMethod;
                        return Statuse;
                    }
                    try
                    {
                        //    var Rfid = dbs.memberMap.FirstOrDefault(x => x.RfidCard );


                        var RFID =
                  (from c in dbs.memberMap
                   where c.RfidCard == RFIDCard.Trim()
                   select new { c.RfidCard }).Count();
                        if (RFIDCard == string.Empty)
                        {

                            Statuse = 3;
                            StatuseCode = 5;
                            return Statuse;

                        }

                        if (RFID >= 1)
                        {
                            MessageBox.Show("این کارت قبلا به شخص دیگری اختصاص یافته است");

                            Statuse = 1;
                            StatuseCode = 4;
                            // Flag = 1;
                            return Statuse;
                        }
                        if (RFID == 1 || RFID == 0)
                        {
                            StatuseCode = 5;
                            Statuse = 3;
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
                        //  Flag = 1;
                        MessageBox.Show("این کارت قبلا به شخص دیگری اختصاص یافته است");
                        // Flag2 = 1;
                        Statuse = 1;
                        Statuses = 5;
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
            Statuse = 3;
            StauseMethod = 3;
           // Statuses = 4;
            Statuse = StauseMethod;
            //صحت اطلاعات
            return Statuse;


        }
        private void ButtonSaveToDataBase_Click(object sender, RoutedEventArgs e)
        {
         

         //   Validate(TextBoxNationalCode.Text);
            if (Error == 1)
            {
                TextBoxNationalCode.Focus();
                MessageBox.Show("مقدار کد ملی صحیح نمی باشد");
                return;
            }
         //   Validate(TextBoxPersonelNo.Text);
            if (Error == 1)
            {
                TextBoxPersonelNo.Focus();
                MessageBox.Show("مقدار کدپرسنلی صحیح نمی باشد");
                return;
            }
          //  Validate(TextBoxRfidCard.Text);
            if (Error == 1)
            {
                TextBoxRfidCard.Focus();
                MessageBox.Show("مقدار کدکارت صحیح نمی باشد");
                return;
            }
      //      Validate(TextBoxTellephon.Text);
            if (Error == 1)
            {
                TextBoxTellephon.Focus();
                MessageBox.Show("مقدار شماره تلفن صحیح نمی باشد");
                return;
            }
            else
            {

                if (TextBoxFullName.Text.Trim() == string.Empty)
                  
                {
                    MessageBox.Show("پر کردن مقادیر ستاره دار الزامی است");
                    return;

                }

                if (TextBoxPersonelNo.Text.Trim() == string.Empty)
                {
                     MessageBox.Show("پر کردن مقادیر ستاره دار الزامی است");
                    return;
                }
                if (TextBoxNationalCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("پر کردن مقادیر ستاره دار الزامی است");
                    return;
                }


                if (TextBoxNationalCode.Text.Length !=  10)
                {
                    MessageBox.Show("مقادیر کد ملی به درستی وارد نشده است");
                    return;
                }
                if (TextBoxRfidCard.Text.Length == 1 )
                {
                     MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxRfidCard.Focus();
                    return;
                }
                if (TextBoxRfidCard.Text.Length == 2)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxRfidCard.Focus();
                    return;
                }
                if (TextBoxRfidCard.Text.Length == 3)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxRfidCard.Focus();
                    return;
                }
                if (TextBoxRfidCard.Text.Length == 4)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxRfidCard.Focus();
                    return;
                }
                if (TextBoxRfidCard.Text.Length == 5)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxRfidCard.Focus();
                    return;
                }
                if (TextBoxRfidCard.Text.Length == 6)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxRfidCard.Focus();
                    return;
                }
                if (TextBoxRfidCard.Text.Length == 7)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxRfidCard.Focus();
                    return;
                }
                if (TextBoxRfidCard.Text.Length == 8)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxRfidCard.Focus();
                    return;
                }
                if (TextBoxRfidCard.Text.Length == 9)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxRfidCard.Focus();
                    return;
                }
                if (TextBoxRfidCard.Text.Length > 10)
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxRfidCard.Focus();
                    return;
                }
                if (TextBoxRfidCard.Text.Length == 0 || TextBoxRfidCard.Text.Length == 10)
                {

                    StatuseCode = 0;

                    if (StatuseCode == 0)
                    {
                        MethodCheckData(StatuseCode, TextBoxNationalCode.Text.Trim(), TextBoxRfidCard.Text.Trim(), TextBoxPersonelNo.Text.Trim());
                    }
                    if (StatuseCode == 1)
                    {
                        return;

                        //  MethodCheckData(StatuseCode);
                    }
                    if (StatuseCode == 2)
                    {
                        MessageBox.Show("خطا در ارتباط");
                        return;

                        //  MethodCheckData(StatuseCode);
                    }
                    if (Statuses == 4)
                    {
                        return;
                    }
                    if (Statuses == 0)
                    {
                        if ( StatuseCode == 5)
                        {
                            //عملیات ذخیره در دیتا بیس
                            SaveToDataBase();
                            // return;

                            //  MethodCheckData(StatuseCode);
                        }
                    }

                    else
                    {
                        MessageBox.Show("خطا در ارتباط");
                    }
                if (TextBoxRfidCard.Text.Length == 1   )
                {
                    MessageBox.Show("شماره کارت می بایست ده رقم باشد");
                    TextBoxRfidCard.Focus();
                    return;

                }
               
                }



                //if (TextBoxTellephon.Text.Length >11)
                //{
                //    MessageBox.Show("شماره تلفن می بایست یازده رقم باشد");
                //    TextBoxNationalCode.Focus();
                //    return;

                //}
                //if (TextBoxTellephon.Text.Length < 11)
                //{
                //    MessageBox.Show("شماره تلفن می بایست یازده رقم باشد");
                //    TextBoxNationalCode.Focus();
                //    return;

                //}


                //if (Image_SnapShot.Source == null)
                //{
                //    //   MessageBox.Show("وارد کردن عکس الزامی می باشد");

                //}

                //else 
                //{
                //  MessageBox.Show("شماره کارت می بایست 10 رقم باشد");
                //}
            }

        }

        private void SaveToDataBase()
        {
          //  string t = "0";
            try
            {


                Flag = 0;
               //  var entityConnectionString = Contex.BuildEntityConnection (@"Data Source=192.168.0.17\sql2014;Initial Catalog=Personel;User ID=sa;Password=@110;Connection Timeout=60;");
                    //string entityConnectionString=@"Data Source=192.168.0.17\sql2014;Initial Catalog=Personel;User ID=sa;Password=@110;Connection Timeout=60;";
                    var setting = GetSetting();
                    var entityConnectionString = Contex.BuildEntityConnection(setting.DataSource, setting.Instance, setting.InitialCatalog, setting.UserId, setting.Password);
                
                    using (var db = new WpfManage.DAL.Contex())
                {
                    using (var dbs = new Contex())
                    {
                       
                       
                        

                        WpfManage.Model.Personel person = new WpfManage.Model.Personel();

                        person.FullName = TextBoxFullName.Text.Trim();
                        person.NCode = TextBoxNationalCode.Text.Trim();
                        person.PersonelNumber = TextBoxPersonelNo.Text.Trim();
                        person.Tellephone = TextBoxTellephon.Text.Trim();
                        person.Address = TextBoxAddres.Text.Trim();
                        person.RfidCard = TextBoxRfidCard.Text.Trim();
                        person.NameFather = TextBoxFather.Text.Trim();
                        //var TextRfid = dbs.memberMap.Single(x => x.RfidCard=="").FirstOrDefault();
                        // var Rfid = dbs.memberMap.Select(x => x.RfidCard);

                     
                        //اگر مقداری بعنوان عکس توسط کاربر انتخاب نشده بود
                        if (ConvertImageToString == null)
                        {
                            if (Flag == 0)
                            {
                                dbs.Entry(person).State = EntityState.Added;
                                dbs.memberMap.Add(person);
                                dbs.SaveChanges();
                          MessageBox.Show("اطلاعات با موفقیت ثبت گردید");
                                //bool hasNationalCode = dbs.memberMap.Any(cus => cus.NCode == TextBoxNationalCode.Text);
                                ////اگر کد ملی در جدول وجود نداشت
                                //if (hasNationalCode==false)
                                //{
                                //    dbs.Entry(person).State = EntityState.Added;
                                //    dbs.memberMap.Add(person);
                                //  //  dbs.SaveChanges();
                                    
                                   
                                //}
                                ////اگر کد ملی در دیتا بیس  ار قبل ذخیره شده بود
                                //if (hasNationalCode == true)
                                //{

                                //    MessageBox.Show("شماره کد ملی می بایست مقداری منحصر بفرد باشد");
                                //    return;
                                 
                                //}




                                TextBoxFullName.Text = "";
                                TextBoxNationalCode.Text = "";
                                TextBoxPersonelNo.Text = "";
                                TextBoxTellephon.Text = "";
                                TextBoxAddres.Text = "";
                                TextBoxRfidCard.Text = "";
                                TextBoxFather.Text = "";
                                Image_Play.Visibility = Visibility.Visible;
                                Image_SnapShot.Source = null;
                                //var result = (from r in dbs.memberMap.ToList()

                                //              select r).ToList();
                                //DataGridPersonel.ItemsSource = result;
                                MethodFillGrid();
                            }
                        }
                        //اگر کاربر عکسی را انتخاب کرده بود
                            if (ConvertImageToString != null)
                            {
                                if (Flag == 0)
                                {
                                    dbs.Entry(person).State = EntityState.Added;
                                    dbs.memberMap.Add(person);
                                    //تبدیل عکس به بیس 64 و ذخیره ان در دیتا بیس
                                    byte[] imageArray = System.IO.File.ReadAllBytes(ConvertImageToString);
                                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                                   
                                    person.Image = base64ImageRepresentation;
                                //
                                dbs.SaveChanges();
                                    MessageBox.Show("اطلاعات با موفقیت ثبت گردید");
                                    TextBoxFullName.Text = "";
                                    TextBoxNationalCode.Text = "";
                                    TextBoxPersonelNo.Text = "";
                                    TextBoxTellephon.Text = "";
                                    TextBoxAddres.Text = "";
                                    TextBoxRfidCard.Text = "";
                                    TextBoxFather.Text = "";
                                    Image_Play.Visibility = Visibility.Visible;
                                    Image_SnapShot.Source = null;
                                    //var result = (from r in dbs.memberMap.ToList()

                                    //              select r).ToList();
                                    //DataGridPersonel.ItemsSource = result;
                                    MethodFillGrid();
                                }



                            }

                            MethodFillGrid();


                            //   Image_SnapShot.Source = null;
                            //var result1 = (from r in dbs.memberMap.ToList()

                            //              select r).ToList();
                            //DataGridPersonel.ItemsSource = result1;
                        }





                    }
                }  
           
                catch
                {
                    MessageBox.Show("خطا در ارتباط");
                }


            }

        public static WpfManage.Setting.Setting GetSetting()
        {
            //خواندن محتوای فایل سیتینگ ذخیره شده در سیستم
            var setting = new WpfManage.Setting.Setting();
            using (var fs = File.OpenRead("D://setting"))
                setting = Serializer.Deserialize<WpfManage.Setting.Setting>(fs);
 
            return setting;
        }
    private void MethodFillGrid()
            {
                //متذ پر کردن گرید
                try
                {

                    var setting = GetSetting();
                    var entityConnectionString =Contex.BuildEntityConnection(setting.DataSource,setting.Instance,setting.InitialCatalog,setting.UserId,setting.Password);
                    using (var dbs = new Contex())
                            {

                              
                               
                                    var result = (from r in dbs.memberMap.ToList()

                                                  select r).ToList();

                                    DataGridPersonel.ItemsSource = result;
                              
                               
                              
                              
                               //if (dbs.Database.Exists())
                               //{
                                   //var blog = new Personel { FullName = "Razeghi" };
                                   //dbs.memberMap.Add(blog);
                                   //dbs.SaveChanges(); 
                                 //  MessageBox.Show(dbs.Database.Connection.ConnectionString);
                             //   string s = dbs.Database.Connection.DataSource;
                            //    MessageBox.Show(s);
                                 
                               //}
                               //else
                               //{
                               //     MessageBox.Show("ارتباط با پایگاه داده ناموفق بود");
                               //}
                              

                               
                             
                            return;
                            }
                        
                      
                     
                     
                    



                    

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,"پیغام خطای پایگاه داده");
                }


            }
 

            private void TextBoxNationalCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                //if (TextBoxNationalCode.Text=="[")
                //{
                //    TextBoxNationalCode.Text = "";
                //}
                //if (TextBoxNationalCode.Text == "]")
                //{
                //    TextBoxNationalCode.Text = "";
                //}

                //اعتبار سنجی
                e.Handled = !IsNumberAllowed(e.Text);

            }
            public void Validate(string input)
            {
                int myNumber;
              
               var s=   int.TryParse(input, out myNumber);
               if (s !=true )
                {
                    //MessageBox.Show("مفادیر عددی به درستی وارد نشده است");
                    Error = 1;
                    return;
                }
               Error = 0;
            }

            //متد عبارات منظم که این متد فقط عدد میگیرد
            private static bool IsNumberAllowed(string text)
            {
             
      
    
         Regex regex = new Regex("[^0[1-9]|1[0-2]+");
          
            return !regex.IsMatch(text);
            }

            //میگیرد متد عبارات منظم که این متدهر چیزی به جز عددو کاراکتر های خاص 

            private static bool IsTextAllowed(string text)
            {

                // Regex regex = new Regex("^[<>.!$@&*() _+=^#%~`/0-9.-]");
                //     Regex regex = new Regex("^[<>.!$@&*() _+=^#%{}[~`/0-9.-]");
                Regex regex = new Regex(@"^[a-zA-Zآ-ی]+$");

                var m = regex.Match(text);

                return m.Success;
                //$^&*()_+

            }


            private void TextBoxPersonelNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                e.Handled = !IsNumberAllowed(e.Text);
            }

            private void TextBoxTellephon_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                //اعتبار سنجی
                e.Handled = !IsNumberAllowed(e.Text);
            }

            private void TextBoxRfidCard_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {

                //کارت Rfid
                //اعتبار سنجی
                e.Handled = !IsNumberAllowed(e.Text);
            }

            private void TextBoxFullName_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                //اعتبار سنجی
                e.Handled = !IsTextAllowed(e.Text);
            }

            private void TextBoxFather_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                //اعتبار سنجی
                e.Handled = !IsTextAllowed(e.Text);
                //  e.Handled = !IsNumberAllowed(e.Text);
                //  IsNumberAllowed
            }

            private void TextBoxRfidCard_SelectionChanged(object sender, RoutedEventArgs e)
            {
                if (TextBoxRfidCard.Text.Length > 10)
                {


                    //  MessageBox.Show("کارت بیشتر از یک بارر بر روی سیستم قرار گرفته است لطفا دوباره سعی کنید");
                    TextBoxRfidCard.Text = "";
                }
            }

            private void TextBoxRfidCard_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                //if ( e.SystemKey == Key.NumPad0 
                // )
                //{
                //    e.Handled =true;
                //}
                //else
                //{
                //    base.OnPreviewKeyDown(e);
                //}
            }

            private void TextBoxRfidCard_KeyDown(object sender, KeyEventArgs e)
            {
            
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
          


        }

            private void TextBoxFullName_SelectionChanged(object sender, RoutedEventArgs e)
            {

            }

            private void TextBoxFullName_KeyDown(object sender, KeyEventArgs e)
            {
                //if ((!(((int)e.key
                //{

                //}
                if (e.Key == Key.Oem1)
                {
                    e.Handled = false;
                }
                if (e.Key == Key.Oem2)
                {
                    e.Handled = false;
                }
                if (e.Key == Key.Oem3)
                {
                    e.Handled = false;
                }
                if (e.Key == Key.Oem4)
                {
                    e.Handled = false;
                }
                if (e.Key == Key.Oem5)
                {
                    e.Handled = false;
                }
                if (e.Key == Key.Oem6)
                {
                    e.Handled = false;
                }
                if (e.Key == Key.Oem7)
                {
                    e.Handled = false;
                }
                if (e.Key == Key.Oem8)
                {
                    e.Handled = false;
                }
                if (e.Key == Key.OemAttn)
                {
                    e.Handled = false;
                }
                if (e.Key == Key.OemPlus)
                {
                    e.Handled = false;
                }

            }

        private void TextBoxNationalCode_KeyUp(object sender, KeyEventArgs e)
        {
            ////چلوگیری از وارد شدن براکت
            //if (e.Key == Key.Oem4)
            //{
            //    // TextBoxNationalCode.FlowDirection=FlowDirection.LeftToRight;
            //    //  e.Key = Key.Back;
            //    TextBoxNationalCode
            //        .Undo();
            //    //  TextBoxNationalCode.Undo();
            //}
            
        }

        private void TextBoxPersonelNo_KeyDown(object sender, KeyEventArgs e)
        {
            ////چلوگیری از وارد شدن براکت
            //if (e.Key == Key.Oem4)
            //{
            //    //  e.Key = Key.Back;
            //    TextBoxPersonelNo.Undo();
            //}
        }

        private void TextBoxTellephon_KeyDown(object sender, KeyEventArgs e)
        {
            ////چلوگیری از وارد شدن براکت
            //if (e.Key == Key.Oem4)
            //{
            //    //  e.Key = Key.Back;
            //    TextBoxPersonelNo.Undo();
            //}
        }

        private void TextBoxPersonelNo_KeyUp(object sender, KeyEventArgs e)
        {
            ////چلوگیری از وارد شدن براکت
            //if (e.Key == Key.Oem4)
            //{
            //    //  e.Key = Key.Back;
            //    TextBoxPersonelNo.Undo();
            //}
        }

        private void TextBoxTellephon_KeyUp(object sender, KeyEventArgs e)
        {
            ////چلوگیری از وارد شدن براکت
            //if (e.Key == Key.Oem4)
            //{
            //    //  e.Key = Key.Back;
            //    TextBoxTellephon.Undo();
            //}
        }

        private void TextBoxRfidCard_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
    }
