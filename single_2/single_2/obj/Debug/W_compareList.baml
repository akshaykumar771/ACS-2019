   M S B A M L   `   `   `  ����C  ?single_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:single_2single_2  5   	       single_2.W_compareList   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:single_2     5   	     � Title$)  #Car Comparision and Sale Statistics��5   	   $��424.954��65   $	��800��6F   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��Grd_cmpTable��5
      $
��Left=�6'   $	��Top=�6B   "   VerticalScrollBarVisibility$
 Auto=�6Z      AutoGenerateColumns .     
IsReadOnly . $	��200��6�   $
��Auto��6�      GridLinesVisibility$
 None=�6�   $��62,5,0,0q�6�      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      -   5        Img��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5   6      Header$ Image��6A      CellTemplate 5      �� 5      .R�5      �� $
��Fill=�6A   ��6$   �� *	imagePath+6A   5      5      0  *System.Windows.Controls.DataGridTextColumn  5      $
 Make��6%   	   MinWidth$	 10Q�6T   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *Manufacturer+6T     5      $ Model��6%   $	 10Q�6O   
 64   �� *Model+6O     5      $ Price��6?   $	 10Q�6N   
 6%   �� *Price+6N     5      $ Transmission��6>   $	 10Q�6T   
 6%   �� *Type+6T     5      $
 Year��6>   $	 10Q�6L   
 6%   �� *Year+6L     5      $
 Fuel��6>   $	 10Q�6L   
 6%   �� *Fuel+6L     5      $ Seats��6?   $	 10Q�6N   
 6%   �� *seats+6N     5      $ 	Tank cap.��6K   $	 10Q�6^   
 6%   �� *fuelTankCapacity+6^     5      $ HP��6D   $	 10Q�6P   
 6%   �� *
horsePower+6P     5      $  Type��6B   $	 10Q�6Q   
 6%   �� *	carType+6Q    � 	Resources 5         DataGridBase �� 
TargetType �� Property �� Value �� Angle �� ScaleX �� ScaleY&   System.Windows.Media.TextOptions*  $System.Windows.Controls.DataGridCell �� BasedOn=	  7System.Windows.Controls.Primitives.DataGridColumnHeader:
  4System.Windows.Controls.Primitives.DataGridRowHeader��%�  &	        '  �     7   '	      7   '
  @    7   �� 5       " ��6-   .�5!      ��  �@�LayoutTransform 5"      V� 5#      .~�5$   "   �� $	 -90Q�62   �� 5%   "   $ 1Q�61   $ -1Q�6<   5&      5(      �� 5)       �@ TextFormattingMode$ Display=�6G   5*      �� 5+      "  6   8   62   �� 5,      " 	 6   8   6:   �� 5-      " 
 6   8   67   5.       � LayoutTransform 5/      V� 50      .~�51      �� $ 90Q�6&   u� 52       u� Matrix$ -1, 0, 0, 1, 0, 0x�6&   53         RowDetailsTemplate 55      �� 56      .R�57      ��  58      V� 59      .~�5:   "   �� $ 90Q�62   u� 5;   "   $ -1, 0, 0, 1, 0, 0x�62   5<      5>      5?      5A      �� 5C   
   -   5        $
��Back��5C      $��Right=�6    $��Bottom=�6<   $��94��6W   $��37��6b   $��	0,0,10,10q�6�   �� 5D   
   -   5        $��
Remove Car��5D      $��Right=�6&   $��Bottom=�6B   $��94��6]   $��37��6h   $��	0,0,10,52q�6�   5G      5H      