   M S B A M L   `   `   `  ����D  @Testownik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Testownik	Testownik  5   	   5clr-namespace:Testownik.HelpersTestownik.Helpers  5   	   #    Testownik.BaseQuestionBrowser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Testownik     5   	   2helperclr-namespace:Testownik.Helpers     5   	   -   5          �Name$  window��5	   5    � Title$ 
TrybEdycji��6	   $	��540��6   $	��740��6)    � 	Resources 5
       �� 
TargetType   contextMenu �� Triggers :� RoutedEvent �� TargetProperty �� KeyTime �� Value	 �� Property
 �� Value��%�  &	        '�� '    '�� u    �� 5   
   " ��6    5      :� 5      $ Click��6   [�5      �� 5      .��5      �� .��5   "   �� $ ContextMenu.IsOpen�6A   .p�5   &   s� $ 0:0:0��6>    . 6N   5   #   5      5      5      .�5      �� 	 � ��$
 3,3,10,3q�6'   5      �� 5   
   " ��6   .�5      �� 	 � ��$
 3,3,10,3q�6'   5      �� 5   
   " ��6   .�5      �� 	 � ��$
 	3,0,10,10q�6'   5       5!      .��5"      � $��7q�6    � ColumnDefinitions 5#   
   �� 5$      $
��auto �6   �� 5%      $
��auto �6   �� 5&      $
��auto �6   �� 5'      $��* �6    � RowDefinitions 5)   
   �� 5*      $
��auto �6   �� 5+      $��* �6   �� 5,      $
��auto �6   �� 5-      $
��auto �6   �� 5.      $��* �6   �� 5/      $
��auto �6   �� 50      $
��auto �6   �� 51      $
��auto �6   .+�53   
   �� $��5��6   $	��165��6$    �� SelectionMode$ Single=�63   $��Stretch=�6�   ��6J   �� *
TestList+ �� SelectedItem 6k   �� *SelectedTest+ 54      $   Testownik.Helpers.BindingProxy 	 proxy   Data��%&   &	         55       64   �� 56      ��57      �� 58      .R�59      ]�  � ContextMenu 5:      �� 5;      .@�5<   "   m� $��
usuń baze��6+    m� Command 6>   �� *Data.DeleteDatabaseCommand+ �� Source# [ 5=      .+�5?      �� ��6    �� *Name+5@      5A      5C      �� 5D   
   $��5��6   $��
dodaj baze��6   ��63   �� *AddDatabaseCommand+�� 5E   
   $��6��6   $��wiecej opcji��6   #��[  65    5F      �� 5G      .@�5H      m� $��dodatkowa opcja 1 dla baz��6   m� 5I      $��dodatkowa opcja 2 dla baz��6   m� 5J      $��dodatkowa opcja 3 dla baz��6   5K      5M      �� 5N   
   $��7��6   $��powrot��6v   ��6   �� *ToMainWindowCommand+��6F   ��  �� ElementName$ window��6v   �� 5O   
   $��1��6   $��6��6#   $	��165��64   $ Single=�6C   $	��165��6�   ��6Z   �� *QuestionList+ 6   �� *SelectedQuestion+ 5P      ��%&   &	         5Q       64   �� 5R      ��5S      �� 5T      .R�5U      ]�  5V      �� 5W      .@�5X   "   m� $��usuń pytanie��6+    6A   �� *Data.DeleteQuestionCommand+# [ 5Y      .+�5[      �� $
��Left=�6?   ��6    �� *
QuestionNo+6?   �� 5\      $��CharacterEllipsis=�6=   $��0,5,0,0q�6^   $	��135��6o   ��6$   �� *	Content+6o   5]      5^      5`      �� 5a   
   $��1��6   $��6��6!   $��dodaj pytanie��6�   ��6.   �� *ToAddQuestionCommand+��6W   �� $ window��6�   �� 5b   
   $��1��6   $��7��6!   $��wiecej opcji��6.   #��[  6F    5c      �� 5d      .@�5e      m� $#��dodatkowa opcja 1 dla pytania��6   m� 5f      $#��dodatkowa opcja 2 dla pytania��6   m� 5g      $#��dodatkowa opcja 3 dla pytania��6   5h      5j      �� 5k   
   $��2��6   $��5,0,10,5q�6    $��1��63   .��6G   	pytanie6P   �� 5l   
   $��2��6   $��1��6$   $��2��61   $
��Wrap=�6E   $��	10,0,10,0q�6Z   ��6m   �� *SelectedQuestion+  QuestionToTextConverter �� 	Converter# [ �� 5m   
   -   5        $��hasImage��5m   0   $��2��6   $��2��6#   $��posiada obrazek��6@   {�.  $��	7,10,0,10q�6�    d� 	IsChecked 6l   �� *HasQuestionPicture+6�   �� 5n   
   $��3��6   $��2��6!   $��pokaz��6.   $��	13,5,13,5q�6y   {�6>   ��  �� Path$ 	IsChecked�$ hasImage��6y   �� 5o   
   $��2��6   $��3��6    $��2��6-   $��7,0,0,0q�6A   .��6R   
odpowiedzi6^   �� 5p   
   -   5        $��answerListView��5p   �   $��2��6   $��4��6#   $��2��60   $��3��6D   $��Stretch=�6�    6U   �� *SelectedAnswer+��6}   �� *
AnswerList+ 5q      ��%&   &	         5r       64   �� 5s      ��5t      �� 5u      .R�5v      ]� $	��0,3q�6     5w      �� 5x      .@�5y   "   m� $��usuń odpowiedź��6+    6C   �� *Data.DeleteAnswerCommand+# [ 5z      .+�5|      �� {�.  $��Right=�6S   $��6,0,0,0q�6j    65   �� *	Correct+6j   �� 5}      $��12(�6=   $��CharacterEllipsis=�6K   ��6$   �� *	Content+��6l   �� $ ActualWidth�$ answerListView��  SubtractConverter# [  �� ConverterParameter$ 	@VALUE-36��5~      5      5�      �� 5�   
   $��2��6   $��2��6!   $��7��65   $��edytuj pytanie��6�   ��6B   �� *ToEditQuestionCommand+��6l   �� $ window��6�   5�      5�      