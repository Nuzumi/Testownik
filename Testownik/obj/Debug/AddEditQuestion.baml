   M S B A M L   `   `   `  ����D  @Testownik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Testownik	Testownik  5   	       Testownik.AddEditQuestion   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Testownik     5   	   -   5        $��window��5   6     � Title$  DodajEdytuj��6	   $	��540��6   $	��740��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��8q�6   $��1��6M   $��0��6a   $��0��5      ��5       �� *SelectedQuestion.QuestionNo+5      �� 5   
   -   5        $��QuestionContent��5   �   $��1��6   $��3��6   $��10,0,0,0q�63    �� TextWrapping$
 Wrap=�6E   $��Stretch=�6Y   ��6~   �� *SelectedQuestion+   QuestionToTextConverter �� 	Converter# [  .��6�   5      �� 5   
   $��3��6   $��2��6$   $��10,0,0,0q�61   ��6C   �� *ImageSource+�� 5   
   $��3��6   $��10q�6   ��6*   �� *GoBackCommand+��6L   ��  �� ElementName$ window��.��6|   powrot5      �� 5   
   $��1��6   $��3��6!   $��10q�6.   ��6:   �� *SaveChangesCommand+.��6a   
zapiszcz5!      �� 5"   
   $��3��6   $��2��6   $��10q�6.   .��6:   dodaj obrazek5$      �� 5%   
   -   5        $��answerListView��5%   �   $��3��6   $��3��6$   $��15q�65   $��Stretch=�6A   ��6f   �� *
AnswerList+ �� SelectedItem 6�   �� *SelectedAnswer+��5.      �� 5/      .R�50      �  51      �� 52      $��* �6/   �� 53      $
��auto �6/   �� 54      $
��auto �6/    56      �� 57      $��* �6,   $��22��67   �� 58      $��* �6,   $��22��67   �� 59      $��* �6,   $��22��67   .+�5;      �� $��3��6"    �� AcceptsReturn . $
 Wrap=�6H   ��6\   �� *	Content+��6u   ��  �� Path$ ActualWidth�$ odpowiedziListView��  SubtractConverter# [ 	 �� ConverterParameter$	 	@VALUE-45���� 5<      $��1��6#   $��1��63   
 � ToolTip$
 poprawne czy nie��6^    d� 	IsChecked 6@   �� *	Correct+6^   �� 5=      $��2��6!   $��x��61   $
 usuwanie pytania��6=   
�������$��0q�6k   #��[" �6   5>      5?      5A      �� 5B   
   $��3��6   $��3��6!   $��15,10,15,10q�6.   $��+��6C   ��6O   �� *AddNewQuestionCommand+5C      5D      