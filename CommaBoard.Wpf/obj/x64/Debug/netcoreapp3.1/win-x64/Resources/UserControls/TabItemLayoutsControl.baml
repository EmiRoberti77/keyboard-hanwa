   M S B A M L   `   `   `  ����K  GCommaBoard.Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.StoreCommaBoard.Store.Static  5      I ECommaBoard.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CommaBoard.Wpf.Resources.UserControls%CommaBoard.Wpf.Resources.UserControls 5      A   ;CommaBoard.Wpf.Resources.UserControls.TabItemLayoutsControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]Syncfusion.SfGrid.WPF, Version=19.4310.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a	 ]Syncfusion.Shared.WPF, Version=20.1310.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89`
 \Syncfusion.Tools.Wpf, Version=19.4310.0.53, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf   	 
 5      Olib?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.Store   	 
 5      Elocal3clr-namespace:CommaBoard.Wpf.Resources.UserControls   	 
 5        � 	Resources  5       �� Source�� 5   
   $E ?/CommaBoard.Wpf;component/Resources/Styles/CommaBoardStyle.xaml?�6   %    5      .��5      � ���#1A384C$��5q�6     � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   .+�5$   
   �� $��1��6   $��1��6!   $��2��61   $��Available Layouts��6E      SettingsTitleBlock#���   6^   �� 5&   
   $��2��6   $��1��6$   $��4��64   .��5'      (  "Syncfusion.UI.Xaml.Grid.SfDataGrid  -   5          Name$ AvailableLayoutsDataGrid��5'   $   $	��180��6H   $	��350��6U   (  "Syncfusion.UI.Xaml.Grid.SfGridBase   	RowHeight$ 50Q�6a      AutoGenerateColumns$ False��5*         AllowSorting$
 True��5+         AllowDraggingRows$
 True��5,      	 J� 	AllowDrop$
	 True��5-      
   LiveDataUpdateMode$
 AllowDataShaping=�5.         ItemsSource 5(      �� "   CommaBoard.Store.Static.Wave   Grid �� Source# Z  �� Path$ LayoutControlLayoutList� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   SelectedItem 5)      �� # Z $! LayoutControlSelectedLayout�$ TwoWay=�$ PropertyChanged=�   SortColumnDescriptions 50      3  -Syncfusion.UI.Xaml.Grid.SortColumnDescription     
ColumnName$ 	logicalId��67      SortDirection$ 	Ascending=�6N      Columns 53      /  )Syncfusion.UI.Xaml.Grid.GridNumericColumn  ,  &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ Id��63      MappingName$ 	logicalId��6C      NumberDecimalDigits$ 0��6[      Width$ 60Q�6s      TextAlignment$ Center=�6~      AllowSorting$
 true��6�   ,  &Syncfusion.UI.Xaml.Grid.GridTextColumn  54      $ Layout Name��60   $
 name��6I   $	 300Q�6\   56      57      �� 59   
     MiniSettingsButton#��[ 6   $��2��6=   $��3��6M   $��Refresh List��6Z   ��6q   �� $ RefreshLayoutsCommand��� 5;   
   #���   6   $��4��6A   $��1��6N   $��2��6^   $��Selected Layout��6r   $��Center=�6�   �� 5=   
     SettingsBlock#���  6   $��5��6<   $��1��6I   $��Logical Id:��6Z   �� 5>   
   #���  6   $��5��6<   $��2��6I   ��6Z   �� # Z $+ %LayoutControlSelectedLayout.logicalId��� 5@   
   #���  6   $��6��6<   $��1��6I   $��Name:��6Z   �� 5A   
   #���  6   $��6��6<   $��2��6I   $��3��6Y   ��6m   �� # Z $&  LayoutControlSelectedLayout.name��� 5C   
   $��7��6   $��1��6$   $��4��64   .��5D        -   5        $ SelectedLayoutDataGrid��5D   $   $	��180��6F   $	��350��6S   $ 40Q�6_   $ False��5G       5E      �� # Z $ LayoutControlCameraList�$ TwoWay=�$ PropertyChanged=� 5F      �� # Z $! LayoutControlSelectedCamera�$ TwoWay=�$ PropertyChanged=� 5I        $ 	logicalId��67    5L        $ Id��63   $ 	logicalId��6C   $ 0��6[   $ 60Q�6s   $ Center=�6~   $
 true��6�     5M      $ Camera Name��60   $
 name��6I   $	 150Q�6\     5N      $ 	Camera IP��60   $	 url��6G   $	 150Q�6Y   5P      5Q      5T      5U      