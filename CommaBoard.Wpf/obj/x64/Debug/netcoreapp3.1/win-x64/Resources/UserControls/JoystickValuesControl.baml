   M S B A M L   `   `   `  ����I  ECommaBoard.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CommaBoard.Wpf.Resources.UserControls%CommaBoard.Wpf.Resources.UserControls  5      A    ;CommaBoard.Wpf.Resources.UserControls.JoystickValuesControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:CommaBoard.Wpf.Resources.UserControls     5        � 	Resources  5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $= 7/CommaBoard.Wpf;component/Resources/Styles/Buttons.xaml?�6%   5      �� 5      $@ :/CommaBoard.Wpf;component/Resources/Styles/TextStyles.xaml?�6%   5      %    5      .��5      � ���#1A384C$��5q�6     � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $
��auto �6   �� 5#      $
��auto �6   �� 5$      $��* �6   .+�5'   
   ��    DisplayTextBlock#���   6   $��0��6?   $��0��6L   $��5��6\   $��Joystick Range Values��6p   $��Center=�6�   �� 5)   
   #���   6   $��1��6?   $��0��6L   $��
Min. Input��6\   �� 5+   
   $��1��6   $��1��6     SettingsTextBox#���  6e   ${�False��6�   ��6/   �� *JstickMinInput.IntValue+ �� Mode$ TwoWay=�6�   �� 5-   
   #���   6   $��2��6?   $��0��6L   $��
Max. Input��6\   �� 5/   
   $��2��6   $��1��6   #���  6e   ${�False��6�   ��6/   �� *JstickMaxInput.IntValue+$ TwoWay=�6�   �� 51   
   #���   6   $��1��6?   $��3��6L   $��Min. Output��6\   �� 53   
   $��1��6   $��4��6   #���  6f   ${�False��6�   ��6/   �� *JstickMinOutput.IntValue+$ TwoWay=�6�   �� 55   
   #���   6   $��2��6?   $��3��6L   $��Max. Output��6\   �� 57   
   $��2��6   $��4��6   #���  6f   ${�False��6�   ��6/   �� *JstickMaxOutput.IntValue+$ TwoWay=�6�   �� 59   
   #���   6   $��3��6?   $��0��6L   $��Message Delay��6\   �� 5;   
   $��3��6   $��1��6   #���  6i   ��6/   �� *JstickMessageDelay.IntValue+$ TwoWay=�6i   �� 5=   
   #���   6   $��3��6?   $��3��6L   $��Joystick Required��6\   �� 5?   
     SettingsCheckBox#���  6   $��3��6>   $��4��6K    d� 	IsChecked 6[   �� *JoystickRequired+ � LayoutTransform 5@      �� 5A       �� ScaleX$ 2Q�6!   	 �� ScaleY$	 2Q�6,   5C      �� 5F   
   $��4��6   $��0��6   $��2��6.     SettingsButton#��[ 6D   $��Save Joystick Values��6l   ��6�   �� 
 �� Path$
 SaveJoystickValuesCommand�5I      5J      