CREATE DATABASE HASAKI
USE HASAKI

CREATE TABLE Roles (--PHÂN QUYỀN CHỨC VỤ CHO EMPLOYEES
    RoleID int PRIMARY KEY,
    RoleName nvarchar(50)
)
INSERT INTO Roles VALUES(1,'admin'),(2,'Cashier'),(3,'Warehouse'),(4,'Delivery');

CREATE TABLE Employees (--NHÂN VIÊN
    EmployeeID int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(50),
    CardID nvarchar(50),
    Phone nvarchar(20),
    Address nvarchar(100),
    Password nvarchar(30),
	Gender nvarchar(10),
	Birthday date,
    HireDate date,
    Salary int,
	RoleID int FOREIGN KEY REFERENCES Roles(RoleID)
)
INSERT INTO Employees (Name, CardID, Phone, Address, Password, Gender, Birthday, HireDate, Salary, RoleID)
VALUES ('Khánh', '09080706543', '0909090909', 'q7,tpHCM', 'Khanh123', 'male', '2002-01-01', '2021-01-01', 30000000, 1)--admin


CREATE TABLE Customers (--KHÁCH HÀNG
    CustomerID int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(50),
	Email nvarchar(50),
	Phone nvarchar(20),
    Address nvarchar(100),
	Password nvarchar(30),
	Gender nvarchar(10),
	Birthday date
)
INSERT INTO Customers (Name, Email, Phone, Address, Password, Gender, Birthday)
VALUES ('JamesDuong', 'taonetuibay@gmail.com', '0909090909', 'q7,tpHCM', '123Duong', 'male', '2003-01-01')

CREATE TABLE Suppliers (--NHÀ CUNG CẤP
    SupplierID int IDENTITY(1,1) PRIMARY KEY,
    SupplierName nvarchar(50),
    Address nvarchar(100),
    Phone nvarchar(20),
    Email nvarchar(50)
)
INSERT INTO Suppliers (SupplierName, Address, Phone, Email)
VALUES ('LA ROCHE-POSAY', 'q1,tpHCM', '0283123456', 'abc@gmail.com'),
('ANESSA', 'q8,tpHCM', '0283000456', 'def@gmail.com'),
('L"OREAL', 'q7,tpHCM', '0200023456', 'hehe@gmail.com'),
('Klairs', 'q3,tpHCM', '0283120006', 'ok@gmail.com');


CREATE TABLE Categories (--DANH MỤC SẢN PHẨM(LOẠI SẢN PHẨM)
    CategoryID int PRIMARY KEY,
    CategoryName nvarchar(50)
)
INSERT INTO Categories VALUES (1,'Sunscreen'),(2,'Cleanser'),(3,'Toner'),(4,'Face Wash'),(5,'Exfoliant'),(6,'Skincare'),(7,'Others');

CREATE TABLE Products (--SẢN PHẨM
    ProductID int IDENTITY(1,1) PRIMARY KEY,
    ProductName nvarchar(500),
	Image nvarchar(200),
    CategoryID int FOREIGN KEY REFERENCES Categories(CategoryID),
	SupplierID int FOREIGN KEY REFERENCES Suppliers(SupplierID),
    UnitPrice int,
    Description nvarchar(1000)
)
INSERT INTO Products (ProductName, Image, CategoryID, SupplierID, UnitPrice, Description)
VALUES ('Kem Chống Nắng La Roche-Posay Kiểm Soát Dầu SPF50+ 50ml Anthelios Anti-Shine Gel-Cream Dry Touch Finish Mattifying Effect SPF50+',
'/images/1.jpg', 1, 2, 399000,
'sản phẩm kem chống nắng dành cho làn da dầu mụn, sở hữu công nghệ cải tiến XL-Protect cùng kết cấu kem gel dịu nhẹ & không nhờn rít,
giúp ngăn ngừa tia UVA/UVB + tia hồng ngoại + tác hại từ ô nhiễm, bảo vệ toàn diện cho làn da luôn khỏe mạnh.'),
('Sữa Chống Nắng Anessa Dưỡng Da Kiềm Dầu 60ml Perfect UV Sunscreen Skincare Milk N SPF50+ PA++++',
'/images/2.jpg',1, 2, 459000, ' sản phẩm chống nắng phiên bản mới nhất năm 2022 đến từ thương hiệu chống nắng dưỡng da ANESSA hàng đầu Nhật Bản suốt 21 năm liên tiếp,
giúp chống lại tác hại của tia UV & bụi mịn tối ưu dưới mọi điều kiện sinh hoạt, kể cả thời tiết khắc nghiệt nhất. Sản phẩm đặc biệt phù hợp với làn da thiên dầu.'),
('Kem Chống Nắng MartiDerm Phổ Rộng Bảo Vệ Toàn Diện 40ml The Originals Proteos Screen SPF50+ Fluid Cream',
'/images/3.jpg', 1, 2, 55000, 'kem chống nắng dạng lỏng dễ hấp thụ với chỉ số SPF 50+ giúp ngăn ngừa và sửa chữa các dấu hiệu lão hoá da sớm.
Sản phẩm cung cấp màng lọc chống nắng phổ rộng chống lại các tia UVA, UVB, IR (hồng ngoại), HEV (ánh sáng xanh)'),
('Nước Tẩy Trang L"Oreal Tươi Mát Cho Da Dầu, Hỗn Hợp 400ml Micellar Water 3-in-1 Refreshing Even For Sensitive Skin',
'/images/4.jpg', 2, 2, 159000, 'sản phẩm tẩy trang dạng nước đến từ thương hiệu L"Oreal Paris, được ứng dụng công nghệ Micellar dịu nhẹ giúp làm sạch da,
lấy đi bụi bẩn, dầu thừa và cặn trang điểm chỉ trong một bước, mang lại làn da thông thoáng, mềm mượt mà không hề khô căng.'),
('Nước Tẩy Trang Bioderma Dành Cho Da Nhạy Cảm 500ml Sensibio H2O',
'/images/5.jpg', 2, 2, 393000, 'sản phẩm nước tẩy trang công nghệ Micellar đầu tiên trên thế giới, do thương hiệu dược mỹ phẩm Bioderma nổi tiếng của Pháp phát minh.
Dung dịch giúp làm sạch sâu da và loại bỏ lớp trang điểm nhanh chóng mà không cần rửa lại bằng nước. '),
('Nước Tẩy Trang Simple Làm Sạch Trang Điểm Vượt Trội 200ml Kind To Skin Micellar Cleansing Water',
'/images/6.jpg', 2, 2, 75000, 'sản phẩm tẩy trang dành cho da mặt đến từ thương hiệu Simple xuất xứ Anh Quốc.
Công thức cải tiến với công nghệ làm sạch Micellar chứa hàng triệu bong bóng Micelles thông minh giúp loại bỏ lớp trang điểm và bụi bẩn hiệu quả,
làm thông thoáng lỗ chân lông, mang lại cảm giác tươi mát cho da sau khi sử dụng.'),
('Nước Hoa Hồng Klairs Không Mùi Cho Da Nhạy Cảm 180ml Supple Preparation Unscented Toner',
'/images/7.jpg', 3, 2, 259000, 'Gentle micellar gel cleanser that removes excess dirt and makeup from the skin without irritation.'),
('Nước Hoa Hồng Obagi BHA 2% Giảm Nhờn Mụn 148ml Clenziderm MD Pore Therapy Salicylic Acid 2% Acne Treatment',
'/images/8.jpg', 3, 2, 800000, 'sản phẩm Toner chuyên biệt giúp làm sạch sâu lỗ chân lông và giảm nhờn, mụn đến từ thương hiệu dược mỹ phẩm Obagi Medical.
Với hoạt chất chính là 2% Salicylic Acid (BHA), sản phẩm giúp lấy đi lượng tế bào chết làm tắc nghẽn lỗ chân lông,
giúp da hấp thu hiệu quả các bước chăm sóc tiếp theo.'),
('Nước Hoa Hồng Simple Làm Dịu Da & Cấp Ẩm 200ml Kind to Skin Soothing Facial Toner',
'/images/9.jpg', 3, 2, 54000, 'sản phẩm Toner không chứa cồn được thiết kế phù hợp cho làn da nhạy cảm và dễ nổi mụn, giúp làm sạch sâu và cân bằng độ pH,
cung cấp độ ẩm dịu nhẹ cho làn da, mang lại cảm giác tươi mát và sảng khoái sau khi sử dụng.'),
('Gel Rửa Mặt Cosrx Tràm Trà, 0.5% BHA Có Độ pH Thấp 150ml Low pH Good Morning Gel Cleanser',
'/images/10.jpg', 4, 2, 123000, 'dòng sữa rửa mặt đến từ thương hiệu mỹ phẩm Cosrx của Hàn Quốc, với độ pH lý tưởng 4.5 - 5.5 sản phẩm
an toàn và dịu nhẹ trên mọi làn da ngay cả làn da nhạy cảm và da mụn.'),
('HASAKI Micellar Gel Cleanser', '/images/11.jpg', 4, 2, 123000, 'dòng sữa rửa mặt đến từ thương hiệu mỹ phẩm Cosrx của Hàn Quốc,
với độ pH lý tưởng 4.5 - 5.5 sản phẩm an toàn và dịu nhẹ trên mọi làn da ngay cả làn da nhạy cảm và da mụn.'),
('Gel Rửa Mặt La Roche-Posay Dành Cho Da Dầu, Nhạy Cảm 400ml Effaclar Purifying Foaming Gel For Oily Sensitive Skin',
'/images/12.jpg', 4, 2, 476000, 'sản phẩm sữa rửa mặt chuyên biệt dành cho làn da dầu, mụn, nhạy cảm đến từ thương hiệu dược mỹ phẩm La Roche-Posay nổi tiếng của Pháp,
với kết cấu dạng gel tạo bọt nhẹ nhàng giúp loại bỏ bụi bẩn, tạp chất và bã nhờn dư thừa trên da.'),
('Dung Dịch Tẩy Da Chết Paula’s Choice BHA 2% 30ml Skin Perfecting 2% BHA Liquid',
'/images/13.jpg', 5, 2, 250000, 'sản phẩm tẩy tế bào chết hóa học với nồng độ 2% BHA (Salicylic Acid) giúp làm sạch sâu lỗ chân lông,
cải thiện tình trạng mụn ẩn - mụn đầu đen, đồng thời làm mờ nếp nhăn sâu, cải thiện tông màu da, mang lại cho bạn làn da sáng mịn, rạng rỡ và khỏe mạnh.'),
('Kem Dưỡng Obagi Retinol 0.5% Ngăn Ngừa Lão Hoá Da 28g Retinol 0.5 Cream',
'14.jpg', 6, 2, 1149000, 'sản phẩm kem dưỡng da trẻ hoá, ngừa mụn nổi tiếng từ thương hiệu dược mỹ phẩm Obagi Medical.
Công thức với hàm lượng Retinol 0.5% / Retinol 1% hoạt động hiệu quả trên mọi làn da, đặc biệt là da dầu, giúp cải thiện các vấn đề về da như mụn, dầu thừa,
lão hoá; mang đến cho bạn làn da mịn màng và tươi trẻ.'),
('Kem Dưỡng Ẩm Neutrogena Cấp Nước Cho Da Dầu 50g Hydro Boost Hyaluronic Acid Water Gel',
'15.jpg', 6, 2, 256000, 'sản phẩm bảo vệ độ ẩm cho da mạnh hơn 80% cùng với công thức 1% các yếu tố giữ ẩm tự nhiên chứa Hyaluronic Acid, Axit Amin 
và chất điện giải. Kết cấu nhẹ thích hợp sử dụng hàng ngày.'),
('Serum Garnier Tăng Cường Sáng Da Mờ Thâm 30ml Bright Complete 30x Vitamin C Booster Serum',
'16.jpg', 6, 2, 127000, 'với công thức chứa nồng độ vitamin C gấp 30 lần từ vitamin C và chiết xuất quả Yuzu mang lại hiệu quả dưỡng sáng da, mờ thâm vượt trội. 
Ngoài ra, sản phẩm còn chứa các thành phần khác như Niacinamide, Salicylic Acid và Glycerin giúp tăng cường thêm hiệu quả cải thiện đốm sắc tố (thâm, sạm, nám) và dưỡng da ẩm mịn. 
Sản phẩm có kết cấu mỏng nhẹ, dễ dàng thẩm thấu nhanh vào da và hấp thụ tối ưu các dưỡng chất.'),
('Serum L"Oreal Hyaluronic Acid Cấp Ẩm Sáng Da 30ml Revitalift Hyaluronic Acid 1.5% Hyaluron Serum',
'17.jpg', 6, 2, 325000, 'sản phẩm với sự kết hợp không chỉ 1 mà đến 2 loại Hyaluronic Acid ưu việt ở nồng độ 1.5% sẽ là giải pháp chăm sóc da hiệu quả dành cho làn da khô & lão hóa,
giúp cung cấp độ ẩm tối đa cho da căng mịn và tươi sáng tức thì. Với Revitalift HA đậm đặc, làn da sẽ có sự thay đổi rõ rệt, mang đến vẻ ngoài rạng rỡ cho bạn.'),
('Serum Vichy Khoáng Phục Hồi Chuyên Sâu 50ml Mineral 89 Serum',
'18.jpg', 6, 2, 816000, 'sản phẩm được cô đặc từ thành phần khoáng chất quý giá dưới lòng núi lửa triệu năm tại Auvergne - Pháp, giúp củng cố hàng rào bảo vệ da, hỗ trợ tái tạo và phục hồi, 
cho da mịn màng, căng mượt và tràn đầy sức sống.'),
('Lotion La Roche-Posay Cho Da Thường, Nhạy Cảm 200ml Soothing Lotion Sensitive Skin',
'19.jpg', 6, 2, 380000, 'sản phẩm giúp làm dịu làn da nhạy cảm khó chịu, đồng thời bảo vệ da và giúp chống oxy hoá cho da. Soothing Lotion sẽ giúp cân bằng lại độ pH của da sau khi rửa mặt, 
làm dịu cảm giác da khô, căng kéo. Bên cạnh đó, sản phẩm còn chứa thành phần Glycerin để cung cấp độ ẩm, giữ ẩm cho da, mang lại một làn da mềm mượt, mịn màng. .'),
('Serum Vichy Khoáng Phục Hồi Chuyên Sâu 50ml Mineral 89 Serum',
'20.jpg', 6, 2, 920000, 'sản phẩm giúp cải thiện rõ rệt các dấu hiệu thiếu hụt Collagen trên da, hỗ trợ nâng cơ và làm săn chắc da, mang lại vẻ tươi trẻ và rạng rỡ. Sản phẩm dành cho mọi loại da, 
thích hợp sử dụng cho ban ngày.'),
('Serum Klairs Vitamin C Dưỡng Sáng Da, Mờ Thâm 35ml Freshly Juiced Vitamin Drop',
'21.jpg', 6, 2, 244000, 'sản phẩm tiếp thêm sinh lực trẻ hóa làn da với sức mạnh của 5% Vitamin C dạng Acid L-ascorbic nhẹ dịu; cùng chiết xuất Rau Má không gây kích ứng nhưng vẫn hiệu quả trong việc
làm mờ các vết mụn và vết nám, cải thiện làn da xỉn và không đều màu.'),
('Kem Dưỡng Sur.Medic+ Nâng Tông & Làm Sáng Da 40ml Super Glutathione 100 Bright Tone Up Cream',
'22.jpg', 6, 2, 208000, 'sản phẩm với thành phần Glutathione dồi dào dưỡng da trắng sáng, làm giảm các sắc tố melanin nguyên nhân xuất hiện các dấu hiệu thâm sạm, nám, tàn nhang, cung cấp collagen thiết yếu giúp da săn chắc,
mịn màng, ngăn ngừa nếp nhăn và làm trẻ hóa làn da.'),
('Kem Dưỡng Obagi Retinol 0.5% Ngăn Ngừa Lão Hoá Da 28g Retinol 0.5 Cream',
'23.jpg', 6, 2, 1149000, ' sản phẩm kem dưỡng da trẻ hoá, ngừa mụn nổi tiếng từ thương hiệu dược mỹ phẩm Obagi Medical. Công thức với hàm lượng Retinol 0.5% / Retinol 1% hoạt động hiệu quả trên mọi làn da, đặc biệt là da dầu, 
giúp cải thiện các vấn đề về da như mụn, dầu thừa, lão hoá; mang đến cho bạn làn da mịn màng và tươi trẻ.');
Select * from Products
CREATE TABLE Inventory (--KHO
    ProductID int PRIMARY KEY FOREIGN KEY REFERENCES Products(ProductID),
    QuantityInStock int
)

CREATE TABLE Orders (--ĐƠN HÀNG
    OrderID int IDENTITY(1,1) PRIMARY KEY,
    OrderDate datetime,
    CustomerID int FOREIGN KEY REFERENCES Customers(CustomerID),
	ShippingMethod nvarchar(50),
	ShippingFee int,
	OrderStatus nvarchar(50),
    TotalAmount int
)
INSERT INTO Orders (OrderDate, ShippingMethod, ShippingFee, OrderStatus,TotalAmount)
VALUES ('2023-04-10',N'Normal shipping',15000,N'on the way',457000),
('2023-03-08',N'Normal shipping',15000,N'on the way',274000),
('2023-04-13',N'Fast shipping in 2 hours',25000,N'on the way',405000),
('2023-04-12',N'Fast shipping in 2 hours',25000,'finished',2045000),
('2023-03-30',N'Normal shipping',15000,N'finish',238000);
Select*From Orders
CREATE TABLE OrderDetails (--CHI TIẾT ĐƠN HÀNG
    OrderDetailID int IDENTITY(1,1) PRIMARY KEY,
    OrderID int FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID int FOREIGN KEY REFERENCES Products(ProductID),
    Quantity int
)

CREATE TABLE feedback(
	FeedbackID int IDENTITY(1,1) PRIMARY KEY,
	ProductID int FOREIGN KEY REFERENCES Products(ProductID),
	CustomerID int FOREIGN KEY REFERENCES Customers(CustomerID),
	OrderID int FOREIGN KEY REFERENCES Orders(OrderID),
	Vote INT,
	TextContent NVARCHAR(200)
)
