   M S B A M L   `   `   `  ����D  @Reservoom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Reservoom.ViewsReservoom.Views  5      ;"clr-namespace:Reservoom.ViewModelsReservoom.ViewModels  6:   )    #Reservoom.Views.MakeReservationView   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Reservoom.Views     5      9
viewmodels"clr-namespace:Reservoom.ViewModels     6:   $��14(�5      .��5
      �   � IsSharedSizeScope$
  True��6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��Make Reservation��5         HeaderStyle#��[  5      � 5   
   $��1��6   $��0 50 0 0q�6    5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��Username��6%   �� 5      $��1��6   
�������
�������$	��4 2q�5!      $��2q�5"        TextBoxBaseControlTemplate#��[ 5#      $��0 5 0 0q�5%      ��5$      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5%      5&      � 5(   
   $��2��6   $��0 10 0 0q�6    5)      �� 5*      $
��auto �6    �� 5+      $
��auto �6     � ColumnDefinitions 5-      �� 5.      $
��auto �6#    z� SharedSizeGroup$ FirstColumn��60   �� 5/      $
��auto �6#   $ SecondColumn��60   .+�52      �� $��0��6   $��0��6%   $��Floor No��65   �� 53      $��0��6   $��1��6%   $��Room No��65   $��10 0 0 0q�6D   �� 55      $��1��6   $��0��56      $	��4 2q�57      $��0 5 0 0q�59      $��2q�5:      #��[ 5;      ��58      �� *FloorNumber+$ PropertyChanged=�5;      �� 5<      $��1��6   $��1��5=      $	��4 2q�5>      $��10 5 0 0q�5@      $��2q�5A      #��[ 5B      ��5?      �� *
RoomNumber+$ PropertyChanged=�5B      5C      � 5E   
   $��3��6   $��0 10 0 0q�6    5F      �� 5G      $
��auto �6    �� 5H      $
��auto �6     5J      �� 5K      $
��auto �6#   $ FirstColumn��60   �� 5L      $
��auto �6#   $ SecondColumn��60   .+�5O      �� $��0��6   $��0��6%   $��
Start date��65   �� 5P      $��0��6   $��1��6%   $��End date��65   $��10 0 0 0q�6E   (  "System.Windows.Controls.DatePicker  5R      $��1��6   $��0��5S      $��0 5 0 0q�5U      
�������$��30��5W         SelectedDate 5T      �� *	StartDate+$ PropertyChanged=�5W        5Y      $��1��6   $��1��6&   
�������$��10 5 0 0q�6�    6I   �� *	EndDate+$ PropertyChanged=�6�   5Z      �� 5\   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��0 25 0 0q�6;   .+�5]      ��   DefaultButtonStyle#��[ 6   $��Submit��6A   ��6R   �� *SubmitCommand+�� 5^      #��[ 6   $��Cancel��6A   $��15 0 0 0q�6t   ��6R   �� *CancelCommand+6t   5_      5`      5a      