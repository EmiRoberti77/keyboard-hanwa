   M S B A M L   `   `   `  ����I  ECommaBoard.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CommaBoard.Wpf.HelperCommaBoard.Wpf.Helper  5      K GCommaBoard.Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.StoreCommaBoard.Store.Static 5      ]3clr-namespace:CommaBoard.Wpf.Resources.UserControls%CommaBoard.Wpf.Resources.UserControls  5      =    7CommaBoard.Wpf.Resources.UserControls.LiveButtonControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2cv#clr-namespace:CommaBoard.Wpf.Helper     5      Olib?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.Store     5      Elocal3clr-namespace:CommaBoard.Wpf.Resources.UserControls     5        � 	Resources  5       �� Source�� 5   
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
��auto �6   �� 5$      $
��auto �6   .+�5'      �   PanelHeaderGrid#��[ 6   $��1��6<   $��1��6I   $��2��6Y   .+�5(      ��   ControlTitleBlock#��[ 6   $��MONITOR CONTROLS��6H   5)      �� 5+   
     ControlSubHeadingBlock#��[ 6   $#��Cycle through the Layout tabs��6E   $��2��6j   $��1��6w   $��3��6�   $��Center=�6�   �� 5-   
     Type01ControlButton#��[ 6   $��1��6>   $��3��6N   $��< PREV
 LAYOUT��6\   ��6|   ��  �� Path$ PreviousLayoutCommand�{�6�   �� ,  &CommaBoard.Store.Static.ControlVisible   	UCVisible �� Source# Z $ LayoutMoveEnabled��� 5/   
   #��[ 6   $��2��6>   $��3��6N   $��  NEXT >
 LAYOUT��6\   ��6{   �� $ NextLayoutCommand�{�6�   �� # Z $ LayoutMoveEnabled��� 51   
   #��[ 6   $+��%Cycle through the Cameras in a Layout��6E   $��4��6r   $��1��6   $��3��6�   $��Center=�6�   �� 53   
   #��[ 6   $��1��6>   $��5��6N   $��< PREV
 CAMERA��6\   $��sc_PrevCamera��6�   ��6|   �� $ CommaBoardButtonCommand�6�   �� 55   
   #��[ 6   $#��Toggle full screen properties��6E   $��6��6j   $��1��6w   $��3��6�   $��Center=�6�   �� 57   
   #��[ 6   $��2��6>   $��5��6N   $��  NEXT >
CAMERA��6\   $��sc_NextCamera��6�   ��6z   �� $ CommaBoardButtonCommand�6�   �� 59   
   #��[ 6   $��1��6>   $��7��6N   $��    TOGGLE
FS MONITOR��6\   $��sc_ToggleFSMonitor��6�   ��6�   �� $ CommaBoardButtonCommand�6�   �� 5;   
   #��[ 6   $��2��6>   $��7��6N   $��    TOGGLE
FS CAMERA��6\   $��sc_ToggleFSCamera��6�   ��6   �� $ CommaBoardButtonCommand�6�   �� 5=   
   #��[ 6   $��Toggle PTZ and Dewarping��6E   $��8��6e   $��1��6r   $��3��6�   $��Center=�6�   �� 5?   
   #��[ 6   $��1��6>   $��9��6N   $��TOGGLE
    PTZ��6[   $��sc_TogglePTZ��6�   ��6x   �� $ CommaBoardButtonCommand�6�   �� 5A   
   #��[ 6   $��2��6>   $��9��6N   $��TOGGLE
DEWARP��6[   $��sc_ToggleDewarp��6�   ��6w   �� $ CommaBoardButtonCommand�6�   5C      5D      5E      