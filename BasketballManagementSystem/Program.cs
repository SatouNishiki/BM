using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasketballManagementSystem.BaseClass.Settings;
using System.Globalization;
using System.Threading;

namespace BasketballManagementSystem.BMForm.Input
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            //アプリの言語設定
            if (AppSetting.GetInstance().Culture != "" && AppSetting.GetInstance().Culture != null)
            {
                //カルチャ情報を取得する
                CultureInfo culture = new CultureInfo(AppSetting.GetInstance().Culture);

                try
                {
                    // Windowsフォームのリソースに対応したUIカルチャを設定する
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
                catch (Exception ex)
                {
                    BMErrorLibrary.BMError.ErrorMessageOutput(ex.Message);
                }
            }

            Application.Run(new FormInput());

            AppSetting.GetInstance().SettingChanged();
        }
    }
}
