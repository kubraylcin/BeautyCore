# 🌟 BeautyCore - Salon Management System API

**BeautyCore**, güzellik salonları ve kuaför zincirleri için geliştirilmiş, modern ve enterprise düzeyde bir randevu ve yönetim sistemidir. Proje; **Clean Architecture**, **CQRS**, **MediatR**, **Vertical Slice Architecture** ve **Entity Framework Core** kullanılarak geliştirilmiştir.

---

## 🏗️ Mimari ve Tasarım Desenleri

Bu proje, sürdürülebilirlik, test edilebilirlik ve ayrılmış sorumluluklar (Separation of Concerns) prensipleri göz önünde bulundurularak tasarlanmıştır:

* **Clean Architecture:** Bağımlılıkların içe doğru (Domain katmanına) olduğu, katmanlar arası sıkı sıkıya bağlılığın engellendiği katmanlı yapı.
* **CQRS (Command Query Responsibility Segregation):** Yazma (Command) ve okuma (Query) işlemlerinin birbirinden ayrılmasıyla yüksek performans ve temiz kod yapısı.
* **MediatR Pattern:** Katmanlar arası gevşek bağlı (loosely coupled) iletişim.
* **Vertical Slice Architecture:** Özelliklerin (Features) kendi içinde modüler olarak organize edilmesi.
* **FluentValidation:** İsteklerin (Commands/Queries) iş katmanına girmeden önce otomatik olarak doğrulanması ve çakışma kurallarının işletilmesi.

---

## 🛠️ Kullanılan Teknolojiler

* **.NET Core / C#** (.NET 8 / 9)
* **Entity Framework Core** (ORM & Fluent API Configurations)
* **MS SQL Server** (Relational Database)
* **MediatR** (In-process messaging)
* **FluentValidation** (Data & Business Rule validation)
* **ASP.NET Core Web API & Swagger / OpenAPI**

---

## 📦 Proje Modülleri & Özellikleri

1. **Appointments (Randevu Modülü):**
   * Randevu oluşturma ve durum yönetimi (Pending, Confirmed, Cancelled vb.).
   * Personel mesai saatleri, mola aralıkları ve çakışma (Overlap) kontrol algoritmaları.
   * Tarih güncelleme (Reschedule) işlemleri.

2. **Staff & Working Hours (Personel ve Çalışma Saatleri):**
   * Personel yönetimi ve şubelere atanması.
   * Gün bazlı çalışma saatleri ve mola tanımlamaları.
   * Belirli bir tarih ve hizmet için personel uygunluk (Availability) sorgulama.

3. **Services (Hizmet Yönetimi):**
   * Salon tarafından sunulan hizmetlerin fiyat ve süre (Duration) bilgileriyle yönetimi.
   * Personele özel hizmet atama yetenekleri.

4. **Payments (Ödeme Modülü):**
   * Randevulara bağlı güvenli ödeme takibi.

5. **Notifications (Bildirim Modülü):**
   * Müşterilere gönderilen SMS, Email ve In-App bildirim yönetimi ve sorgulama uç noktaları.

6. **Branches (Şube Yönetimi):**
   * Çoklu şube altyapısı ve şube bazlı listeleme operasyonları.

---
