   M S B A M L   `   `   `  ���� D  @Reservoom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Reservoom.ViewsReservoom.Views  ;"clr-namespace:Reservoom.ViewModelsReservoom.ViewModels  )    #Reservoom.Views.MakeReservationView   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:Reservoom.Views     9
viewmodels"clr-namespace:Reservoom.ViewModels     $��14(�.���   � IsSharedSizeScope$
  True�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��Make Reservation��   HeaderStyle#��[  � $��1��$��0 50 0 0q� �� $
��auto ��� $
��auto �.+��� $��0��$��Username���� $��1��
�������
�������$	��4 2q�$��2q�  TextBoxBaseControlTemplate#��[ $��0 5 0 0q����� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�� $��2��$��0 10 0 0q� �� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto � z� SharedSizeGroup$ FirstColumn���� $
��auto �$ SecondColumn��.+��� $��0��$��0��$��Floor No���� $��0��$��1��$��Room No��$��10 0 0 0q��� $��1��$��0��$	��4 2q�$��0 5 0 0q�$��2q�#��[ ���� *FloorNumber+$ PropertyChanged=��� $��1��$��1��$	��4 2q�$��10 5 0 0q�$��2q�#��[ ���� *
RoomNumber+$ PropertyChanged=�� $��3��$��0 10 0 0q� �� $
��auto ��� $
��auto � �� $
��auto �$ FirstColumn���� $
��auto �$ SecondColumn��.+��� $��0��$��0��$��
Start date���� $��0��$��1��$��End date��$��10 0 0 0q�(  "System.Windows.Controls.DatePicker  $��1��$��0��$��0 5 0 0q�
�������$��30��   SelectedDate �� *	StartDate+$ PropertyChanged=�  $��1��$��1��
�������$��10 5 0 0q� �� *	EndDate+$ PropertyChanged=��� $��4�� �� Orientation$ 
Horizontal=�$��0 25 0 0q�.+���   DefaultButtonStyle#��[ $��Submit������ *SubmitCommand+�� #��[ $��Cancel��$��15 0 0 0q����� *CancelCommand+