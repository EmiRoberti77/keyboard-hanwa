   M S B A M L   `   `   `  ����K  GCommaBoard.Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.StoreCommaBoard.Store.Static  5      I ECommaBoard.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CommaBoard.Wpf.Resources.UserControls%CommaBoard.Wpf.Resources.UserControls 5      =#clr-namespace:CommaBoard.Wpf.HelperCommaBoard.Wpf.Helper 5      =#clr-namespace:CommaBoard.Wpf.HelperCommaBoard.Wpf.Helper 5	      ?   9CommaBoard.Wpf.Resources.UserControls.CreateLayoutControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olib?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.Store     5      Elocal3clr-namespace:CommaBoard.Wpf.Resources.UserControls     5      2cv#clr-namespace:CommaBoard.Wpf.Helper     5      2pw#clr-namespace:CommaBoard.Wpf.Helper     5	        � 	Resources  5       �� Source�� 5   
   $E ?/CommaBoard.Wpf;component/Resources/Styles/CommaBoardStyle.xaml?�6   %    5      .��5      ��    
GridBorder#��[  6   ._�5   
   �   	PanelGrid#��[ 6    � RowDefinitions 5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6     5"   
   6  0CommaBoard.Wpf.Helper.BooleanVisibilityConverter  BooleanConverter��%   &	         5#      6,   5$      .+�5'   
   ��   DisplayBlock#���  6   $��0��6;   $��1��6H   $��2��6X   $��Create A New layout��6l   $��Center=�6�   �� 5)   
     SettingsBlock#���  6   $��1��6<   $��1��6I   $��2��6Y   $5��/You can add Cameras to this layout once created��6m   �� 5+   
   #���  6   $��2��6;   $��1��6H   $��Layout Name��6X   �� 5-   
   $��2��6   $��2��6     SettingsTextBox#���  6/   ��6Y   �� "   CommaBoard.Store.Static.Wave   Grid �� Source# Z  �� Path$ NewLayoutName� �� UpdateSourceTrigger$ PropertyChanged=��� 5/   
   #���  6   $��3��6;   $��1��6H   $��
Logical Id��6X   �� 51   
     DisplayLabel#���  6   $��3��68   $��2��6E   ��6U   �� # Z $ NewLayoutLogicalId�$ PropertyChanged=��� 53   
   $��6��6   $��1��6     MiniSettingsButton#��[ 60   $��Create��6\   $��CreateLayout��6�   ��6m   �� $ CommaBoardButtonCommand�6�   �� 55   
   $��6��6   $��2��6   #��[ 60   $��Cancel��6\   ��6m   �� $ CancelCreateCommand�58      59      5:      