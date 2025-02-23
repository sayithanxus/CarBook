# 🚀 Asp.Net Core API 8.0 Onion Architecture ile CarBook Projesi
📚 Bu proje, RESTful API, CQRS, Mediator Design Patterns ve Onion Architecture gibi kavramları derinlemesine öğrenmemi sağladı.

## 🎯 Projenin Temel Amacı
Bu proje, bir araç kiralama platformu olarak tasarlandı. Kullanıcılar, belirli bir lokasyona göre araçları filtreleyebilir ve seçtikleri araçlar için rezervasyon yapabilirler. Ayrıca, platformda yer alan blogları okuyabilir, etiketlere, yazarlara veya kategorilere göre blogları listeleyebilirler. Kullanıcılar, okudukları bloglara ve kiraladıkları araçlara yorum yapabilir, iletişim formu aracılığıyla sistem yöneticisine mesaj gönderebilirler. Proje, rol bazlı yönetim sistemi ile güçlü bir yönetim paneli sunmaktadır.

## 🔧 Kullanılan Teknolojiler ve Yaklaşımlar
* 🌐 Onion Architecture mimarisi temel alınarak proje yapısı oluşturuldu.
* 🛠️ CQRS ve Mediator Design Patterns kullanılarak proje modüler hale getirildi.
* 🗄️ DbCodeFirst yaklaşımıyla MSSQL veritabanı tasarlandı ve yönetildi.
* 🔗 Entity Framework Core 8.0 ile veritabanı etkileşimi ve ORM işlemleri gerçekleştirildi.
* 🔐 JWT Token kullanılarak güvenli kimlik doğrulama sağlandı ve POSTMAN ile testler yapıldı.
* ⚡ SignalR entegrasyonuyla anlık veri güncellemeleri sağlandı.
* 👥 Rol bazlı yetkilendirme sistemiyle kullanıcı erişimleri yönetildi.
* 🔄 RESTful API yapısıyla tüm CRUD işlemleri gerçekleştirildi.
* 🖥️ Admin Paneli, Area yapısı kullanılarak ana sistemden ayrıldı ve yönetimi kolaylaştırıldı.
* 🧩 SOLID prensipleri ve düzenli klasör yapısıyla proje geliştirildi.
* 📊 DTO katmanı kullanılarak veri transferi optimize edildi.
* 🎨 HTML, CSS, ve Bootstrap ile kullanıcı arayüzleri tasarlandı.
* ✅ Fluent Validation ile veri girişleri kontrollü hale getirildi.
* 🗂 Area sistemi sayesinde paneller birbirinden bağımsız hale getirildi.
* 🧱 İç içe layout ve ViewComponent yapıları sıkça kullanıldı.
* 📝 Ado.Net ve Linq Sorguları ile veri erişimi sağlandı.

# Veritabanı
![Veritabanı](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/DatabaseDiagram.png?raw=true)
### Giriş
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/Login.png?raw=true)
### Yeni Üyelik
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/Register.png?raw=true)

### Yönetim Paneli
#### Dashboard
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/dashboard.png?raw=true)
#### İstatistikler
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/statistics.png?raw=true)
#### Araçlar
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/cars.png?raw=true)
#### Bloglar
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/blogs.png?raw=true)
#### Blogların Kategorileri
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/BlogsCategory.png?raw=true)
#### Lokasyonlar
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/location.png?raw=true)

#### Ana Ekran
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/1.png?raw=true)
###### 1
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/2.png?raw=true)
###### 2
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/3.png?raw=true)
#### Bloglar
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/blog.png?raw=true)
##### Blog Detayları
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/blogdetail1.png?raw=true)
##### Blog Detayları 2
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/blogdetail2.png?raw=true)
#### Araçlar
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/car_list.png?raw=true)
##### Araç Detay 
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/car_detail.png?raw=true)
##### Araç Fiyatları
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/car_price.png?raw=true)
##### Araç Kiralama
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/reservation.png?raw=true)
#### İletişim Sayfası
![](https://github.com/sayithanxus/CarBook/blob/master/Frontends/CarBook.WebUI/wwwroot/ProjectImages/contacts.png?raw=true)
