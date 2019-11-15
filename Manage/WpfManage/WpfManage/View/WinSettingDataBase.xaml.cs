using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfManage.View
{
    /// <summary>
    /// Interaction logic for WinSettingDataBase.xaml
    /// </summary>
    public partial class WinSettingDataBase : Window
    {
        public WinSettingDataBase()
        {
            InitializeComponent();
        }

     


 

        private void ButtonSavetoSetting_Click(object sender, RoutedEventArgs e)
        {
            //پر کردن مقادیر اجباری
            //پر کردن مقادیر اجباری
            //if (TextBoxDataSource.Text.Trim() == string.Empty)
            //{
            //    TextBoxDataSource.Focus();
            //    MessageBox.Show("پر کردن مقادیر ستاره دار الزامی است");
       
            //    return;
            //}
            //if (TextBoxUserId.Text.Trim() == string.Empty)
            //{
            //    TextBoxUserId.Focus();
            //    MessageBox.Show("پر کردن مقادیر ستاره دار الزامی است");
          
            //    return;
            //}
            //if (TextBoxInitialCatalog.Text.Trim() == string.Empty)
            //{
            //    TextBoxInitialCatalog.Focus();
            //    MessageBox.Show("پر کردن مقادیر ستاره دار الزامی است");
          
            //    return;
            //}
            //if (TextBoxPassword.Text.Trim() == string.Empty)
            //{
            //    TextBoxPassword.Focus();
            //    MessageBox.Show("پر کردن مقادیر ستاره دار الزامی است");
           
            //    return;
            //}
            //if (TextBoxInstance.Text.Trim() == string.Empty)
            //{
            //    TextBoxInstance.Focus();
            //    MessageBox.Show("پر کردن مقادیر ستاره دار الزامی است");
            //    TextBoxDataSource.Focus();
            //    return;
            //}
         //   else
         //   {
                // ذخیره مقادیر در سیتینگ
                WpfManage.Setting.Setting se = new Setting.Setting();
                se.DataSource = TextBoxDataSource.Text.Trim();
                se.Instance = TextBoxInstance.Text.Trim();
                se.UserId = TextBoxUserId.Text.Trim();
                se.Password = TextBoxPassword.Text.Trim();
                se.InitialCatalog = TextBoxInitialCatalog.Text.Trim();
                SaveSetting(se);
                MessageBox.Show("اطلاعات با موفقیت ذخیره گردید");
              
                TextBoxDataSource.Text = "";
                TextBoxInstance.Text = "";
                TextBoxUserId.Text = "";
                TextBoxPassword.Text = "";
                TextBoxInitialCatalog.Text = "";
         //   }
          //  Application.Current.Shutdown();
        }
        private static void SaveSetting(WpfManage.Setting.Setting setting)
        {
          
            //متد ذخیره  در فایل ایجاد شده در دایرکتوری جاری
            try
            {
                string filePath = "d://setting";

                using (var fs = File.Create(filePath))
                    Serializer.Serialize(fs, setting)
                        ;
            }
            catch
            {
                MessageBox.Show("خطا در ذخیره تنظیمات  ");
            }
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

       
         
      

        }

        private void WinDataBase_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        public static WpfManage.Setting.Setting GetSetting()
        {
           
                var setting = new WpfManage.Setting.Setting();
            try
            {
                using (var fs = File.OpenRead("d://setting"))
                    setting = Serializer.Deserialize<WpfManage.Setting.Setting>(fs);
            }
            catch
            {
                MessageBox.Show("تنظیمات از قبل وارد نشده است");
            }
              

                return setting;
           
          
          
        }

        private void WinShowProgram_Click(object sender, RoutedEventArgs e)
        {
            var setting = GetSetting();
            //if (setting.DataSource== null)
            //{
            //    MessageBox.Show("تنظیمات پایگاه داده را تصحیح نمایید");
            //    return;

            //}
            //if (setting.DataSource == string.Empty)
            //{
            //    MessageBox.Show("تنظیمات پایگاه داده را تصحیح نمایید");
            //    return;

            //}

            //if (setting.InitialCatalog == null)
            //{
            //    MessageBox.Show("تنظیمات پایگاه داده را تصحیح نمایید");
            //    return;
            //}
            //if (setting.InitialCatalog == String.Empty)
            //{
            //    MessageBox.Show("تنظیمات پایگاه داده را تصحیح نمایید");
            //    return;
            //}
            //if (setting.Instance == String.Empty)
            //{
            //    MessageBox.Show("تنظیمات پایگاه داده را تصحیح نمایید");
            //    return;
            //}
            //if (setting.Instance == null)
            //{
            //    MessageBox.Show("تنظیمات پایگاه داده را تصحیح نمایید");
            //    return;
            //}
            //if (setting.Password == null)
            //{
            //    MessageBox.Show("تنظیمات پایگاه داده را تصحیح نمایید");
            //    return;
            //}
            //if (setting.Password == String.Empty)
            //{
            //    MessageBox.Show("تنظیمات پایگاه داده را تصحیح نمایید");
            //    return;
            //}
            //if (setting.UserId == String.Empty)
            //{
            //    MessageBox.Show("تنظیمات پایگاه داده را تصحیح نمایید");
            //    return;
            //}
            //if (setting.UserId == null)
            //{
            //    MessageBox.Show("تنظیمات پایگاه داده را تصحیح نمایید");
            //    return;
            //}
         //   else
         //   {
                new MainWindow().ShowDialog();
            //    Close();
          //  }
        }

        private void ButtoدloadedSettinf_onclick(object sender, RoutedEventArgs e)
        {

            //پیاده سازی آخرین تنظیمات
            var setting = GetSetting();
            if (setting != null)
            {
                TextBoxDataSource.Text = setting.DataSource;
                TextBoxInstance.Text = setting.Instance;
                TextBoxUserId.Text = setting.UserId;
                TextBoxPassword.Text = setting.Password;
                TextBoxInitialCatalog.Text = setting.InitialCatalog;

            }
            if (setting == null)
            {
                MessageBox.Show("تنظیمات پایگاه داده در سیستم انجام نشده است");
            }
        }
    }
}
