   M S B A M L   `   `   `  ����R  NKütüphane Projesi wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Kütüphane_Projesi_wpfKütüphane_Projesi_wpf  5   	   8    2Kütüphane_Projesi_wpf.Kullanicilari_görüntüle   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Kütüphane_Projesi_wpf     5   	   -   5          � Title$   Kullanicilari_görüntüle��5   	   $	��450��6)   $	��800��66   .��5	      � -   5        .+�5
   
   �� -   5         ��Name$ 	İsim_Bul��5
   C    � ToolTip$ İsime Göre Bul��6   $��İsime Göre Bul��6*   $
��Left=�6U   $��
70,320,0,0q�6p   $	��Top=�6�   $��48��6�   $	��160��6�   $��20(�6�   $��	Agency FB)�6�   
�������6�   �� 5   
   -   5         ��Name$ listview��5   �    %� IsVirtualizing$
 True��6    %� VirtualizationMode$ Standard=�6;   $��208,10,10,174q�6k    �� View 5      �� 5      .P�5      ��  �� Width$ 95��6%   $��İsim��60    �� DisplayMemberBinding 6>   �� *Isim+�� 5      $ 95��6%   $��Soyisim��60    6A   �� *
Soy_Isim+�� 5      $ 95��6%   $��	Tc Kimlik��60    6C   �� *Tc_No+�� 5      $ 95��6%   $��Telefon Numarası��60    6J   �� *telefon_numarasi+�� 5      $ 95��6%   $��Sifre��60    6?   �� *Sifre+�� 5      $ 95��6%   $��Yetki��60    6?   �� *yetki+�� 5      5      5      �� 5   
   -   5        	 ��Name$	 Isim_Box��5   .   $ İsminizi Giriniz��6   $
��Left=�6@   $��	10,52,0,0q�6[   
 �� TextWrapping$

 Wrap=�6n   $	��Top=�6�   $	��131��6�   $��37��6�   $��16(�6�   $��Italic$�6�   $��	Agency FB)�6�    J� RenderTransformOrigin$ 0.529,-1.516&�6�   �� 5   
   -   5         ��Name$ kitap_isimi_text��5      $��İsim��6+   $��20(�6:   $
��Left=�6H   $��	10,10,0,0q�6c   $	��Top=�6v   �� 5   
   -   5        $ Yetkiye_Gore��5   G   $ Yetkiye Göre Bul��6   $��Yetkiye Göre Bul��6,   $
��Left=�6]   $��235,320,0,0q�6x   $	��Top=�6�   $��48��6�   $	��160��6�   $��20(�6�   $��	Agency FB)�6�   
�������6�   �� 5   
   -   5        $	 Soyisim_Box��5   1   $ Soyisminizi Giriniz��6   $
��Left=�6F   $��
10,140,0,0q�6a   $

 Wrap=�6u   $	��Top=�6�   $	��131��6�   $��37��6�   $��16(�6�   $��Italic$�6�   $��	Agency FB)�6�   $ 0.529,-1.516&�6�   �� 5   
   -	   5        $ soyisim��5      $��Soyisim��6"   $��20(�64   $
��Left=�6B   $��	10,98,0,0q�6]   $	��Top=�6p   �� 5   
   -
   5        $ soyisime_gore��5   I   $ Soyisime göre bul��6   $��Soyisime Göre Bul��6-   $
��Left=�6`   $��400,320,0,0q�6{   $	��Top=�6�   $��48��6�   $	��160��6�   $��20(�6�   $��	Agency FB)�6�   
�������6�   �� 5   
   -   5        $��yetkiler��5   B   $
��Left=�6   $��
10,232,0,0q�6.   $	��Top=�6R   $	��131��6j   $��37��6v   $��18(�6�   $��	Agency FB)�6�   �� 5    
   -   5        $ soyisim_Copy��5       $��Yetkiler��6'   $��20(�6:   $
��Left=�6H   $��
13,190,0,0q�6c   $	��Top=�6w   �� 5!   
   -   5        $ Ana_Menu��5!   G   $ Ana Menü Ekranına Atar��6   $��Ana Menüye��62   $
��Left=�6Y   $��565,320,0,0q�6t   $	��Top=�6�   $��48��6�   $	��166��6�   $��20(�6�   $��	Agency FB)�6�   
�������6�   5#      5$      