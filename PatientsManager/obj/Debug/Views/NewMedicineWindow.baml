   M S B A M L   `   `   `  ����J  FPatientsManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PatientsManager.ViewsPatientsManager.Views  5   	   G(clr-namespace:PatientsManager.ViewModelsPatientsManager.ViewModels  5   	   G(clr-namespace:PatientsManager.ConvertersPatientsManager.Converters  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	   	   -    'PatientsManager.Views.NewMedicineWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PatientsManager.Views     5   	   ?
viewModels(clr-namespace:PatientsManager.ViewModels     5   	   ?
converters(clr-namespace:PatientsManager.Converters     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	   	     � Title$  NewMedicineWindow��5   	   $	��550��6#   $	��900��60    � WindowStartupLocation$ CenterScreen=�5   	   $��Roboto)�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . ���	#CCFFFFFF � DataContext 5      3   -PatientsManager.ViewModels.MedicinesViewModel  5   
    � 	Resources 5      5   /PatientsManager.Converters.PatientToIDConverter   patientToIDConverter7   1PatientsManager.Converters.TreatmentToIDConverter  treatmentToIDConverter �� 
TargetType �� Property �� Value	 �� BasedOn��%=  &	        &	      '�� &     '�� �     7��'�� s    7��'�� #    7��  5   
   6*     5   
   6,   �� 5   
   " ��6   .�5      ��  � ��$ 20(�5      �� 5       � ��$ Center=�5      �� 5       � ��$
 40 0q�5       5!      �� 5#   
   " ��6   8	   .�5&      ��  � ��$ Center=�5'      �� 5(       � ��$ 0 0 40 0q�5)      �� 5*       � ��$ 14(�5+      5,      �� 5.   
   " ��6   8	   .�51      ��  � ��$ 0 0 40 0q�52      �� 53       �@��
IsEditable . 54      �� 55       � ��$ 14(�56      57      �� 59   
   " ��6   8	   .�5<      ��  � ��$ Center=�5=      �� 5>       � ��$ Center=�5?      �� 5@       � ��$	 200��5A      �� 5B       � ��$ 40��5C      5D      5E      .��5G      � 
 � ColumnDefinitions
 5H   
   �� 5I      �� 5J       � RowDefinitions 5M   
   �� 5N      $	��.8* �6   �� 5O      $	��.8* �6   �� 5P      $��* �6   �� 5Q      $��* �6   �� 5R      $��* �6   �� 5S      $	��.4* �6   �� 5T      $��* �6   �� 5U      $��* �6   �� 5V      $
��1.2* �6   .+�5Y   
   �� $��medicine info��6   $��30(�5Z      $
��Bold"�5[      $��Center=�5\      $��Center=�5]      $��2��5^      �� 5`   
   $��
Patient ID��6   $��1��5a      �� 5b   
   $��1��6   $��1��5c      ��5d      ��  �� Path$ ExistingPatients� �� Mode$ OneWay=� �� SelectedItem 5e      �� $ NewMedicine.PatientID�$ OneWayToSource=� �� 	Converter# [   �� Text 5f      ��  �� RelativeSource ��  �� Mode$
 Self=�$ SelectedValue�.  (System.Windows.Interactivity.Interaction   Triggers 5h      /  )System.Windows.Interactivity.EventTrigger  5i         	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5j      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� $, &UpdateSelectedPatientTreatmentsCommand�5k      ��5n      �� 5o      #	 [B��6   " ��5p      .�5q      ��  � ��$ 14(�5r      �� 5s       � ��$ 0 0 40 0q�5t      �� 5u       �@��
IsEditable .  5v      5w      ��5y      �� 5z      .R�5{      ]� ��.  .+�5|      �� $
��Left=�6$   ��5}   $   �� $ 	PatientID��� 5~      $��Right=�6$   ��5   $   �� *
LastName+�� 5�      $��Right=�6$   $��0 0 5 0q�5�   $   ��5�   $   �� *	FirstName+5�      5�      5�      �� 5�   
   $��Treatment ID��6   $��2��5�      �� 5�   
   $��2��6   $��1��5�      ��5�      �� $ SelectedPatientTreatments�$ OneWay=� 5�      �� $ NewMedicine.TreatmentID�$ OneWayToSource=�# [  5�      ��  �� $
 Self=�$ SelectedValue���5�      �� 5�      #	 [B��6   " ��5�      .�5�      ��  � ��$ 14(�5�      �� 5�       � ��$ 0 0 40 0q�5�      �� 5�       �@��
IsEditable .  5�      5�      ��5�      �� 5�      .R�5�      ]� ��.  .+�5�      �� $
��Left=�6$   ��5�   $   �� $ TreatmentID��� 5�      $��Right=�6$   ��5�   $   �� *	Diagnosis+5�      5�      5�      �� 5�   
   $
��Type��6   $��3��5�      �� 5�   
   $��3��6   $��1��5�      ��5�      �� $ NewMedicine.MedicineType�$ OneWayToSource=��� 5�   
   $
��Name��6   $��4��5�      �� 5�   
   $��4��6   $��1��5�      ��5�      �� $ NewMedicine.MedicineName�$ OneWayToSource=��� 5�   
   $��Dosage��6   $��24(�5�      $��Italic$�5�      $��Center=�5�      $��Center=�5�      $��2��5�      $��5��5�      �� 5�   
   $
��Days��6   $��6��5�      �� 5�   
   $��6��6   $��1��5�       5�      �� $ NewMedicine.DosageDays�$ OneWayToSource=�.@�5�      �� $��5��6   �� 5�      $��10��6   �� 5�      $��10��6   �� 5�      $��30��6   5�      �� 5�   
   $��Times per Day��6   $��7��5�      �� 5�   
   $��7��6   $��1��5�       5�      �� $ NewMedicine.TimesPerDay�$ OneWayToSource=�.@�5�      �� $��5��6   �� 5�      $��10��6   �� 5�      $��10��6   �� 5�      $��30��6   5�      �� 5�   
   $
��Save��6   $��8��5�      ��5�      �� $ SaveMedicineCommand���5�      ��  �� $ FindAncestor=� �� AncestorType$ WindowL��� 5�   
   $��Cancel��6   $��8��5�      $��1��5�      ��5�      �� $ CloseWindowCommand���5�      ��  �� $ FindAncestor=�$ WindowL�5�      5�      