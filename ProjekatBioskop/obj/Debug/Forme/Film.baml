   M S B A M L   `   `   `  ����J  FProjekatBioskop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjekatBioskop.FormeProjekatBioskop.Forme  5   	        ProjekatBioskop.Forme.Film   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ProjekatBioskop.Forme     5   	     � Title$  Dodaj/izmeni film��5   	   $	��450��6#   $	��400��60   .��5	      � .+�5   
   �� 
�������
�������$��Arial)�6A   $��Italic$�6T   $��17(�6g   $��Naziv filma:��6u   $
��Left=�6�   $��	77,38,0,0q�6�   $	��Top=�6�   �� 5   
   
�������
�������$��Arial)�6A   $��Italic$�6T   $��17(�6g   $��Opis filma:��6u   $
��Left=�6�   $��	77,83,0,0q�6�   $	��Top=�6�   �� 5   
   
�������
�������$��Arial)�6A   $��Italic$�6T   $��17(�6g   $��	Trajanje:��6u   $
��Left=�6�   $��
77,144,0,0q�6�   $	��Top=�6�   �� 5   
   
�������
�������$��Arial)�6A   $��Italic$�6T   $��17(�6g   $��Jezik:��6u   $
��Left=�6�   $��
77,184,0,0q�6�   $	��Top=�6�   �� 5   
   
�������
�������$��Arial)�6A   $��Italic$�6T   $��17(�6g   $��Datum:��6u   $
��Left=�6�   $��
77,223,0,0q�6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatum��5      $
��Left=�6%   $��225,223,0,0q�6@   $	��Top=�6U   $	��120��6m   �� 5   
   -   5        $��txtNazivFilma��5      $
��Left=�6'   $��23��6B   $��
225,38,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   �� 5   
   -   5        $��txtOpisFilma��5      $
��Left=�6&   $��23��6A   $��
225,90,0,0q�6M   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5   
   -   5        $��txtTrajanje��5      $
��Left=�6%   $��23��6@   $��225,144,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5   
   -   5        $��txtJezik��5      $
��Left=�6"   $��23��6=   $��225,184,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5   
   
�������
�������$��Arial)�6A   $��Italic$�6T   $��17(�6g   $��Žanr:��6v   $
��Left=�6�   $��
77,265,0,0q�6�   $	��Top=�6�   �� 5   
   
�������
�������$��Arial)�6A   $��Italic$�6T   $��17(�6g   $��	Lokacija:��6u   $
��Left=�6�   $��
77,310,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $��cbZanrFilma��5      $
��Left=�6&   $��225,265,0,0q�6A   $	��Top=�6V   $	��120��6n    �� DisplayMemberPath$
 Zanr��6z    �� SelectedValuePath$ ZanrFilmaID��6�   �� 5   
   -   5        $��
cbLokacija��5      $
��Left=�6%   $��225,310,0,0q�6@   $	��Top=�6U   $	��120��6m   $ Adresa��6y   $ 
LokacijaID��6�   �� 5   
   -   5        $��
btnSacuvaj��5   �   
������ $��2q�6*   
�������
�������$��Arial)�6o   $��Italic$�6�   $��17(�6�   $��Sačuvaj��6�   $
��Left=�6�   $��164,374,0,0q�6�   $	��Top=�6�   $��75��6  6  �� 5   
   -	   5        $��	btnOtkazi��5   �   
������ $��2q�6*   
�������
�������$��Arial)�6o   $��Italic$�6�   $��17(�6�   $��Otkaži��6�   $
��Left=�6�   $��270,374,0,0q�6�   $	��Top=�6�   $��75��6  6  5      5      