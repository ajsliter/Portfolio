;-------------------------------------------------------------
;- CIS333 Assignment 3
;- Author: Austin Sliter
;- Date Created: 9/23/19 @ 1:51 PM
;- Date Modified: 9/25/19 @ 1:00 PM 
;- Date Finished: 9/25/19 @ 1:56 PM
;-
;1. There is a limit to the number of terms that this program
;-  can calculate.
;-
;2. The maximum unsigned integer supported by a 16-bit CPU 
;-  register is 65535. The Fibonacci Sequence up to 24 would be
;-  safe with a 16-bit CPU (as Fib(24)'s max value is = 46,368 
;-  46,368 < 65,535), Fibonacci 25's maximum value is 75,025 
;-  which is 9,490 integer values above the maximum integer for 
;-  a 16-bit register which in high level languages would 
;-  generate a integer overflow error. In the case of assembly,
;-  however, it will truncate the bits which are above the 
;-  16-bit register size and keep the lowest 16 bits so when 
;-  Fibonacci 25 is executed in this program it will display 
;-  9,489 in hex (2511).
;-
;3. There is one theoretical way of overcoming the CPU register
;-  limit if you want to intentionally have integer overflow for
;-  32-bit number calculation. The method is to page a 32-bit
;-  number in word-based chunks and perform the calculation 
;-  chunk by chunk while carrying any bits that would be outside
;-  the current word over to the second word chunk and so on. 
;-------------------------------------------------------------
.MODEL SMALL      

;---------------------------------------------------------------------------
;- Declare Data and constants
;---------------------------------------------------------------------------
.DATA
;-Punctuation-
cr          equ 0Dh                         ;carriage return
lf          equ 0Ah                         ;line feed
comma       db ', $'                        ;Comma Character Plus Space

;-Processing- 
hextable    db  '0123456789ABCDEF'          ;Hex Table
fib_in      equ 20d                         ;Define the Input for the
                                            ;Fibonacci Value (def 20d) 
                                        
num1        dw  0d                          ;Define the Processing Variable 
                                            ;num1
                                            
num2        dw  1d                          ;Define the Processing Variable 
                                            ;num2
;-Header-
fib_msg     db  'Fibonacci(20):'            ;Define the Standard Output of the
            db  cr, lf, '$'                 ;Fibonacci Number
          


.STACK 100h    ;Create Stack Segment  

;-------------------
;- Main ASM Code
;-------------------
.CODE
main: 
        ;---
        ;-START
        ;---
        mov ax, @DATA           ;init data segment
        mov ds, ax
        
        ;----
        ;-Clear Screen
        ;----
        mov ah, 06h             ;White Chars
        mov bh, 07h             ;Background Black
        mov cx, 0000h           ;row 0/col0
        mov dh, 24d             ;row 24
        mov dl, 79              ;row 79
        int 10h                 ;Execute
        
        ;---
        ;-Move Cursor to Origin
        ;---                   
        mov ah, 02h             ;Move Cursor
        mov bh, 00h             ;To Page 0
        mov dx, 0000h           ;row 0/col 0
        int 10h                 ;Execute
        
        ;---
        ;-Print Initial Message
        ;---
        mov ah, 09h             ;Print
        lea dx, fib_msg         ;Fibonacci Head (hex Number Evaluating + crlf)
        int 21h                 ;Execute output to console (21h)
            
        ;---
        ;-Call Fibonacci Procedure
        ;---
        call calc_fib
        
                  
        ;---
        ;-END
        ;---
        mov ax, 4C00h ;Call int21h to
        int 21h       ;End the Program
        
        ;-----------------------------------------
        ;-Procedure: Calculate Fibonacci
        ;- Continues to do decimal addition until 
        ;- done, calls display hex when time to 
        ;- display sequence value.
        ;-----------------------------------------
        calc_fib proc near
            mov ax, num1           ;Move value of number 1 to ax
            mov bx, num2           ;Move value of number 2 to bx
            
            mov dx, fib_in         ;move value of fib_in to dx (Default 20) 
                               
            mov cx,0d              ;starting value for loop (20 terms + 0)
         
         while:
            cmp cx, dx             ;when cx is > dx (Default 20)
            ja endproc             ;jump to endproc
            
            ;-Display term and calculate next term-
            call display_hex       ;Display Term1
            mov num1, bx           ;move not displayed term to num1
            add ax,bx              ;add to get next term               
            mov num2, ax           ;store next term in num2

        if:            
            cmp cx,dx              ;if cx is not max
            jnz printcommas        ;jump to print the commas 
            
        printnocommas:             ;last term to print - no add op
            inc cx                 ;increment cx loop
            jmp while              ;loop
            
        printcommas:           
            ;-Print Number + comma
            push ax                     ;push ax to the stack
            push dx                     ;push dx to the stack
            mov ah, 09h                 ;Print
            lea dx, comma               ;Output Comma
            int 21h                     ;Execute output to console (21h)
            pop dx                      ;restore dx
            pop ax                      ;restore ax
                         
            ;Reset AX and BX for next loop
            mov ax,num1
            mov bx,num2
            
            ;Increment cx and loop
            inc cx
            jmp while
  
         endproc:                  ;exit loop
            ret                    ;Return to Main
            
        calc_fib endp
        
       ;--------------------------------------
       ; display_hex - converts a decimal number to hex
       ;               one hex digit at a time and then
       ;               displays the converted digit
       ; Note: Dr. James Example Code
       ;--------------------------------------
       display_hex   PROC    near
             ;---
             ;--- We will use ax, bx, cx and dx in this routine
             ;--- which would corrupt whatever data was in them
             ;--- from the main program.  Therefore, we should
             ;--- preserve a copy on the stack by pushing them...
             push       ax
             push       bx
             push       cx
             push       dx
             
             mov        bx,ax   ;Copy decimal number to bx which
                                ;is what we will dissect to get
                                ;4 binary digits to look up in
                                ;table
             mov        cl,04   ;We will be rotating 4 digits at a time
             mov        ch,04   ;Loop counter -- There are 4 hex digits max
                                ;in a word (which is size of ax)
        proc_digit:
             rol        bx,cl   ;Rotate bits left to get digit to convert in
                                ;last 4 bits of bl
             mov        al,bl         ;Copy the BL into the AL
             and        al,00001111b  ;Clear bits 4-7 of AL
                                      ;-- bits 0-3 contain the digit and
                                      ;  we can now point at table
             push       bx            ;Save the BX's contents since we need
                                      ;to convert other digits
             lea        bx,hextable   ;Load the hextable's address into BX
             xlat                     ;This instruction is used to look up
                                      ;information in a table.  The BX must
                                      ;point to the table's start (offset)
                                      ;and AL must point to an entry (element)
                                      ;in the table.  Once xlat is done AL
                                      ;will contain the value from the table.
             pop        bx            ;Restore bx for next digit
             mov        dl,al         ;Call an interrupt to print out the
                                      ;digit we got from the table
             mov        ah,02h
             int        21h
             dec        ch            ;Decrement the ch counter by 1
             jnz        proc_digit
             
             ;---
             ;--- Reload original register values prior to this proc call
             ;---
             pop        dx
             pop        cx
             pop        bx
             pop        ax
             ret                        ;Return control to calling program
        display_hex  ENDP
        
        END main   ;End of File