   M S B A M L   `   `   `  ����J  FPatientsManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PatientsManager.ViewsPatientsManager.Views  5   	   G(clr-namespace:PatientsManager.ViewModelsPatientsManager.ViewModels  5   	   ,    &PatientsManager.Views.NewPatientWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PatientsManager.Views     5   	   ?
viewModels(clr-namespace:PatientsManager.ViewModels     5   	     � Title$  NewPatientWindow��5	   	   $	��550��6"   $	��900��6/    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . ���	#CCFFFFFF � 	Resources 5       �� 
TargetType �� Property �� Value �� BasedOn��%�  '��       '�� �     7��'�� M    7��'�� �    7���� 5   
   " ��6   .�5      ��  � ��$ 20(�5      �� 5       � ��$ Center=�5      �� 5       � ��$
 40 0q�5      5      �� 5   
   " ��6   8   .�5      ��  � ��$ Center=�5      �� 5       � ��$ 0 0 40 0q�5      �� 5        � ��$ 14(�5!      5"      �� 5$   
   " ��6   8   .�5'      ��  � ��$ 0 0 40 0q�5(      �� 5)       � ��$ 14(�5*      5+      �� 5-   
   " ��6   8   .�50      ��  � ��$ Center=�51      �� 52       � ��$ Center=�53      �� 54       � ��$	 200��55      �� 56       � ��$ 40��57      58      59      .��5;      � 	 � ColumnDefinitions	 5<   
   �� 5=      �� 5>      
 � RowDefinitions
 5A   
   �� 5B      $	��.8* �6   �� 5C      $��* �6   �� 5D      $��* �6   �� 5E      $��* �6   �� 5F      $��* �6   �� 5G      $��* �6   �� 5H      $��* �6   �� 5I      $��* �6   �� 5J      $
��1.2* �6   .+�5M   
   �� $��patient personal info��6   $��30(�5N      $
��Bold"�5O      $��Center=�5P      $��Center=�5Q      $��2��5R      �� 5T   
   $��
First Name��6   $��1��5U      �� 5V   
   $��1��6   $��1��5W      ��5X      ��  �� Path$ NewPatient.FirstName� �� Mode$ OneWayToSource=��� 5Z   
   $��	Last Name��6   $��2��5[      �� 5\   
   $��2��6   $��1��5]      ��5^      �� $ NewPatient.LastName�$ OneWayToSource=��� 5`   
   $��Date of Birth��6   $��3��5a      (  "System.Windows.Controls.DatePicker  5b   
   $��3��6   $��1��5c      $��0 0 40 0q�5d         SelectedDate 5e      �� $ NewPatient.DateOfBirth�$ OneWayToSource=��� 5g   
   $��Marital Status��6   $��4��5h      �� 5i   
   $��4��6   $��1��5j      ��5k      �� $ MaritalStatuses� �� SelectedItem 5l      �� $ NewPatient.MaritalStatus�$ OneWayToSource=��� 5n   
   $��Phone Number��6   $��5��5o      �� 5p   
   $��5��6   $��1��5q      ��5r      �� $ NewPatient.PhoneNumber�$ OneWayToSource=��� 5t   
   $��Email Address��6   $��6��5u      �� 5v   
   $��6��6   $��1��5w      ��5x      �� $ NewPatient.EmailAddress�$ OneWayToSource=��� 5z   
   $��Physical Address��6   $��7��5{      �� 5|   
   $��7��6   $��1��5}      ��5~      �� $  NewPatient.PhysicalAddress�$ OneWayToSource=��� 5�   
   $
��Save��6   $��8��5�      ��5�      �� $ SaveNewPatientCommand���5�      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL��� 5�   
   $��Cancel��6   $��8��5�      $��1��5�      ��5�      �� $ CloseWindowCommand���5�      ��  �� $ FindAncestor=�$ WindowL�5�      5�      