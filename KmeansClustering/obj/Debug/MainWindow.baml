   M S B A M L   `   `   `  ����K  GKmeansClustering, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:KmeansClusteringKmeansClustering  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   !    KmeansClustering.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:KmeansClustering     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � WindowState$  	Maximized=�5       � Title$ 
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��1��6   $��	0 10 5 10q�6%   .+�5      �� $��10q�6   
����� ���64   �� *
NewCommand+.��5      �� .+�5      �� $��Nouvelle��6    $��16(�61   $
��Bold"�6?   $��Center=�6Q   �� 5      $��
Simulation��6    $��16(�63   $
��Bold"�6A   5      5      5      �� 5   
   $��0��6   $��1q�6!   
���   �$��10q�6I   ._�5      �  5      �� 5      $��* �6'   �� 5      $��4* �6'    � RowDefinitions 5!      �� 5"      $��* �6$   .+�5$      �� $��0��6   $��5q�6)   $��1q�64   
���   � �� Padding$ 10q�6\   ._�5%      �� .+�5&      �� $	��0.1q�6!   
���   �$��0 5 0 5q�6K   �� 5'      .+�5(      �� $��Classification :��6(   �� 5)      $��18(�6H   ��6(   �� *Classification+6H   5*      �� 5+      $	��0.1q�6!   
���   �$��0 5 0 5q�6K   �� 5,      .+�5-      �� $(��"Algorithms de Calcule de Distance:��6(   �� 5.      $��18(�6K   ��6(   �� *SelectedAlgorithm+6K   5/      �� 51      $	��0.1q�6!   
���   �$��0 5 0 5q�6K   �� 52      .+�53      �� $��N° Cluster :��6(   �� 54      $��18(�6D   ��6(   �� *
NbClusters+6D   55      �� 56      $	��0.1q�6!   
���   �$��0 5 0 5q�6K   �� 57      .+�58      �� $��N° Point :��6(   �� 59      $��18(�6B   ��6(   �� *
NbPoints+6B   5:      �� 5;      $	��0.1q�6!   
���   �$��0 5 0 5q�6K   �� 5<      .+�5=      �� $��Temp d'Execution :��6(   �� 5>       �� Orientation$ 
Horizontal=�6)   .+�5?   "   �� $��18(�6K   ��6,   �� *ExecutionTime+6K   �� 5@   "   $	�� ms��6,   $��18(�67   5A      5B      �� 5C      $	��0.1q�6!   
���   �$��0 5 0 5q�6K   �� 5D      .+�5E      �  5F   "   �� 5G   &   $��* �67   �� 5H   &   $
��auto �67   .+�5K   "   �� $��0��6-   .+�5L   &   �� $��Sillouette % :��60   �� 5M   &   $ 
Horizontal=�61   .+�5N   *   �� $��18(�6Z   ��64   �� *SilhouettePercentage+6Z   �� 5O   *   $�� %��64   $��18(�6>   5P   '   5Q   #   �� 5R   "   $��1��6)   $��0 5 5 5q�69   $��18(�6J   $	��5 0q�6X   ��5S   )   �� *SilouetteCommand+.��5T   &   �� $��	Consulter��60   5U   #   5W      5Z      �� 5[      $	��0.1q�6!   
���   �$��0 5 0 5q�6K   5\      5]      �� 5^      $��1��6   $��5q�6)   $��1q�64   
���   �._�5_      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   DisableAnimations .    Series 6)   �� *SeriesCollection+5a      5b      5c      5f      5h      5i      