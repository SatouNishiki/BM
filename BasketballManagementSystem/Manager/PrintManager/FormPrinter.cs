using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BasketballManagementSystem.Manager.PrintManager
{
    public class FormPrinter
    {
        //フォームのイメージを保存する変数
        private Bitmap memoryImage;

        /// <summary>
        /// フォームのイメージを印刷する
        /// </summary>
        /// <param name="frm">イメージを印刷するフォーム</param>
        public void PrintForm(Form frm)
        {
            //フォームのイメージを取得する
            memoryImage = CaptureControl(frm);
            //フォームのイメージを印刷する
            System.Drawing.Printing.PrintDocument PrintDocument1 =
                 new System.Drawing.Printing.PrintDocument();
            PrintDocument1.PrintPage +=
                 new System.Drawing.Printing.PrintPageEventHandler(
                 PrintDocument1_PrintPage);
           // PrintDocument1.Print();

            //PrintDialogクラスの作成
            PrintDialog pdlg = new PrintDialog();
            //PrintDocumentを指定
            pdlg.Document = PrintDocument1;
            //印刷の選択ダイアログを表示する
            if (pdlg.ShowDialog() == DialogResult.OK)
            {
                //OKがクリックされた時は印刷する
                PrintDocument1.Print();
            }

            memoryImage.Dispose();
        }

        /// <summary>
        /// コントロールのイメージを印刷する
        /// </summary>
        /// <param name="ctr">イメージを印刷するコントロール</param>
        public void PrintForm(Control ctr)
        {
            //フォームのイメージを取得する
            memoryImage = CaptureControl(ctr);
            //フォームのイメージを印刷する
            System.Drawing.Printing.PrintDocument PrintDocument1 =
                 new System.Drawing.Printing.PrintDocument();
            PrintDocument1.PrintPage +=
                 new System.Drawing.Printing.PrintPageEventHandler(
                 PrintDocument1_PrintPage);
        //    PrintDocument1.Print();

            //PrintDialogクラスの作成
            PrintDialog pdlg = new PrintDialog();
            //PrintDocumentを指定
            pdlg.Document = PrintDocument1;


            //印刷の選択ダイアログを表示する
            if (pdlg.ShowDialog() == DialogResult.OK)
            {
                //OKがクリックされた時は印刷する
                PrintDocument1.Print();
            }

            memoryImage.Dispose();

        }
        /*
        public void PrintScrollForm(Form form)
        {
            //フォームのイメージを取得する
            memoryImage = CaptureControl(form);

            //Graphicsの作成
            Graphics g = Graphics.FromImage(memoryImage);
            //画面全体をコピーする
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), memoryImage.Size);
            //解放
            g.Dispose();

            //フォームのイメージを印刷する
            System.Drawing.Printing.PrintDocument PrintDocument1 =
                 new System.Drawing.Printing.PrintDocument();
            PrintDocument1.PrintPage +=
                 new System.Drawing.Printing.PrintPageEventHandler(
                 PrintDocument1_PrintPage);
            //    PrintDocument1.Print();

            //PrintDialogクラスの作成
            PrintDialog pdlg = new PrintDialog();
            //PrintDocumentを指定
            pdlg.Document = PrintDocument1;


            //印刷の選択ダイアログを表示する
            if (pdlg.ShowDialog() == DialogResult.OK)
            {
                //OKがクリックされた時は印刷する
                PrintDocument1.Print();
            }

            memoryImage.Dispose();
        }
        */
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest,
             int nXDest, int nYDest, int nWidth, int nHeight,
             IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        private const int SRCCOPY = 0xCC0020;

        /// <summary>
        /// コントロールのイメージを取得する
        /// </summary>
        /// <param name="ctrl">キャプチャするコントロール</param>
        /// <returns>取得できたイメージ</returns>
        public Bitmap CaptureControl(Control ctrl)
        {
            Graphics g = ctrl.CreateGraphics();
            Bitmap img = new Bitmap(ctrl.ClientRectangle.Width,
                ctrl.ClientRectangle.Height, g);
            Graphics memg = Graphics.FromImage(img);
            IntPtr dc1 = g.GetHdc();
            IntPtr dc2 = memg.GetHdc();
            BitBlt(dc2, 0, 0, img.Width, img.Height, dc1, 0, 0, SRCCOPY);
            g.ReleaseHdc(dc1);
            memg.ReleaseHdc(dc2);
            memg.Dispose();
            g.Dispose();
            return img;
        }

        //PrintDocument1のPrintPageイベントハンドラ
        private void PrintDocument1_PrintPage(object sender,
             System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        public void ShowPrintPreview(Form form)
        {
            //フォームのイメージを取得する
            memoryImage = CaptureControl(form);

            //PrintDocumentオブジェクトの作成
            System.Drawing.Printing.PrintDocument pd =
                new System.Drawing.Printing.PrintDocument();
            //PrintPageイベントハンドラの追加
            pd.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(PrintDocument1_PrintPage);

            //PrintPreviewDialogオブジェクトの作成
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            //プレビューするPrintDocumentを設定
            ppd.Document = pd;
            //印刷プレビューダイアログを表示する
            ppd.ShowDialog();

            memoryImage.Dispose();
        }

        public void ShowPrintPreview(Control ctr)
        {
            //フォームのイメージを取得する
            memoryImage = CaptureControl(ctr);

            //PrintDocumentオブジェクトの作成
            System.Drawing.Printing.PrintDocument pd =
                new System.Drawing.Printing.PrintDocument();
            //PrintPageイベントハンドラの追加
            pd.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(PrintDocument1_PrintPage);

            //PrintPreviewDialogオブジェクトの作成
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            //プレビューするPrintDocumentを設定
            ppd.Document = pd;
            //印刷プレビューダイアログを表示する
            ppd.ShowDialog();

            memoryImage.Dispose();
        }
    }
}
