   M S B A M L   `   `   `  ����K  GCommaBoard.Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.StoreCommaBoard.Store.Static  5      I ECommaBoard.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CommaBoard.Wpf.Resources.UserControls%CommaBoard.Wpf.Resources.UserControls 5      9   3CommaBoard.Wpf.Resources.UserControls.CameraControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]Syncfusion.SfGrid.WPF, Version=19.4310.0.38, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=20.1310.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a	 ]Syncfusion.Shared.WPF, Version=20.1310.0.52, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89`
 \Syncfusion.Tools.Wpf, Version=19.4310.0.53, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf   	 
 5      Olib?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.Store   	 
 5      Elocal3clr-namespace:CommaBoard.Wpf.Resources.UserControls   	 
 5        � 	Resources  5       �� Source�� 5   
   $E ?/CommaBoard.Wpf;component/Resources/Styles/CommaBoardStyle.xaml?�6   %    5      .��5      ��    
GridBorder#��[  6   ._�5   
   �   	PanelGrid#��[ 6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5       �� $��0��6   $��1��6%   $��2��65   $��Available Cameras��6I     SettingsTitleBlock#���  6b   �� 5#      $��1��6   $��1��6(   $��2��68   .��5$      (  "Syncfusion.UI.Xaml.Grid.SfDataGrid  -   5          Name$ AvailableCamerasDataGrid��5$   (   $	��150��6L   (  "Syncfusion.UI.Xaml.Grid.SfGridBase   	RowHeight$ 40Q�6Y      AutoGenerateColumns$ False��5(         ItemsSource 5%      �� "   CommaBoard.Store.Static.Wave   Grid	 �� Source#	 Z 
 �� Path$
 CameraControlCameraList� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   SelectedIndex 5&      �� #	 Z $ 
 CameraControlSelectedIndex�$ TwoWay=�$ PropertyChanged=�   SelectedItem 5'      �� #	 Z $!
 CameraControlSelectedCamera�$ TwoWay=�$ PropertyChanged=�   SortColumnDescriptions 5*      3  -Syncfusion.UI.Xaml.Grid.SortColumnDescription     
ColumnName$ 	logicalId��6;      Columns 5-      /  )Syncfusion.UI.Xaml.Grid.GridNumericColumn  ,  &Syncfusion.UI.Xaml.Grid.GridColumnBase   
HeaderText$ Id��67      MappingName$ 	logicalId��6G      NumberDecimalDigits$ 0��6_      Width$ 60Q�6w      TextAlignment$ Center=�6�      AllowSorting$
 true��6�   ,  &Syncfusion.UI.Xaml.Grid.GridTextColumn  5.      $ Camera Name��64   $
 name��6M   $	 150Q�6`     5/      $ 	Camera IP��64   $	 url��6K   $	 150Q�6]   51      52      �� 54        MiniSettingsButton#��[ 6   $��2��6A   $��1��6N   $��Add To Layout��6^   $��	AddCamera��6�   ��6v   �� $
 CommaBoardButtonCommand�6�   �� 56      #��[ 6   $��2��6A   $��2��6N   $��Refresh List��6^   $��RefreshCameras��6�   ��6u   �� $
 CommaBoardButtonCommand�6�   59      5:      5;      