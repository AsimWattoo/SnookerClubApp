   M S B A M L   `   `   `  ���� I  ESnookerClubApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SnookerClubAppSnookerClubApp       SnookerClubApp.NumberInput   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:SnookerClubApp     -     >�Name$
  Root��.���� $��1q����#eee �� CornerRadius$ 5��._�� 
������� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� -   $��Center=�$��Center=�$��0q�
�������$
��10 0q����� *Time+ �� ElementName$
 Root������ *
FontSize+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType UserControl� $��1�� � RowDefinitions �� $��* ��� $��* �.+��� -    ��Name$ btnUp��$	��5 1q�	 �� Padding$		 3 2q����#eee$ 2��
 � Cursor$

 Hand�� � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .����  g� Duration$ 0:0:0.2D�	 �� To Gray �� TargetProperty$ Background.Color��� $ 0:0:0.2D�	 White �� 
TargetName$ 	upBtnText��$ Foreground.Color�:� $ 
MouseLeave��.[��� .���� .���� $ 0:0:0.2D� #eee$ Background.Color��� $ 0:0:0.2D�	 black$ 	upBtnText��$ Foreground.Color�._��� -    ��Name$ 	upBtnText��   AngleUpIcon#��[  $��Center=�  FontAwesome_Solid#��[ �� -   $ btnDown��$	��5 1q�$		 3 2q�$��1�����#eee$ 2��$

 Hand�� :� $ 
MouseEnter��.[��� .���� .���� $ 0:0:0.2D� Gray$ Background.Color��� $ 0:0:0.2D�	 White$ downBtnText��$ Foreground.Color�:� $ 
MouseLeave��.[��� .���� .���� $ 0:0:0.2D� #eee$ Background.Color��� $ 0:0:0.2D�	 black$ downBtnText��$ Foreground.Color�._��� -   $ downBtnText��  AngleDownIcon#��[ $��Center=�#��[ 