   M S B A M L   `   `   `  ????  	SchoolGUI    SchoolGUI.RegisterWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     ? Title$  RegisterWindow??5   	   $	??720??6    $
??1280??6-   ??5      ?? 5	   
    ?? EndPoint$ 0.5,1&?6    ?? 
StartPoint$ 0.5,0&?6/   .??5
      ?  ? Color$ 	#FF1DA79E??6    ? Offset$ 0.221Q?6-   ? 5      $ 	#FF31C3BA??6   $ 0.233Q?6-   5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??0.26* ?6   ?? 5      .+?5   
   ?? $??0??6   .+?5      ??  ?? Orientation$ 
Horizontal=?6   $??Center=?62   $??Center=?6M   $??0,7,0,0q?6j   .+?5      ?? $??/Pictures/Logo/logo.png??6   $	??130??69   $	??130??6F   $??0,0,50,0q?6R   ?? 5      $7??1Образовательная платформа??6   $??72(?6<   $??Franklin Gothic Medium)?6J   $??90??6n   
?????????6?   Z? 5      5      ?? 5   
   $??1??6   $ Vertical=?6"   $??Center=?69   $??Center=?6T   .+?5      ?? $ 
Horizontal=?6   $??Center=?62   $??Center=?6M   .+?5      ?? -   5         ??Name$  registerwindow_error_label??5      $?? ??6<   $??25(?6G   $??Franklin Gothic Medium)?6U   
???  ??6y   5      ?? 5!      $ 
Horizontal=?6   $??Center=?62   .+?5"      ?? $ Vertical=?6   $??0,0,5,0q?64   .+?5#      ?? $ 
Horizontal=?6!   $??Center=?6:   $
??Left=?6U   .+?5$      ?? $"??Выберите логин:??6    $??25(?6:   $??Franklin Gothic Medium)?6H   
???????6l   5%      ?? 5&      $ 
Horizontal=?6!   $??Center=?6:   $??Center=?6U   .+?5'      ?? -   5         ??Name$" registerwindow_login_textbox??5'   "   $	??300??6?   $??35??6?   ???	#FF0D7C75$??20(?6?   $??Franklin Gothic Medium)?6?   $??Center=?6  $??Center=?62  .??6T  ??5(      ?? 5)   "   $ 0.5,1&?66   $ 0.5,0&?6G   .??5*   &   ? $ 	#FF31C3BA??63   $ 0Q?6E   ? 5+   &   $ 	#FF39FEF2??63   $ 1Q?6E   5,   #   .??5-   2   5.      5/      50      51      ?? 53      $ 
Horizontal=?6   .+?54      ?? $ Vertical=?6   $??0,0,5,0q?64   .+?55      ?? $ 
Horizontal=?6!   $??Center=?6:   $
??Left=?6U   .+?56      ?? $$??Выберите пароль:??6    $??25(?6;   $??Franklin Gothic Medium)?6I   
???????6m   57      ?? 58      $ 
Horizontal=?6!   $??Center=?6:   $??Center=?6U   .+?59      G? -   5        	 G?Name$)	 #registerwindow_password_passwordbox??59   &   $	??300??6?   $??35??6?   ???	#FF0D7C75$??20(?6?   $??Franklin Gothic Medium)?6?   $??Center=?6  $??Center=?6?  ??5:      ?? 5;   "   $ 0.5,1&?66   $ 0.5,0&?6G   .??5<   &   ? $ 	#FF31C3BA??63   $ 0Q?6E   ? 5=   &   $ 	#FF39FEF2??63   $ 1Q?6E   5>   #   5@      5A      5B      ?? 5D      $ Vertical=?6   $??5,0,0,0q?64   .+?5E      ?? $ 
Horizontal=?6!   $??Center=?6:   $
??Left=?6U   .+?5F      ?? $&?? Повторите пароль:??6    $??25(?6<   $??Franklin Gothic Medium)?6J   
???????6n   5G      ?? 5H      $ 
Horizontal=?6!   $??Center=?6:   $??Center=?6U   .+?5I      G? -   5        $*	 $registerwindow_password2_passwordbox??5I   &   $	??300??6?   $??35??6?   ???	#FF0D7C75$??20(?6?   $??Franklin Gothic Medium)?6?   $??Center=?6  $??Center=?6@  ??5J      ?? 5K   "   $ 0.5,1&?66   $ 0.5,0&?6G   .??5L   &   ? $ 	#FF31C3BA??63   $ 0Q?6E   ? 5M   &   $ 	#FF39FEF2??63   $ 1Q?6E   5N   #   5P      5Q      5R      5S      ?? 5U      $ 
Horizontal=?6   .+?5V      ?? $ Vertical=?6   $??0,0,5,0q?64   .+?5W      ?? $ 
Horizontal=?6!   $??Center=?6:   $
??Left=?6U   .+?5X      ?? $??Ваше имя:??6    $??25(?64   $??Franklin Gothic Medium)?6B   
???????6f   5Y      ?? 5Z      $ 
Horizontal=?6!   $??Center=?6:   $??Center=?6U   .+?5[      ?? -   5        $! registerwindow_name_textbox??5[   "   $	??300??6?   $??35??6?   ???	#FF0D7C75$??20(?6?   $??Franklin Gothic Medium)?6?   $??Center=?6	  $??Center=?6-  .??6O  ??5\      ?? 5]   "   $ 0.5,1&?66   $ 0.5,0&?6G   .??5^   &   ? $ 	#FF31C3BA??63   $ 0Q?6E   ? 5_   &   $ 	#FF39FEF2??63   $ 1Q?6E   5`   #   .??5a   2   5b      5c      5d      ?? 5f      $ Vertical=?6   $??5,0,0,0q?64   .+?5g      ?? $ 
Horizontal=?6!   $??Center=?6:   $
??Left=?6U   .+?5h      ?? $??Ваша фамилия:??6    $??25(?68   $??Franklin Gothic Medium)?6F   
???????6j   5i      ?? 5j      $ 
Horizontal=?6!   $??Center=?6:   $??Center=?6U   .+?5k      ?? -   5        $$ registerwindow_surname_textbox??5k   "   $	??300??6?   $??35??6?   ???	#FF0D7C75$??20(?6?   $??Franklin Gothic Medium)?6?   $??Center=?6  $??Center=?60  .??6R  ??5l      ?? 5m   "   $ 0.5,1&?66   $ 0.5,0&?6G   .??5n   &   ? $ 	#FF31C3BA??63   $ 0Q?6E   ? 5o   &   $ 	#FF39FEF2??63   $ 1Q?6E   5p   #   .??5q   2   5r      5s      5t      5u      ?? 5w      $ 
Horizontal=?6   .+?5x      ?? $ Vertical=?6   $??0,0,5,0q?64   .+?5y      ?? $ 
Horizontal=?6!   $??Center=?6:   $
??Left=?6U   .+?5z      ?? $)??#Ваш номер телефона:??6    $??25(?6>   $??Franklin Gothic Medium)?6L   
???????6p   5{      ?? 5|      $ 
Horizontal=?6!   $??Center=?6:   $??Center=?6U   .+?5}      ?? $??+7??6    $??21(?6-   $??Franklin Gothic Medium)?6;   
???????6_   ?? 5~      -   5        $" registerwindow_phone_textbox??5~   "   $?? ??6?   $	??265??6?   $??35??6?   ???	#FF0D7C75$??20(?6?   $??Franklin Gothic Medium)?6?   $??Center=?6  $??Center=?69  .??6[  ??5      ?? 5?   "   $ 0.5,1&?66   $ 0.5,0&?6G   .??5?   &   ? $ 	#FF31C3BA??63   $ 0Q?6E   ? 5?   &   $ 	#FF39FEF2??63   $ 1Q?6E   5?   #   .??5?   2   5?      5?      5?      ?? 5?      $ Vertical=?6   $??5,0,0,0q?64   .+?5?      ?? $ 
Horizontal=?6!   $??Center=?6:   $
??Left=?6U   .+?5?      ?? $1??+Ваша электронная почта:??6    $??25(?6B   $??Franklin Gothic Medium)?6P   
???????6t   5?      ?? 5?      $ 
Horizontal=?6!   $??Center=?6:   $??Center=?6U   .+?5?      ?? -   5        $" registerwindow_email_textbox??5?   "   $	??300??6?   $??35??6?   ???	#FF0D7C75$??20(?6?   $??Franklin Gothic Medium)?6?   $??Center=?6  $??Center=?61  .??6S  ??5?      ?? 5?   "   $ 0.5,1&?66   $ 0.5,0&?6G   .??5?   &   ? $ 	#FF31C3BA??63   $ 0Q?6E   ? 5?   &   $ 	#FF39FEF2??63   $ 1Q?6E   5?   #   .??5?   2   5?      5?      5?      5?      ?? 5?      $ 
Horizontal=?6   $??Center=?62   $??Center=?6M   $??0,20,0,0q?6j   .+?5?      ?? -	   5        
 ??Name$$
 registerwindow_register_button??5?      $*??$Зарегистрироваться??6e   $??30(?6?   $??Franklin Gothic Medium)?6?   ???	#FFDAFF00$	??300??6?   ???	#FFDAFF00??6?   Z? 6?   5?      ?? 5?      $ 
Horizontal=?6   $??Center=?62   $??Right=?6M   $??0,20,0,0q?6i   .+?5?      ?? $9??3Выберите темы для изучения: ??6   $??20(?6?   $??Franklin Gothic Medium)?6M   
???????6q   ?? 5?      $	??300??6   $??70??6+   .??5?      ?? -
   5         ??Name$ themes_stackpanel??5?   !   $ Vertical=?6<   5?      5?      5?      ?? 5?      $ 
Horizontal=?6   $??Center=?62   $??Center=?6M   $??0,20,0,0q?6j   .+?5?      ?? $%??Уже есть аккаунт???6   $??20(?64   $??Franklin Gothic Medium)?6B   
???????6f   ?? 5?      -   5        $??
Войти??5?      $??20(?6J   $??Franklin Gothic Medium)?6X   $??20,0,0,0q?6|   ???	#FFDAFF00??6?   Z? ??6?   Z? 5?      5?      5?      5?      