   M S B A M L   `   `   `  ����K  GCommaBoard.Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.StoreCommaBoard.Store.Static  5      I ECommaBoard.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CommaBoard.Wpf.Resources.UserControls%CommaBoard.Wpf.Resources.UserControls 5      =#clr-namespace:CommaBoard.Wpf.HelperCommaBoard.Wpf.Helper 5      =#clr-namespace:CommaBoard.Wpf.HelperCommaBoard.Wpf.Helper 5	      C   =CommaBoard.Wpf.Resources.UserControls.ServerConnectionControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olib?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.Store     5      Elocal3clr-namespace:CommaBoard.Wpf.Resources.UserControls     5      2cv#clr-namespace:CommaBoard.Wpf.Helper     5      2pw#clr-namespace:CommaBoard.Wpf.Helper     5	        � 	Resources  5       �� Source�� 5   
   $E ?/CommaBoard.Wpf;component/Resources/Styles/CommaBoardStyle.xaml?�6   %    5      .��5      ��    
GridBorder#��[  6   ._�5   
   �   	PanelGrid#��[ 6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6     � ColumnDefinitions 5!      �� 5"      $��* �6#   �� 5#      $
��auto �6#   �� 5$      $
��auto �6#   �� 5%      $��* �6#   .+�5(      ��   SettingsTitleBlock#���  6   $��1��6E   $��1��6R   $��4��6b   $��Center=�6v   $-��'Wisenet WAVE Server Connection Settings��6�   � 5*      $��2��6   $��1��6    $��2��60    5+      �� 5,      $
��auto �6'   �� 5-      $
��auto �6'   �� 5.      $
��auto �6'   �� 5/      $
��auto �6'   �� 50      $
��auto �6'   �� 51      $
��auto �6'   .+�54      ��   SettingsBlock#���  6   $��0��6D   $��Center=�6T   $��Full IP��6q   �� 55      #���  6   $��1��6D   $��Center=�6T   $��https://��6q   �� 56      #���  6   $��2��6D   $��Center=�6T   ��6q   ��  �� Path$ WaveIP.StringValue��� 57      #���  6   $��3��6D   $��Center=�6T   $��:��6q   �� 58      #���  6   $��4��6D   $��Center=�6T   ��6q   �� $ WavePort.StringValue��� 59      #���  6   $��5��6D   $��Center=�6T   $��/��6q   5:      �� 5<      #���  6   $��3��6@   $��1��6M   $��
IP Address��6_   �� 5>      $��3��6   $��2��6#     SettingsTextBox#���  6�   ��63   �� $ WaveIP.StringValue� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5@      #���  6   $��4��6@   $��1��6M   $
��Port��6_   �� 5B      $��4��6   $��2��6#   #���  6�   ��63   �� $ WavePort.StringValue�$ TwoWay=�$ PropertyChanged=�6�   �� 5D      #���  6   $��5��6@   $��1��6M   $��Username��6]   �� 5F      $��5��6   $��2��6#   #���  6�   ��63   �� $ WaveUsername.StringValue�$ TwoWay=�$ PropertyChanged=�6�   �� 5H      #���  6   $��6��6@   $��1��6M   $��Password��6]   G� 5J      -   5         G�Name$ PasswordBox��5J   7   $��6��6   $��2��6'   0  *CommaBoard.Wpf.Helper.PasswordBoxAssistant   BindPassword$
 true��6L     SettingsPasswordBox#���  6�   	   BoundPassword	 6y   �� $ WavePassword.StringValue�$ TwoWay=�$ PropertyChanged=�6�   �� 5L      $��8��6   $��1��6"   $��2��62     SettingsButton#��[ 6F   $%��Save Server Connection Settings��6n   ��6�   �� $ SaveSettingsCommand�5O      5P      5Q      