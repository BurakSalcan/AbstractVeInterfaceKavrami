using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AbstractVeInterfaceKavrami
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Insan sınıfının nesnesini oluşturalım. 
            Insan ins = new Insan("Murtaza", "Şuayipoğlu");
            ins.Yazdir();

            Personel prs = new Personel("Selim", "Koçovalı", "İnsan kaynakları");
            prs.Yazdir();

            //Abstract classların nesnesi oluşturulamaz. 
            //Bu sınıfların amacı kalıtımda base class olarak kullanılmaktır.
            //Arac arc = new Arac();

            BinekArac ba = new BinekArac("Honda", "Civic", "34 ABC 34");
            ba.Yazdir();

            //Abstract Classlar
            //Constructor içerebilirler.
            //Static Üyeler içerebilir.
            //Farklı tiplerde Access Modifier (erişim belirleyicisi)(public, private) içerebilir.
            //Sınıfın ait olduğu kimliği belirlemek amacıyla kullanılır.
            //Bir sınıf sadece bir adet abstract class Implement edebilir. Yani çoklu kalıtım desteklemiyor.
            //Abstract class'tan türetilen sınıf elemanlarının kısmi kullanımı mümkündür. 

            //Interfaceler
            //Constructor içeremez.
            //Static üyeler içeremez.
            //Farklı tiplerde access modifier içeremez.
            //Sınıfın yapabileceği kabiliyetleri belirtmek için kullanılır.
            //Bir sınıf birden fazla Interface Implement edebilir. 
            //Interface sadece metot imzalarını barındırabilir. İçerikleri bulunamaz. 
            //Türetilen sınıflar tüm Interface elemanlarını içermek zorundadır. 
        }

        public class Insan
        {
            public string Isim { get; set; }

            public string Soyisim { get; set; }

            public Insan() { }

            public Insan(string isim, string soyisim)
            {
                Isim = isim;
                Soyisim = soyisim;
            }

            public virtual void Yazdir()
            {
                Console.WriteLine($"Isim: {Isim}\nSoyisim: {Soyisim}");
            }

        }

        public class Personel : Insan
        {
            public string Departman { get; set; }

            public Personel() { }

            public Personel(string isim, string soyisim, string departman) : base(isim, soyisim)//base class'ın constuctor'una parametre gönderdik.
            {
                Departman = departman;
            }

            public override void Yazdir()
            {
                base.Yazdir();
                Console.WriteLine("Departman: " + Departman);
            }
        }

        public abstract class Arac
        {
            public string Marka { get; set; }

            public string Model { get; set; }

            public Arac() { }

            public Arac(string marka, string model)
            {
                Marka = marka;
                Model = model;
            }

            public virtual void Yazdir()
            {
                Console.WriteLine($"Marka: {Marka}\nModel: {Model}");
            }

        }

        public class BinekArac: Arac
        {
            public string Plaka { get; set; }

            public BinekArac() { }

            public BinekArac(string marka, string model, string plaka):base(marka, model) 
            {
                Plaka = plaka;
            }

            public override void Yazdir()
            {
                base.Yazdir();
                Console.WriteLine("Plaka: " + Plaka);
            }

        }

        public interface IEsya
        {
            //Interface field kabul etmiyor. Prop kabul etmiyor.
            void Yazdir(string marka, string model);
        
        }

        public class BeyazEsya : IEsya
        {
            public void Yazdir(string marka, string model)
            {
                Console.WriteLine($"Marka: {marka}\nModel: {model}");
            }
        }

        public interface IModel
        {
            
            bool Ekle(object model);
            List<object> Listele();
            object getir(int id);
            bool Guncelle(object model);
            void sil(int id);
        }

        public interface IBaglanti
        {
            SqlConnection con { set; }
            SqlCommand cmd { set; }
        }

        public class KategoriModel : IModel, IBaglanti 
        {
                public SqlConnection con { set => new SqlConnection("Baglantı"); }
                public SqlCommand cmd { set => new SqlCommand(); }

                public bool Ekle(object model)
            {
                throw new NotImplementedException();
            }

            public object getir(int id)
            {
                throw new NotImplementedException();
            }

            public bool Guncelle(object model)
            {
                throw new NotImplementedException();
            }

            public List<object> Listele()
            {
                throw new NotImplementedException();
            }

            public void sil(int id)
            {
                throw new NotImplementedException();
            }
        }
    }
}
