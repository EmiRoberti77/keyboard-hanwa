   M S B A M L   `   `   `  ����I  ECommaBoard.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CommaBoard.Wpf.HelperCommaBoard.Wpf.Helper  5      K GCommaBoard.Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.StoreCommaBoard.Store.Static 5      ]3clr-namespace:CommaBoard.Wpf.Resources.UserControls%CommaBoard.Wpf.Resources.UserControls  5      7    1CommaBoard.Wpf.Resources.UserControls.MiscControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2cv#clr-namespace:CommaBoard.Wpf.Helper     5      Olib?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.Store     5      Elocal3clr-namespace:CommaBoard.Wpf.Resources.UserControls     5        � 	Resources  5       �� Source�� 5   
   $E ?/CommaBoard.Wpf;component/Resources/Styles/CommaBoardStyle.xaml?�6   %    5      .��5      ��    
GridBorder#��[  6   ._�5   
   �   	PanelGrid#��[ 6    � ColumnDefinitions 5   
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
��auto �6   �� 5!      $
��auto �6   �� 5"      $
��auto �6   �� 5#      $
��auto �6     5&   
   6   0CommaBoard.Wpf.Helper.BooleanVisibilityConverter  BooleanConverter��%   &	         5'      6,   5(      .+�5*      �   PanelHeaderGrid#��[ 6   $��1��6<   $��1��6I   $��2��6Y   .+�5+      ��   ControlTitleBlock#��[ 6   $��MISCELLANEOUS CONTROLS��6H   5,      �� 5-        ControlSubHeadingBlock#��[ 6   $%��Grab image from selected Camera��6I   $��2��6p   $��1��6}   $��2��6�   $��Center=�6�   �� 5/   
     Type02ControlButton#��[ 6   $��1��6>   $��3��6N   $�� GRAB
IMAGE��6\   $��sc_GrabImage��6�   ��6v   ��  �� Path$ CommaBoardButtonCommand�6�   �� 51   
   #��[ 6   $��2��6>   $��3��6N   $�� SAVE
IMAGE��6\   $��sc_SaveImage��6�   ��6v   �� $ CommaBoardButtonCommand�6�   �� 54   
   #��[ 6   $'��!Record video from selected Camera��6E   $��4��6n   $��1��6{   $��2��6�   $��Center=�6�   �� 56   
   #��[ 6   $��1��6>   $��5��6N   $��     START
RECORDING��6\   ��6   �� $ StartRecordingCommand�y�6�   �� ,  &CommaBoard.Store.Static.ControlVisible   	UCVisible �� Source# Z $ StartRecordingEnabled� �� 	Converter# [ �� 58   
     Type04ControlButton#��[ 6   $��1��6>   $��5��6N   $��     STOP
RECORDING��6\   ��6~   �� $ StopRecordingCommand�y�6�   �� # Z $ StopRecordingEnabled�# [ �� 5:   
   #��[ 6   $��2��6>   $��5��6N   $��     SAVE
RECORDING��6\   $��sc_SaveRecording��6�   ��6~   �� $ CommaBoardButtonCommand�6�   �� 5=   
   #��[ 6   $��Show device list��6E   $��6��6]   $��1��6j   $��2��6z   $��Center=�6�   �� 5?   
   #��[ 6   $��1��6>   $��7��6N   $��
OPEN
 INFO��6\   $��sc_OpenInfo��6�   ��6u   �� $ CommaBoardButtonCommand�6�   �� 5A   
   #��[ 6   $��2��6>   $��7��6N   $��CLOSE
 INFO��6\   $��sc_CloseInfo��6�   ��6v   �� $ CommaBoardButtonCommand�6�   �� 5D   
   #��[ 6   $%��Increase/decrease system volume��6E   $��8��6l   $��1��6y   $��2��6�   $��Center=�6�   � 5F   
   $��9��6   $��1��6   $��2��6,    5G      �� 5H      $
��auto �6#   �� 5I      $
��auto �6#   �� 5J      $
��auto �6#   .+�5M      ��   Type02ControlButtonSmall#��[ 6   $��0��6G   $��VOL. -��6W   $��sc_VolumeMinus��6�   ��6h   �� $ CommaBoardButtonCommand�6�   �� 5O      #��[ 6   $��1��6G   $
��MUTE��6W   $��sc_VolumeMute��6�   ��6f   �� $ CommaBoardButtonCommand�6�   �� 5Q      #��[ 6   $��2��6G   $��VOL. +��6W   $��sc_VolumePlus��6�   ��6h   �� $ CommaBoardButtonCommand�6�   5S      5V      5W      5X      