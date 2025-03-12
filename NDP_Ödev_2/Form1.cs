/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
**                                                          SAKARYA ÜNİVERSİTESİ
**                                          BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**                                              BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**                                           NESNEYE DAYALI PROGRAMLAMA DERSİ
**                                                      2022-2023 BAHAR DÖNEMİ
**
**                          ÖDEV NUMARASI..........: 2
**                          ÖĞRENCİ ADI............: DEMİRHAN SÖYLEMEZ
**                          ÖĞRENCİ NUMARASI.......: G211210010
**                          DERSİN ALINDIĞI GRUP...: 2-A
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDP_Ödev_2
{
    public partial class Form1 : Form
    {
        TextBox txtSayi = new TextBox();
        Label lblYazi = new Label();
        Button btnHesapla = new Button();
        public Form1()
        {
            InitializeComponent();
            //Form
            this.Size = new System.Drawing.Size(450, 265);
            this.Text = "Sayıyı Yazıya Çevirici";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //Label
            Point lblPoint = new Point((this.Size.Width - lblYazi.Size.Width) / 2 - 170, 60);
            lblYazi.Location = lblPoint;
            lblYazi.AutoSize = true;
            //Textbox
            Point txtPoint = new Point((this.Size.Width - txtSayi.Size.Width) / 2, 30);
            txtSayi.Location = txtPoint;
            //Buton
            Point btnPoint = new Point((this.Size.Width - btnHesapla.Size.Width) / 2, 90);
            this.btnHesapla.BackColor = Color.Gray;
            this.btnHesapla.Text = "Hesapla";
            btnHesapla.Location = btnPoint;
            this.AcceptButton = btnHesapla;
            btnHesapla.Click += new EventHandler(btnHesapla_Click);

            this.Controls.Add(btnHesapla);
            this.Controls.Add(lblYazi);
            this.Controls.Add(txtSayi);
        }
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            lblYazi.Visible = true;
            string girilenSayi;
            girilenSayi = txtSayi.Text;
            string birYazi = "", onYazi = "", yuzYazi = "", binYazi = "", onBinYazi = "", birKrsYazi = "", onKrsYazi = "";
            char birSayi;
            string sayiTam = " ";
            bool hataKontrol = false;
            //Textbox'a sadece sayı veya nokta girilip girilmediğini kontrol eder.
            foreach (char item in girilenSayi)
            {
                if (!char.IsDigit(item) && item != '.')
                {
                    hataKontrol = true;
                }
            }
            string[] kesme = girilenSayi.Split('.');
            sayiTam = kesme[0];
            //Eğer sayı girilmezse veya sayının uzunluğu 5'i geçerse hata verir.
            if (hataKontrol || sayiTam.Length > 5)
            {
                lblYazi.Visible = false;
                MessageBox.Show("Hatalı giriş yaptınız. Lütfen sadece 5 rakam giriniz.");
            }
            //Eğer sayı ondalıksa aşağıdaki işlemler yapılır.
            if (kesme.Length == 2)
            {
                string sayiOndalik;
                char birKrs;
                sayiOndalik = kesme[1];
                //Ondalık kısımın uzunluğu 2'yi geçerse hata verir.
                if (sayiOndalik.Length > 2 || sayiOndalik == "")
                {
                    lblYazi.Visible = false;
                    sayiOndalik = " ";
                    MessageBox.Show("Hatalı giriş yaptınız. Noktadan sonra sadece 2 rakam gelebilir.");
                }
                birKrs = sayiOndalik[sayiOndalik.Length - 1];
                //Girilen sayıya göre yazı karşılığı atanır.
                if (sayiOndalik.Length == 1)
                {
                    birKrs = sayiOndalik[sayiOndalik.Length - 1];
                    //Girilen sayıya göre yazı karşılığı atanır.
                    switch (birKrs)
                    {
                        case '0':
                            birKrsYazi = "KURUŞ";
                            break;
                        case '1':
                            birKrsYazi = "ON KURUŞ";
                            break;
                        case '2':
                            birKrsYazi = "YİRMİ KURUŞ";
                            break;
                        case '3':
                            birKrsYazi = "OTUZ KURUŞ";
                            break;
                        case '4':
                            birKrsYazi = "KIRK KURUŞ";
                            break;
                        case '5':
                            birKrsYazi = "ELLİ KURUŞ";
                            break;
                        case '6':
                            birKrsYazi = "ALTMIŞ KURUŞ";
                            break;
                        case '7':
                            birKrsYazi = "YETMİŞ KURUŞ";
                            break;
                        case '8':
                            birKrsYazi = "SEKSEN KURUŞ";
                            break;
                        case '9':
                            birKrsYazi = "DOKSAN KURUŞ";
                            break;
                        default:
                            birKrsYazi = "";
                            break;
                    }
                }
                //Ondalık kısım 2 haneli ise aşağıdaki işlemler yapılır.
                if (sayiOndalik.Length == 2)
                {
                    char onKrs;
                    switch (birKrs)
                    {
                        case '0':
                            birKrsYazi = "KURUŞ";
                            break;
                        case '1':
                            birKrsYazi = "BİR KURUŞ";
                            break;
                        case '2':
                            birKrsYazi = "İKİ KURUŞ";
                            break;
                        case '3':
                            birKrsYazi = "ÜÇ KURUŞ";
                            break;
                        case '4':
                            birKrsYazi = "DÖRT KURUŞ";
                            break;
                        case '5':
                            birKrsYazi = "BEŞ KURUŞ";
                            break;
                        case '6':
                            birKrsYazi = "ALTI KURUŞ";
                            break;
                        case '7':
                            birKrsYazi = "YEDİ KURUŞ";
                            break;
                        case '8':
                            birKrsYazi = "SEKİZ KURUŞ";
                            break;
                        case '9':
                            birKrsYazi = "DOKUZ KURUŞ";
                            break;
                        default:
                            birKrsYazi = "";
                            break;
                    }
                    onKrs = sayiOndalik[sayiOndalik.Length - 2];
                    //Girilen sayıya göre yazı karşılığı atanır.
                    switch (onKrs)
                    {
                        case '1':
                            onKrsYazi = "ON ";
                            break;
                        case '2':
                            onKrsYazi = "YİRMİ ";
                            break;
                        case '3':
                            onKrsYazi = "OTUZ ";
                            break;
                        case '4':
                            onKrsYazi = "KIRK ";
                            break;
                        case '5':
                            onKrsYazi = "ELLİ ";
                            break;
                        case '6':
                            onKrsYazi = "ALTMIŞ ";
                            break;
                        case '7':
                            onKrsYazi = "YETMİŞ ";
                            break;
                        case '8':
                            onKrsYazi = "SEKSEN ";
                            break;
                        case '9':
                            onKrsYazi = "DOKSAN ";
                            break;
                        default:
                            onKrsYazi = "";
                            break;
                    }

                }
            }

            //Eğer herhangi bir değer girilmezse hata olmaması için.
            if (sayiTam == "")
            {
                sayiTam = " ";
            }
            birSayi = sayiTam[sayiTam.Length - 1];
            //Girilen sayıya göre yazı karşılığı atanır.
            switch (birSayi)
            {
                case '0':
                    birYazi = "LİRA ";
                    break;
                case '1':
                    birYazi = "BİR LİRA ";
                    break;
                case '2':
                    birYazi = "İKİ LİRA ";
                    break;
                case '3':
                    birYazi = "ÜÇ LİRA ";
                    break;
                case '4':
                    birYazi = "DÖRT LİRA ";
                    break;
                case '5':
                    birYazi = "BEŞ LİRA ";
                    break;
                case '6':
                    birYazi = "ALTI LİRA ";
                    break;
                case '7':
                    birYazi = "YEDİ LİRA ";
                    break;
                case '8':
                    birYazi = "SEKİZ LİRA ";
                    break;
                case '9':
                    birYazi = "DOKUZ LİRA ";
                    break;
                default:
                    birYazi = "";
                    break;
            }
            //Onlar basamağı için işlemler.
            if (sayiTam.Length > 1)
            {
                char onSayi;
                onSayi = sayiTam[sayiTam.Length - 2];
                //Girilen sayıya göre yazı karşılığı atanır.
                switch (onSayi)
                {
                    case '1':
                        onYazi = "ON ";
                        break;
                    case '2':
                        onYazi = "YİRMİ ";
                        break;
                    case '3':
                        onYazi = "OTUZ ";
                        break;
                    case '4':
                        onYazi = "KIRK ";
                        break;
                    case '5':
                        onYazi = "ELLİ ";
                        break;
                    case '6':
                        onYazi = "ALTMIŞ ";
                        break;
                    case '7':
                        onYazi = "YETMİŞ ";
                        break;
                    case '8':
                        onYazi = "SEKSEN ";
                        break;
                    case '9':
                        onYazi = "DOKSAN ";
                        break;
                    default:
                        onYazi = "";
                        break;
                }
            }
            //Yüzler basamağı için işlemler.
            if (sayiTam.Length > 2)
            {
                char yuzSayi;
                yuzSayi = sayiTam[sayiTam.Length - 3];
                //Girilen sayıya göre yazı karşılığı atanır.
                switch (yuzSayi)
                {
                    case '1':
                        yuzYazi = "YÜZ ";
                        break;
                    case '2':
                        yuzYazi = "İKİ YÜZ ";
                        break;
                    case '3':
                        yuzYazi = "ÜÇ YÜZ ";
                        break;
                    case '4':
                        yuzYazi = "DÖRT YÜZ ";
                        break;
                    case '5':
                        yuzYazi = "BEŞ YÜZ ";
                        break;
                    case '6':
                        yuzYazi = "ALTI YÜZ ";
                        break;
                    case '7':
                        yuzYazi = "YEDİ YÜZ ";
                        break;
                    case '8':
                        yuzYazi = "SEKİZ YÜZ ";
                        break;
                    case '9':
                        yuzYazi = "DOKUZ YÜZ ";
                        break;
                    default:
                        yuzYazi = "";
                        break;
                }
            }
            //Binler basamağı için işlemler.
            if (sayiTam.Length > 3)
            {
                char binSayi;
                binSayi = sayiTam[sayiTam.Length - 4];
                //Girilen sayıya göre yazı karşılığı atanır.
                switch (binSayi)
                {
                    case '1':
                        binYazi = "BİN ";
                        break;
                    case '2':
                        binYazi = "İKİ BİN ";
                        break;
                    case '3':
                        binYazi = "ÜÇ BİN ";
                        break;
                    case '4':
                        binYazi = "DÖRT BİN ";
                        break;
                    case '5':
                        binYazi = "BEŞ BİN ";
                        break;
                    case '6':
                        binYazi = "ALTI BİN ";
                        break;
                    case '7':
                        binYazi = "YEDİ BİN ";
                        break;
                    case '8':
                        binYazi = "SEKİZ BİN ";
                        break;
                    case '9':
                        binYazi = "DOKUZ BİN ";
                        break;
                    default:
                        binYazi = "";
                        break;
                }
            }
            //Onbinler basamağı için işlemler.
            if (sayiTam.Length > 4)
            {
                char onBinSayi;
                onBinSayi = sayiTam[sayiTam.Length - 5];
                //Girilen sayıya göre yazı karşılığı atanır.
                switch (onBinSayi)
                {
                    case '1':
                        onBinYazi = "ON ";
                        break;
                    case '2':
                        onBinYazi = "YİRMİ ";
                        break;
                    case '3':
                        onBinYazi = "OTUZ ";
                        break;
                    case '4':
                        onBinYazi = "KIRK ";
                        break;
                    case '5':
                        onBinYazi = "ELLİ ";
                        break;
                    case '6':
                        onBinYazi = "ALTMIŞ ";
                        break;
                    case '7':
                        onBinYazi = "YETMİŞ ";
                        break;
                    case '8':
                        onBinYazi = "SEKSEN ";
                        break;
                    case '9':
                        onBinYazi = "DOKSAN ";
                        break;
                    default:
                        onBinYazi = "";
                        break;
                }
                //Binler basamağında 0 olması özel durumunda oluşacak hataları düzeltir.
                if (sayiTam[sayiTam.Length - 4] == '0')
                {
                    lblYazi.Text = onBinYazi + "BİN " + yuzYazi + onYazi + birYazi + onKrsYazi + birKrsYazi;
                }
                //Binler basamağında 1 olması özel durumunda oluşacak hataları düzeltir
                else if (sayiTam[sayiTam.Length - 4] == '1')
                {
                    string yeniOnBinYazi = "";
                    //Girilen sayıya göre yazı karşılığı atanır.
                    switch (onBinSayi)
                    {
                        case '1':
                            yeniOnBinYazi = "ON BİR ";
                            break;
                        case '2':
                            yeniOnBinYazi = "YİRMİ BİR ";
                            break;
                        case '3':
                            yeniOnBinYazi = "OTUZ BİR ";
                            break;
                        case '4':
                            yeniOnBinYazi = "KIRK BİR ";
                            break;
                        case '5':
                            yeniOnBinYazi = "ELLİ BİR ";
                            break;
                        case '6':
                            yeniOnBinYazi = "ALTMIŞ BİR ";
                            break;
                        case '7':
                            yeniOnBinYazi = "YETMİ BİR ";
                            break;
                        case '8':
                            yeniOnBinYazi = "SEKSEN BİR ";
                            break;
                        case '9':
                            yeniOnBinYazi = "DOKSAN BİR ";
                            break;
                        default:
                            yeniOnBinYazi = "";
                            break;
                    }
                    lblYazi.Text = yeniOnBinYazi + binYazi + yuzYazi + onYazi + birYazi + onKrsYazi + birKrsYazi;
                }
                else
                {
                    lblYazi.Text = onBinYazi + binYazi + yuzYazi + onYazi + birYazi + onKrsYazi + birKrsYazi;
                }
            }
            //0.65 gibi bir değer girildiğinde ekrana lira yazısı çıkmaması için
            else if (birSayi == '0' && sayiTam.Length == 1)
            {
                lblYazi.Text = onKrsYazi + birKrsYazi;
            }
            else
            {
                lblYazi.Text = onBinYazi + binYazi + yuzYazi + onYazi + birYazi + onKrsYazi + birKrsYazi;
            }
        }
    }
}
