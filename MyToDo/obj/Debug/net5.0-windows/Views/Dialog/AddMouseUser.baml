   M S B A M L   `   `   `  ����A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MyToDo.Views.DialogMyToDo.Views.Dialog  5      C&clr-namespace:MyToDo.ViewModels.DialogMyToDo.ViewModels.Dialog  5      &     MyToDo.Views.Dialog.AddMouseUser   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      -local!clr-namespace:MyToDo.Views.Dialog  5      3dialog&clr-namespace:MyToDo.ViewModels.Dialog  5      .��5      � $��0,0,0,38q�6     � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   ]� $��0��6   .+�5      �� $��20,10,20,10q�6   $
��Left=�6-   $��添加新用戶��6C   $��20(�6P   $
��Bold"�6^   �� 5      -   5         ��Name$ btnclose��5   Y   $��Right=�67   $��30��6N   $	��✕��6k      MaterialDesignToolButton#��[  6w   $��20(�6�    � Cursor$
 Hand��6�   $	��Top=�6�   $��Right=�6�   ��6   �� *CancelCommand+6�   5      � 5   
   $��20q�6   $��1��6   $��Center=�6(   .+�5      �� .+�5      �� $
��0,10q�6   $��17(�6)   $	��Top=�6[   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 請輸入MouseId��6p   
�������$ IBeam��6�   ��67   �� *MouseUser.Mouse_ID+6�   �� 5      $
��0,10q�6   $��17(�6)   $	��Top=�6Z   $ 請輸入用戶名��6o   
�������$ IBeam��6�   ��67   �� *MouseUser.User_ID+6�   5      5      �� 5   
   $��	20,0,20,0q�6   $��2��6(    �� Orientation$ 
Horizontal=�65   $��Center=�6N   $��Bottom=�6k   .+�5      �� $	��100��68   $��10q�6D   $��2��6P   $��確定��6]   $��Center=�6j   $��Bottom=�6�   $
 Hand��6�   ��6   �� *ConfirmCommand+6�   �� 5       " MaterialDesignPaperLightButton#��[ 6   $	��100��6o   $��10q�6{   $��2��6�   $��取消��6�   $��Center=�6�   $��Bottom=�6�   $
 Hand��6�   ��6M   �� *CancelCommand+6�   5      5       5!      