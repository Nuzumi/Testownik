   M S B A M L   `   `   `  ���� D  @Testownik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Testownik	Testownik  #    Testownik.BaseQuestionBrowser   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:Testownik     -     �Name$  window�� � Title$ 
TrybEdycji��$	��540��$	��740�� � 	Resources  �� 
TargetType   contextMenu �� Triggers :� RoutedEvent �� TargetProperty �� KeyTime �� Value	 �� Property
 �� Value��%�   &	        '�� �     '�� �     �� " �� :� $ Click��[��� .���� .���� $ ContextMenu.IsOpen�.p�s� $ 0:0:0�� . .��� 	 � ��$
 3,3,10,3q��� " ��.��� 	 � ��$
 3,3,10,3q��� " ��.��� 	 � ��$
 	3,0,10,10q�.��� $��7q� � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $��* � � RowDefinitions �� $
��auto ��� $��* ��� $
��auto ��� $
��auto ��� $��* ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��5��$	��165�� �� SelectionMode$ Single=����� *
TestList+ �� SelectedItem �� *SelectedTest+���� .R��� ���� *Name+ � ContextMenu �� .@�m� $��
usuń baze�� m� Command �� *#!DataContext.DeleteDatabaseCommand+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ ListViewL��� $��5��$��
dodaj baze������ *AddDatabaseCommand+�� $��6��$��wiecej opcji��#��[   �� .@�m� $��dodatkowa opcja 1 dla baz��m� $��dodatkowa opcja 2 dla baz��m� $��dodatkowa opcja 3 dla baz���� $��7��$��powrot������ *ToMainWindowCommand+����  �� ElementName$ window���� $��1��$��6��$	��165��$ Single=����� *QuestionList+ �� *SelectedQuestion+���� .R��� ���� *
QuestionNo+�� $��1��$��6��$��dodaj pytanie������ *ToAddQuestionCommand+���� $ window���� $��1��$��7��$��wiecej opcji��#��[   �� .@�m� $#��dodatkowa opcja 1 dla pytania��m� $#��dodatkowa opcja 2 dla pytania��m� $#��dodatkowa opcja 3 dla pytania���� $��2��$��5,0,10,5q�.��	pytanie�� $��2��$��1��$��2��$
��Wrap=�$��	10,0,10,0q����� *SelectedQuestion+  QuestionToTextConverter �� 	Converter# [ �� -   $��hasImage��$��2��$��2��$��posiada obrazek��{�.  $��	7,10,0,10q� d� 	IsChecked �� *HasQuestionPicture+�� $��3��$��2��$��pokaz��$��	13,5,13,5q�{���  �� Path$ 	IsChecked�$ hasImage���� $��2��$��3��$��2��$��7,0,0,0q�.��
odpowiedzi�� -   $��answerListView��$��2��$��4��$��2��$��3��$��Stretch=����� *AnswereList+���� .R�]� $	��0,3q�.+��� {�.  $��Right=�$��6,0,0,0q� �� *	Correct+�� $��12(�$��CharacterEllipsis=����� *	Content+���� $ ActualWidth�$ answerListView��  SubtractConverter# [  �� ConverterParameter$ 	@VALUE-36���� $��2��$��2��$��7��$��edytuj pytanie������ *ToAddQuestionCommand+���� $ window��