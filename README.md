# TelephoneDirectory

Proje Dokümanı
Proje dosya yapısı üç klasörden oluşuyor 
1.	Solucation Items adlı klasör İçinde bir tane txt dosyası yer alıyor txt dosyasının içinde servislerin adresleri girilir ,
2.	Src adlı  klasör projenin asıl bulunduğu yerdir .
3.	Test adlı klasör test işlemlerinin bulunduğu klasördür ,

Src klasörü içinde iki klasöre ayrılır bir api gateway birde services olmak üzere;
Gateway içinde bir gateway adlı proje bulunmaktadır client den gelecek istekler bu gateway e gelir ,
İstek yapılan adresi : http://localhost:5000  adresinde ayağa kaldırılıyor 
Bunun için postman vb gibi yerlerden test edilmesinde mümkün,
Gateway da kullanılan teknolojiler => ocelot microservice mimarisi ile geliştirebilmek için port yönlendirmede kullandım startup.cs dosyasında ayarları yaptım configuration.development.json adlı dosyada port configurosyan ayarlarını gerçekleştirdim.

Services adlı klasörde iki microservis bulunmaktadır 
Directory adlı servis => http://Localhost:5001 den ayağa kaldırılıyor, gatewayden gelen yönlendirme adresi ise http://localhost:5000/services/directory/
http://localhost:5001/swagger/index.html adresinden metotları test etmek ve geri dönüş bilgi formatını ve gerekli olan parametrelerini görüntülemek için swagger teknolojisi ekledim 
metotları; 
 http://localhost:5000/services/directory/Person/Add    Rehbere kişi ekleme
 http://localhost:5000/services/directory/Person/Delete/b23717fc-158b-42cf-807f-43c68ac33408  Rehberden Kişi kaldırma
 http://localhost:5000/services/directory/Person/GetAll Rehberdeki Kişileri Listeleme 
 http://localhost:5000/services/directory/Person/GetAllDetail Rehberdeki kişilerin detaylı Listeleme
 http://localhost:5000/services/directory/GetDetail/40065c7a-14a7-439a-8d41-1a6883f04b0b Rehberdeki bir kişiyi detaylı getirme 
http://localhost:5000/services/directory/ContactInformation/GetAll  Rehberdeki Kişilerin İletişim Bilgisini listeleme  
http://localhost:5000/services/directory/ContactInformation/Add  Rehberdeki bir kişiye İletişim Bilgisini ekleme
http://localhost:5000/services/directory/ContactInformation/Delete/40065c7a-14a7-439a-8d41-1a6883f04 Rehberdeki bir Kişinin iletişim bilgisini silme

Directory service katmanlı mimari yapısında ve entityframeworkcore  çatısında geliştirildi linq sorgular kullanıldı  veri tabanı olarak postsql kullanıldı
migrations işlemi ile veri tabanı oluşturulmaktadır, DataAcces katmanında yer alan DirectoryRepositoryDbContext adındaki sınıfın içinde ilgi yere kendi veri tabanı yolunuzu yazınız.

Report servis http://localhost:5002 den ayağa kaldırılıyor, gatewayden gelen yönlendirme adresi ise http://localhost:5000/services/report/ adresi ile iletişime geçiliyor,

http://localhost:5002/swagger/index.html adresinden metotları test etmek ve geri dönüş bilgi formatını ve gerekli olan parametrelerini görüntülemek için swagger teknolojisi ekledim 


http://localhost:5000/services/report/Report/GetAllReport  adresinden rapor isteği yapılır 

Rapor istekterinin çalışma mantığı message gueu mantığı ile çalışıyor gelen istekleri kuyruğa yazılır  report servisin içinde yer alan background servis kuyruğu async olarak dinler ver excel oluşturur 

Kullanılan teknolojiler ; rabbbitmq  mesajlaşma için ,  

Rabbitmq  docker üzerinden kaldırdım, kodu;
docker run -d --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.10-management

Excel yolu = src\Services\Report\Report.WebApi\ExcelFile.

Test işlemleri test klasörünün içinde yer alan test projeleri yer almaktadır,
Ve belirttiğim gibi swagger eklentisi ekledim test amaçlı ve daha net görünmesi açısından 

Not => Rapor kısmıında bazı eksiklikler mevcut ama rahat giderebileceğim durumlar zadece yoğun çalışma ve  bazı olaylar (ev taşıma ve uygun ortam sağlayamama  ve internet sorunları) yaşadığımdan verilen süreyi verimli kullanamamış olmam.
Gerektiği takdirde istenilen güncellemeleri hızlı bir şekilde yaparım.

Saygılarımla 
İyi günler dilerim.
