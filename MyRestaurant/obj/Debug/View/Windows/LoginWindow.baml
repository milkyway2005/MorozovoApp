   M S B A M L   `   `   `  ����G  CMyRestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MyRestaurant.View.WindowsMyRestaurant.View.Windows  5   	   A%clr-namespace:MyRestaurant.View.PagesMyRestaurant.View.Pages  5   	   S.clr-namespace:MyRestaurant.ViewModel.WindowsVM MyRestaurant.ViewModel.WindowsVM  5   	   +    %MyRestaurant.View.Windows.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MyRestaurant.View.Windows     5   	   4pg%clr-namespace:MyRestaurant.View.Pages     5   	   =vm.clr-namespace:MyRestaurant.ViewModel.WindowsVM     5   	     � Title$  Авторизация��5
   	   $	��500��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�66      loginWindow#��[  5   	    � DataContext 5      4   .MyRestaurant.ViewModel.WindowsVM.LoginWindowVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��9* �6   .+�5   
   �� $��0 0 5 0q�6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $��Right=�6Z   $��0��6v   .+�5      ��   windowButtons#��[ 6   $��_��6<   ��6H   �� *ResizeWindow+�� 5      #��[ 6   $��x��6<   ��6H   �� *CloseWindow+5      � 5   
   $��Center=�6   $
��Left=�6*   $��50q�6E   $��1��6Q    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5!      � $��0��6    5"      �� 5#      $
��Auto �6$   �� 5$      $
��Auto �6$    � ColumnDefinitions 5&      �� 5'      $
��Auto �6'   �� 5(      $
��Auto �6'   .+�5+      ��   loginTextBlock#��[ 6   $��
Логин��6D   $��0��6Q   $��0��6^   �� 5,      #��[ 6   $��Пароль��6D   $��1��6R   $��0��6_   �� 5-        loginTextBox#��[ 6   $��0��6@   $��1��6M   $	��200��6]   ��6i   �� *CurrentLogin+�� 5.      #��[ 6   $��1��6@   $��1��6M   $	��200��6]   ��6i   �� *CurrentPassword+5/      �� 50        loginButton#��[ 6   $��
Войти��6:   $��1��6J   ��6W   �� *OpenControlWindow+�� 51        message#��[ 6   $��2��69   ��6F   �� *MessageText+52      53      54      