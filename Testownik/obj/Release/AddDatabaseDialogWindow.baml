   M S B A M L   `   `   `  ���� D  @Testownik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Testownik	Testownik  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity '    !Testownik.AddDatabaseDialogWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:Testownik     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     -   $��window��  � Title$  AddDatabaseDialogWindow��$	��300��$	��300�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ Height=� � WindowStyle$
 None=�.���  � ColumnDefinitions �� $��* ��� $��* � � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Nazwa Bazy (wymagane)��$��2��$��5q��� -   $��databaseName��$��1��$��2��$��5,0,5,5q����� *DatabaseName+ �� UpdateSourceTrigger$ PropertyChanged=��� $+��%Prowadzacy (to juz nie jest wymagane)��$��2��$��2��$��5,0,5,5q��� $��3��$��2��$��5,0,5,5q����� *DatabaseTeacherName+$ PropertyChanged=��� $��2q�$��4��$��2����  �� 	IsDefault . $��dodaj��$��5��$��10q����� *	OkCommand+����  �� ElementName$ window���� $��anuluj��$��5��$��1��$��10q����� *CancleCommand+���� $ window��