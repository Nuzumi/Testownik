   M S B A M L   `   `   `  ����D  @Testownik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Testownik	Testownik  5   	   ;"clr-namespace:Testownik.ViewModelsTestownik.ViewModels  5   	       Testownik.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Testownik     5   	   8	viewModel"clr-namespace:Testownik.ViewModels     5   	   -   5          �Name$  
mainWindow��5	   5    � Title$ 
MainWindow��6	   $	��540��6   $	��740��6)    � DataContext 5
      '   !Testownik.ViewModels.MainWindowVM  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��2��6   $��20q�6$    �� SelectionMode$ Single=�60   $��Stretch=�6H   ��6m   �� *
TestList+ �� SelectedItem 6�   �� *SelectedTest+��5      �� 5      .R�5      ]� .+�5      �� $��Right=�6C   ��6    �� *QuestionsCount+6C   �� 5      $��ilosc pytan: ��6    $��Right=�68   �� 5      ��6    �� *Name+5      5       5"      � 5#   
   $��2��6   $��2��6    5$      �� 5%      $
��auto �6#   �� 5&      $��* �6#   �� 5'      $
��auto �6#    5)      �� 5*      $
��auto �6    �� 5+      $��* �6    �� 5,      $
��auto �6    �� 5-      $��* �6    �� 5.      $
��auto �6    �� 5/      $��* �6    .+�51      � $��3��6   .+�52      �� $*��$ilosc powtórzeń pytan na poczatek:��6   �� 53      $��4,0,0,0q�6q   ��6   ��  �� ElementName$ slider1�� �� Path$ Value�	 �� UpdateSourceTrigger$	 PropertyChanged=�6q   54      �� 55      $��1��6   $��1��6!   $��Center=�6-   �� 56      -   5        $��slider1��56   w   $��1��6   $��1��6%   
 � Minimum$
 1Q�6^    � Maximum$ 10Q�6j    �� IsSnapToTickEnabled . $��Center=�6�    �� TickFrequency$ 1Q�6�    �� TickPlacement$ BottomRight=�6�    � Value 62   �� *QuestionRepetitionOnStart+6�   �� 57      $��1��6   $��2��6!   $��10��61   $��Center=�6>   � 58      $��2��6   $��3��6%   .+�59      �� $,��&ilosc powtorzen po blednej odpowiedzi:��6   �� 5:      $��4,0,0,0q�6q   ��6   �� $ slider2��$ Value�$	 PropertyChanged=�6q   5;      �� 5<      $��3��6   $��0��6!   $��Center=�6-   �� 5=      -   5        $��slider2��5=   �   $��1��6   $��3��6%    . $
 0Q�6�   $ 10Q�6�   $��Center=�6�   $ 1Q�6�   $ BottomRight=�6�    62   �� *#!QuestionRepetitionAftherBadAnswer+6�   �� 5>      $��3��6   $��2��6!   $��10��61   $��Center=�6>   � 5?      $��3��6   $��4��6,   .+�5@      �� $��ilosc pytan naraz:��6   �� 5A      ��6   �� $ slider3��$ Value�$	 PropertyChanged=�5B      �� 5C      $��5��6   $��1��6!   $��Center=�6-   �� 5D      -   5        $��slider3��5D   x   $��1��6   $��5��6%    . $
 1Q�6�   $��Center=�6�   $ 1Q�6  $ BottomRight=�6   62   �� *QuestionRepetitionAtOnce+ 6�   �� *SelectedTestQuestionAmount+$	 PropertyChanged=�6  �� 5E      $��5��6   $��2��6!   $��Center=�6b   ��61   �� *	Maximum+$ slider3��6b   5F      �� 5G   
   $��1��6   $��17,20,17,10q�6z   $��tryb edycji��6�   $��45��6�   ��6!   �� *ToBrowserCommand+��6F   �� $ 
mainWindow��6�   �� 5H   
   $��1��6   $��2��6!   $��17,25,17,25q�6�   $��zacznij sie uczyc��6�   ��6.   �� *ToTestCommand+��6P   �� $ 
mainWindow��6�   �� 5I   
   $��1��6   $��3��6!   $��17,25,17,25q�6.   $#��kontynuluj ostatnie podejscie��6C   ��6k   �� *ContinueLastTestCommand+��6�   �� $ 
mainWindow��5J      5K      