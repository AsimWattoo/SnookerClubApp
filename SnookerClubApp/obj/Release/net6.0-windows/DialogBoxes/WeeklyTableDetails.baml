   M S B A M L   `   `   `  ���� I  ESnookerClubApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SnookerClubAppSnookerClubApp  W0clr-namespace:SnookerClubApp.Attached_Properties"SnookerClubApp.Attached_Properties  '    !SnookerClubApp.WeeklyTableDetails   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:SnookerClubApp     ?at0clr-namespace:SnookerClubApp.Attached_Properties       � WindowStyle$
  None=� � AllowsTransparency$
 true�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Title$ WeeklyTableDetails��$	��500��$	��370�� � 	Resources '   !SnookerClubApp.WeeklyTableDetails �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Padding � RowDefinitions �� FallbackValue �� RelativeSource �� Mode �� AncestorType �� Path � ColumnDefinitions �� Orientation   ControlButton  WindowCloseIcon�   �SnookerClubApp.AttachedProperties.Base.BaseAttachedProperty`2[[SnookerClubApp.Attached_Properties.OnMouseEnter, SnookerClubApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Windows.Media.Color, PresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   Value�   �SnookerClubApp.AttachedProperties.Base.BaseAttachedProperty`2[[SnookerClubApp.Attached_Properties.OnMouseLeave, SnookerClubApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Windows.Media.Color, PresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   Value��%n  '        7   7  �� "  .���  � �� �� "	 �.R��� 
�������
�������$	��0.5q�$
 10q�._��  �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��2��$
 0 10 0 0q�._��� #��z���� $��1��$	��0.5q�
�������� ���� *CaptionHeight+$ 40������  �� $ FindAncestor=�
 Border$ 
Background� �� $��* ��� $
��Auto �.+��� $��2��$��Center=�$��Center=�.+��� ���#d33834$��25(�$��SemiBold"����� *Title+�� $��1��$ 
Horizontal=�$��Center=�$��Center=�.+��� $��30��8��  8�� $	 Red��$ white������ *CloseCommand+'  !System.Windows.Shell.WindowChrome   WindowChrome      CornerRadius$ 0��   CaptionHeight �� *CaptionHeight+.���  �� $��50 ��� $��* ��� $��80 � �� $��* ��� $��* �.+��� $
��Days��$
��Bold"�$��Center=�$��Center=�$��20(��� $��Price��$��1��$
��Bold"�$��Center=�$��Center=�$��20(�� $��1�� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$	��0 0q�._��� $��Monday��$��Center=�$��Center=�$��17(��� $��1�����#dedede._��� $��Tuesday��$��Center=�$��Center=�$��17(��� $��2��$	��0 0q�._��� $��	Wednesday��$��Center=�$��Center=�$��17(��� $��3��$	��0 0q�._��� $��Thursday��$��Center=�$��Center=�$��17(��� $��4��$	��0 0q�._��� $��Friday��$��Center=�$��Center=�$��17(��� $��5��$	��0 0q�._��� $��Saturday��$��Center=�$��Center=�$��17(��� $��6��$	��0 0q�._��� $��Sunday��$��Center=�$��Center=�$��17(��� $��1��$��1������ *Items+���� .R�    SnookerClubApp.NumberInput     Suffix$	 /hr��   Prefix$ £��$	��0 5q�$��18(�$��Center=�$��Center=�$	��140��
   Min 0   Number �� *Value+ �� Mode$ TwoWay=����� .R�A�  A� Rows$ 7���� $��2��$	��150��$	
 0 5q�$��Center=�$��Center=����#60ff93 � Cursor$
 Hand�� �� CornerRadius$ 5��  J� InputBindings  d� ! d� MouseAction$! 	LeftClicke�" �� Command" �� *SaveCommand+._��� $
��Save��$��18(�
���   �$��Center=�$��Center=��� $��2��$��1��$	��150��$	
 0 5q�$��Center=�$��Center=����#fe5f62$
 Hand��$ 5��  d� $! 	LeftClicke�" �� *CloseCommand+._��� $��Cancel��$��18(�
�������$��Center=�$��Center=�