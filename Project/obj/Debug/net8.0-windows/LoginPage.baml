   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	       Project.LoginPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	     � Title$  	LoginPage��5   	   $	��150��6   $	��400��6(    � WindowStartupLocation$ CenterScreen=�64   .��5	      � 
����ح� � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      $	��200 �6   �� 5      $	��100 �6   .+�5   
   �� $��
UserName :��6   $��0��6%   $��0��62   $��14(�6B   �� 5   
   -   5         ��Name$ txtUserName��5   ;   $��25��6   $��0��6   $��1��6+   6;   �� 5   
   $��
PassWord :��6   $��1��6%   $��0��62   $��14(�6C   �� 5   
   -   5        $ txtPassWord��5   ;   $��25��6   $��1��6   $��1��6+   6;   �� 5   
   -   5         ��Name$ btnLogin��5      $��Login��6#   $��80��63   $��2��6>   $��25��6K   $��0��6W   6g   �� 5   
   -   5        $ btnRegister��5      $��Register��6&   $��80��69   $��1��6D   $��25��6Q   $��1��6_   $��
60,28,60,0q�6o   $��2��6�   $	��Top=�6�   6�   �� 5   
   -   5        $ btnExit��5      $
��Exit��6"   $��80��61   $��1��6<   $��25��6I   $��2��6W   $��
10,28,10,0q�6g   $��2��6{   $	��Top=�6�   6�   5      5      