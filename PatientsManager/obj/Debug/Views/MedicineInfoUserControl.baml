   M S B A M L   `   `   `  ����J  FPatientsManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PatientsManager.ViewsPatientsManager.Views  5      3    -PatientsManager.Views.MedicineInfoUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:PatientsManager.Views     5        � 	Resources  5
       �� 
TargetType �� Property �� Value �� BasedOn��%�  '��       '�� �     7���� 5   
   " ��6   .�5      ��  � ��$ 20(�5      �� 5       � ��$ Center=�5      �� 5       � ��$ 	40 0 40 0q�5      5      �� 5   
   " ��6   8   .�5      ��  � ��$ 14(�5      �� 5       � ��$ Center=�5      �� 5       � ��$ 	40 0 40 0q�5      �� 5       �@��AcceptsReturn . 5      �� 5        �@��
IsReadOnly . 5!      5"      5#      .��5%      �  � ColumnDefinitions 5&   
   �� 5'      �� 5(       � RowDefinitions 5+   
   �� 5,      $��* �6   �� 5-      $��* �6   �� 5.      $��* �6   �� 5/      $��* �6   �� 50      $��* �6   .+�53   
   �� $��Medicine ID��6   $��0��54      $��0��55      �� 56   
   $��0��57      $��1��58      ��56      ��  �� Path$! SelectedMedicine.MedicineID�58      �� 5:   
   $��Medicine Type��6   $��1��5;      $��0��5<      �� 5=   
   $��1��5>      $��1��5?      ��5=      �� $# SelectedMedicine.MedicineType�5?      �� 5A   
   $��Medicine Name��6   $��2��5B      $��0��5C      �� 5D   
   $��2��5E      $��1��5F      ��5D      �� $# SelectedMedicine.MedicineName�5F      �� 5H   
   $��Dosage Days��6   $��3��5I      $��0��5J      �� 5K   
   $��3��5L      $��1��5M      ��5K      �� $! SelectedMedicine.DosageDays�5M      �� 5O   
   $��Dosage Times per Day��6   $��4��5P      $��0��5Q      �� 5R   
   $��4��5S      $��1��5T      ��5R      �� $" SelectedMedicine.TimesPerDay�5T      5U      5V      