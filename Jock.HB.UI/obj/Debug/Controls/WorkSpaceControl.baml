   M S B A M L   `   `   `  ����E  AJock.HB.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Jock.HB.UI.ControlsJock.HB.UI.Controls  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      *    $Jock.HB.UI.Controls.WorkSpaceControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Jock.HB.UI.Controls     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      [ WEsri.ArcGISRuntime, Version=100.4.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad866esri+http://schemas.esri.com/arcgis/runtime/2013  5      y�5
   7   �� *
Visibility+.��5      �   � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.5* �6   .+�5   
   � $��0��6   $��1��6     5      �� 5      $��0.15* �6    �� 5      $��* �6    .+�5      �� -   5         ��Name$ HotelsComboBox��5      $��0��6/   $��10q�6<    �� 
IsReadOnly . ��5      �� *Hotels+ �� Text 5      �� *ChoosenHotel+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ DropDownClosed��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *ChangeComboBoxCommand+	   CommandParameter	 5   0   �� 5       5"      5#      � 5$   
   $��1��6   $��1��6     5%      �� 5&      $��* �6    �� 5'      $��0.25* �6     5)      �� 5*      $��* �6#   �� 5+      $��* �6#   .+�5-      �� $��1��6   $��1��6"   $��5q�5.      
������ 
�������$ ��Забронировать��5/   (   ��50      �� *ToBookHotelCommand+��6<   �� 51      � 52   
   $��1��6   $��0��6     53      �� 54      $��0.25* �6    �� 55      $��0.25* �6    �� 56      $��0.25* �6    �� 57      $��0.25* �6    �� 58      $��0.25* �6     5:      �� 5;      $��0.35* �6#   �� 5<      $��* �6#   .+�5>      �� $��0��6   $��0��6!   $��Информация:��61   
������ 
�������5?   -   �� 5@      $��1��6   $��0��6!   $&�� Количество звёзд:��61   
������ 
�������5A   -   �� 5B      $��2��6   $��0��6!   $)��#Стоимость за номер:��61   
������ 
�������5C   -   �� 5D      $��3��6   $��0��6!   $"��Свободных мест:��61   
������ 
�������5E   -   �� 5F      $��4��6   $��0��6!   $*��$Контактный телефон:��61   
������ 
�������5G   -   �� 5H      $��0��6   $��1��6!   
������ 
���������5I   '   �� *	HotelName+�� 5J      $��1��6   $��1��6!   
������ 
���������5K   '   �� *
HotelStars+�� 5L      $��2��6   $��1��6!   
������ 
���������5M   '   �� *
HotelPrice+�� 5N      $��3��6   $��1��6!   
������ 
���������5O   '   �� *
HotelRooms+�� 5P      $��4��6   $��1��6!   
������ 
���������5Q   '   �� *	HotelInfo+5R      �� 5S   
   $��1��6   $��0��6!   $��2��5T      
 K� ZIndex$
 -1��6(   ��5U      �� 5V       �� EndPoint$	 1,1&�6&    � MappingMode$ RelativeToBoundingBox=�65    �� 
StartPoint$
 -1,0&�6Y    �� Opacity$	 0.5Q�6k   .��5W      �  � Color$ Black��6#    � Offset$ 1Q�61   � 5X      $ 	#FF142278��6#   $ 0.543Q�65   5Y      5[      ,  &Esri.ArcGISRuntime.UI.Controls.MapView  5\   
   $��10q�6      WrapAroundMode$ EnabledWhenSupported=�6#   $��0��5]      $��0��6$   
   Map 64   �� *Map+5^      5_      