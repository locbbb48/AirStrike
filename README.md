# AirStrike
Game Code by Unity C#.
Assets and game content as described by WEUP GAME STUDIO.

Link Preview & DownLoad(GG Driver): https://drive.google.com/drive/folders/1GZFahCTGD0r_J9g00mGuqlF8RMJ5f74w?usp=drive_link

Mô tả: 
 Gameplay gồm có :
 Player di chuyển được trên màn hình, bắn ra đạn với chu kì 0.1s sẽ sinh ra 1 viên đạn
 Enemy sẽ có 5 máu sắp xếp, di chuyển theo đội hình
 Score : Khi enemy chết sẽ được cộng 1 điểm

 Cách di chuyển của enemy:
 Game gồm 16 enemy, ban đầu di chuyển từ ngoài màn hình vào sắp xếp thành đội hình thành hình vuông gồm 4 hàng và 4 cột
 Sau 5s tiếp tục di chuyển thành hình thoi
 Sau 5s tiếp tục di chuyển thành hình tam giác
 Sau 5s tiếp tục di chuyển thành hình chữ nhật
 Sau khi enemy sắp xếp xong các hình dạng trên sẽ bắt đầu tính va chạm với đạn, mỗi enemy khi va chạm với viên đạn sẽ mất 1 máu và viên đạn cũng biến mất. Khi enemy hết máu sẽ được cộng 1 điểm và chết ( biến mất). 

Kĩ thuật:
 Game sử dụng Object Pooling để quản lí bullet và enemy, giúp tối ưu hiệu năng.
 Design Pattern: Singleton, Adapter Pattern.
 Code theo hướng đối tượng, phát triển các object từ các lớp abstract, game hoàn toàn có thể phát triển tiếp và theo nhiều hướng khác nhau.
