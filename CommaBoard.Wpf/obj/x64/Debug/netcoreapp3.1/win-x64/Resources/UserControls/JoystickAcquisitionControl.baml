   M S B A M L   `   `   `  ����I  ECommaBoard.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CommaBoard.Wpf.Resources.UserControls%CommaBoard.Wpf.Resources.UserControls  5      F    @CommaBoard.Wpf.Resources.UserControls.JoystickAcquisitionControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:CommaBoard.Wpf.Resources.UserControls     5        � 	Resources  5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $= 7/CommaBoard.Wpf;component/Resources/Styles/Buttons.xaml?�6%   5      �� 5      $@ :/CommaBoard.Wpf;component/Resources/Styles/TextStyles.xaml?�6%   5      %    5      .��5      � ���#1A384C$��5q�6     � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5       $
��auto �6   �� 5!      $
��auto �6   .+�5$   
   ��    DisplayTextBlock#���   6   $��0��6?   $��0��6L   $��2��6\   $��Center=�6p   $��Joystick HID Settings��6�   �� 5&   
   $��1��6   $��0��6   $��2��6.     SettingsButton#��[ 6C   $!��Search For Attached Devices��6k   ��6�   ��  �� Path$ SearchForDevicesCommand��� 5)   
   #���   6   $��2��6?   $��0��6L   $��2��6\   $/��)Available HID Joystick found after search��6p   �� 5+   
   #���   6   $��3��6?   $��0��6L   $��2��6\   $	��350��6�   $��16(�6�   ��6p   �� *JoystickName+6�   �� 5-   
   #���   6   $��4��6?   $��0��6L   $��Auto detect Joystick��6\   �� 5/   
     SettingsCheckBox#���  6   $��4��6>   $��1��6K    d� 	IsChecked 6[   �� *JoystickRequired+ � LayoutTransform 50      �� 51       �� ScaleX$ 2Q�6!   	 �� ScaleY$	 2Q�6,   53      �� 55   
   $��5��6   $��0��6   $��2��6.   #��[ 6C   $��Save HID Joystick Values��6k   ��6�   �� $ SaveDeviceCommand�58      59      