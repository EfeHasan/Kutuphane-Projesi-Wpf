   M S B A M L   `   `   `  ����R  NKütüphane Projesi wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Kütüphane_Projesi_wpfKütüphane_Projesi_wpf  5   	   *    $Kütüphane_Projesi_wpf.Kitap_Ekleme   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Kütüphane_Projesi_wpf     5   	   -   5          � Title$  Kitap_Ekleme��5   	   $	��450��6   $	��800��6+   .��5	      � -   5        .+�5
   
   �� $��Kitap İsmi:��6   $��16(�6&   $
��Left=�64   $��	10,89,0,0q�6O   $	��Top=�6b   $��	Agency FB)�6z   �� 5   
   -   5        $��
Kitap_Ismi��5   k   $
��Left=�6   $��16(�6.   $��	98,91,0,0q�6<    �� TextWrapping$
 Wrap=�6O   $�� ��6c   $	��Top=�6}   $	��123��6�   $��24��6�   $��	Agency FB)�6�   �� 5   
   $��Kitap Yazarı:��6   $��16(�6(   $
��Left=�66   $��
10,132,0,0q�6Q   $	��Top=�6e   $��	Agency FB)�6}   �� 5   
   -   5         ��Name$ kitap_yazari��5   k   $
��Left=�6   $��16(�6-   $��
98,134,0,0q�6;   $
 Wrap=�6O   $�� ��6c   $	��Top=�6�   $	��123��6�   $��24��6�   $��	Agency FB)�6�   �� 5   
   -   5        $��
kitap_turu��5      $
��Left=�6%   $��
98,184,0,0q�6@   $	��Top=�6T   $	��120��6l   6x   �� 5   
   $��Kitap Türü:��6   $��16(�6&   $
��Left=�64   $��
10,177,0,0q�6O   $	��Top=�6c   $��	Agency FB)�6{   �� 5   
   $��Basım Tari:��6   $��16(�6&   $
��Left=�64   $��
10,215,0,0q�6O   $	��Top=�6c   $��	Agency FB)�6{   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��tarih��5      $
��Left=�6"   $��
98,217,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5         ��Name$ 
Kitap_Ekle��5   E    � ToolTip$ Kitap Ekleme Butonu��6   $��Kitabı Ekle��6/   $
��Left=�6Y   $��
10,308,0,0q�6t   $	��Top=�6�   $��34��6�   $��92��6�   $��	Agency FB)�6�   $��16(�6�   
�������
�������6  �� 5   
   -   5        $ Kitabı_Sil��5   C   $ Kitap Silme Butonu��6   $��Kitabı Sil��6.   $
��Left=�6W   $��107,308,0,0q�6r   $	��Top=�6�   $��34��6�   $��92��6�   $��	Agency FB)�6�   $��16(�6�   
�������
�������6  �� 5   
   -	   5        $ ana_menu��5   >   $ Ana Menü Butonu��6   $��	Ana Menü��6+   $
��Left=�6P   $��495,308,0,0q�6k   $	��Top=�6�   $��34��6�   $��92��6�   $��	Agency FB)�6�   $��16(�6�   
�������
�������6�   �� 5   
   -
   5        $ Yazari_degistir��5   O   $$ Kitabın Yazarını Değiştir��6   $��Yazarı Değiştir��65   $
��Left=�6h   $��204,308,0,0q�6�   $	��Top=�6�   $��34��6�   $��92��6�   $��	Agency FB)�6�   $��16(�6�   
�������
�������6  �� 5   
   -   5        $ tarihini��5   W   $) #Kitabın Basım Tarihini Değiştir��6   $��Tarihini Değiştir��6;   $
��Left=�6i   $��301,308,0,0q�6�   $	��Top=�6�   $��34��6�   $��92��6�   $��	Agency FB)�6�   $��16(�6�   
�������
�������6  �� 5   
   -   5        $ Turu_degistir��5   M   $# Kitabın Türünü Değiştir��6   $��Türünü Değiştir��63   $
��Left=�6d   $��398,308,0,0q�6   $	��Top=�6�   $��34��6�   $��92��6�   $��	Agency FB)�6�   $��16(�6�   
�������
�������6  5      5      