   M S B A M L   `   `   `  ����R  NKütüphane Projesi wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Kütüphane_Projesi_wpfKütüphane_Projesi_wpf  5   	   6    0Kütüphane_Projesi_wpf.Kitapları_Görüntüler   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Kütüphane_Projesi_wpf     5   	   -   5          � Title$  Kitapları_Görüntüler��5   	   $	��450��6&   $	��800��63   .��5	      � -   5        .+�5
   
   �� -   5        $��listview��5
   �    %� IsVirtualizing$
 True��6    %� VirtualizationMode$ Standard=�6@   $��240,10,10,174q�6u    �� View 5      �� 5      .P�5      ��  �� Width$ 95��6%   $��Kitap İsmi��60    �� DisplayMemberBinding 6D   �� *kitap_isimi+�� 5      $ 95��6%   $��Kitap Yazarı��60    6F   �� *kitap_yazari+�� 5      $ 95��6%   $��Kitap Türü��60    6D   �� *
kitap_turu+�� 5      $ 95��6%   $��Basım Tarihi��60    6F   �� *basim_tarihi+�� 5      $ 95��6%   $��Durumu��60    6@   �� *durumu+�� 5      5      5      �� 5   
   -   5        $��Tarihe_Sirala��5   \    � ToolTip$$ Basım Tarihine Göre Sıralar��6   $#��Basım Tarihine Göre Sırala��67   $
��Left=�6q   $��390,351,0,0q�6�   $	��Top=�6�   $��56��6�   $	��185��6�   $��20(�6�   $��	Agency FB)�6�   
�������6
  �� 5   
   -   5         ��Name$ Ture_Gore_Sirala��5   s   $J DComboBox a Girndiğiniz Değer Aracığıyla Türü Bularak Sıralar��6   $��Türe Göre Sırala��6X   $
��Left=�6�   $��200,351,0,0q�6�   $	��Top=�6�   $��56��6�   $	��185��6�   $��20(�6�   $��	Agency FB)�6�   
�������6&  �� 5   
   -   5        $ 	Kitap_Bul��5   O   $' !Aranan İsime Göre Kitabı Bulur��6   $��Kitabı Bul��6:   $
��Left=�6b   $��
10,351,0,0q�6}   $	��Top=�6�   $��56��6�   $	��185��6�   $��20(�6�   $��	Agency FB)�6�   
�������6�   �� 5   
   -   5         ��Name$ 
Kitap_ismi��5   2   $ Kitap ismini Giriniz��6   $
��Left=�6F   $��	50,77,0,0q�6a   	 �� TextWrapping$
	 Wrap=�6t   $	��Top=�6�   $	��131��6�   $��37��6�   $��16(�6�   $��Italic$�6�   $��	Agency FB)�6�   
 J� RenderTransformOrigin$
 0.529,-1.516&�6�   �� 5   
   -   5        $��
Tur_Kutusu��5   2   $ Kitap Türünü Giriniz��6   $
��Left=�6D   $��
50,172,0,0q�6_   $	��Top=�6s   $	��131��6�   $��37��6�   �� 5   
   -	   5        $��kitap_isimi_text��5      $��Kitap İsmi��6)   $��20(�6>   $
��Left=�6L   $��	50,35,0,0q�6g   $	��Top=�6z   �� 5   
   -
   5        $��Kitap_turu_text��5      $��Kitap Türü��6'   $��20(�6<   $
��Left=�6J   $��
50,135,0,0q�6e   $	��Top=�6y   �� 5   
   -   5        $ Ana_Menu��5   G   $ Ana Menü Ekranına Atar��6   $��Ana Menüye��62   $
��Left=�6Y   $��580,351,0,0q�6t   $	��Top=�6�   $��56��6�   $	��185��6�   $��20(�6�   $��	Agency FB)�6�   
�������6�   5       5!      