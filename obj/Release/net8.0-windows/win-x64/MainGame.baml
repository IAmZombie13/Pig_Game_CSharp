   M S B A M L   `   `   `  ���� E  AThePigGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ThePigGame
ThePigGame      ThePigGame.MainGame   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:ThePigGame     .��� .+��� 
��������   � ColumnDefinitions  �� $��10 ��� $��* ��� $��* ��� $��* ��� $��10 � � RowDefinitions �� $��10 ��� $��* ��� $��* ��� $��* ��� $��10 �.+��� -    ��Name$ Player1��$��2��$��1��._��� .+��� $.��(pack://application:,,,/Images/Player.png��$��Center=�$��Center=�$	��100��$	��100���� $��Player 1��$��Center=�$��Center=�$��15(�$
��Bold"��� -    ��Name$ Player1Score��$��30(�$��Center=�$��Center=�
���   �
�������$��40��$��70���� -   $ Player2��$��2��$��3��._��� .+��� $.��(pack://application:,,,/Images/Player.png��$��Center=�$��Center=�$	��100��$	��100���� $��Player 2��$��Center=�$��Center=�$��15(�$
��Bold"��� -   $ Player2Score��$��30(�$��Center=�$��Center=�
���   �
�������$��40��$��70���� -   $ Player3��$��1��$��2��._��� .+��� $.��(pack://application:,,,/Images/Player.png��$��Center=�$��Center=�$	��100��$	��100���� $��Player 3��$��Center=�$��Center=�$��15(�$
��Bold"��� -   $ Player3Score��$��30(�$��Center=�$��Center=�
���   �
�������$��40��$��70���� -   $ Player4��$��3��$��2��._��� .+��� $.��(pack://application:,,,/Images/Player.png��$��Center=�$��Center=�$	��100��$	��100���� $��Player 2��$��Center=�$��Center=�$��15(�$
��Bold"��� -   $ Player4Score��$��30(�$��Center=�$��Center=�
���   �
�������$��40��$��70���� $��2��$��2��._��� $��Center=�$��Center=�.+��� $��Center=� �� Orientation$ 
Horizontal=�$��Center=�.+��� -	   $��Roll Die��$��30��$��60���� -
    ��Name$ 	DiceImage��$��Images/One.png��$��Center=�$��Center=�$	��100��$	��100���� -   $��End Turn��$��30��$��60���� $��Center=�$ 
Horizontal=�$��Center=�.+��� -   $ 	DiceScore��$��30(�$��Center=�$��Center=�
���  ��
�������$��40��$��70���� -   $ PlayerNotification��$��2��$��1��$��3��$	��500�� �� CornerRadius$ 5��
���   �$��5q����� .���  � Color$	 red�� � Offset$	 0.1Q�._��� -   $ PlayerNotificationText��$��Center=�$��Center=�$��60(�$
��Bold"�