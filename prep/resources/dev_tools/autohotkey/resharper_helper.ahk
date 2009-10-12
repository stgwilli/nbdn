;==========================
;Initialise
;==========================
#NoEnv
SendMode Input
SetWorkingDir %A_ScriptDir% 
SetTitleMatchMode 2

;==========================
;Process Move Down A Method
;==========================
$!J::
    Send, !{Down}
return

;==========================
;Process Move Up A Method
;==========================
$!K::
	Send, !{Up}
return

;==========================
;Process Move Method Up
;==========================
$^+!K::
    Send, ^+!{Up}
return

;==========================
;Process Move Method Down
;==========================
$^+!J::
    Send, ^+!{Down}
return

;==========================
;Process Go to next usage 
;==========================
$+!J::
    Send, ^!{Down}
return

;==========================
;Process Go to previous usage 
;==========================
$+!k::
    Send, ^!{Up}
return

;==========================
;Process Generate Code
;==========================
$!I::
    Send, !{Insert}
return
;==========================
;Highlight Current Usages
;==========================
$!8::
    Send, ^+{F7}
return
;==========================
;Find Usages
;==========================
$!9::
    Send, !{F7}
return
;==========================
;Next Error In Solution
;==========================
$!0::
    Send, !{F12}
return
