   M S B A M L   `   `   `  ����I  ESnookerClubApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SnookerClubAppSnookerClubApp  5           SnookerClubApp.NumberInput   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SnookerClubApp     5      -   5          >�Name$
  Root��5	      .��5
      �� $��1q�6   ���#eee �� CornerRadius$ 5��5      ._�5   
   � 
������� � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        $��Center=�5      $��Center=�5      $��0q�5      
�������$
��10 0q�5      ��5      �� *Time+ �� ElementName$
 Root����5      �� *
FontSize+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType UserControl5      � 5      $��1��6    � RowDefinitions 5      �� 5       $��* �6$   �� 5!      $��* �6$   .+�5$      �� -   5         ��Name$ btnUp��5)      $	��5 1q�5$      	 �� Padding$		 3 2q�5%      ���#eee$ 2��5'      
 � Cursor$

 Hand��5(       � Triggers 5+      :� 5,       :� RoutedEvent$ 
MouseEnter��6'   .[�5-      �� .��5.   "   �� .��5/   &   ��  g� Duration$ 0:0:0.2D�65   	 �� To Gray50   5    �� TargetProperty$ Background.Color�51   5   �� 52   &   $ 0:0:0.2D�65   	 White53   5    �� 
TargetName$ 	upBtnText��54   5   $ Foreground.Color�55   5   56   #   57      58      :� 59      $ 
MouseLeave��6'   .[�5:      �� .��5;   "   �� .��5<   &   �� $ 0:0:0.2D�65    #eee5=   5   $ Background.Color�5>   5   �� 5?   &   $ 0:0:0.2D�65   	 black5@   5   $ 	upBtnText��5A   5   $ Foreground.Color�5B   5   5C   #   5D      5E      ._�5G      �� -   5         ��Name$ 	upBtnText��5I          AngleUpIcon#��[  5G       $��Center=�5H         FontAwesome_Solid#��[ 5J       5K      �� 5M      -   5        $ btnDown��5R      $	��5 1q�5M      $		 3 2q�5N      $��1��5O      ���#eee$ 2��5Q      $

 Hand��5T       5U      :� 5V      $ 
MouseEnter��6'   .[�5W      �� .��5X   "   �� .��5Y   &   �� $ 0:0:0.2D�65    Gray5Z   5   $ Background.Color�5[   5   �� 5\   &   $ 0:0:0.2D�65   	 White5]   5   $ downBtnText��5^   5   $ Foreground.Color�5_   5   5`   #   5a      5b      :� 5c      $ 
MouseLeave��6'   .[�5d      �� .��5e   "   �� .��5f   &   �� $ 0:0:0.2D�65    #eee5g   5   $ Background.Color�5h   5   �� 5i   &   $ 0:0:0.2D�65   	 black5j   5   $ downBtnText��5k   5   $ Foreground.Color�5l   5   5m   #   5n      5o      ._�5q      �� -   5        $ downBtnText��5s         AngleDownIcon#��[ 5q       $��Center=�5r       #��[ 5t       5u      5v      5x      5y      5z      