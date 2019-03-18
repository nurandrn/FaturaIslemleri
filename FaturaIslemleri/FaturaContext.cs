namespace FaturaIslemleri
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class FaturaContext : DbContext
    {
        // Your context has been configured to use a 'FaturaContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FaturaIslemleri.FaturaContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FaturaContext' 
        // connection string in the application configuration file.
        public FaturaContext()
            : base("name=FaturaContext")
        {
        }
        public virtual DbSet<Ilce> Ilceler { get; set; }
        public virtual DbSet<Il> Iller { get; set; }
        public virtual DbSet<Birim> Birimler { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<FaturaMaster> FaturaMasters { get; set; }
        public virtual DbSet<FaturaDetay> FaturaDetays { get; set; }

    }
    [Table("Ilce")]
    public class Ilce
    {
        public Ilce()
        {
            this.musteri = new HashSet<Musteri>();//hýzlý ve sýralý listelemeye saðlar.
        }
        [Key]
        public int IlceId { get; set; }
        public string Aciklama { get; set; }
        public int IlID { get; set; }
        //il tablosuyla baglantýyý saðlýyor
        public virtual Il il { get; set; }
        public virtual ICollection<Musteri> musteri { get; set; }

    }

    [Table("Il")]
    public class Il
    {

        [Key]
        public int IlID { get; set; }
        public string Aciklama { get; set; }

        //ilce tablosuyla bire çok iliþki saglýyor.
        public virtual ICollection<Ilce> ilce { get; set; }
    }


    [Table("Birim")]
    public class Birim
    {
        public Birim()
        {
            this.urun = new HashSet<Urun>();
        }

        [Key]
        public int BirimID { get; set; }
        public string BirimAdi { get; set; }

        // tablosuyla bire çok iliþki saglýyor.
        public virtual ICollection<Urun> urun { get; set; }
    }


    [Table("Urun")]
    public class Urun
    {
        public Urun()
        {
            this.FaturaDetay = new HashSet<FaturaDetay>();//hýzlý ve sýralý olarak tutulmasý saðlar.
        }
        [Key]
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int UrunKodu { get; set; }
        public int BirimID { get; set; }
        public decimal BirimFiyat { get; set; }
        public virtual Birim birim { get; set; }

        //FaturaDetay tablosuyla baglantýyý saðlýyor
        public virtual ICollection<FaturaDetay> FaturaDetay { get; set; }

    }



    [Table("Musteri")]
    public class Musteri
    {
        public Musteri()
        {
            this.faturamaster = new HashSet<FaturaMaster>();
        }
        [Key]
        public int MusteriID { get; set; }
        public string MusteriUnvani { get; set; }
        public int IlceID { get; set; }
        public string MusteriAdresi { get; set; }

        //il tablosuyla baglantýyý saðlýyor
        public virtual Ilce ilce { get; set; }
        public virtual ICollection<FaturaMaster> faturamaster { get; set; }

    }

    [Table("FaturaMaster")]
    public class FaturaMaster
    {
        public FaturaMaster()
        {
            this.faturadetay = new HashSet<FaturaDetay>();
            this.FaturaTarihi = DateTime.Now;
        }
        [Key]
        public int FaturaID { get; set; }
        public int MusteriID { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public int IrsaliyeNo { get; set; }
        public DateTime OdemeTarihi { get; set; }

        //Musteri tablosuyla baglantýyý saðlýyor/one to money baðlantýyý saðlar
        public virtual Musteri musteri { get; set; }
        public virtual ICollection<FaturaDetay> faturadetay { get; set; }

    }

    [Table("FaturaDetay")]
    public class FaturaDetay
    {
        public FaturaDetay()
        {
            this.Aciklama = "Vadesinden sonra ödenen faturalara %5 kanunu ceza faizi uygulanýr.";
        }
        [Key]
        [Column(Order = 0)]  // Hem ÜrünID hem de FaturaID beraber ortak primarykey oluyor.
        public int FaturaID { get; set; }
        [Key]
        [Column(Order = 1)]//her durumda 1.kolonda gelmesi için yazmamýz lazým
        public int UrunID { get; set; }
        public decimal Miktar { get; set; }
        public decimal ToplamFiyat { get; set; }
        public decimal KDV { get; set; }
        public decimal KDVliFiyat { get; set; }
        public decimal FaturaToplam { get; set; }
        public string Aciklama { get; set; }

        // tablosuyla baglantýyý saðlýyor
        public virtual FaturaMaster faturamaster { get; set; }
        public virtual Urun urun { get; set; }


    }

}