   M S B A M L   `   `   `  ����R  NKütüphane Projesi wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Kütüphane_Projesi_wpfKütüphane_Projesi_wpf  5   	   1    +Kütüphane_Projesi_wpf.emanet_görüntüle   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Kütüphane_Projesi_wpf     5   	   -   5          � Title$  emanet_görüntüle��5   	   $	��450��6"   $	��800��6/   .��5	      � -   5         � RowDefinitions 5
   
   �� 5      $	��39* �6   �� 5      $
��395* �6   .+�5   
   �� -   5         ��Name$ listview��5   �    %� IsVirtualizing$
 True��6    %� VirtualizationMode$ Standard=�6;   $��240,10,10,174q�6k   $��2��6�    �� View 5      �� 5      .P�5      ��  �� Width$ 95��6%   $��İsim��60    �� DisplayMemberBinding 6>   �� *Isim+�� 5      $ 95��6%   $��Soyisim��60    6A   �� *	SoyIsim+�� 5      $ 95��6%   $��	Tc Kimlik��60    6C   �� *	Tc_Kimlik+�� 5      $ 95��6%   $��Kitap İsmi��60    6D   �� *
Kitap_Ismi+�� 5      $ 95��6%   $��Alım Tarihi��60    6E   �� *Alim_Tarihi+�� 5      5      5      �� 5   
   -   5         ��Name$ Tarihe_Sirala��5   Z   	 � ToolTip$#	 Alım Tarihine Göre Sıralar��6   $"��Alım Tarihine Göre Sırala��66   $
��Left=�6q   $��390,308,0,0q�6�   $	��Top=�6�   $��56��6�   $	��185��6�   $��20(�6�   $��	Agency FB)�6�   
�������$��1��6
  6  �� 5   
   -   5        $ Kullanici_Bul��5   e   $=	 7Aranan İsim Ve Soyismine Göre Kullanıyıcıyı Bulur��6   $��Kullanıcı Bul��6M   $
��Left=�6|   $��200,308,0,0q�6�   $	��Top=�6�   $��56��6�   $	��185��6�   $��20(�6�   $��	Agency FB)�6�   
�������$��1��61  �� 5   
   -   5        
 ��Name$
 Isim_Box��5   .   $	 İsminizi Giriniz��6   $
��Left=�6@   $��	50,51,0,0q�6[    �� TextWrapping$
 Wrap=�6n   $	��Top=�6�   $	��131��6�   $��37��6�   $��16(�6�   $��Italic$�6�   $��	Agency FB)�6�    J� RenderTransformOrigin$ 0.529,-1.516&�6�   $��1��6  �� 5   
   -   5         ��Name$ kitap_isimi_text��5      $��İsim��6+   $��20(�6:   $
��Left=�6H   $��50,9,0,0q�6c   $	��Top=�6u   $��1��6�   $��37��6�   $��46��6�   �� 5   
   -   5        $ Ana_Menu��5   G   $	 Ana Menü Ekranına Atar��6   $��Ana Menüye��62   $
��Left=�6Y   $��580,308,0,0q�6t   $	��Top=�6�   $��56��6�   $	��185��6�   $��20(�6�   $��	Agency FB)�6�   
�������$��1��6	  �� 5    
   -	   5        $
 Soyisim_Box��5    1   $	 Soyisminizi Giriniz��6   $
��Left=�6F   $��
50,151,0,0q�6a   $
 Wrap=�6u   $	��Top=�6�   $	��131��6�   $��37��6�   $��16(�6�   $��Italic$�6�   $��	Agency FB)�6�   $ 0.529,-1.516&�6�   $��1��6  �� 5!   
   $��Soyisim��6   $��20(�6"   $
��Left=�60   $��
50,109,0,0q�6K   $	��Top=�6_   $��1��6w   $��37��6�   $��77��6�   �� 5"   
   -
   5        $ 	Goruntule��5"   G   $#	 Bütün Hepsini Görüntüşe��6   $��Görüntüle��63   $
��Left=�6Z   $��
10,308,0,0q�6u   $	��Top=�6�   $��56��6�   $	��185��6�   $��20(�6�   $��	Agency FB)�6�   
�������$��1��6
  5#      5$      