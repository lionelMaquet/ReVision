   M S B A M L   `   `   `  ����C  ?ReVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ReVisionReVision  5   	       ReVision.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ReVision     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $
��1000��6)    � 	Resources 5       �� 
TargetType   ButtonStyle �� Property �� Value  HeaderStyle��%�  &	        &	 �     �� 5   
   " ��6   .�5      ��  � ��
 ��ح�6+   �� 5       � ��$ 0q�60   �� 5       � ��$ Medium"�6+   �� 5       � ��$ 10 10 10 10q�6'   �� 5       � ��$ 10 10 10 10q�6(   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 0q�60   �� 5       � ��$ 17(�6)   �� 5       � ��$ DemiBold"�6+   5      5      .��5      � -   5         �Name$ myGrid��5       � ColumnDefinitions 5    
   �� 5!      -   5         ��Name$ SubjectColumn��5!   +   $	��150 �6   6+   �� 5"      -   5        $ QuestionColumn��5"   )   $��* �6   6)   �� 5#      -   5        $ AnswerColumn��5#   )   $��* �6   6)    � RowDefinitions 5&   
   �� 5'      $��50 �6   6*   �� 5(      $��* �6   6)   �� 5)      $	��100 �6   6+   .+�5,   
   �� $��0��6   $��0��6"   #��[ 6/   .��6T   
Subjects6^   �� 5-   
   $��1��6   $��0��6"   #��[ 6/   .��6T   	Questions6_   �� 5.   
   $��2��6   $��0��6"   #��[ 6/   .��6T   	Answers6]   �� 51   
   $��0��6   $��1��6'   .��52      �� -   5        	 ��Name$	 	SubjectSP��52      55      56      �� 5:   
   $��1��6   $��1��6'   .��5;      �� -   5        $	 
QuestionSP��5;   6   $��1��6   $��1��6)   6L   5<      �� 5?   
   $��2��6   $��1��6'   .��5@      �� -   5        $	 AnswerSP��5@      6-   5A      �� 5C   
   -	   5        
 ��Name$
 SelectedAnswerResult��5C      $��2��60   $��3��6@   6O   5E      5F      