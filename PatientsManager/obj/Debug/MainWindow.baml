   M S B A M L   `   `   `  ����J  FPatientsManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PatientsManagerPatientsManager  5   	   G(clr-namespace:PatientsManager.ViewModelsPatientsManager.ViewModels  5   	        PatientsManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PatientsManager     5   	   ?
viewModels(clr-namespace:PatientsManager.ViewModels     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$
  Home��5	   	   $	��450��6   $	��800��6#    � WindowStyle$
 None=�5
   	    � WindowState$ 	Maximized=�5   	    � 
ResizeMode$ NoResize=�5   	      MaterialDesignBody#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � DataContext 5      .   (PatientsManager.ViewModels.MainViewModel  5   
   .��5      � .+�5   
   �� $#��Images/hospitalBackground.jpg��6   $
��Fill=�5      ]� 5   
   ��.  .+�5       �� $	��Top=�6   $��Center=�5!       �� Orientation$ 
Horizontal=�5"      .+�5$      �� $��maneater��6   $��jokerman)�5%      
�������$��24(�5'      $��0 0 20 0q�5(      �� 5)      $��hospital��6   
�������$��24(�5+      $	��0 5q�5,      5-      `� 5/      $
��Left=�6    `� Orientation$ Vertical=�50      	 `� 
Background
	 ���� $��40q�52      .�54      c� 
������   MaterialDesignToolBar#���  55      $��24(�56      .@�57      �� $��New Patient��6   $��200px��58      $
��Left=�59      ��5:      �� 
 �� Path$
 NewPatientCommand��� 5;      $��New Treatment��6   $��200px��5<      $
��Left=�5=      ��5>      �� $
 NewTreatmentCommand��� 5?      $��New Medicine��6   $��200px��5@      $
��Left=�5A      ��5B      �� $
 NewMedicineCommand�5C      c� 5E      
������ $��24(�5F      $
��Left=�5G      .@�5H      �� $��View Patients��6   $��200px��5I      $
��Left=�5J      ��5K      �� $
 ViewPatientsCommand��� 5L      $
��Exit��6   $��200px��5M      $
��Left=�5N      ��5O      �� $
 ExitCommand�5P      5Q      5T      5U      5V      