   M S B A M L   `   `   `  ����I  ECommaBoard.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CommaBoard.Wpf.HelperCommaBoard.Wpf.Helper  5      K GCommaBoard.Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.StoreCommaBoard.Store.Static 5      ]3clr-namespace:CommaBoard.Wpf.Resources.UserControls%CommaBoard.Wpf.Resources.UserControls  5      ;    5CommaBoard.Wpf.Resources.UserControls.PlaybackControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2cv#clr-namespace:CommaBoard.Wpf.Helper     5      Olib?clr-namespace:CommaBoard.Store.Static;assembly=CommaBoard.Store     5      Elocal3clr-namespace:CommaBoard.Wpf.Resources.UserControls     5        � 	Resources  5       �� Source�� 5   
   $E ?/CommaBoard.Wpf;component/Resources/Styles/CommaBoardStyle.xaml?�6   %    5      .��5      ��    
GridBorder#��[  6   ._�5   
   �   	PanelGrid#��[ 6    � ColumnDefinitions 5      �� 5      $��* �6   �� 5      $
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
��auto �6   �� 5%      $
��auto �6   �� 5&      $
��auto �6   �� 5'      $
��auto �6     5*   
   6   0CommaBoard.Wpf.Helper.BooleanVisibilityConverter  BooleanConverter��%   &	         5+      6,   5,      .+�5.      �   PanelHeaderGrid#��[ 6   $��1��6<   $��1��6I   $��2��6Y   .+�5/      ��   ControlTitleBlock#��[ 6   $��PLAYBACK ASSISTANT��6H   50      �� 51        ControlSubHeadingBlock#��[ 6   $��Play or Pause Video��6I   $��2��6d   $��1��6q   $��Center=�6�   �� 53      #��[ 6   $��Toggle Sync��6I   $��2��6\   $��2��6i   $��Center=�6z   �� 55        Type03ControlButton#��[ 6   $��1��6B   $��3��6R   $��PLAY / PAUSE��6`   $��sc_PlayPause��6�   ��6w   ��  �� Path$ CommaBoardButtonCommand�6�   �� 57      #��[ 6   $��2��6B   $��3��6R   $��TOGGLE SYNC��6`   $��sc_Sync��6�   ��6v   �� $ CommaBoardButtonCommand�6�   �� 59      #��[ 6   $$��Slow down or speed up playback��6I   $��4��6o   $��1��6|   $��2��6�   $��Center=�6�   �� 5;   
   #��[ 6   $��1��6>   $��5��6N   $��	SLOW
DOWN��6\   $��sc_SlowDownPlayback��6�   ��6t   �� $ CommaBoardButtonCommand�6�   �� 5=   
   #��[ 6   $��2��6>   $��5��6N   $��SPEED
   UP��6\   $��sc_SpeedUpPlayback��6�   ��6v   �� $ CommaBoardButtonCommand�6�   �� 5@   
   #��[ 6   $'��!Previous and next recorded chunks��6E   $��6��6n   $��1��6{   $��2��6�   $��Center=�6�   �� 5B   
   #��[ 6   $��1��6>   $��7��6N   $��PREVIOUS
  CHUNK��6\   $��sc_PreviousChunk��6�   ��6{   �� $ CommaBoardButtonCommand�6�   �� 5D   
   #��[ 6   $��2��6>   $��7��6N   $�� NEXT
CHUNK��6\   $��sc_NextChunk��6�   ��6v   �� $ CommaBoardButtonCommand�6�   �� 5G   
   #��[ 6   $%��Archive selection start and end��6E   $��8��6l   $��1��6y   $��2��6�   $��Center=�6�   �� 5I   
   #��[ 6   $��1��6>   $��9��6N   $��ARCHIVE
  START��6[   $��sc_ArchiveStart��6�   ��6y   �� $ CommaBoardButtonCommand�6�   �� 5K   
   #��[ 6   $��2��6>   $��9��6N   $��ARCHIVE
   END��6[   $��sc_ArchiveEnd��6�   ��6x   �� $ CommaBoardButtonCommand�6�   5N      5O      5P      