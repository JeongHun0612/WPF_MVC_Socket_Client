   M S B A M L   `   `   `  ����P  LWPF_MVC_Socket_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WPF_MVC_Socket_Client.ViewModelWPF_MVC_Socket_Client.ViewModel  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� Triggers �� Binding9    3WPF_MVC_Socket_Client.ViewModel.MainWindowViewModel    ReceiveOptionViewModel �� Source �� Path �� Value �� Property �� Value	 �� RelativeSource
 �� AncestorType �� 
TargetType ��Name �� Padding J� SnapsToDevicePixels �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName   ListItemHoverBackgroudBrush & "ListItemSelectedTrueBackgroudBrush ' #ListItemSelectedFalseBackgroudBrush ^� 
Conditions �� Binding  RXTXRectAngleStyle   ListItemRXTagForegroundBrush   ListItemTXTagForegroundBrush  RXTXTagTextStyle  ContentTextStyle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;	viewModel-clr-namespace:WPF_MVC_Socket_Client.ViewModel  5      %   '��       '��     7   7  7  &	 �    7  7  &	 �    7  7  &	 �	    �� 5      "  ��6    5   
   �� 5       6   �� # Z $ IsLineBreak� True6�   .a�5      ��  � ��$ Disabled=�6O   5	      �� 5
       6   �� # Z $ IsLineBreak�	 False6�   .a�5      ��  � ��$
 Auto=�6O   5      5      �� 5      "  ��6   .�5   
   ��  �@�FocusVisualStyle 6-   Z� �� 5   
    �@J�SnapsToDevicePixels . 60   �� 5   
    � �� 67   �� *HorizontalContentAlignment+	 �� "
 ���� 5   
    � �� 65   �� *VerticalContentAlignment+	 �� "
 ���� 5   
    � ��
 ���� 6'   �� 5   
    � ��
 ���� 6(   �� 5   
    � ��$ 1q�6,   �� 5   
    � ��$ 13(�6%   �� 5   
    � ��$ /Fonts/#Roboto Light)�6'   �� 5   
    � ��$ 0q�6$   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� $ Bd��6   #��z��6)   #��z��6U   #��z��6�   # z��6�    . ._�5      �� #��z��6+   # z 6n   #��z��6�   5        5!      ]� 5"       5#      �� 5$   "    �@J�IsMouseOver . 6C   ./�5&      �� $ Bd��6;   8    � ��6K   5'      ]� 5(       5)      �� 5*   "    �@��IsSelectionActive . 6R   �� 5+   "    �@��
IsSelected . 6B   ./�5-      �� $ Bd��6;   8   � ��6K   5.      ]� 5/       50      �� 51   "    �@��IsSelectionActive .  6R   �� 52   "    �@��
IsSelected . 6B   ./�54      �� $ Bd��6;   8   � ��6K   55      ^� 56       57      �� 58   "    6,   �� *	RXTXTag+ [RX]6H   �� 59   "    6,   �� # Z $ 	IsReceive�	 False6�   .0�5;      ��  � y�$ 	Collapsed=�6;   5<      ^� 5=       5>      �� 5?   "    6,   �� *	RXTXTag+ [TX]6H   �� 5@   "    6,   �� # Z $ 
IsTransmit�	 False6�   .0�5B      ��  � y�$ 	Collapsed=�6;   5C      5E      5G      5H      �� 5K      "  ��6'   .�5L   
   ��  � ��
 �   �6#    5M   
   �� 5N       6   �� *	RXTXTag+ [RX]66   .a�5O      ��  � ��8   6)   5P      �� 5Q       6   �� *	RXTXTag+ [TX]66   .a�5R      ��  � ��8  6)   5S      5U      �� 5X      "  ��6%    5Y   
   �� 5Z       6   �� *	RXTXTag+ [RX]66   .a�5[      ��  � ��8   6/   5\      �� 5]       6   �� *	RXTXTag+ [TX]66   .a�5^      ��  � ��8  6/   5_      5a      �� 5d      "  ��6%    5e   
   �� 5f       6   �� # Z $ IsLineBreak� True6�   .a�5g      ��  � ��$
 Wrap=�61   5h      �� 5i       6   �� # Z $ IsLineBreak�	 False6�   .a�5j      ��  � ��$ NoWrap=�61   5k      5m      5n      