   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	       Project.ManageCategory   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	   -   5          � Title$  ManageCategory��5   	   $	��700��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�69   .��5
      � 
����ح� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   
����ح� � Orientation$ Vertical=�68   .+�5      �� $��Car Information:��6   
���  ��$��25(�6@   $
��Bold"�6N   �� 5      $��
Car Name :��6   $��18(�6)   �� 5      -   5         ��Name$ txtName��5      $��25��6'   $	��300��63   ��6?   ��  �� Path$ CarName� �� Mode$ OneWay=� � DataContext 6i   �� 	 �� ElementName$	 lvCar��$ SelectedItem��� 5      $��Car Producer :��6   $��18(�6-   �� 5      -   5        $ txtPro��5      $��25��6&   $	��300��62   �� 5      $��Car Price :��6   $��18(�6*   �� 5      -   5        $ txtPrice��5      $��25��6(   $	��300��64   �� 5      $��Car Remain :��6   $��18(�6+   �� 5      -   5        $ 	txtremain��5      $��25��6)   $	��300��65   �� 5      
 �� Orientation$
 
Horizontal=�6   .+�5       �� -   5         ��Name$ 	btnInsert��5       $��Insert��6,   $��80��6=   $��25��6H   $��10q�6T   6`   �� 5!      -   5        $ 	btnUpdate��5!      $��Update��6,   $��80��6=   $��25��6H   $��10q�6T   6`   �� 5"      -   5        $ 	btnDelete��5"      $��Delete��6,   $��80��6=   $��25��6H   $��10q�6T   6`   5#      5$      �� 5%   
   -	   5         ��Name$ listViewCars��5%      $��Stretch=�6)   $��Stretch=�6G   $��1��6c    �� View 5&      �� 5'      .P�5(      �� $��CarID��6%    �� Width$ 50��6`    �� DisplayMemberBinding 64   �� $ CarID�6`   �� 5)      $��CarName��6%   $	 150��6d    66   �� $ CarName�6d   �� 5*      $��CarProducer��6%   $	 150��6l    6:   �� $ CarProducer�6l   �� 5+      $��CarPrice��6%   $	 100��6f    67   �� $ CarPrice�6f   �� 5,      $
��Sold��6%   $ 50��6^    63   �� $
 Sold�6^   �� 5-      $��Remain��6%   $ 50��6b    65   �� $ Remain�6b   5.      50      �� 51   
   -
   5        $
��Exit��51      $��2��6    $��25��6-   $��10q�69   $��80��6E   6P   �� 52   
   -   5        $��Logout��52      $��2��6"   $��0��6/   $��25��6?   $��80,10,510,10q�6K   $��80��6a   6l   �� 53   
   -   5        $
��Back��53      $��2��6    $��1��6-   $��25��6=   $��10q�6I   $��80��6U   6`   54      55      