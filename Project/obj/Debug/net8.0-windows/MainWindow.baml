   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	       Project.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	     � Title$  
MainWindow��5   	   $	��200��6   $	��500��6)    � WindowStartupLocation$ CenterScreen=�65   .��5	      � 
����ح� � RowDefinitions 5
   
   �� 5      $��40 �6   �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $	��200 �6   �� 5      $	��100 �6   .+�5   
   �� $ ��Manage Category in Store :��6   $��0��65   $��0��6B   $��14(�6R   �� 5   
   -   5         ��Name$ btnManageCategory��5      $��ManageCategory��6,   $��0��6E   $��1��6U   $��25��6b   $	��100��6n   6z   �� 5   
   $ ��Manage Employee in Store :��6   $��0��65   $��1��6B   $��14(�6R   �� 5   
   -   5        $ btnManageEmployee��5      $��ManageEmployee��6,   $��1��6E   $��1��6U   $��25��6b   $	��100��6n   6z   �� 5   
   -   5        $ btnExit��5      $��Log Out��6"   $��2��64   $��1��6D   $��25��6Q   $��80��6]   6h   5      5      