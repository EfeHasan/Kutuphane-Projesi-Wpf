   M S B A M L   `   `   `  ����R  NKütüphane Projesi wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Kütüphane_Projesi_wpfKütüphane_Projesi_wpf  5   	   +    %Kütüphane_Projesi_wpf.Kayit_Ekranı   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Kütüphane_Projesi_wpf     5   	     � Title$  Kayit_Ekranı��5   	   $	��450��6   $	��800��6+   .��5	      � -   5        ���	#FF474747.+�5
   
   �� -   5         ��Name$ Isim_Kutusu��5
   6    � ToolTip$$ Kullanıcı adınızı giriniz��6   $
��Left=�6K   $��
269,80,0,0q�6f    �� TextWrapping$
 Wrap=�6z   $	��Top=�6�   $	��131��6�   $��34��6�   $��16(�6�   $��Italic$�6�   $��	Agency FB)�6�    J� RenderTransformOrigin$ 0.529,-1.516&�6�   G� 5   
   -   5         G�Name$ Sifre_kutusu��5   2   $ Şifrenizi giriniz��6   $
��Left=�6H   $��269,291,0,0q�6c   $	��Top=�6x   $	��131��6�   $��34��6�   $��16(�6�   $��	Agency FB)�6�   6�   �� 5   
   $��Adınızı Girniz:��6   $
��Left=�6*   $��
115,80,0,0q�6E   $	��Top=�6Y   $��35��6q   $	��131��6}   $��	Agency FB)�6�   $��16(�6�   
�������6�   �� 5   
   $��Şifrenizi Giriniz:��6   $
��Left=�6-   $��115,291,0,0q�6H   $	��Top=�6]   $��35��6u   $	��131��6�   $��	Agency FB)�6�   $��16(�6�   
�������6�   �� 5   
   -   5        $ Soy_Isim_Kutusu��5   /   $ Soyadınızı Giriniz��6   $
��Left=�6H   $��269,133,0,0q�6c   $
 Wrap=�6x   $	��Top=�6�   $	��131��6�   $��34��6�   $��16(�6�   $��Italic$�6�   $��	Agency FB)�6�   $ 0.529,-1.516&�6�   �� 5   
   $��Soyadınızı Girniz:��6   $
��Left=�6-   $��115,132,0,0q�6H   $	��Top=�6]   $��35��6u   $	��131��6�   $��	Agency FB)�6�   $��16(�6�   
�������6�   �� 5   
   -   5        $ 	Tc_kimlik��5   9   $$ Tc Kimlik Numaranızı Giriniz��6   $
��Left=�6L   $��269,183,0,0q�6g   $
 Wrap=�6|   $	��Top=�6�   $	��131��6�   $��34��6�   $��16(�6�   $��Italic$�6�   $��	Agency FB)�6�   $ 0.529,-1.516&�6�   �� 5   
   $��Tc Numaranızı Giriniz:��6   $
��Left=�61   $��115,182,0,0q�6L   $	��Top=�6a   $��35��6y   $	��131��6�   $��	Agency FB)�6�   $��16(�6�   
�������6�   �� 5   
   $#��Telefon Numaranızı Giriniz:��6   $
��Left=�66   $��115,236,0,0q�6Q   $	��Top=�6f   $��35��6~   $	��154��6�   $��	Agency FB)�6�   $��16(�6�   
�������6�   �� 5   
   -   5         ��Name$ Kayit_button��5      $��	Kayıt Ol��6'   $
��Left=�6:   $��280,354,0,0q�6U   $	��Top=�6j   $��44��6�   $	��120��6�   ���	#FF474747���	#FF474747
�������$��	Agency FB)�6�   $��16(�6�   6  � 5   
   -   5        $��sifre_zorluk��5      $
��Left=�6*   $��35��6E   $��405,290,0,0q�6Q   $	��Top=�6f   $	��132��6~   �� 5   
   -   5        $��Sifre_Zorluk��5      $�� ��6$   $
��Left=�6/   $��417,334,0,0q�6J   $	��Top=�6_   $��35��6w   $	��108��6�   $��	Agency FB)�6�   $��16(�6�   
�������6�   �� 5   
   -	   5        $ 	Giris_Yap��5      $��	Giris Yap��6$   $
��Left=�68   $��440,354,0,0q�6S   $	��Top=�6h   $��44��6�   $	��120��6�   ���	#FF474747���	#FF474747
�������$��	Agency FB)�6�   $��16(�6�   6�   �� 5   
   -
   5        $ Telefon_numarası��5   7   $" Telefon Numaranızı Giriniz��6   $
��Left=�6Q   $��269,237,0,0q�6l   $
 Wrap=�6�   $	��Top=�6�   $	��131��6�   $��34��6�   $��16(�6�   $��Italic$�6�   $��	Agency FB)�6�   $ 0.529,-1.516&�6�   5      5      