   M S B A M L   `   `   `  ����I  ECommaBoard.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CommaBoard.Wpf.Resources.UserControls%CommaBoard.Wpf.Resources.UserControls  5      <    6CommaBoard.Wpf.Resources.UserControls.NumberPadControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      ?local3clr-namespace:CommaBoard.Wpf.Resources.UserControls  5        � 	Resources  5
       �� Source�� 5   
   $E ?/CommaBoard.Wpf;component/Resources/Styles/CommaBoardStyle.xaml?�6   %    5      .��5      ��    
GridBorder#��[  6   ._�5   
   �   	PanelGrid#��[ 6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $
��auto �6   .+�5%      �   PanelHeaderGrid#��[ 6   $��1��6<   $��1��6I   $��4��6Y   .+�5&      ��   ControlTitleBlock#��[ 6   $��NUMBER PAD CONTROL��6H   5'      � 5)      $��2��6   $��1��6    $��3��60    5*      �� 5+      $
��auto �6#   �� 5,      $
��auto �6#   .+�5.      ��   DigitAncillaryButton#��[ 6   $��0��6C   $��LAYOUT��6U   $��Layout��6�   ��6f   ��  �� Path$ CommaBoardButtonCommand�6�   �� 5/      #��[ 6   $��1��6C   $��CAMERA��6U   $��Camera��6�   ��6f   �� $ CommaBoardButtonCommand�6�   50      �� 52   
     DigitButton#���  6   $��1��67   $��3��6G   $��1��6T   $��1��6�   ��6`   �� $ CommaBoardButtonCommand�6�   �� 53   
   #���  6   $��2��67   $��3��6G   $��2��6T   $��2��6�   ��6`   �� $ CommaBoardButtonCommand�6�   �� 54   
   #���  6   $��3��67   $��3��6G   $��3��6T   $��3��6�   ��6`   �� $ CommaBoardButtonCommand�6�   �� 55   
   #��[ 6   $��1��66   $��4��6F   $��4��6S   $��4��6�   ��6_   �� $ CommaBoardButtonCommand�6�   �� 56   
   #��[ 6   $��2��66   $��4��6F   $��5��6S   $��5��6�   ��6_   �� $ CommaBoardButtonCommand�6�   �� 57   
   #��[ 6   $��3��66   $��4��6F   $��6��6S   $��6��6�   ��6_   �� $ CommaBoardButtonCommand�6�   �� 58   
   #��[ 6   $��1��66   $��5��6F   $��7��6S   $��7��6�   ��6_   �� $ CommaBoardButtonCommand�6�   �� 59   
   #��[ 6   $��2��66   $��5��6F   $��8��6S   $��8��6�   ��6_   �� $ CommaBoardButtonCommand�6�   �� 5:   
   #��[ 6   $��3��66   $��5��6F   $��9��6S   $��9��6�   ��6_   �� $ CommaBoardButtonCommand�6�   �� 5;   
   #��[ 6   $��1��66   $��6��6F   $��0��6S   $��0��6�   ��6_   �� $ CommaBoardButtonCommand�6�   �� 5=   
   #��[ 6   $��2��6?   $��6��6O   $��2��6\   $��CLEAR��6r   $��Clear��6�   ��6�   �� $ CommaBoardButtonCommand�6�   �� 5>   
   #��[ 6   $��1��6?   $��7��6O   $��3��6\   $��ENTER��6q   $��Enter��6�   $	��350��6�   ��6�   �� $ CommaBoardButtonCommand�6�   5A      5B      5C      