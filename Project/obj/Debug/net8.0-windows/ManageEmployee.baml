   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	       Project.ManageEmployee   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	     � Title$  ManageEmployee��5   	   $	��450��6    $	��800��6-   .��5	      � 
����ح� � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   
����ح� � Orientation$ Vertical=�68   .+�5      �� $��Employee Information:��6   
���  ��$��25(�6E   $
��Bold"�6S   �� 5      $��Employee Name :��6   $��18(�6.   �� 5      -   5         ��Name$ txtName��5      $��25��6'   $	��300��63   ��6?   ��  �� Path$ CarName� �� Mode$ OneWay=� � DataContext 6i   ��  �� ElementName$ lvCar��$ SelectedItem��� 5      $��Date of Birth :��6   $��18(�6.   (  "System.Windows.Controls.DatePicker  5      -   5        $��dtDate��5   %   $	��300��6   6%   �� 5      $��Employee Address:��6   $��18(�60   �� 5      -   5        $ txtAdd��5      $��25��6&   $	��300��62   �� 5      $��Phone :��6   $��18(�6&   �� 5      -   5        $ txtPhone��5      $��25��6(   $	��300��64   �� 5      	 �� Orientation$	 
Horizontal=�6   .+�5      �� -   5        
 ��Name$
 	btnInsert��5      $��Insert��6,   $��80��6=   $��25��6H   $��10q�6T   6`   �� 5       -   5        $
 	btnUpdate��5       $��Update��6,   $��80��6=   $��25��6H   $��10q�6T   6`   �� 5!      -   5        $
 	btnDelete��5!      $��Delete��6,   $��80��6=   $��25��6H   $��10q�6T   6`   5"      5#      �� 5$   
   -   5        $��lvCar��5$       $��1��6    �� View 5%      �� 5&      .P�5'      �� $��ID��6%    �� Width$ 50��61    �� DisplayMemberBinding 6<   �� $ CarID��� 5(      $
��Name��6%   $	 150��63    6?   �� $ CarName��� 5)      $��DateOfBirth��6%   $	 150��6:    6F   �� $ CarProducer��� 5*      $��Address��6%   $	 150��66    6B   �� $ CarPrice��� 5+      $
��Sold��6%   $ 80��63    6>   �� $
 Sold��� 5,      $��Remain��6%   $ 80��65    6@   �� $ Remain�5-      5/      �� 50   
   -	   5        $
��Exit��50      $��2��6    $��25��6-   $��10q�69   $��80��6E   6P   �� 51   
   -
   5        $��Logout��51      $��2��6"   $��0��6/   $��25��6?   $��80,10,510,10q�6K   $��80��6a   6l   �� 52   
   -   5        $
��Back��52      $��2��6    $��1��6-   $��25��6=   $��10q�6I   $��80��6U   6`   53      54      