   M S B A M L   `   `   `  ����I  EPlatinumInform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PlatinumInform.PagesPlatinumInform.Pages  5      $    PlatinumInform.Pages.PricePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:PlatinumInform.Pages     5      -   5          N� Title$  Цена изделия��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��79* �6   �� 5      $
��296* �6   �� 5      $	��75* �6   .+�5   
   �� $��Center=�6    �� Orientation$ 
Horizontal=�60   $
��Left=�6I   .+�5      �� $��Изделие��6   $��17(�6'   $	��120��65   �� 5      -   5         ��Name$ 	cbProduct��5      $��17(�6*   $	��220��68    �� DisplayMemberPath$ NameProduct��6D   6d   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgPrice��5      $��1��6$   $��17(�61      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	№ П/П��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6N   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *NumPP+6N     5      $! Дата установки��6%   $	 * 6u   
 6=   �� *
DateInsert+ �� StringFormat$ 
dd/MM/yyyy��6u     5      $ Изделие��6%   $	 * 6^   
 66   �� *Product.NameProduct+6^     5      $ Цена��6%   $	 * 6L   
 63   �� *Cost+6L     5      $ № договора��6%   $	 * 6Y   
 69   �� *NumContract+6Y   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   $
��Left=�6;   $��Center=�6V   .+�5      �� -   5         ��Name$ btnAdd��5      $��Добавить��6%   $��17(�68   $	��150��6F   $��7q�6R   6]   �� 5       -   5        $ btnDel��5       $��Удалить��6%   $��17(�67   $	��150��6E   $��7q�6Q   6\   5!      �� 5"   
   $ 
Horizontal=�6   $��2��6.   $��Right=�6;   $��Center=�6W   .+�5#      �� -   5        $ btnReset��5#      $��Сброс поиска��6'   $��17(�6>   $	��150��6L   $��7q�6X   6c   �� 5$      -   5        $ btnBack��5$      $��
Назад��6&   $��17(�66   $	��150��6D   $��7q�6P   6[   5%      5&      5'      