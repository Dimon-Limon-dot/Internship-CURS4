   M S B A M L   `   `   `  ����I  EPlatinumInform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PlatinumInform.PagesPlatinumInform.Pages  5      %    PlatinumInform.Pages.ReportPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:PlatinumInform.Pages     5        N� Title$  Отчетность��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��65* �6   �� 5      $
��344* �6   �� 5      $	��41* �6    � ColumnDefinitions 5   
   �� 5      $
��617* �6   �� 5      $
��183* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� $#��Укажите изделие��6   $��17(�6/   $	��140��6=   �� 5      -   5         ��Name$ 	cbProduct��5      $��17(�6*   $	��220��68    �� DisplayMemberPath$ NameProduct��6D   6d   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgReport��5      $��1��6%   $��10q�62      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$ 	 Децимальный №��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      `� 5       �� StringFormat$  {0}.{1}.{2}��6'   .1�5      ��  �� Path$ Product.CodeOrg�6&   �� 5      $ Product.CodeCharac�6&   �� 5       $ Product.SerialNum�6&   5!      5#        5$      $	 Наименование��6%   $
 * 6;    6E   �� *Product.NameProduct+  5%      $	 Цена��6%   $
 * 6L    63   �� *Cost+6L     5&      $%	 Цех производства��6%   $
 * 6l    6?   �� *Product.Departament.Name+6l   5(      �� 5)   
   $��1��6   $��1��6%   $	��Top=�62   .+�5*      �� -   5         ��Name$ 
btnRepWord��5*      $��
Отчет��6)   $��17(�69   $	��150��6G   $��35��6S   $��5q�6_   6j   �� 5+      -   5        $ btnExcel��5+      $��Excel��6'   $��17(�67   $	��150��6E   $��35��6Q   $��5q�6]   6h   5,      �� 5-   
   -   5        $ btnBack��5-      $��
Назад��6"   $��1��62   $��1��6B   $��Bottom=�6O   $��17(�6j   $	��150��6x   $��35��6�   $��5q�6�   6�   5.      5/      