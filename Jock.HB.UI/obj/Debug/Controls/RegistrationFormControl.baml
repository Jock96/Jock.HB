   M S B A M L   `   `   `  ����E  AJock.HB.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Jock.HB.UI.ControlsJock.HB.UI.Controls  5      1    +Jock.HB.UI.Controls.RegistrationFormControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Jock.HB.UI.Controls     5      
�������y�5
      �� *
Visibility+.��5      � ��5   
   �� 5        �� EndPoint$	  1,1&�6"    � MappingMode$ RelativeToBoundingBox=�61    �� 
StartPoint$
 -1,0&�6U    �� Opacity$	 0.5Q�6g   .��5      �  � Color$ Black��6    � Offset$ 1Q�6-   � 5      $ 	#FF142278��6   $ 0.543Q�61   5       � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��1.5* �6   �� 5      $��0.75* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��2��6   $'��!Форма регистрации��6$   $��Center=�5       $��Center=�6-   
�������$��15(�5!   #   �� 5"   
   $&�� Имя пользователя:��6   $��10q�6,   $��1��5#      $��0��6   
�������5$      �� 5%   
   $(��"Электронная почта:��6   $��10q�6-   $��2��5&      $��0��6   
�������5'      �� 5(   
   $��Пароль:��6   $��10q�6"   $��3��5)      $��0��6   
�������5*      �� 5+   
   $&�� Повторите пароль:��6   $��10q�6,   $��4��5,      $��0��6   
�������5-      �� 5.   
   $��6��6   $��0��6   $��5q�5/      $*��$Зарегестрироваться��6   
������ 
���������51      �� *ApplyRegistrationCommand+��6>   �� �� 52   
   -   5         ��Name$! UserNameRegistrationTextBox��52      $��1��67   $��1��53      $
��5,10q�6"   
������ 
���������54      �� *UserRegistrationName+55      �� 56   
   -   5        $! UserMailRegistrationTextBox��56      $��2��67   $��1��57      $
��5,10q�6"   
������ 
���������58      �� *UserRegistrationMail+59      �� 5:   
   -   5        $% UserPasswordRegistrationTextBox��5:      $��3��6;   $��1��5;      $
��5,10q�6"   
������ 
���������5<   %   �� *UserRegistrationPassword+�� 5=   
   -   5        $# UserPasswordValidationTextBox��5=      $��4��69   $��1��5>      $
��5,10q�6"   
������ 
���������5?   %   �� *UserRegistrationValidPassword+�� 5@   
   $��Отмена��6   
������ 
�������$��6��5A   $   $��1��5B      $��5q�6!   ��5C      �� *CancelRegistrationCommand+��6?   �� 5D      5E      