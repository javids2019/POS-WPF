   M S B A M L   `   `   `  ����N  JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:FirstFloor.ModernUI.Windows.Controls$FirstFloor.ModernUI.Windows.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089b ^Microsoft.Windows.Shell, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35  �� MergedDictionaries �� Source7    1FirstFloor.ModernUI.Windows.Controls.ModernWindow �� 
TargetType �� Property   WindowBackgroundContent �� Value  DefaultFontFamily  DefaultFontSize  
WindowText&   System.Windows.Media.TextOptions �� 
TargetType ��Name/  )Microsoft.Windows.Shell.SystemParameters2   Current �� Source	 �� Path  WindowBackgroundColor
 �� Color � 	Resources  Key �� 
TargetName �� TargetProperty	 �� To g� Duration  WindowBorder �Name � RowDefinitions    BackgroundContent 
 Accent  ModernWindowTitle    IsTitleVisible � DataContext 	 ToUpperConverter �� 	Converter  
 BooleanToVisibilityConverter �� 	Converter � LayoutTransform �� Angle    LogoData  NullToVisibilityConverter �� ConverterParameter �� Stretch �� Orientation*  $Microsoft.Windows.Shell.WindowChrome   IsHitTestVisibleInChrome � ToolTip  SystemButton,  &Microsoft.Windows.Shell.SystemCommands   MinimizeWindowCommand  �� RelativeSource! �� Mode" �� AncestorType# ��Name$   RestoreWindowCommand% � UseLayoutRounding&   MaximizeWindowCommand'   CloseWindowCommand(    
TitleLinks) ��Name	* �� X1	+ �� Y1	, �� X2	- �� Y2  SeparatorBackground  SystemButtonLink. �� ElementName/ �� Triggers0 �� Binding1 �� Value2 �� 
TargetName5   /FirstFloor.ModernUI.Windows.Controls.ModernMenu3    MenuLinkGroups4   
LinkGroups5   SelectedSource6 �� Mode7   1FirstFloor.ModernUI.Windows.Controls.ModernButton7   IconData6   0FirstFloor.ModernUI.Windows.Controls.ModernFrame8  Name9    ContentLoader:   ContentLoader;   Source< F�Name  WindowBorderActive= �� Triggers> P� Property? P� Value@ ]� 
ConditionsA �� PropertyB �� ValueC   CornerRadiusD   GlassFrameThicknessE   UseAeroCaptionButtons�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ?controls2clr-namespace:FirstFloor.ModernUI.Windows.Controls  5      Kshell?http://schemas.microsoft.com/winfx/2006/xaml/presentation/shell  5        5      �� 5   
   $7 1/FirstFloor.ModernUI;component/Assets/Button.xaml?�6   �� 5   
   $; 5/FirstFloor.ModernUI;component/Assets/Converters.xaml?�6   %�  '         7 	 7 
 7  7  7  7  7  7  7 
 �� 5      "   6   .�5   
   ��  �@  BackgroundContent# �   6.   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6%   �� 5   
    � ��# �  6'   �� 5   
    � ��$	 800��6"   �� 5   
    � ��$	 640��6#   �� 5   
    � ��$	 320��6%   �� 5   
    � ��$	 320��6&   �� 5   
    �@�
ResizeMode$ CanResizeWithGrip=�6'   �� 5   
    �@�UseLayoutRounding . 6.   �� 5   
    �@ TextFormattingMode$ Display=�6;   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� $ WindowBorder��6   ��63   �� # Z $#	 WindowNonClientFrameThickness���5      �� 5      WindowBorderBackground��#
 �  6N    5      ���� 5       BackgroundAnimation .��5!   "   �� $ WindowBorderBackground��61   $ Color�6`   # �  6�   $ 0:0:.6D�6�   5"      5#      ._�5%      � .+�5&      �� #���  6%   $��1q�6R   ._�5'   "   �� .u�5(   &   � $ 
LayoutRoot��6+    5)   *   �� 5*   .   $��36 �6<   �� 5+   .   $
��Auto �6<   �� 5,   .   $
��Auto �6<   �� 5-   .   $��* �6<   �� 5.   .   $��15 �6<   .+�52   *   �� $��5��69   #��z 6J   �� 55   *   $��5��61   #���  56   1   $z�1,0,0,1,0,32W�57   1   $��14��58   1   $��53��6?   $
��Left=�59   1   $	��Top=�5:   1   ._�5;   .   �� 
�������$	��0,8q�5=   8   #���  5>   8   $��Center=�5?   8   # z 5@   8   ��5;   8   �� *Title+8   y�5A   8   �� 8   5B   2   �� 5C   6   $	 -90Q�6F   5E   /   5F   +   �� 5I   *   #���  61   $��36��6W   $��36��6b   $��Right=�6n   $	��Top=�6�   $��0,0,76,0q�6�   # z 5J   1   y�5K   1   �� 8  $ inverse��._�5L   .   F� $
 Fill=�6D   
�������$��24��6`   $��24��6k   $��Center=�6w   $��Center=�6�   ��63   �� 6�   5M   +   �� 5P   *   $ 
Horizontal=�65   $��Right=�6N   $	��Top=�6j   $��0,8,6,0q�6�    . .+�5Q   .   �� $ minimize��6�   8�� ��65   �� # Z ��5R   2   � 5S   6   $��13��6;   $��12��6F   $z�1,0,0,1,0,1W�6R   .+�5T   :   F� ����    ��[ � z ��[ 	$��8��6R   $��7��6\   $��Center=�6g   $��Center=�6�   $��2��5U   �   ��6?   �� *
Foreground+  �� $! FindAncestor=�$" ButtonL�6�   5V   7   5X   /   � 5Y   .   $��1,0,1,0q�63   .+�5Z   2   �� $# Restore��69   $ restore��6�   8�� $y�	Collapsed=�6�   ��6J   �� # Z$ ��5[   6   � 5\   :   $��13��6?   $��12��6J   % . $z�1,0,0,1,.5,.5W�6o   .+�5]   >   F� X���Ѐ�     � z     � z ��[ �    ��- р�[ ��- �    �� р�[ �� р�[  z �     z 	$��8��6y   $��8��6�   $��Center=�6�   $��Center=�6�   $��1��5^   �   ��6C   �� *
Foreground+  �� $! FindAncestor=�$" ButtonL�6�   5_   ;   5a   3   �� 5b   2   $# Maximize��69   $ maximize��6�   8�� ��6K   �� # Z& ��5c   6   � 5d   :   $��13��6?   $��12��6J   .+�5e   >   F� +����    @B �@T� @B �@T�  z �     z 	$��9��6`   $��8��6j   $��Center=�6u   $��Center=�6�   $��2��5f   �   ��6C   �� *
Foreground+  �� $! FindAncestor=�$" ButtonL�6�   5g   ;   5i   3   5j   /   �� 5k   .   $ close��6�   8�� ��65   �� # Z' ��5l   2   � 5m   6   $��13��6;   $��12��6F   $z�1,0,0,1,0,1W�6R   .+�5n   :   F� +����        � z ��j � z     �    ��j 	$��8��6\   $��7��6f   $��Center=�6q   $��Center=�6�   $	��1.5��5o   �   ��6?   �� *
Foreground+  �� $! FindAncestor=�$" ButtonL�6�   5p   7   5r   /   5s   +   �� 5v   *   #��z( 67   $��Right=�6b   $	��Top=�6~   $��	0,6,180,0q�6�    . ��5w   .   �� 5x   2   .R�5y   6   �� $ 
Horizontal=�6A   5z   3   ��5|   .   �� 5}   2   .R�5~   6   �� $ 
Horizontal=�6A   .+�5   :   �� $) 	Separator��6?   $* .5��6R   $+ 3��6Z   $, .5��6a   $- 12��6i   $��7,0,5,0q�6q   #���  6�   �� 5�   :   $!��NavigationCommands.GoToPage��5�   A   8�� ��5�   A   �� *DisplayName+��5�   A   �� *Source+��5�   A   �� $. ContentFrame��5�   A   5�   7   / 5�   6   �� 5�   :   0 6F   ��   �� *PreviousData+1 6�   Z� .a�5�   >   �� $2 	Separator��6[    � y�$ 	Collapsed=�6r   5�   ;   5�   3   5�   +     5�   *   $��1��6>   $��36,0,0,0q�5�   >   #4 z3 5�   >   5 5�   >   �� *Source+$. ContentFrame��$6 TwoWay=�5�   >     5�   *   a7 ��@����O�@������p\-�������@��� �8@����ا  6n� �8��� ������� �p\-��O�@����O$#��NavigationCommands.BrowseBack��5�   @   $
 back��5�   @   $��2��5�   @   $
��Left=�6Q   $	��Top=�6l   $��	34,24,0,0q�6�    . ��5�   @   �� $. ContentFrame��5�   +     5�   *   $8 ContentFrame��6?   $��3��6U   $��2��6b   $��
36,8,16,16q�6s   #: z9 6�   ; 6�   �� *ContentSource+  �� *TemplatedParent+$6 TwoWay=�6�   � 5�   *   $��4��6/   .+�5�   .   F� $< 
ResizeGrip��63   $y�	Collapsed=�6G   $��12��6^   $��12��6i   $��1q�6u   $��Right=�6�   #���  5�   3   $��1��5�   3   $
 None=�5�   3   �����@B ��� ���- ��� �@KL ��� ���j ��� �@T� ��� ��ا ��� Ѐ� @T� р� �ا Ѐ�[ @T� р�[ �ا Ѐ�� @T� р�� �ا �@KL ��[ ���j ��[ �@T� ��[ ��ا ��[ Ѐ�[ @KL р�[ ��j Ѐ�� @KL р�� ��j �@T� �� ��ا �� Ѐ�� @B р�� ��- 5�   3   5�   +   5�   '   5�   #   5�      �� 5�      #���  6%   $��1q�6X   y�6l   �� *
IsActive+  �� *FindAncestor+"" �8  5�      5�      = 5�      P� 5�      > �@�WindowState$? 	Maximized=�69   . �5�      �� $2 Maximize��6%    � y�$ 	Collapsed=�6Q   �� 5�      $2 Restore��6%    � y�$ Visible=�6P   �� 5�      $2 
LayoutRoot��6%    � ��$ 7q�6O   5�      P� 5�      > �@�WindowState$? Normal=�69   . �5�      �� $2 Maximize��6%    � y�$ Visible=�6Q   �� 5�      $2 Restore��6%    � y�$ 	Collapsed=�6P   5�      ]� 5�      @ 5�      �� 5�   "   A �@�
ResizeMode$B CanResizeWithGrip=�6B   �� 5�   "   A �@�WindowState$B Normal=�6C   ./�5�      �� $2 
ResizeGrip��6%    � y�$ Visible=�6S   5�      5�      5�      �� 5�   
    �@ WindowChrome 5�        5�      $C 0��6%   $D 1q�66   E .  6N   5�      5�      5�      