   M S B A M L   `   `   `  ����C  ?DashCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DashCoreDashCore  5      "    DashCore.DashCore_Card_Table   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:DashCore     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $��10q�5      .��5
      �� -   5          ��Name$  Border��5   	   $	��350��5   	   $	��200��5   	   ���#e8e8e8 �� CornerRadius$ 4��5   	   ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      A� $��0��6    A� Columns$ 2��6'   .+�5      �� -   5         ��Name$ Header_Label��5      $	��5,2q�5      $��Center=�5      $��Header��5      $��16(�5      $
��Bold"�5      
�������5      �� 5       -   5         ��Name$ ThreeDot_Button��5!      $��18��5"      $��15��5#      $��10q�5$      $��Right=�5%      $��Center=�5&      
������ 
������ $��0q�5)      .��5*      �� $��img/three_dot.png��6   5+      5,      �� 5-      -   5         ��Name$ Search_TextBox��5.      $��1��5/      $
��10 2q�50      $��1q�51      $��Center=�52      $��Search in table ... ��53      $��12(�54      
�������58      � 59      -   5         �Name$ TableContainer��5:      $��2��5;      $��	10 2 10 5q�5<      .+�5>      &   System.Windows.Controls.DataGrid  -   5          Name$ DynamicDataGrid��5?      	   AutoGenerateColumns$	 False��5@      ���#D3D3D3$��1q�5B      
   GridLinesVisibility$	
 All=�5C         HeadersVisibility$ Column=�5D         
IsReadOnly$
 True��5E       � 	Resources 5F      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow��%�  '        '      '  %    �� 5G      "  6    .�5H      ��  � �� �#E0E0E06;   �� 5I       � ��$
 Bold"�6;   �� 5J       � ��$ 5q�68   �� 5K       � �� �#D3D3D36<   �� 5L       � ��$ 0,0,1,1q�6@   �� 5M       � ��
 �����6;   5N      �� 5O      "  6    .�5P      ��  � ��$ 5q�68   �� 5Q       � ��
 �����6<   �� 5R       � ��$ 0,0,1,1q�6@   �� 5S       �@��TextAlignment$
 Left=�6H   �� 5T       � ��$	 2 0q�6A   �� 5U       � ��
 �����6;   5V      �� 5W      "  6    .�5X      ��  � ��
 ���� 6;   5Y      5Z      5[      5\      5]      5^      5_      