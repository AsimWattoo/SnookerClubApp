   M S B A M L   `   `   `  ����I  ESnookerClubApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SnookerClubAppSnookerClubApp  5      E'clr-namespace:SnookerClubApp.ConvertersSnookerClubApp.Converters  5
      !    SnookerClubApp.TableDisplay   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:SnookerClubApp     5      =	converter'clr-namespace:SnookerClubApp.Converters     5
      $��10q�5	      $	��200��5      $	��260��5      .��5      � -   5        
�������  � Cursor$
  Hand��5      z�5   
   �� 5       �� ScaleX$ 1Q�6    �� ScaleY$ 1Q�6(   -   5        	transform��5   3    � Triggers 5   
   :� 5       :� RoutedEvent$ 
MouseEnter��6   .[�5      �� .��5      �� .��5      W�  g� Duration$ 0:0:0.2D�6*   	 W� To 1.025   )    �� TargetProperty$ ScaleX�5   )    �� 
TargetName$ 	transform��5   )   W� 5      $ 0:0:0.2D�6*    1.025   )   $ ScaleY�5   )   $ 	transform��5   )   5       5!      5"      :� 5#      $ 
MouseLeave��6   .[�5$      �� .��5%      �� .��5&      W� $ 0:0:0.2D�6*    15'   )   $ ScaleX�5(   )   $ 	transform��5)   )   W� 5*      $ 0:0:0.2D�6*    15+   )   $ ScaleY�5,   )   $ 	transform��5-   )   5.      5/      50      .+�53   
   �� 	 �� CornerRadius$	 20��6   
�������
 J� Effect
 54      3  -System.Windows.Media.Effects.DropShadowEffect  55         
BlurRadius$ 30Q�6#      ShadowDepth$ 2Q�56         Opacity$	 0.1Q�57      59      � 5;   
   $��0 0 0 10q�6    � RowDefinitions 5<      �� 5=      $��2* �6    �� 5>      $��* �6    �� 5?      $��* �6    �� 5@      $
��Auto �6    .+�5C      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5D      $��Center=�5E      .+�5F      �� $��Table��6   $��SemiBold"�5G      $��30(�5H      �� 5I      $��5 0 0 0q�5J      $��SemiBold"�5K      $��30(�5L      ��5I      �� *Number+5L      5M      �� 5O      $��1��6   $��Center=�5Q      $��Center=�5R      $��20(�5S      $��light"�5T      ��5P      �� *CurrentDayRate+ �� 	Converter .   (SnookerClubApp.Converters.PriceConverter  5T      �� 5V      $��2��6   $��Center=�5W      $��Center=�5X       �� Padding$
 15 3q�5Y      $	 15��5Z      ��5[      �� 5\       �� Opacity$	 0.1Q�6r    �� Color 6&   �� *Status+ ;   5SnookerClubApp.Converters.TableStatusToColorConverter  6r   ._�5^      �� $��20(�64   ��6   �� *Status+��6B   �� *Status+ ;   5SnookerClubApp.Converters.TableStatusToBrushConverter  5_      5a      5b      5c      