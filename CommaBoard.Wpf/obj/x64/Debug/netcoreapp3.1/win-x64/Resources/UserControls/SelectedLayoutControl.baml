   M S B A M L   `   `   `  ����K  GCommaBoard.Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.StoreCommaBoard.Store.Static  5      I ECommaBoard.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CommaBoard.Wpf.Resources.UserControls%CommaBoard.Wpf.Resources.UserControls 5      A   ;CommaBoard.Wpf.Resources.UserControls.SelectedLayoutControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]Syncfusion.SfGrid.WPF, Version=19.4310.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a	 ]Syncfusion.Shared.WPF, Version=20.1310.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89`
 \Syncfusion.Tools.Wpf, Version=19.4310.0.53, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf   	 
 5      Olib?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.Store   	 
 5      Elocal3clr-namespace:CommaBoard.Wpf.Resources.UserControls   	 
 5        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $= 7/CommaBoard.Wpf;component/Resources/Styles/Buttons.xaml?�6%   5      �� 5      $@ :/CommaBoard.Wpf;component/Resources/Styles/TextStyles.xaml?�6%   5      %    5      .��5      � ���#1A384C$��5q�6     � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $
��auto �6   �� 5#      $
��auto �6   �� 5$      $
��auto �6   �� 5%      $
��auto �6   �� 5&      $
��auto �6   �� 5'      $
��auto �6   .+�5*   
   ��    SettingsTitleTextBlock#���   6   $��0��6E   $��1��6R   $��2��6b   $��Selected Layout��6v   $��Center=�6�   �� 5,   
     SettingsTextBlock#���  6   $��1��6@   $��1��6M   $��Logical Id:��6^   �� 5-   
   #���  6   $��1��6@   $��2��6M   ��6^   �� "   CommaBoard.Store.Static.Wave   Grid �� Source# Z  �� Path$+ %LayoutControlSelectedLayout.logicalId��� 5/   
   #���  6   $��2��6@   $��1��6M   $��Name:��6^   �� 50   
   #���  6   $��2��6@   $��2��6M   $��3��6]   ��6q   �� # Z $&  LayoutControlSelectedLayout.name��� 52   
   $��3��6   $��1��6$   $��4��64   .��53      (  "Syncfusion.UI.Xaml.Grid.SfDataGrid  -   5          Name$ SelectedLayoutDataGrid��53   $   $	��150��6F   (  "Syncfusion.UI.Xaml.Grid.SfGridBase	   	RowHeight$	 40Q�6S   
   AutoGenerateColumns$
 False��57         ItemsSource 54      �� # Z $ LayoutControlCameraList� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   SelectedItem 55      �� # Z $! LayoutControlSelectedCamera�$ TwoWay=�$ PropertyChanged=�   SelectedIndex 56      �� # Z $  LayoutControlSelectedIndex�$ TwoWay=�$ PropertyChanged=�   SortColumnDescriptions 59      3  -Syncfusion.UI.Xaml.Grid.SortColumnDescription     
ColumnName$ 	logicalId��67      Columns 5<      /  )Syncfusion.UI.Xaml.Grid.GridNumericColumn  ,  &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ Id��63      MappingName$ 	logicalId��6C      NumberDecimalDigits$ 0��6[      Width$ 60Q�6s      TextAlignment$ Center=�6~      AllowSorting$
 true��6�   ,  &Syncfusion.UI.Xaml.Grid.GridTextColumn  5=      $ Camera Name��60   $
 name��6I   $	 150Q�6\     5>      $ 	Camera IP��60   $	 url��6G   $	 150Q�6Y   5@      5A      �� 5C   
     MiniSettingsButton#��[ 6   $��3��6=   $��1��6M   $��2��6Z   $��Remove Camera��6n   $��RemoveCamera��6�   $
��Left=�6�   $��	20,10,0,4q�6�   ��6�   �� $ CommaBoardButtonCommand�6�   5F      5G      