   M S B A M L   `   `   `  ����E  ATrabajoWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TrabajoWPF
TrabajoWPF  5   	       TrabajoWPF.AuxWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TrabajoWPF     5   	     � Title$  	AuxWindow��5   	   $	��550��6   $	��650��6(   $	��550��5	   	   $	��650��5
   	   .��5      � -   5        $��AuxGrid��5      ���#212834 � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5    
   &   System.Windows.Controls.DataGrid  -   5        $��G_auxWindow��5    �      BrushBackground0#��[  6   #��[  6B      EnableRowVirtualization .  !   EnableColumnVirtualization .     
IsReadOnly .    AutoGenerateColumns .  $��8��6�   $��6��6
  $��10,10,10,25q�6     VerticalGridLinesBrush
 ����    HorizontalGridLinesBrush
 ���� 	   Columns	 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *ID+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5#      $
 Image��6)   $ * 68    .    CellTemplate 5$      �� 5%      .R�5&      �� $	��100��6?   $��Center=�6L   ��6$   �� *	ImgPath+6L   5'      5)       � 	Resources 5+      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property  BrushBackground2 �� Value  BrushAcentoVerde*  $System.Windows.Controls.DataGridCell  BrushAcentoVerdeOscuro��%  '        7 7  7  '  �     7 7   7  7  �� 5,      8   "  6Q   .�5-      ��  � ��8  63   �� 5.       � ��$ Center=�6C   �� 5/       � ��8  63   �� 50       � ��$ 22��6/   �� 51       � ��$ 16(�61   �� 52       � ��
 ���� 64   53      �� 54      8   "  6I   .�55      ��  � ��8  63   �� 56       � ��8  63   �� 57       � ��$ 20(�61   �� 58       �@��TextAlignment$ Center=�6@   �� 59       � ��8  64   5:      5;      5<      �� 5=   
   -   5        $��C_Show��5=      $��60��6!   $	��192��60   $��5��6V   $��2��6c   $��0��6t   $��3��6�   $��20,55,30,20q�6�     
UICheckBox#��[ 6�   $��16(�6�   #��[ 6�   .��6  Mostrar cartas6  �� 5>   
   -   5        $��L_Diff��5>      $��Dificultad: Fácil��6   $��6��6:   $��3��6G   $��2��6[   $��Center=�6l   $��0,0,25,0q�6�   #��[ 6�   $��16(�6�   $��Center=�6�   �� 5?   
   -   5        $��S_Diff��5?      $��7��6B   $��Center=�6O   $��3��6j   $��	20,0,50,0q�6~    � Maximum$ 2Q�6�    �� TickPlacement$ BottomRight=�6�    �� TickFrequency$ 1Q�6�    �� IsSnapToTickEnabled . 6�   �� 5@   
   -   5        $��T_Save��5@      $��30��6    $��5��6-   $��2��6=   $��5��6Q   $��2��6^   $��	0,10,55,0q�6p   $��16(�6�   #��[ 6�   #��[  6�   
������ $��Center=�6	  �� 5A   
   -   5        $��B_Save��5A      $	��135��6   $��70��6+   $	��260��67   $��6��6F   $��2��6V   $��2��6j   $��5��6{   $��	15,10,5,0q�6�     GreenButton#��[ 6�   $��Center=�6�   $��Center=�6�   .��6  	Guardar6  �� 5B   
   -   5        $��C_Save��5B      $	��125��6L   $��25��6X   $��6��6d   $��2��6t   $��2��6�   $��6��6�   $��	0,25,25,0q�6�   $��16(�6�   #��[ 6�   $��Center=�6�   $��Center=�6   �� DisplayMemberPath$
 Name��6S   �� SelectedItem 6/  ��  �� Path$
 Game�6S  5C      5D      