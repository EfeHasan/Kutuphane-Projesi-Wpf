 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Xps.Serialization;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Crypto.Encodings;

namespace Kütüphane_Projesi_wpf
{
    class Giris_Yap
    {
        public static string baglanti = "Server=localhost;Database=kutuphane_projesi_xaml;Uid=root;Pwd='Ananbeanan1_';";

        string sifre_, ad_;
        public Giris_Yap(string sifre, string ad)
        {
            sifre_ = sifre;
            ad_ = ad;
        }
        public bool giris_yap()
        {
            bool varmi = false;

            using (MySqlConnection conn = new MySqlConnection(baglanti))
            {
                int count;
                string ara = "select * from kullanicilar where Isim=@Isim and Sifre=@Sifre";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(ara, conn);
                cmd.Parameters.AddWithValue("@Isim", ad_);
                cmd.Parameters.AddWithValue("@Sifre", sifre_);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    varmi = true;
                }
                return varmi;
                conn.Close();
            }
        }
        string yetki_;

        public string yetki_varmi()
        {

            using (MySqlConnection conn = new MySqlConnection(baglanti))
            {

                string varmi = "Select yetki from kullanicilar where Isim=@Isim and Sifre=@Sifre";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(varmi, conn);
                cmd.Parameters.AddWithValue("@Isim", ad_);
                cmd.Parameters.AddWithValue("@Sifre", sifre_);
                using(MySqlDataReader reader=cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        yetki_=reader.GetString(0);
                    }

                }
            }
            return yetki_;

        }
        public void beni_hatirla()
        {
            using(MySqlConnection conn = new MySqlConnection(baglanti))
            {
                string eylem = "insert into beni_hatirla(kullanici_adi,sifre) values(@kullanici_adi,@sifre)";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(eylem, conn))
                {
                    cmd.Parameters.AddWithValue("@kullanici_adi", ad_);
                    cmd.Parameters.AddWithValue("@sifre", sifre_);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public int hatirlaniyormuyum() 
        {
            int deger = 0;
            using (MySqlConnection conn = new MySqlConnection(baglanti))
            {
                conn.Open();
                string eylem = "Select * from beni_hatirla";

                MySqlCommand command = new MySqlCommand(eylem, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    deger++;
                }
            }
            return deger;
        }
        public void kayitlari_sil()
        {
            using(MySqlConnection con = new MySqlConnection(baglanti))
            {
                con.Open();
                string eylem = "delete from beni_hatirla";
                MySqlCommand command=new MySqlCommand(eylem, con);
                command.ExecuteNonQuery();
                con.Close();

            }
        }
    }
    class Kayit_OL
    {
        string Tc_No, Isim, Soy_Isim, Sifre, yetki_sifresi, telefon_no;
        public Kayit_OL(string tc, string isim, string soy, string sifre,string telefon)
        {
            Tc_No = tc;
            Isim = isim;
            Soy_Isim = soy;
            Sifre = sifre;
            telefon_no = telefon;
        }
        public void kayit_ol()
        {
            bool varmi = tc_varmi();
            if (!varmi)
            {
                using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
                {
                    conn.Open();
                    string ekle = "insert into kullanicilar(Tc_No,Isim,Soy_Isim,Sifre,yetki,telefon_numarasi) values(@Tc_No,@Isim,@Soy_Isim,@Sifre,@yetki_sifresi,@telefon_numarasi)";
                    using (MySqlCommand cmd = new MySqlCommand(ekle, conn))
                    {
                        cmd.Parameters.AddWithValue("@Tc_No", Tc_No);
                        cmd.Parameters.AddWithValue("@Isim", Isim);
                        cmd.Parameters.AddWithValue("@Soy_Isim", Soy_Isim);
                        cmd.Parameters.AddWithValue("@Sifre", Sifre);
                        cmd.Parameters.AddWithValue("@telefon_numarasi", telefon_no);
                        cmd.Parameters.AddWithValue("@yetki_sifresi", "kullanıcı");
                        int oldumu = cmd.ExecuteNonQuery();
                        if (oldumu > 0)
                        {
                            MessageBox.Show("kayit başarılı");
                        }
                        else
                        {
                            MessageBox.Show("kayıt başarısız");
                        }
                    }
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Bu tc kimlik numarası başka bir kullanıcıda var");
            }
        }

        public static int sifre_inceleme(string sifre)
        {
            int incele = 0;
            for (int i = 0; i < sifre.Length; i++)
            {
                for (int j = 0; j < Kayit_Ekranı.buyukHarfler.Length; j++)
                {
                    if (sifre[i].ToString() == Kayit_Ekranı.buyukHarfler[j] || sifre[i].ToString() == Kayit_Ekranı.buyukHarfler[j].ToLower())
                    {
                        incele += 8;
                    }
                    else if (j < 9)
                    {
                        if (sifre[i].ToString() == Kayit_Ekranı.sayilar[j])
                        {
                            incele += 10;
                        }
                    }
                }
            }
            return incele;
        }
        private bool tc_varmi()
        {
            bool varmi = false;
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string kontrol = "select Tc_No from kullanicilar where Tc_No=@Tc_No";
                MySqlCommand command =new MySqlCommand(kontrol, conn);
                command.Parameters.AddWithValue("@Tc_No", Tc_No);
                MySqlDataAdapter adapter =new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                int deger = table.Rows.Count;
                if (deger > 0)
                {
                    varmi = true;
                }
                else
                {
                    varmi = false;
                }
            }
            return varmi;
        }
        public bool sifre_varmi()
        {
            bool var = false;
            using(MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                int sayi = 0;
                conn.Open();
                string bak = "select Sifre from kullanicilar where Sifre=@Sifre";
                MySqlCommand mySqlCommand = new MySqlCommand(bak, conn);
                mySqlCommand.Parameters.AddWithValue("@Sifre", Sifre);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    sayi++;
                }
                if (sayi > 0)
                {
                    var = true;
                }
                conn.Close();

            }
            return var;
        }
    }

    class Kitap_Islemleri
    {
        string kitap_isim1, yazar, durumu, kitap_turu;
        DateTime basim_tarihi;
        public Kitap_Islemleri(string kitap_isim, string kitap_yazari, string durumu, string kitap_turu, DateTime basim_tarih)
        {
            kitap_isim1= kitap_isim;
            yazar = kitap_yazari;
            this.durumu = durumu;
            this.kitap_turu = kitap_turu;
            this.basim_tarihi = basim_tarih;
        }

        public void kitap_ekle()
        {
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string ekle = "insert into kitaplar(kitap_yazari,kitap_isimi,kitap_turu,basim_tarihi,durumu) values(@kitap_yazari,@kitap_isimi,@kitap_turu,@basim_tarihi,@durumu)";
                using (MySqlCommand cmd = new MySqlCommand(ekle,conn))
                {
                    cmd.Parameters.AddWithValue("@kitap_yazari", yazar);
                    cmd.Parameters.AddWithValue("@kitap_isimi",kitap_isim1);
                    cmd.Parameters.AddWithValue("@kitap_turu", kitap_turu);
                    cmd.Parameters.AddWithValue("@basim_tarihi", basim_tarihi);
                    cmd.Parameters.AddWithValue("@durumu", durumu);
                    int sayi = cmd.ExecuteNonQuery();
                    if (sayi > 0) 
                    {
                        MessageBox.Show("ekleme başarılı");
                    }
                    else
                    {
                        MessageBox.Show("ekleme başarısız");
                    }
                }
                conn.Close();
            }
        }
        public void kitap_sil()
        {
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string sil = "delete from kitaplar where kitap_isimi=@kitap_isimi and kitap_turu=@kitap_turu";
                MySqlCommand cmd=new MySqlCommand(sil,conn);
                cmd.Parameters.AddWithValue("@kitap_isimi", kitap_isim1);
                cmd.Parameters.AddWithValue("@kitap_turu", kitap_turu);
                int sayi = cmd.ExecuteNonQuery();
                if (sayi > 0)
                {
                    MessageBox.Show("işlem başarılı");
                }
                else
                {
                    MessageBox.Show("işlem başarısız");
                }
                conn.Close();
            }

        }
        public int degistir(string update, string degisecek, string isim, string parametres, string parametres1) 
        {
            int cikti = 0;

            using (MySqlConnection connection = new MySqlConnection(Giris_Yap.baglanti))
            {
                connection.Open();

                if (degisecek == "@basim_tarihi")
                {
                    MySqlCommand cmd = new MySqlCommand(update, connection);
                    cmd.Parameters.AddWithValue(degisecek, Convert.ToDateTime(parametres));
                    cmd.Parameters.AddWithValue(isim, parametres1);
                    cikti = cmd.ExecuteNonQuery();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand(update, connection);
                    cmd.Parameters.AddWithValue(degisecek, parametres);
                    cmd.Parameters.AddWithValue(isim, parametres1);
                    cikti = cmd.ExecuteNonQuery();
                }
                connection.Close();
;
            }
            return cikti;
            
        }
    }
    class kitap
    {
        public string kitap_isimi { get; set; }
        public string kitap_yazari { get; set; }
        public string basim_tarihi { get; set; }
        public string durumu { get; set; }
        public string kitap_turu { get; set; }
    }
    class kitaplari_goruntuleri
    {
        public static List<kitap> sonuc = new List<kitap>();
        public static List<kitap> sonuc1 = new List<kitap>();
        public static List<kitap> sonuc2 = new List<kitap>();

        public string kitap_isimi { get; set; } = "";
        public string secilen_tur { get; set; } = "";

        public void isime_gore()
        {
            sonuc.Clear();

            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string aranan = "select * from kitaplar where kitap_isimi=@kitap_isimi";
                MySqlCommand mySqlCommand = new MySqlCommand(aranan, conn);
                mySqlCommand.Parameters.AddWithValue("@kitap_isimi", kitap_isimi);
                using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        kitap kitap_ = new kitap
                        {
                            kitap_isimi = reader["kitap_isimi"].ToString(),
                            kitap_yazari = reader["kitap_yazari"].ToString(),
                            kitap_turu = reader["kitap_turu"].ToString(),
                            basim_tarihi = reader["basim_tarihi"].ToString(),
                            durumu = reader["durumu"].ToString()
                        };
                        sonuc.Add(kitap_);

                    }

                }
                conn.Close();
            }
        }
        
        public void turlere_gore()
        {
            sonuc1.Clear();
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string update = "select * from kitaplar where kitap_turu=@kitap_turu";
                MySqlCommand cmd = new MySqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@kitap_turu", secilen_tur);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    kitap kitap_ = new kitap
                    {
                        kitap_isimi = reader["kitap_isimi"].ToString(),
                        kitap_yazari = reader["kitap_yazari"].ToString(),
                        kitap_turu = reader["kitap_turu"].ToString(),
                        basim_tarihi = reader["basim_tarihi"].ToString(),
                        durumu = reader["durumu"].ToString()
                    };
                    sonuc1.Add(kitap_);

                }
                conn.Close();
            }
        }
        public void tarihe_Gore_Yuksel()
        {
            sonuc2.Clear();
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string sirala = "SELECT * FROM Kitaplar ORDER BY basim_tarihi ASC";
                MySqlCommand command=new MySqlCommand(sirala, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    kitap kitap_ = new kitap
                    {
                        kitap_isimi = reader["kitap_isimi"].ToString(),
                        kitap_yazari = reader["kitap_yazari"].ToString(),
                        kitap_turu = reader["kitap_turu"].ToString(),
                        basim_tarihi = reader["basim_tarihi"].ToString(),
                        durumu = reader["durumu"].ToString()
                    };
                    sonuc2.Add(kitap_);
                }
                conn.Close();
            }
        }        
        public void tarihe_Gore_Kucul()
        {
            sonuc2.Clear();
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string sirala = "SELECT * FROM Kitaplar ORDER BY basim_tarihi DESC";
                MySqlCommand command = new MySqlCommand(sirala, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kitap kitap_ = new kitap
                    {
                        kitap_isimi = reader["kitap_isimi"].ToString(),
                        kitap_yazari = reader["kitap_yazari"].ToString(),
                        kitap_turu = reader["kitap_turu"].ToString(),
                        basim_tarihi = reader["basim_tarihi"].ToString(),
                        durumu = reader["durumu"].ToString()
                    };
                    sonuc2.Add(kitap_);
                }
                conn.Close();
            }
        }
    }

    class emanet_islmeleri
    {
        public static bool a(string deger)
        {
            bool uygun = true;
            for (int i = 0; i < Kayit_Ekranı.buyukHarfler.Length; i++)
            {
                for (int a = 0; a < deger.Length; a++)
                {
                    if (deger[a].ToString() == Kayit_Ekranı.buyukHarfler[i] || deger[a].ToString() == Kayit_Ekranı.buyukHarfler[i].ToLower())
                    {
                        uygun = false;
                    }
                }
            }

            return uygun;
        }
        
        //string Tc_Kimlik, Kitap_Ismi, Isim, SoyIsim;
        string Tc_Kimlik;
        bool uygun = true;
        public string tc_kimlik
        {
            get
            {
                return Tc_Kimlik;
            }
            set
            {
                if (a(value) && value.Length == 11)
                {
                    Tc_Kimlik = value;
                }
                else
                {
                    MessageBox.Show("başarısız");

                }
            }
        }
        public string kitap_ismi { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public void ekle()
        {
            int i=0;
            if (!string.IsNullOrEmpty(kitap_ismi) && !string.IsNullOrEmpty(isim) && !string.IsNullOrEmpty(soyisim) && !string.IsNullOrEmpty(tc_kimlik))
            {
                bool bos_ = false;
                using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
                {
                    conn.Open();
                    string durumu = "select durumu from kitaplar where kitap_isimi=@kitap_isimi";
                    using (MySqlCommand command = new MySqlCommand(durumu, conn))
                    {
                        command.Parameters.AddWithValue("@kitap_isimi", kitap_ismi);
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["durumu"].ToString() == "boş")
                            {
                                bos_ = true;
                            }
                        }
                        reader.Close();
                        conn.Close();
                    }
                }
                using(MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
                {
                    conn.Open();
                    string varmi = "select * from kullanicilar where Tc_No=@Tc_No and Isim=@Isim";
                    MySqlCommand command = new MySqlCommand(varmi, conn);
                    command.Parameters.AddWithValue("@Isim",isim);
                    command.Parameters.AddWithValue("@Tc_No", tc_kimlik);

                    MySqlDataReader reader=command.ExecuteReader();
                    while (reader.Read())
                    {
                        i++;
                    }
                    conn.Close() ;
                }
                if (bos_ && i > 0) 
                {

                    using (MySqlConnection a = new MySqlConnection(Giris_Yap.baglanti))
                    {
                        a.Open();
                        string add = "insert into kitap_alim(Tc_Kimlik, Kitap_Ismi,Alim_Tarihi,Isim,SoyIsim) values(@Tc_Kimlik,@Kitap_Ismi,@Alim_Tarihi,@Isim,@SoyIsim)";
                        using (MySqlCommand command = new MySqlCommand(add, a))
                        {
                            command.Parameters.AddWithValue("@Tc_Kimlik", tc_kimlik);
                            command.Parameters.AddWithValue("@Kitap_Ismi", kitap_ismi);
                            command.Parameters.AddWithValue("@Alim_Tarihi", DateTime.Today);
                            command.Parameters.AddWithValue("@Isim", isim);
                            command.Parameters.AddWithValue("@SoyIsim", soyisim);
                            int deger = command.ExecuteNonQuery();
                            if (deger > 0)
                            {
                                string update = "update kitaplar set durumu=@durumu where kitap_isimi=@kitap_isimi";
                                using (MySqlCommand ab = new MySqlCommand(update, a))
                                {
                                    ab.Parameters.Add("@durumu", MySqlDbType.VarChar).Value = "dolu";
                                    ab.Parameters.Add("@kitap_isimi", MySqlDbType.VarChar).Value = kitap_ismi;
                                    ab.ExecuteNonQuery();
                                }
                                MessageBox.Show("İşlem Başarılı");
                            }
                            else
                            {
                                MessageBox.Show("İşlem Başarısız");
                            }
                        }

                        a.Close();
                    }
                }
                else
                {
                    if (!bos_)
                    {
                        MessageBox.Show("Kitap Durumu Boş Değil");
                    }
                    if (i <= 0)
                    {
                        MessageBox.Show("Böyle Bir Kullanıcı Bulunamamıştır");
                    }
                }
            }
            else
            {
                MessageBox.Show("Kutucuklar Boş Bırakılmış");
            }
        }
        public void sil()
        {
            int deger;
            int rowsAffected;
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string delete = "DELETE FROM kitap_alim WHERE Isim=@Isim and Tc_kimlik=@Tc_kimlik";
                using (MySqlCommand command = new MySqlCommand(delete, conn))
                {
                    command.Parameters.Add("@Tc_Kimlik", MySqlDbType.VarChar).Value = tc_kimlik;
                    command.Parameters.Add("@Isim", MySqlDbType.VarChar).Value = isim;
                    deger = command.ExecuteNonQuery();
                }
                string update = "update kitaplar set durumu=@durumu where kitap_isimi=@kitap_isimi";
                using (MySqlCommand ab = new MySqlCommand(update, conn))
                {
                    ab.Parameters.AddWithValue("@durumu", "boş");
                    ab.Parameters.AddWithValue("@kitap_isimi", kitap_ismi);
                    rowsAffected = ab.ExecuteNonQuery();
                }

                conn.Close();
            }

            if (deger > 0 && rowsAffected > 0)
            {
                MessageBox.Show("İşlem Başarılı");
            }
            else
            {
                MessageBox.Show("İşlem Başarısız");
            }


        }
        public void komple_sil()
        {
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string delete = "delete from kitap_alim";
                MySqlCommand command = new MySqlCommand(delete,conn);
                int deger = command.ExecuteNonQuery();
                string update = "update kitaplar set durumu=@durumu";
                using (MySqlCommand ab = new MySqlCommand(update, conn))
                {
                    ab.Parameters.AddWithValue("@durumu", "boş");
                    ab.ExecuteNonQuery();
                }

                if (deger > 0)
                {
                    MessageBox.Show("İşlem Başarılı");
                }
                else
                {
                    MessageBox.Show("İşlem Başarısız");
                }
                conn.Close();
            }
        }
    }
    class emanet_goruntule
    {
        public List<emanet_goruntule> ciktilar = new List<emanet_goruntule>();
        string tc;
        public string Isim { get; set; }
        public string Kitap_Ismi { get; set; }
        public string SoyIsim { get; set; }
        public string Tc_Kimlik
        {
            get
            {
                return tc;
            }
            set
            {
                
                if (emanet_islmeleri.a(value) && value.Length == 11)
                {
                    tc = value;
                }
                else
                {
                    MessageBox.Show("Tc isetnilen kraterlere uymuyor");
                }
            }
        }
        public string Alim_Tarihi { get; set; }

        public void isime_gore_bul()
        {
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti)) 
            {
                conn.Open();
                string getirilecek = "select * from kitap_alim where Isim=@Isim and SoyIsim=@SoyIsim ";
                MySqlCommand mySqlCommand = new MySqlCommand(getirilecek,conn);

                mySqlCommand.Parameters.AddWithValue("@Isim", Isim);
                mySqlCommand.Parameters.AddWithValue("SoyIsim", SoyIsim);

                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ciktilar.Add(new emanet_goruntule
                    {
                        Isim = reader["Isim"].ToString(),
                        SoyIsim = reader["SoyIsim"].ToString(),
                        Alim_Tarihi = reader["Alim_Tarihi"].ToString(),
                        Tc_Kimlik = reader["Tc_Kimlik"].ToString(),
                        Kitap_Ismi = reader["Kitap_Ismi"].ToString()
                    });
                }
                reader.Close();
                conn.Close();
            }
        }
        
        public void goruntule()
        {
            using(MySqlConnection conn =new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string goruntule = "select * from kitap_alim";
                MySqlCommand cmd = new MySqlCommand(goruntule, conn);
                
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    ciktilar.Add(new emanet_goruntule
                    {
                        Isim = mySqlDataReader["Isim"].ToString(),
                        SoyIsim = mySqlDataReader["SoyIsim"].ToString(),
                        Alim_Tarihi = mySqlDataReader["Alim_Tarihi"].ToString(),
                        Tc_Kimlik = mySqlDataReader["Tc_Kimlik"].ToString(),
                        Kitap_Ismi = mySqlDataReader["Kitap_Ismi"].ToString()
                    });
                }
                mySqlDataReader.Close();
                conn.Close();
            }
        }
        public void tarihe_gore(int a)
        {
            if (a % 2 == 0) 
            {
                using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
                {
                    conn.Open();
                    string goruntule = "select * from kitap_alim ORDER BY Alim_Tarihi Asc";
                    MySqlCommand cmd = new MySqlCommand(goruntule, conn);
                    MySqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ciktilar.Add(new emanet_goruntule
                        {
                            Isim = sqlDataReader["Isim"].ToString(),
                            SoyIsim = sqlDataReader["SoyIsim"].ToString(),
                            Alim_Tarihi = sqlDataReader["Alim_Tarihi"].ToString(),
                            Tc_Kimlik = sqlDataReader["Tc_Kimlik"].ToString(),
                            Kitap_Ismi = sqlDataReader["Kitap_Ismi"].ToString()
                        });
                    }
                    sqlDataReader.Close();
                    conn.Close();
                }
            }
            else if (a % 2 != 0)
            {
                using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
                {
                    conn.Open();
                    string goruntule = "select * from kitap_alim ORDER BY Alim_Tarihi DESC";
                    MySqlCommand cmd = new MySqlCommand(goruntule, conn);   
                    MySqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ciktilar.Add(new emanet_goruntule
                        {
                            Isim = sqlDataReader["Isim"].ToString(),
                            SoyIsim = sqlDataReader["SoyIsim"].ToString(),
                            Alim_Tarihi = sqlDataReader["Alim_Tarihi"].ToString(),
                            Tc_Kimlik = sqlDataReader["Tc_Kimlik"].ToString(),
                            Kitap_Ismi = sqlDataReader["Kitap_Ismi"].ToString()
                        });
                    }
                    sqlDataReader.Close();
                    conn.Close();
                }
            }
        }
    }
    class kullanici_düzenle
    {
        string sifre_, tc_, numara_;
        public string Isim { get; set; }
        public string SoyIsim { get; set; }
        public string Sifre
        {
            get
            {
                return sifre_;
            }
            set
            {
                if (sifre_.Length >= 8 && sifre_.Length <= 16)
                {
                    sifre_ = value;
                }
                else
                {
                    MessageBox.Show("Şifre istenen koşulları sağlamıyor");
                }
            }
        }
        public string Tc_Kimlik
        {
            get
            {
                return tc_;
            }
            set
            {
               if(emanet_islmeleri.a(value) && value.Length == 11)
                {
                    tc_ = value;
                }
                else
                {
                    MessageBox.Show("tc istenilen kraterleri karşılamıyor");
                }
            }
        }
        public string numara_get
        {
            get
            {
                return numara_;
            }
            set
            {
                if (emanet_islmeleri.a(value) && value.Length == 11) 
                {
                    numara_ = value;
                }
                else
                {
                    MessageBox.Show("Numara yanlış yazılmıştır");
                }
            }
        }
        public int Sifre_Degistir()
        {
            int deger = 0;
            if (!string.IsNullOrEmpty(Isim) && !string.IsNullOrEmpty(SoyIsim) && !string.IsNullOrEmpty(Sifre) && !string.IsNullOrEmpty(Tc_Kimlik))
            {
                using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
                {
                    string sifre_degistir = "update from kullanicilar set Sifre=@Sifre where Isim=@Isim and Soy_Isim=@Soy_Isim and Tc_No=@Tc_No";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sifre_degistir, conn);
                    cmd.Parameters.AddWithValue("@Isim", Isim);
                    cmd.Parameters.AddWithValue("@Soy_Isim", SoyIsim);
                    cmd.Parameters.AddWithValue("@Sifre", Sifre);
                    cmd.Parameters.AddWithValue("@Tc_No", Tc_Kimlik);
                    deger = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {
                if(string.IsNullOrEmpty(Isim))
                {
                    MessageBox.Show("isim kutusu boş bırakılmıştır");
                }
                if (string.IsNullOrEmpty(SoyIsim))
                {
                    MessageBox.Show("Soyisim kutusu boş bırakılmıştır");
                }
                if (string.IsNullOrEmpty(Sifre))
                {
                    MessageBox.Show("Şifre Kutusu boş bırakılmıştır");
                }
                if (string.IsNullOrEmpty(Tc_Kimlik))
                {
                    MessageBox.Show("Tc kimlik kutusu boş bırakılmıştır");
                }
            }
            return deger;
        }
        public int Numara_Degistir()
        {
            int deger = 0;
            if (!string.IsNullOrEmpty(Isim) && !string.IsNullOrEmpty(SoyIsim) && !string.IsNullOrEmpty(numara_get) && !string.IsNullOrEmpty(Tc_Kimlik))
            {
                using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
                {
                    string numara = "update kullanicilar set telefon_numarasi=@telefon_numarasi where Isim=@Isim and Soy_Isim=@Soy_Isim and Tc_No=@Tc_No";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(numara, conn);
                    cmd.Parameters.AddWithValue("@Isim", Isim);
                    cmd.Parameters.AddWithValue("@Soy_Isim", SoyIsim);
                    cmd.Parameters.AddWithValue("@telefon_numarasi", numara_get);
                    cmd.Parameters.AddWithValue("@Tc_No", Tc_Kimlik);
                    deger = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Isim))
                {
                    MessageBox.Show("isim kutusu boş bırakılmıştır");
                }
                if (string.IsNullOrEmpty(SoyIsim))
                {
                    MessageBox.Show("Soyisim kutusu boş bırakılmıştır");
                }
                if (string.IsNullOrEmpty(numara_get))
                {
                    MessageBox.Show("Numara kutusu boş bırakılmıştır");
                }
                if (string.IsNullOrEmpty(Tc_Kimlik))
                {
                    MessageBox.Show("Tc kimlik kutusu boş bırakılmıştır");
                }
            }
            return deger;
        }

        public int Yetki_Ver()
        {
            int deger = 0;
            if (!string.IsNullOrEmpty(Isim) && !string.IsNullOrEmpty(SoyIsim) && !string.IsNullOrEmpty(Tc_Kimlik))
            {
                using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
                {
                    string numara = "update kullanicilar set yetki=@yetki where Isim=@Isim and Soy_Isim=@Soy_Isim and Tc_No=@Tc_No";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(numara, conn);
                    cmd.Parameters.AddWithValue("@Isim", Isim);
                    cmd.Parameters.AddWithValue("@Soy_Isim", SoyIsim);
                    cmd.Parameters.AddWithValue("@yetki", "yetkili");
                    cmd.Parameters.AddWithValue("@Tc_No", Tc_Kimlik);
                    deger = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Isim))
                {
                    MessageBox.Show("isim kutusu boş bırakılmıştır");
                }
                if (string.IsNullOrEmpty(SoyIsim))
                {
                    MessageBox.Show("Soyisim kutusu boş bırakılmıştır");
                }
                if (string.IsNullOrEmpty(Tc_Kimlik))
                {
                    MessageBox.Show("Tc kimlik kutusu boş bırakılmıştır");
                }
            }
            return deger;

        }

        public int Tc_Degistir()
        {
            int deger = 0;
            if (!string.IsNullOrEmpty(Isim) && !string.IsNullOrEmpty(SoyIsim) && !string.IsNullOrEmpty(Tc_Kimlik))
            {
                using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
                {
                    string numara = "update kullanicilar set Tc_No=@Tc_No where Isim=@Isim and Soy_Isim=@Soy_Isim and telefon_numarasi=@telefon_numarasi";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(numara, conn);
                    cmd.Parameters.AddWithValue("@Isim", Isim);
                    cmd.Parameters.AddWithValue("@Soy_Isim", SoyIsim);
                    cmd.Parameters.AddWithValue("@telefon_numarasi", numara_get);
                    cmd.Parameters.AddWithValue("@Tc_No", Tc_Kimlik);
                    deger = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Isim))
                {
                    MessageBox.Show("isim kutusu boş bırakılmıştır");
                }
                if (string.IsNullOrEmpty(SoyIsim))
                {
                    MessageBox.Show("Soyisim kutusu boş bırakılmıştır");
                }
                if (string.IsNullOrEmpty(Tc_Kimlik))
                {
                    MessageBox.Show("Tc kimlik kutusu boş bırakılmıştır");
                }
                if (string.IsNullOrEmpty(numara_get))
                {
                    MessageBox.Show("Numara kutusu boş bırakılmıştırr");
                }
            }
            return deger;
        }

    }

    class insanlar
    {
        public string Tc_No { get; set; }
        public string Isim { get; set; }
        public string Soy_Isim { get; set; }
        public string Sifre { get; set; }
        public string yetki { get; set; }
        public string telefon_numarasi { get; set; }
    }

   class kullanici_goruntule : insanlar
    {
        public List<insanlar> kullanicilar = new List<insanlar>();
        
        public void isime_gore()
        {
            using(MySqlConnection conn =new MySqlConnection(Giris_Yap.baglanti))
            {
                string ara = "select * from kullanicilar where Isim=@Isim";
                conn.Open();

                MySqlCommand command = new MySqlCommand(ara, conn);
                command.Parameters.AddWithValue("@Isim", Isim);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kullanicilar.Add(new insanlar
                    {
                        Isim = reader["Isim"].ToString(),
                        Sifre = reader["Sifre"].ToString(),
                        Soy_Isim = reader["Soy_Isim"].ToString(),
                        Tc_No = reader["Tc_No"].ToString(),
                        telefon_numarasi = reader["telefon_numarasi"].ToString(),
                        yetki = reader["yetki"].ToString()
                    });
                }
                conn.Close();
            }
        }
        public void soyisime_gore()
        {
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string bul = "select * fron kullanicilar where Soy_Isim=@Soy_Isim";
                MySqlCommand command = new MySqlCommand(bul,conn);
                command.Parameters.AddWithValue("@Soy_Isim", Soy_Isim);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kullanicilar.Add(new insanlar
                    {
                        Isim = reader["Isim"].ToString(),
                        Sifre = reader["Sifre"].ToString(),
                        Soy_Isim = reader["Soy_Isim"].ToString(),
                        Tc_No = reader["Tc_No"].ToString(),
                        telefon_numarasi = reader["telefon_numarasi"].ToString(),
                        yetki = reader["yetki"].ToString()
                    });
                }
                conn.Close();
            } 
        }
        public void ture_gore()
        {
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string bul = "select * from kullanicilar yetki=@yetki";
                MySqlCommand command = new MySqlCommand(bul, conn);
                command.Parameters.AddWithValue("@yetki", yetki);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kullanicilar.Add(new insanlar
                    {
                        Isim = reader["Isim"].ToString(),
                        Sifre = reader["Sifre"].ToString(),
                        Soy_Isim = reader["Soy_Isim"].ToString(),
                        Tc_No = reader["Tc_No"].ToString(),
                        telefon_numarasi = reader["telefon_numarasi"].ToString(),
                        yetki = reader["yetki"].ToString()
                    });
                }
                conn.Close();
            }
        }
    }
    class emanetler
    {
        public string Tc_Kimlik { get; set; }
        public string Kitap_Ismi { get; set; } 
        public string Alim_Tarihi { get; set; }
        public string Isim { get; set; }
        public string SoyIsim { get; set; }
    }
    class alinmasi_gerekenler : emanetler
    {
        public List<emanetler> emanetler1 = new List<emanetler>();
        public void goruntule()
        {
            using (MySqlConnection conn = new MySqlConnection(Giris_Yap.baglanti))
            {
                conn.Open();
                string bul_ = "select * from kitap_alim";
                MySqlCommand command = new MySqlCommand(bul_, conn);
                MySqlDataReader a = command.ExecuteReader();
                while (a.Read())
                {
                    TimeSpan gun = Convert.ToDateTime(a["Alim_Tarihi"]) - DateTime.Now;
                    if (-gun.Days >= 15)
                    {
                        emanetler1.Add(new emanetler
                        {
                            Alim_Tarihi = a["Alim_Tarihi"].ToString(),
                            Isim = a["Isim"].ToString(),
                            Kitap_Ismi = a["Kitap_Ismi"].ToString(),
                            SoyIsim = a["SoyIsim"].ToString(),
                            Tc_Kimlik = a["Tc_Kimlik"].ToString()
                        });
                    }
                }
                conn.Close();
            }
        }
        public void ne_sectim()
        {
            MessageBoxResult result = MessageBox.Show("Oturumu Kapatmak İstiyormusunuz", "Çıkış", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (MessageBoxResult.Yes == result)
            {
                using(MySqlConnection conn =new MySqlConnection(Giris_Yap.baglanti))
                {
                    conn.Open();
                    string sil = "delete from beni_hatirla";
                    MySqlCommand command = new MySqlCommand(sil, conn);
                    command.ExecuteNonQuery();
                }
            }
            Application.Current.Shutdown();

        }
    }
}
