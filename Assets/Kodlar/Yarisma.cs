using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//uı elementini kullanma kütüphanesi
using UnityEngine.SceneManagement;//sahne değişimi kütüphanesi


public class Yarisma : MonoBehaviour {

    public GameObject Canvas;//soru sormak için kullandığımız canvas
    public GameObject DogruCanvas;//dogru cevap bilindiğinde çıkan canvas.
    public GameObject SureBitti;//sure bittiğinde çıkan canvas.
    public GameObject YanlisCevap;//yanlış cevap verildiğinde cıkan canvas.
    public GameObject OyunBitti;//oyun bittiğinde cıkan canvas.
    public GameObject zamanYaziCanvas;//zamanı kaldırdığında bu canvas cıksın.
    public GameObject ZamaniKaldirButton;//zamanı kaldır buttonu için canvas olusturduk.
    public GameObject zamanjokeri;//zaman jokeri için canvas olusturduk.
    public GameObject cıkıscanvas;
    public GameObject buton1;
    public GameObject buton2;
    public GameObject buton3;
    public GameObject buton4;
    public GameObject yariyariyabuton;

    public Text soruismi, cevapa, cevapb, cevapc, cevapd,skorYazi,zamanYazi,kazanilanYazi,sonkazanilanYazi,sonkazanilanYazi2;//oyunda ekrana çıkan yazıları text objesi olarak belirledik.
    public bool bilindi = false;//bilindi bool değişkeni bizim için sorunun dogru veya yanlış cevaplandığını gösteriyor.
    Sorular sr;
    public List<bool> sorulanlar;//soruların bir daha sorulmaması için liste oluşturduk 
    public int cevap,skor,kazanilan,sonkazanilan,sonkazanilan2;//cevaplar,sorusayısı,kazanılan para için integer değer oluşturduk.
    public float zaman;//soru zamanı için float değer oluşturduk.
    public int yarı = 1;//yarıyarıya jokeri için değişken.
    public float dogruzaman;// dogru canvası için zaman floatı oluşturduk.
    public int bilsayac = 0;//belli degil
    void Start () {
        sr = GetComponent<Sorular>();// soruları bu listeye ekledik
        for (int i = 0; i < sr.sorular.Count; i++)//tüm soru degeri kadar dögüyü döndürüyoruz.
        {
            sorulanlar.Add(false);//tüm sorularu false diye işaretliyoruz.
        }
        SoruEkle();//soru ekle void ine yönlendiriyoruz.
        
	}
	
	void Update () {
        if (zaman>0)//eger zaman sıfırdan büyükse...
        {
            zaman -= Time.deltaTime;//zamanı 1'er saniye azalt.
            zamanYazi.text = zaman.ToString("00");//zamanı ekrana yazdır.
        }
        else//sure bittiyse..
        {

            SureBitti.SetActive(true);//sure bitti canvasını aç.
            DogruCanvas.SetActive(false);
            YanlisCevap.SetActive(false);
            Canvas.SetActive(false);//soru canvasını kapat.

            Debug.Log("Oyun Bitti");//ekrana oyun bitti yazdır.
            
        }
        if(bilindi==true)//eger soru dogru bilindiyse..
        {
            zaman = 4;
            Canvas.SetActive(false);//soru canvasını kapat.
            DogruCanvas.SetActive(true);//dogru cevap canvasını aç.
            if (dogruzaman < 3f)//dogru cevap canvasını 3 saniye goster.
            {
                dogruzaman += Time.deltaTime;//3 saniye boyunca çalıştır..

            }
            if (dogruzaman > 3f && dogruzaman < 3.2f)//eger 3 saniye dolduysa..
            {
                Canvas.SetActive(true);//soru canvasını aç.
                DogruCanvas.SetActive(false);//dogru cevap canvasını kapat.
                SoruEkle();//yeni bir soru ekle.
                dogruzaman = 0;//dogru zamanını tekrar sıfırla.
                bilindi = false;//dogru cevap ikaz kodunu kapat.
            }
        }
        
       
	}
    public int zamanj1 = 0;//zaman jokeri için sınır belirledik.
    public void zamanikaldir()//zaman jokeri kullandığımızda kaldırılacak şeyleri kaldırmak için void olusturduk.
    {
        zamanYaziCanvas.SetActive(false);//zamanı gösteren canvası kaldır.
        ZamaniKaldirButton.SetActive(false);//zaman butonunu kaldır.
        zamanjokeri.SetActive(true);//zaman jokerini göster.
        zaman = 5000;// zamanı 5000 olarak belirle.
        zamanj1++;//zaman jokeri sınırını tekrar belile.
    }
    public void zamaniver()
    {
        zamanYaziCanvas.SetActive(true);//zamanı göster
        
        zamanjokeri.SetActive(false);//zaman jokerini gösterme.
        if (zamanj1>0)//zaman jokeri bir defa kullanıldıysa bu kodu çalıştır.
        {
            ZamaniKaldirButton.SetActive(false);//zaman butonunu gösterme.
        }
    }

    public void yariyariya()
    {
        yariyariyabuton.SetActive(false);
        if (cevap==1)
        {
            buton2.SetActive(false);
            buton4.SetActive(false);
        }
        if (cevap == 2)
        {
            buton1.SetActive(false);
            buton3.SetActive(false);
        }
        if (cevap == 3)
        {
            buton1.SetActive(false);
            buton2.SetActive(false);
        }
        if (cevap == 4)
        {
            buton2.SetActive(false);
            buton3.SetActive(false);
        }



    }
    public void yariyariyagerigel()
    {
        buton1.SetActive(true);
        buton2.SetActive(true);
        buton3.SetActive(true);
        buton4.SetActive(true);
    }
    public void SoruEkle()//soru eklemek için yeni bir void oluşturduk.
    {
        zamaniver();
        yariyariyagerigel();

        for (int i = 0; i < sorulanlar.Count; i++)// Soru sayısının sınırına kadar gitmesi için for döngüsüne aldık. 
        {
            if (sorulanlar[i]==false)//eğer seçilen soru sorulmamışsa alttaki kodları çalıştır.
            {
                int sorusayi = Random.Range(0, sorulanlar.Count);//burada soruların peş peşe değil rastegle gelmesi için random oluşturduk.
                if (sorulanlar[sorusayi] == false)//eğer soru sorulmadıysa alt kodu çalıştır 
                {
                    sorulanlar[sorusayi] = true;//sorulan soruları true olarak işaretle
                    skor++;// burada skor olarak işaretlediğimiz yer soru saysını belirtiyor soru sorulduğunda skor 1 artıyor 
                    
                    kazanilanYazi.text = kazanilan.ToString("0000"); // her soruda kazanılan parayı ekrana yazdırıyor.
                    kazanilan = kazanilan + 1000;//her dogru soruda 1000 artıyor.
                    
                    sonkazanilanYazi.text = sonkazanilan.ToString("0000");//bu en son kazanılan parayı göstermek için son tarafta gösterilen yer.
                    sonkazanilan = kazanilan;//son kazanılan kazanılan paraya eşitlendi.

                    sonkazanilanYazi2.text = sonkazanilan2.ToString("0000");//bu en son kazanılan parayı göstermek için son tarafta gösterilen yer.
                    sonkazanilan2 = kazanilan;//son kazanılan kazanılan paraya eşitlendi.

                    skorYazi.text = "" + skor;//soru sayısını ekrana yazdırdık. 
                    zaman = 21;//zaman 21 olarak belirlendi
                    dogruzaman = 0;//dogru bildiniz ekranı için zaman değişkeni ayarladık.
                    soruismi.text = sr.sorular[sorusayi].soruismi;// burada gameobjectler ile değişkenler birleştiriyoruz.
                    cevapa.text = sr.sorular[sorusayi].cevapa;//cevap1 i eşleştirdik.
                    cevapb.text = sr.sorular[sorusayi].cevapb;//cevap2 yi eşleştirdik.
                    cevapc.text = sr.sorular[sorusayi].cevapc;//cevap3 ü eşleştirdik.
                    cevapd.text = sr.sorular[sorusayi].cevapd;//cevap4 ü eşleştirdik.
                    cevap = sr.sorular[sorusayi].cevap;//dogru cevap değişkenini eşleştirdik.
                }
                else
                {
                    SoruEkle();//eğer soruların hepsi sorulmadıysa tekrar basa don.
                }

                break;//sorulduysa kodu kapat.
            }
            if (i==sorulanlar.Count-1)//eğer soruların hepsi sorulduysa ekrana oyun kazandın yazdır.
            {
                Debug.Log("Oyunu Kazandın");
                Canvas.SetActive(false);
                SureBitti.SetActive(false);
                OyunBitti.SetActive(true);

            }
        }
        
    }


    

    public void CevapVer(int deger)//burada kullanıcıdan aldığımız değer için bir void actık.
    {
       
        if (deger == cevap)//eğer cevap dogruysa bilindi adlı bool değişkenini 1 yani true yap.
        {
            bilindi = true;         
            
        }
        else//yanlışsa 
        {
            Canvas.SetActive(false);//soru canvasını kapat.
            YanlisCevap.SetActive(true);//yanlış cevap canvasını aç.
            Debug.Log("Yanlış Cevap");//ekrana yanlış cevap yazdır.
        }
    }

   

}
