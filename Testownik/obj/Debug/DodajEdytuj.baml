   M S B A M L   `   `   `  ����D  @Testownik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Testownik	Testownik  5   	       Testownik.DodajEdytuj   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Testownik     5   	     � Title$  DodajEdytuj��5   	   $	��540��6   $	��740��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��8q�6   .��6   	pytanie5      �� 5   
   $��1��6   $��2��6!   $��10,0,0,0q�65   $
��Wrap=�6G   $��Center=�6[   ��Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sed dolor viverra, vestibulum sapien sit amet, aliquet nulla. Fusce ullamcorper, leo eu accumsan semper, ligula est tempor lacus, eu pellentesque velit mauris vitae tellus. Phasellus sit amet nibh interdum, pulvinar massa vel, pharetra nibh.5      �� 5   
   $��3��6   $��10q�6   .��6*   powrot5      �� 5   
   $��3��6   $��1��6   $��10q�6.   .��6:   dodaj obrazek5       �� 5!   
   -   5        $��odpowiedziListView��5!   5   $��2��6   $��3��6$   $��15q�6O   $��Stretch=�6[   ��5"      �� 5#      .R�5$      �  5%      �� 5&      $��* �6/   �� 5'      $
��auto �6/   �� 5(      $
��auto �6/    5*      �� 5+      $��* �6,   $��22��67   �� 5,      $��* �6,   $��22��67   �� 5-      $��* �6,   $��22��67   .+�5/      �� $��3��6"    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6H   ��6\   �� *Tekst+��6s   ��  �� Path$ ActualWidth� �� ElementName$ odpowiedziListView��   SubtractConverter �� 	Converter# [   �� ConverterParameter$ 	@VALUE-45���� 50      $��1��6#   $��1��63   	 � ToolTip$	 poprawne czy nie��6_   
 d� 	IsChecked
 6@   �� *
Poprawna+6_   �� 51      $��2��6!   $��x��61   $	 usuwanie pytania��6=   
�������$��0q�6k   #��[" �6   52      53      55      �� 56   
   $��2��6   $��3��6!   $��15,10,15,10q�6.   $��+��6C   57      58      