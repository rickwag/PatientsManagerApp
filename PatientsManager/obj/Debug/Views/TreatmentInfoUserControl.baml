   M S B A M L   `   `   `  ����J  FPatientsManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PatientsManager.ViewsPatientsManager.Views  5      G(clr-namespace:PatientsManager.ConvertersPatientsManager.Converters  5      4    .PatientsManager.Views.TreatmentInfoUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:PatientsManager.Views     5      ?
converters(clr-namespace:PatientsManager.Converters     5        � 	Resources  5      9  3PatientsManager.Converters.LongDateToShortConverter   longDateToShortConverter �� 
TargetType �� Property �� Value �� BasedOn��%�  &	        '��      '�� �     7��  5   
   6.   �� 5   
   " ��6   .�5      ��  � ��$ 20(�5      �� 5       � ��$ Center=�5      �� 5       � ��$ 	40 0 40 0q�5      5      �� 5   
   " ��6   8   .�5      ��  � ��$ 14(�5      �� 5       � ��$ Center=�5      �� 5       � ��$ 	40 0 40 0q�5       �� 5!       �@��AcceptsReturn . 5"      �� 5#       �@��
IsReadOnly . 5$      5%      5&      .��5(      �  � ColumnDefinitions 5)   
   �� 5*      �� 5+       � RowDefinitions 5.   
   �� 5/      $	��.5* �6   �� 50      $	��.5* �6   �� 51      $��* �6   �� 52      $��* �6   .+�55   
   �� $��Treatment ID��6   $��0��56      $��0��57      �� 58   
   $��0��59      $��1��5:      ��58      ��  �� Path$# SelectedTreatment.TreatmentID�5:      �� 5<   
   $��Date of Treatment��6   $��1��5=      $��0��5>      �� 5?   
   $��1��5@      $��1��5A      ��5?      �� $% SelectedTreatment.TreatmentDate� �� 	Converter# [  5A      �� 5C   
   $��Symptoms��6   $��2��5D      $��0��5E      �� 5F   
   $��2��5G      $��1��5H      ��5F      �� $  SelectedTreatment.Symptoms�5H      �� 5J   
   $��	Diagnosis��6   $��3��5K      $��0��5L      �� 5M   
   $��3��5N      $��1��5O      ��5M      �� $! SelectedTreatment.Diagnosis�5O      5P      5Q      