   M S B A M L   `   `   `  ����K  GCommaBoard.Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.StoreCommaBoard.Store.Static  5       CommaBoard.WpfA   ;CommaBoard.Wpf.Resources.UserControls.TabItemCamerasControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]Syncfusion.SfGrid.WPF, Version=19.4310.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a	 ]Syncfusion.Shared.WPF, Version=20.1310.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89`
 \Syncfusion.Tools.Wpf, Version=19.4310.0.53, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf   	 
 5      Olib?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.Store   	 
 5        � 	Resources  5
       �� Source�� 5   
   $E ?/CommaBoard.Wpf;component/Resources/Styles/CommaBoardStyle.xaml?�6   %    5      .��5      � ���#1A384C$��5q�6     � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��1��6!   $��2��61   $��Available Cameras��6E      SettingsTitleTextBlock#���   6^   �� 5!   
   $��1��6   $��1��6$   $��2��64   .��5"      (  "Syncfusion.UI.Xaml.Grid.SfDataGrid  -   5          Name$ AvailableCamerasDataGrid��5"   $   $	��350��6H   $	��400��6T   (  "Syncfusion.UI.Xaml.Grid.SfGridBase   	RowHeight$ 40Q�6a      AutoGenerateColumns$ False��5&         AllowSorting$
 True��5'         LiveDataUpdateMode$ AllowDataShaping=�5(      	   ItemsSource	 5#      �� "   CommaBoard.Store.Static.Wave
   Grid �� Source# Z
  �� Path$ CameraControlCameraList� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   SelectedIndex 5$      �� # Z
 $  CameraControlSelectedIndex�$ TwoWay=�$ PropertyChanged=�   SelectedItem 5%      �� # Z
 $! CameraControlSelectedCamera�$ TwoWay=�$ PropertyChanged=�   SortColumnDescriptions 5*      3  -Syncfusion.UI.Xaml.Grid.SortColumnDescription     
ColumnName$ 	logicalId��67      SortDirection$ 	Ascending=�6N      Columns 5-      /  )Syncfusion.UI.Xaml.Grid.GridNumericColumn  ,  &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ Id��63      MappingName$ 	logicalId��6C      NumberDecimalDigits$ 0��6[      Width$ 60Q�6s      TextAlignment$ Center=�6~      AllowSorting$
 true��6�   ,  &Syncfusion.UI.Xaml.Grid.GridTextColumn  5.      $ Camera Name��60   $
 name��6I   $	 150Q�6\     5/      $ 	Camera IP��60   $	 url��6G   $	 150Q�6Y   51      52      �� 54   
     MiniSettingsButton#��[ 6   $��2��6=   $��2��6J   $��Refresh List��6Z   ��6q   �� $ RefreshCamerasCommand�58      59      