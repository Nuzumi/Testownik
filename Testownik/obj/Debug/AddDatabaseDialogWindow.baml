   M S B A M L   `   `   `  ����D  @Testownik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Testownik	Testownik  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   '    !Testownik.AddDatabaseDialogWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Testownik     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   -   5        $��window��5
         � Title$  AddDatabaseDialogWindow��5	   	   $	��300��6)   $	��300��66    � WindowStartupLocation$ CenterScreen=�6B    � SizeToContent$ Height=�5
   	    � WindowStyle$
 None=�6.   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Nazwa Bazy (wymagane)��6   $��2��60   $��5q�6D   �� 5   
   -   5        $��databaseName��5   �   $��1��6   $��2��6   $��5,0,5,5q�63   ��6D   �� *DatabaseName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $+��%Prowadzacy (to juz nie jest wymagane)��6   $��2��6@   $��2��6M   $��5,0,5,5q�6a   �� 5   
   $��3��6   $��2��6   $��5,0,5,5q�63   ��6D   �� *DatabaseTeacherName+$ PropertyChanged=��� 5   
   $��2q�6   $��4��6(   $��2��65   �� 5   
    �� 	IsDefault . $��dodaj��6p   $��5��6�   $��10q�6�   ��6"   �� *	OkCommand+��6@   ��  �� ElementName$ window��6�   �� 5   
   $��anuluj��6   $��5��6t   $��1��6�   $��10q�6�   ��6"   �� *CancleCommand+��6D   �� $ window��6�   5      5       