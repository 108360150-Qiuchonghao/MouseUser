   M S B A M L   `   `   `  ����A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MyToDo.ExtensionsMyToDo.Extensions  5      +clr-namespace:MyToDo.ViewsMyToDo.Views  5      5clr-namespace:MyToDo.ViewModelsMyToDo.ViewModels  5          MyToDo.Views.LoginView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      *passclr-namespace:MyToDo.Extensions  5      &localclr-namespace:MyToDo.Views  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	      [	 WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T
 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/ 	 
 5
      2
viewmodelsclr-namespace:MyToDo.ViewModels 	 
 5      $	��600��5      $	��350��6   # 
 Prism.Services.Dialogs.Dialog    WindowStyle  5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value$	 600��6&   �� 5       � ��$	 350��6'   �� 5       �@�SizeToContent$ WidthAndHeight=�6.   �� 5       �@�
ResizeMode$ NoResize=�6+   �� 5       �@ WindowStartupLocation$ CenterScreen=�6C   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      .+�5   
   �� $��50q�6   $��/Images/user1.jpg��6   '  !MaterialDesignThemes.Wpf.Snackbar  5    
   -   5          Name$ LoginSnackbar��5        K� ZIndex$ 0��6-   $��2��5!   7      MessageQueue 6   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  67   7  1MaterialDesignThemes.Wpf.Transitions.Transitioner  5"   
   $��1��6    �� SelectedIndex 6*   �� *SelectIndex+	 �� FallbackValue$	 0��.@�5#      <  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide  .��5$      ]� $��1��6   $��Center=�6-   $��20q�6H   
 � Cursor$
 IBeam��6T   .+�5%      �� $��歡迎使用��6    $��20(�6,   $
��Bold"�6:   $
��0,30q�6L   $	��Top=�6Z   �� 5&      $
��0,10q�6   $	��Top=�6-   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 請輸入賬號��6B   
�������$
 IBeam��6�   ��6p   �� *	Account+6�   G� 5'      $
��0,10q�6"   $	��Top=�60   $ 請輸入密碼��6E   
�������$
 IBeam��6�   *   $MyToDo.Extensions.PassWordExtensions   PassWord 6s   �� *
Password+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5(      (	   "MyToDo.Extensions.PasswordBehavior	  5)      5+      �� 5-      -   5         ��Name$ 	btn_login��5-      
�������$��登錄��6C   $	��Top=�6P   $

 Hand��6e   $��Login��6�   ��6t   �� *ExecuteCommand+6�   ]� 5.      $��False��6    $
��0,17q�67   .+�5/      �� $��註冊賬號��6$   $

 Hand��60      Triggers 50      +
  %Microsoft.Xaml.Behaviors.EventTrigger
  51   "    
  	EventName$ MouseLeftButtonDown��61   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 52   &   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter$ Go��6_      Command 6<   �� *ExecuteCommand+6_   53   #   55      �� 57      $��忘記密碼��6$   $��Right=�60   59      5:      5;        5<      .��5=      ]� $��Center=�6   $��10q�67   .+�5>      �� $��註冊賬號��6    $	��0,5q�6,   $��30(�69   $
��Bold"�6G   $	��Top=�6Y   �� 5?      $	��Top=�6   $ 請輸入賬號��64   $
��0,10q�6p   ��6O   �� *UserDto.Account+6p   �� 5@      $	��Top=�6   $ 請輸入用戶名��63   $
��0,10q�6q   ��6O   �� *UserDto.UserName+6q   G� 5A      $
��0,10q�6"   $	��Top=�60   $ 請輸入密碼��6E   
�������$
 IBeam��6�    6s   �� *UserDto.PassWord+$ TwoWay=�$ PropertyChanged=� 5B      	  5C      5E      G� 5F      $
��0,10q�6"   $	��Top=�60   $ 請再次輸入密碼��6E   
�������$
 IBeam��6�    6u   �� *UserDto.NewPassWord+$ TwoWay=�$ PropertyChanged=� 5G      	  5H      5J      �� 5L      $��註冊賬號��6   $��Register��5M      $	��Top=�5N      $��10q�5O      $

 Hand��5P      ��5L   ,   �� *ExecuteCommand+5P      �� 5Q      $��返回登錄��6   $��Return��5R      $	��Top=�5S      $��10q�5T      $

 Hand��5U      ��5Q   ,   �� *ExecuteCommand+5U      5W      5X      5Y      5\      5]      