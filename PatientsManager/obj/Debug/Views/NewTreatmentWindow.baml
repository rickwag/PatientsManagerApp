   M S B A M L   `   `   `  ����J  FPatientsManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PatientsManager.ViewsPatientsManager.Views  5   	   G(clr-namespace:PatientsManager.ConvertersPatientsManager.Converters  5   	   .    (PatientsManager.Views.NewTreatmentWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PatientsManager.Views     5   	   ?
converters(clr-namespace:PatientsManager.Converters     5   	     � Title$  NewTreatmentWindow��5	   	   $	��550��6$   $	��900��61    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . ���	#CCFFFFFF � 	Resources 5      5   /PatientsManager.Converters.PatientToIDConverter   patientToIDConverter �� 
TargetType �� Property �� Value �� BasedOn��%�  &	        '��      '�� �     7��'�� �    7��  5   
   6*   �� 5   
   " ��6   .�5      ��  � ��$ 20(�5      �� 5       � ��$ Center=�5      �� 5       � ��$
 40 0q�5      5      �� 5   
   " ��6   8   .�5      ��  � ��$ Center=�5      �� 5       � ��$ 0 0 40 0q�5       �� 5!       � ��$ 14(�5"      �� 5#       �@��AcceptsReturn . 5$      5%      �� 5'   
   " ��6   8   .�5*      ��  � ��$ Center=�5+      �� 5,       � ��$ Center=�5-      �� 5.       � ��$	 200��5/      �� 50       � ��$ 40��51      52      53      .��55      � 	 � ColumnDefinitions	 56   
   �� 57      �� 58      
 � RowDefinitions
 5;   
   �� 5<      $	��.8* �6   �� 5=      $��* �6   �� 5>      $��* �6   �� 5?      $��* �6   �� 5@      $��* �6   .+�5C   
   �� $��treatment info��6   $��30(�5D      $
��Bold"�5E      $��Center=�5F      $��Center=�5G      $��2��5H      �� 5J   
   $��
Patient ID��6   $��1��5K      �� 5L   
   $��1��6   $��1��5M      ��5N      ��  �� Path$ ExistingPatients� �� Mode$ OneWay=� �� SelectedItem 5O      �� $ NewTreatment.PatientID�$ OneWayToSource=� �� 	Converter# [   �� Text 5P      ��  �� RelativeSource ��  �� Mode$
 Self=�$ SelectedValue���5R      �� 5S      # [B��6   " ��5T      .�5U      ��  � ��$ 14(�5V      �� 5W       � ��$ 0 0 40 0q�5X      �� 5Y       �@��
IsEditable .  5Z      5[      ��5]      �� 5^      .R�5_      ]� ��.  .+�5`      �� $
��Left=�6$   ��5a   $   �� $ 	PatientID��� 5b      $��Right=�6$   ��5c   $   �� *
LastName+�� 5d      $��Right=�6$   $��0 0 5 0q�5e   $   ��5f   $   �� *	FirstName+5g      5h      5j      �� 5l   
   $��Symptoms��6   $��2��5m      �� 5n   
   $��2��6   $��1��5o      ��5p      �� $ NewTreatment.Symptoms�$ OneWayToSource=��� 5r   
   $��	Diagnosis��6   $��3��5s      �� 5t   
   $��3��6   $��1��5u      ��5v      �� $ NewTreatment.Diagnosis�$ OneWayToSource=��� 5x   
   $
��Save��6   $��4��5y      ��5z      �� $ SaveNewTreatmentCommand���5{      ��  �� $ FindAncestor=� �� AncestorType$ WindowL��� 5|   
   $��Cancel��6   $��4��5}      $��1��5~      ��5      �� $ CloseWindowCommand���5�      ��  �� $ FindAncestor=�$ WindowL�5�      5�      