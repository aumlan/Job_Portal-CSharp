   M S B A M L   `   `   `  ����F  BProjectDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjectDemoProjectDemo  5   	        ProjectDemo.Company_Resume   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjectDemo     5   	     � Title$  Company_Resume��5   	   $	��720��6    $
��1280��6-    � WindowStartupLocation$ CenterScreen=�6:   .��5	      � ��5
   
   �� 5       �� ImageSource$ aaaaaaaaaaaaa.jpg��6   .+�5   
   �� $��Company Profile��6   $
��Left=�6*   $��
400,10,0,0q�6E   $	��Top=�6Y   $��52��6q   $	��298��6}   $��30(�6�   �� 5   
   $��Company Name��6   $��	64,83,0,0q�6'   $	��244��6:   $��20(�6F   $��72��6T   $
��Left=�6`   $	��Top=�6{   ���	#DDFFFFFF6�   �� 5   
   $��Email��6   $��
64,138,0,0q�6    $	��123��64   $��20(�6@   $��72��6N   $
��Left=�6Z   $	��Top=�6u   ���	#DDFFFFFF6�   �� 5   
   $��Address��6   $��
64,251,0,0q�6"   $	��161��66   $��20(�6B   $��69��6P   $
��Left=�6\   $	��Top=�6w   ���	#DDFFFFFF6�   �� 5   
   $��Contact��6   $��
63,303,0,0q�6"   $	��166��66   $��20(�6B   $��72��6P   $
��Left=�6\   $	��Top=�6w   ���	#DDFFFFFF6�   �� 5   
   $
��Type��6   $��68,356,0,-9q�6   $	��146��64   $��20(�6@   $��72��6N   $
��Left=�6Z   $	��Top=�6u   ���	#DDFFFFFF6�   �� 5   
   $��Website��6   $��64,410,0,-63q�6"   $	��146��68   $��20(�6D   $��72��6R   $
��Left=�6^   $	��Top=�6y   ���	#DDFFFFFF6�   �� 5   
   $��Trade License��6   $��64,464,0,-117q�6(   $	��270��6?   $��20(�6K   $��72��6Y   $
��Left=�6e   $	��Top=�6�   ���	#DDFFFFFF6�   �� 5   
   $��Description��6   $��68,535,0,-188q�6&   $	��210��6=   $��20(�6I   $��72��6W   $
��Left=�6c   $	��Top=�6~   ���	#DDFFFFFF6�   �� 5   
   $��Password��6   $��
64,190,0,0q�6#   $	��146��67   $��20(�6C   $��72��6Q   $
��Left=�6]   $	��Top=�6x   ���	#DDFFFFFF6�   �� 5   
   -   5         ��Name$
 back��5      $
��Back��6   $
��Left=�6.   $��1079,611,0,0q�6I   $	��Top=�6_   $	��131��6w   $��47��6�   6�   �� 5   
   -   5         ��Name$ companyName��5      $�� ��6%   $
��Left=�60   $��
378,89,0,0q�6K   $	��Top=�6_   $	��243��6w   $��50��6�   ���	#DDFFFFFF$��20(�6�   �� 5   
   -   5        $ companyEmail��5      $�� ��6&   $
��Left=�61   $��378,147,0,0q�6L   $	��Top=�6a   $	��243��6y   $��42��6�   ���	#DDFFFFFF$��20(�6�   �� 5   
   -   5        $ companyPass��5      $�� ��6%   $
��Left=�60   $��378,201,0,0q�6K   $	��Top=�6`   $	��243��6x   $��44��6�   ���	#DDFFFFFF$��20(�6�   �� 5   
   -   5        $ companyAddress��5      $�� ��6(   $
��Left=�63   $��378,260,0,0q�6N   $	��Top=�6c   $	��243��6{   $��46��6�   ���	#DDFFFFFF$��20(�6�   �� 5   
   -   5        $ companyContact��5      $�� ��6(   $
��Left=�63   $��378,313,0,0q�6N   $	��Top=�6c   $	��243��6{   $��47��6�   ���	#DDFFFFFF$��20(�6�   �� 5   
   -   5        $ companyType��5      $�� ��6%   $
��Left=�60   $��378,365,0,0q�6K   $	��Top=�6`   $	��243��6x   $��48��6�   ���	#DDFFFFFF$��20(�6�   �� 5   
   -   5        $ companyWebsite��5      $�� ��6(   $
��Left=�63   $��378,421,0,-48q�6N   $	��Top=�6e   $	��243��6}   $��46��6�   ���	#DDFFFFFF$��20(�6�   �� 5   
   -	   5        $ companyTLicense��5      $�� ��6)   $
��Left=�64   $��378,470,0,-107q�6O   $	��Top=�6g   $	��243��6   $��56��6�   ���	#DDFFFFFF$��20(�6�   �� 5    
   -
   5        $ companyDescription��5       $�� ��6,   $
��Left=�67   $��382,536,0,-221q�6R   $	��Top=�6j   $	��242��6�   $	��104��6�   ���	#DDFFFFFF$��20(�6�   �� 5!   
   $��:��6   $
��Left=�6   $��
298,87,0,0q�67   $	��Top=�6K   $��20(�6c   $��47��6q   $��17��6}   ���	#DDFFFFFF6�   �� 5"   
   $��:��6   $
��Left=�6   $��298,137,0,0q�67   $	��Top=�6L   $��20(�6d   $��46��6r   $��17��6~   ���	#DDFFFFFF6�   �� 5#   
   $��:��6   $
��Left=�6   $��298,190,0,0q�67   $	��Top=�6L   $��20(�6d   $��46��6r   $��17��6~   ���	#DDFFFFFF6�   �� 5$   
   $��:��6   $
��Left=�6   $��300,254,0,0q�67   $	��Top=�6L   $��20(�6d   $��46��6r   $��16��6~   ���	#DDFFFFFF6�   �� 5%   
   $��:��6   $
��Left=�6   $��298,307,0,0q�67   $	��Top=�6L   $��20(�6d   $��47��6r   $��17��6~   ���	#DDFFFFFF6�   �� 5&   
   $��:��6   $
��Left=�6   $��298,358,0,0q�67   $	��Top=�6L   $��20(�6d   $��46��6r   $��17��6~   ���	#DDFFFFFF6�   �� 5'   
   $��:��6   $
��Left=�6   $��298,412,0,-40q�67   $	��Top=�6N   $��20(�6f   $��47��6t   $��17��6�   ���	#DDFFFFFF6�   �� 5(   
   $��:��6   $
��Left=�6   $��298,466,0,-94q�67   $	��Top=�6N   $��20(�6f   $��47��6t   $��17��6�   ���	#DDFFFFFF6�   �� 5)   
   $��:��6   $
��Left=�6   $��298,538,0,-166q�67   $	��Top=�6O   $��20(�6g   $��47��6u   $��17��6�   ���	#DDFFFFFF6�   �� 5*   
   $��Interview Time:��6   $
��Left=�6*   $��720,144,0,0q�6E   $	��Top=�6Z   $	��148��6r   $��52��6~   $��20(�6�   ���	#DDFFFFFF6�   �� 5+   
   $��Interview Location:��6   $
��Left=�6.   $��720,198,0,0q�6I   $	��Top=�6^   $	��181��6v   $��52��6�   $��20(�6�   ���	#DDFFFFFF6�   �� 5,   
   $��Interview Date:��6   $
��Left=�6*   $��
720,89,0,0q�6E   $	��Top=�6Y   $	��148��6q   $��52��6}   $��20(�6�   ���	#DDFFFFFF6�   �� 5-   
   -   5        $ cseInterViewDate��5-      $�� ��6*   $
��Left=�65   $��
920,86,0,0q�6P   $	��Top=�6d   $	��243��6|   $��50��6�   ���	#DDFFFFFF$��20(�6�   �� 5.   
   -   5        $ cseInterViewTime��5.      $�� ��6*   $
��Left=�65   $��920,141,0,0q�6P   $	��Top=�6e   $	��243��6}   $��50��6�   ���	#DDFFFFFF$��20(�6�   �� 5/   
   -   5        $ cseInterViewLoc��5/      $�� ��6)   $
��Left=�64   $��920,195,0,0q�6O   $	��Top=�6d   $	��243��6|   $��50��6�   ���	#DDFFFFFF$��20(�6�   51      52      