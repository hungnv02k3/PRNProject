   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	       Project.RegisterPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	     � Title$  RegisterPage��5   	   $	��250��6   $	��400��6+    � WindowStartupLocation$ CenterScreen=�67   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��130 �6   �� 5      $	��200 �6   .+�5   
   �� $��
UserName :��6   $��0��6%   $��0��62   $��14(�6B   �� 5   
   -   5         ��Name$ txtUserName��5   ;   $��25��6   $��0��6   $��1��6+   6;   �� 5   
   $��
PassWord :��6   $��1��6%   $��0��62   $��14(�6C   �� 5   
   -   5        $ txtPassWord��5   ;   $��25��6   $��1��6   $��1��6+   6;   �� 5   
   $��ConfirmPassWord :��6   $��2��6,   $��0��69   $��14(�6J   �� 5   
   -   5        $ txtConfirmPass��5   ;   $��25��6   $��2��6   $��1��6+   6;   �� 5   
   -   5         ��Name$ btnRegister��5      $��Register��6&   $��3��6:   $��80��6G   $��Center=�6R   $��25��6o   6{   �� 5   
   -   5        $ btnBack��5      $
��Back��6"   $��3��62   $��1��6?   $��80��6O   $��Center=�6Z   $��25��6w   $��Bottom=�6�   6�   5      5      