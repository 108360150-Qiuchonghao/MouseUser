   M S B A M L   `   `   `  ����A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MyToDo.Views.TestViewsMyToDo.Views.TestViews  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      G4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	      S.clr-namespace:MyToDo.ViewModels.TestViewModels MyToDo.ViewModels.TestViewModels  5      -    'MyToDo.Views.TestViews.UserDataTestView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      0local$clr-namespace:MyToDo.Views.TestViews  5      =lv4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      _	 [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes 	 5      ?
viewmodels.clr-namespace:MyToDo.ViewModels.TestViewModels 	 5      .��5      ) 	 #MaterialDesignThemes.Wpf.DialogHost  .��5   
   ) 	 #MaterialDesignThemes.Wpf.DrawerHost      IsRightDrawerOpen  6   �� *IsRightDrawerOpen+   RightDrawerContent 5      � 5       � RowDefinitions 5      �� 5      $
��auto �6(   �� 5      .+�5      �� $��0��5      $��10q�5      $��20(�5      $
��Bold"�5      $��修改用戶信息��5      �� 5      $��1��5       $��10q�5!      $	��Top=�5"       �� Orientation$ Vertical=�5#      .+�5$      �� $��10q�5%      $��20(�5&      ��5'      ��  �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� Path$ SelectedItem.User_ID� �� ElementName$ NameBox�� �� StringFormat$ 舊名稱:{0}���� 5(      $��10q�5)      ) 	 #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 請輸入新名稱��5*      
 � Cursor$
 IBeam��5+      �� 5,      $
��0,20q�6%   $ 
Horizontal=�63   .+�5-      �� $��3q�5.   !   $��確認��50   !   $

 Hand��51   !   $��13(�52   !    "  MaterialDesignPaperLightButton#��[  53   !   ��5/   !   �� *
ModifyTrue+53   !   �� 54      $��3q�55   !   $��取消��57   !   $

 Hand��58   !   $��13(�59   !   #��[  5:   !   ��56   !   �� *Modifycancel+5:   !   5;      5<      5=      .��5@      �  5A      �� 5B      $
��auto �6$   �� 5C      $
��auto �6$   �� 5D      $
��auto �6$   �� 5E      .+�5H      �� $��0��5I      $��20,0,0,0q�5J      $ 
Horizontal=�5K      .+�5L      �� .+�5M      �� -   5         ��Name$ NameBox��5N      $��10q�5O      $��Center=�5P      $��Center=�5Q      $��20(�5R      ��5S      �� *
NameBars+ �� SelectedIndex 5T      �� *	NameIndex+ �� SelectedItem 5U      �� *NameSelectedItem+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5V      +  %Microsoft.Xaml.Behaviors.EventTrigger  5W   "      	EventName$ SelectionChanged��61   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5X   &   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6<   �� *NameListselect+   CommandParameter 6_   �� $ listComboBox��$ SelectedValue�5Y   #   ��5[      �� 5\   "   .R�5]   &   �� ��60   �� *	User_ID+5^   #   5`      5a      �� 5b      $��10q�5c      $��28(�5d      $��日期:��5e      �� 5f      -   5        $ timeBar��5g      $��10q�5h      $��Center=�5i      $��Center=�5j      $

 Hand��5k      $��20(�5l        MyComboBoxStyle#��[ 5n      ��5o      �� *
TimeBars+ 5p      �� *TimeBarIndex+ 5q      �� *TimeSelectedItem+ 5r        5s      $ SelectionChanged��6-   . 5t   "      68   �� *Timelistselect+ 6[   �� $ listComboBox��$ SelectedValue�5u      ��5w      �� 5x      .R�5y   "   �� $��5q�6B   ��6,   �� *Date+6B   5z      5|      �� 5~      $��0��5      $��0,0,15,0q�5�      $��Right=�5�      $��Center=�5�      $��刷新圖表��5�      $

 Hand��5�      #��[  5�      ��5�      �� 5�      5�      �� 5�      $��0��5�      $��0,0,15,0q�5�      $��Right=�5�      $��修改用戶信息��5�      $

 Hand��5�      #��[  5�      ��5�      �� *modifycommand+5�      �� 5�      $��2��5�      $��0,2,0,0q�5�      ���#DDDDDD$��0,0,0,2q�5�      �� 5�      $��2��5�      $��15,0,0,0q�5�      $/��)以上數據更新于2022年4月3日 0:55��5�      �� 5�      $��1��5�      $
��0,10q�5�      ��5�      �� *
TaskBars+��5�      �� 5�      .R�5�      A�  A� Columns$ 3��6*   5�      ��5�      �� 5�      .R�5�      �� $��10q�5�   !    �� CornerRadius$ 4��5�   !   ��5�   !   �� *Color+��5�   "   �� 5�   &    �� 
TargetType" ��6,    �� Triggers 5�   *   P� 5�   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �5�   2   ��  �� Property �@J�Effect �� Value 5�   6   3  -System.Windows.Media.Effects.DropShadowEffect  5�   :      
BlurRadius$ 10Q�5�   =      ShadowDepth$ 1Q�5�   =      Color$ #DDDDDD��5�   =   5�   3   5�   /   .�5�   *   ��  �@�Cursor$
 Hand��6C   5�   '   ._�5�   "   �  5�   &   �� 5�   *   $
��auto �68   �� 5�   *   .+�5�   &   �� .+�5�   *   '	 	 !MaterialDesignThemes.Wpf.PackIcon	  $��15,15q�66    	  Kind 6E   �� *Icon+�� 5�   *   $��	10,5,0,-3q�5�   -   $��20(�5�   -   ��5�   -   �� *Title+�� 5�   *   $��10q�5�   -   $��40(�5�   -   $��Heavy"�5�   -   ��5�   -   �� *	Content+5�   '   �� 5�   &   $
}�True��6-   .+�5�   *   �� 
 �� Top$ 10��5�   -     �� Right$	  -50��5�   -   $	��120��5�   -   $	��120��5�   -   ���#FFFFFF$	 100��5�   -   ! J� Opacity$	! 0.2Q�5�   -   �� 5�   *   $ 50��5�   -   $	  -10��5�   -   $	��120��5�   -   $	��120��5�   -   ���#FFFFFF$ 80��5�   -   $	! 0.2Q�5�   -   5�   '   5�   #   5�      5�      5�      �� 5�      $��3��6   .��5�      �  5�      �� 5�      $
��auto �6,   �� 5�      �� 5�      .+�5�      #
  LiveCharts.Wpf.CartesianChart
  -   5        " 
 Name$" HRChart��5�      $��0��5�      $	��250��5�      $��20q�5�      
�������&   LiveCharts.Wpf.Charts.Base.Chart#   Series# 5�   "     LiveCharts.Wpf.LineSeries  $   LineSmoothness$$ 1Q�5   %   %   PointGeometrySize$% 0Q�5  %     LiveCharts.Wpf.Series&   Stroke
& �����'   StrokeThickness$' 10Q�5  %   (   Values( 5  %   �� *HRData+5     
  5     -   5        $" 	SPO2Chart��5	     $��1��5
     $	��250��5     $��20q�5     
�������# 5     �� *SeriesCollection+)   Zoom) 5     �� *ZoomingMode+*   AxisX* 5  "     LiveCharts.Wpf.Axis  -   5        $��X��5  %      LiveCharts.Wpf.DefaultAxes+   CleanSeparator,   	Separator#, Z+ 5  %   -   LabelFormatter- 5  %   �� *
XFormatter+5  %   .   AxisY. 5  "     -   5        $��Y��5  +   - 64   �� *
YFormatter+5     
  5     $��2��5     $	��250��5     $��20q�5      
�������# 5$  "     $$ 1Q�5%  %   $% 0Q�5&  %   
& �����$' 10Q�5(  %   ( 5)  %   �� *HRData+5+     5,     5-     5.     5/     50     51     