   M S B A M L   `   `   `  ����E  ATrabajoWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TrabajoWPF
TrabajoWPF  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source �� 
TargetType   
UICheckBox �� Property �� Value �� 
TargetType �Name � ColumnDefinitions � RowDefinitions	 ��Name  BrushBackground0
 �� CornerRadius  BrushBackground1 ��Name �� Triggers ]� 
Conditions �� Property �� Value N� EnterActions ��Name g� Duration �� 
TargetName �� TargetProperty  ColorBackground1Light	 �� To	 t� To N� ExitActions g� FillBehavior  ColorBackground1  ColorAcentoVerdeClaro  ColorAcentoVerde�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      "localclr-namespace:TrabajoWPF  5        5      �� 5   
   $) #pack://application:,,,/Colours.xaml?�6   %  &	        7  7  7  7  7  7  7  �� 5      " ��6   .�5   
   ��  � �� 5	      �� 5
      " ��6"   .R�5      �� 
������ $��2q�67   ._�5      � $ MainGrid��6    5      �� 5   "   �� 5   "   �� 5   "   �� 5   "   �� 5   "   �� 5   "    5      �� 5   "   �� 5   "   �� 5   "   �� 5   "   .+�5      �� $	 
MainBorder��6%   $��0��69   $��0��6F   $��6��6V   $��4��6j   $��5,5,20,5q�6{   8��  $
 4��6�   �� 5      $	 CheckBorder��6%   $��1��6:   $��0��6G   $��3��6W   $��2��6k   $��	14,2,56,2q�6|   8�� $
 4��6�   �� 5      $	 GreenBorder��6&   $��1��6;   $��0��6H   $��2��6X   $��2��6l   
������ 
������ $��	18,6,30,6q�6�   $
 1��6�   �� 5      $	 GreenBorder2��6&   $��1��6<   $��0��6I   $��2��6Y   $��2��6m   
������ 
������ $��	18,6,30,6q�6�   $
 1��6�   �� 5       $ MainContentPresenter��6/   $��0��6M   $��52,0,0,1q�6]   $
��Left=�6o   $��Center=�6�   $��6��6�   $��1��6�   $��2��6�   |�.  ��. 6�   5!      5"       5$      ]� 5%       5&      �� 5'   "    � {� . 6A   �� 5(   "    �@J�IsMouseOver . 6C    5*      �� 5+   "   .��5,   &   �� $ 
MouserOver��61   .��5-   *   �� $ 
0:0:0:0.15D�69   $ CheckBorder��6O   $ Background.Color�6s   8  6�   t� 5.   *   $ CheckBorder��6=   $ Margin�6a   $ 	12,0,54,0X�6�   $ 
0:0:0:0.15D�6�   5/   '   50   #    52      �� 53   "   .��54   &   �� $ 	MouserOut��61   $
 Stop=�6D   .��55   *   �� $ 
0:0:0:0.15D�69   $ CheckBorder��6O   $ Background.Color�6s   8  6�   t� 56   *   $ CheckBorder��6=   $ Margin�6a   $ 	14,2,56,2X�6�   $ 
0:0:0:0.15D�6�   57   '   58   #   5:      ]� 5<       5=      �� 5>   "    � {� . 6A   �� 5?   "    �@J�IsMouseOver . 6C   �� 5@   "    �@d�	IsChecked$
 trueY�6A    5B      �� 5C   "   .��5D   &   �� $ MouserOver2��61   .��5E   *   �� $ 
0:0:0:0.15D�69   $ GreenBorder2��6O   $ Background.Color�6t   8  6�   t� 5F   *   $ GreenBorder2��6=   $ Margin�6b   $ 	16,4,28,4X�6�   $ 
0:0:0:0.15D�6�   5G   '   5H   #    5J      �� 5K   "   .��5L   &   �� $ 
MouserOut2��61   $
 Stop=�6E   .��5M   *   �� $ 
0:0:0:0.15D�69   $ GreenBorder2��6O   $ Background.Color�6t   $ TransparentX�6�   t� 5N   *   $ GreenBorder2��6=   $ Margin�6b   $ 	18,6,30,6X�6�   $ 
0:0:0:0.15D�6�   5O   '   5P   #   5R      ]� 5T       5U      �� 5V   "    � {� . 6A   �� 5W   "    �@d�	IsChecked$
 trueY�6A    5Y      �� 5Z   "   .��5[   &   �� $ Checked��61   .��5\   *   �� $ 
0:0:0:0.15D�69   $ GreenBorder��6O   $ Background.Color�6s   8  6�   5]   '   5^   #    5`      �� 5a   "   .��5b   &   �� $ 
NotChecked��61   $
 Stop=�6E   .��5c   *   �� $ 
0:0:0:0.15D�69   $ GreenBorder��6O   $ Background.Color�6s   8  6�   5d   '   5e   #   5g      5i      5k      5l      5n      