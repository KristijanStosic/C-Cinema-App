   M S B A M L   `   `   `  ����J  FProjekatBioskop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjekatBioskopProjekatBioskop  5   	        ProjekatBioskop.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ProjekatBioskop     5   	     � Title$  Bioskop��5   	   $	��400��6   $	��900��6&   
�������$��4q�5
   	   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5      $��Center=�6-   $
��auto��6J   $��Center=�6Y   $
��auto��6t      
IsReadOnly .    AlternatingRowBackground
 �����   CanUserAddRows .     SelectionUnit$ FullRow=�6�      SelectionMode$ Single=�6�   �� 5   
   $��Center=�6   $��50��62   $	��Top=�6?   $
��auto��6W    �� Orientation$ 
Horizontal=�6d   .+�5      �� -   5        $��
btnFilmovi��5   �   $��3q�6   
�������
�������
������ $��Arial)�6s   $��Italic$�6�   $��19(�6�   $��Filmovi��6�   $
��Left=�6�   $��50��6�   $	��Top=�6�   $	��100��6
  6  �� 5      -   5        $��btnKupci��5   �   $��3q�6   
�������
�������
������ $��Arial)�6s   $��Italic$�6�   $��19(�6�   $��Kupci��6�   $
��Left=�6�   $��50��6�   $	��Top=�6�   $	��100��6  6  �� 5      -   5        $��btnLokacije��5   �   $��3q�6   
�������
�������
������ $��Arial)�6s   $��Italic$�6�   $��19(�6�   $��Lokacije��6�   $
��Left=�6�   $��50��6�   $	��Top=�6�   $	��100��6  6  �� 5      -   5        $��btnRezervacije��5   �   $��3q�6   
�������
�������
������ $��Arial)�6s   $��Italic$�6�   $��19(�6�   $��Rezervacije��6�   $
��Left=�6�   $��50��6�   $	��Top=�6�   $	��120��6  6  �� 5      -   5        $��btnTipKarte��5   �   $��3q�6   
�������
�������
������ $��Arial)�6s   $��Italic$�6�   $��19(�6�   $��Tipovi karata��6�   $
��Left=�6�   $	��120��6�   6�   �� 5      -   5        $��btnZaposleni��5   �   $��3q�6   
�������
�������
������ $��Arial)�6s   $��Italic$�6�   $��19(�6�   $��	Zaposleni��6�   $
��Left=�6�   $��50��6�   $	��Top=�6�   $	��100��6  6  �� 5      -   5        $��btnZanrFilma��5   �   $��3q�6   
�������
�������
������ $��Arial)�6s   $��Italic$�6�   $��19(�6�   $��Žanr filma��6�   $
��Left=�6�   $��50��6�   $	��Top=�6�   $	��100��6  6  5      �� 5   
   $��Center=�6   $��50��62   $��Bottom=�6?   $	��450��6Z   $ 
Horizontal=�6f   .+�5      �� -	   5        $��btnDodaj��5   �   $��3q�6   
�������$��Arial)�6B   $��Italic$�6U   $��20(�6h   
�������
������ $��Dodaj��6�   $��50��6�   $	��150��6�   6�   �� 5      -
   5        $��	btnIzmeni��5   �   $��3q�6   
�������$��Arial)�6B   $��Italic$�6U   $��20(�6h   
�������
������ $��Izmeni��6�   $��50��6�   $	��150��6�   6�   �� 5      -   5        $��	btnObrisi��5   �   $��3q�6   
�������$��Arial)�6B   $��Italic$�6U   $��20(�6h   
�������
������ $��Obriši��6�   $��50��6�   $	��150��6�   6�   5      5      5      