   M S B A M L   `   `   `  ����P  LWPF_MVC_Socket_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WPF_MVC_Socket_Client.ViewModelWPF_MVC_Socket_Client.ViewModel  5      I)clr-namespace:WPF_MVC_Socket_Client.ModelWPF_MVC_Socket_Client.Model  5      0    *WPF_MVC_Socket_Client.View.DataReceiveView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      C	viewModel-clr-namespace:WPF_MVC_Socket_Client.ViewModel     5      ;model)clr-namespace:WPF_MVC_Socket_Client.Model     5        � DataContext  5      :   4WPF_MVC_Socket_Client.ViewModel.DataReceiveViewModel  5   
    J� InputBindings 5      �� 5   
    �� 	Modifiers$
 Ctrlf�6   
 �� Key$ S��6&    �� Command 6.   �� *CommandSaveClick+�� 5   
   $
 Ctrlf�6   $ X��6&    6.   �� *CommandClearClick+.��5      �  � RowDefinitions 5   
   �� 5      $��34 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��Right=�6   $��0,2,0,0q�68   .+�5      � .+�5      �� $
��Save��6   $��70��6(   $��25��63   ��6?   �� *CommandSaveClick+�� 5         ErrorButtonStyle#���   6   $��Clear��6D   $��70��6T   $��25��6_   $��10,0,0,0q�6�   ��6k   �� *CommandClearClick+6�   5      5       �� 5#   
   $��1��6     MainBackgroundBrush#��[ 6     ContentBorderBrush#��[ 6P   $��1q�6�   ._�5$      �� -   5        $��Visible=�5$   �   $��Disabled=�6�   .��5%      �� -   5         ��Name$ DataReceiveListView��5%      
������ $��0q�6     ContentForegroundBrush#��[ 6�    �� SelectionMode$ Extended=�6�   ��68   �� *ReceiveDataCollection+��5&      �� 5'       �� DataType2   ,WPF_MVC_Socket_Client.Model.ReceiveDataModel"  6'   .R�5(      � .+�5)   "   ��   RXTXRectAngleStyle#���  6,   $��10��6Y   y�6d   �� 9   3WPF_MVC_Socket_Client.ViewModel.MainWindowViewModel	   ReceiveOptionViewModel
 �� Source#
 Z	  �� Path$ 	IsRXTXTag�  BoolToVisibilityReverse �� 	Converter# [ �� 5*   "   $
��Auto��6,     RXTXTagTextStyle#���  69   $��0,0,5,0q�6}   ��6d   �� *	RXTXTag+y�5+   (   �� #
 Z	 $ 	IsRXTXTag�  BoolToVisibility# [ �� 5,   "   $
��Auto��6,   $��0,0,5,0q�6O   ��69   �� *Time+y�5-   ,   �� #
 Z	 $ 	IsTimeTag�# [ �� 5.   "   $
��Auto��6,     ContentTextStyle#���  69   ��6d   �� *	Content+5/      50       52      �� 53      $
 Ctrlf�6%   $ C��66    6>   �� *CommandSelectedItemCopy+ �� CommandParameter 6j   ��  �� ElementName$ DataReceiveListView��$ SelectedItems�55      56      57      58      59      