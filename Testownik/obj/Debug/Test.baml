   M S B A M L   `   `   `  ����D  @Testownik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Testownik	Testownik  5   	   5clr-namespace:Testownik.HelpersTestownik.Helpers  5   	       Testownik.Test   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Testownik     5   	   2helperclr-namespace:Testownik.Helpers     5   	   -   5          �Name$  window��5	   5    � Title$ 
UczenieSie��6	   $	��540��6   $	��740��6)    � 	Resources 5
       �� 
TargetType �� Property �� Value��%Y   '��       �� 5   
   " ��6   .�5      ��  � ��$ 	15,7,15,7q�6'   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��2��6   $
��Wrap=�6(   $��15q�6<   ��6I   �� *ActualQuestion+   QuestionToTextConverter �� 	Converter# [  5      �� 5   
   -   5        $��answersList��5   Y   $��1��6   $��3��6    $��15q�64   	 �� SelectionMode$	 Multiple=�6@   
 �� SelectedItem
 6l   �� *Answer+��6�   �� *ActualQuestionAnswersList+ 5      $   Testownik.Helpers.BindingProxy 	 proxy   Data��%&   &	         5       64   �� 5       ��5!      �� 5"      .R�5#      �� $��10q�69   ��6    �� *	Content+69   5$      ��5&      �� 5'      " ��6    �� Triggers 5(      ^� 5)       ^� 
Conditions 5*      �� 5+   "    �� Binding 6,   ��  �� Source# [  �� Path$$ Data.WasActualQuestionChcecked� �� Value true6�   �� 5,   "    6,   �� *	Correct+ true6H   .0�5.      ��  � ��
 ����6;   5/      ^� 50       51      �� 52   "    6,   �� # [ $$ Data.WasActualQuestionChcecked� true6�   �� 53   "    6,   �� *	Correct+	 false6H   .0�55      ��  � ��
 �\\��6;   56      58      5:      �� 5;   
   $��2��6   $��2��6    � 5<   
   $��3��6   $��1��6   $��2,5,2,5q�6,    5=      ��%�   '��       '�� M     �� 5>      " ��6   .�5?      ��  � ��$ 2,4,2,4q�6/   5@      �� 5A      " ��6   .�5B      ��  � ��$ 0,4,0,0q�6/   5C      5D       5E      �� 5F      $��* �6#   �� 5G      $��* �6#    5I      �� 5J      $
��auto �6    �� 5K      $
��auto �6    �� 5L      $
��auto �6    �� 5M      $
��auto �6    �� 5N      $��* �6    .+�5P      �� $��2��6   ��6(   �� *
AnswerText+�� 5Q      $��1��6   $
��Wrap=�6%   $��poprawne odpowiedzi��69   �� 5R      $��1��6   $��1��6"   ��62   �� *GoodAnswersCount+�� 5S      $��2��6   $
��Wrap=�6%   $��bledne odpowiedzi��69   �� 5T      $��2��6   $��1��6!   ��61   �� *BadAnswersCount+�� 5U      $��3��6   $
��Wrap=�6%   $$��ilosc powtorzen danego pytania��69   �� 5V      $��3��6   $��1��6!   ��61   �� *ActualQuestionRepetition+� 5W      $��4��6   $��2��6'    � Orientation$ Vertical=�6;    � Minimum$ 0Q�6R   
���\\��
������$��15,10,35,10q�6�    � Value 6^   �� *LernedQuestionCount+ � Maximum 6�   �� *QuestionCount+6�   5X      �� 5Y   
   $��3��6   $��powrot��6v   ��6   �� *ToMainWindowCommand+��6F   ��  �� ElementName$ window��6v   �� 5Z   
   $��3��6   $��1��6   $��edytuj��6�   {�.  ��6.   �� *ToEditQuestionCommand+��6X   �� $ window��6�   �� 5[   
   $��3��6   $��2��6   $��sprawdz��6.   ��6@   �� $ answersList��$ SelectedItems���6�   �� *CheckAnswersCommand+�� 5\   
   -   5        $
��Next��5\   g   $��3��6   $��3��6   $��dalej��6.   ��6?   �� *NextQuestionCommand+6g   5]      5^      