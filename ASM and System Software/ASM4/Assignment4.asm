;-------------------------------------------------------------
;- CIS333 Assignment 4
;- Author: Austin Sliter
;- Date Created: 9/30/19 @ 1:12 PM
;- Date Modified: 9/30/19 @ 3:09 PM 
;- Date Finished: 9/30/19 @ 3:09 PM
;-------------------------------------------------------------
.MODEL SMALL      

;---------------------------------------------------------------------------
;- Declare Data and constants
;---------------------------------------------------------------------------
.DATA
;-Punctuation and Standard out-
cr          equ 0Dh                         ;carriage return
lf          equ 0Ah                         ;line feed
crlf        db  cr,lf,'$'                   ;combines the crlf into one string

outmsg      db  20h,'doubled is',20h, '$'   ;standard printout between origin 
                                            ;value and doubled value
;-Numerical Values-
stnum       equ 100d                        ;Defines the starting loop value to 
                                            ;double
mxnum       equ 10000d                      ;Defines the maximum loop value to
                                            ;double
mxloop      equ 100d                        ;Defines the maximum number of loops
                                            ;mxnum / stnum
step        equ 100d                        ;The increment step for each loop

;-Processing-
hextable    db  '0123456789ABCDEF'          ;Defines the hex table to convert
                                            ;memory binary to hex output.
                                            
.STACK 100h                                 ;Create standard stack segment (100h)

.CODE
main: 
    ;---
    ;-START
    ;---
    mov ax, @DATA           ;init data segment
    mov ds, ax  
    
    ;---
    ;-Calculate doubles for 100 to 10000 step 100
    ;---
    mov ax, stnum
    mov dx, mxnum
    call lp_doublenum ;Call the double number loop proc
    
    ;---
    ;-Print Output
    ;---
    call print_output ;Print the output residing on the stack
    
    ;---
    ;-END
    ;---
    mov ax, 4C00h ;Call int21h to
    int 21h       ;End the Program           
    
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
    
    ;------------------------------------------------------------------
    ;Print String - Prints any string as long as lea dx, msg is defined
    ;------------------------------------------------------------------
    print_string PROC near
        push ax                 ;Push ax, it might contain something important
        mov ah, 09h             ;Print Service
        int 21h                 ;Execute output to console (21h)
        pop ax                  ;Pop value of ax back into the program
        ret
    print_string ENDP
    
    
    
    ;------------------------------------------------------------------
    ;Loop doublenum - Pushes to the stack for looping based on 
    ;                 constants. Will double the number each loop then
    ;                 push origin number and doubled number to the stack 
    ;                 for further processing and output later.
    ;------------------------------------------------------------------
    lp_doublenum PROC near
        pop cx ;pop the return address to cx temporarily until 
               ;loop concludes
    while:
        cmp ax,dx ;compare if ax, loop counter is maximum number dx
        ja return_doublenum ;if above max num return
        
        ;-if not equal continue-
        mov  bx,ax   ;copy ax into bx for adding
        add  bx,ax   ;double the number
        push bx      ;push the result to the stack first
        push ax      ;push the initial number to the stack last
        mov  bx,step ;Move the step constant to bx to add 100 for 
                     ;loop increment
        add  ax,bx   ;increment loop by step
        jmp while    ;return to check condition before continuing
        
    return_doublenum:
        push cx ;push return address back to top of the stack to 
                ;return easily
        ret
    lp_doublenum ENDP
    
    ;------------------------------------------------------------------
    ; print_output - This is the handler for the printing of the stack                               
    ;                values
    ;------------------------------------------------------------------
    print_output PROC near
        call clrscrn        ;clear the screen
        call defpnt         ;Move cursor to Default 0,0 page 0
        pop  cx             ;Puts the return address in cx to work with the stack
        
        mov  dx, mxloop     ;Sets max loop value
        mov  bx, 1d         ;Sets 1 as the first number
    print:
        cmp  bx,dx          ;if bx is above dx (1-100 valid values default)
        ja   return_prntout ;End Proc
        
        ;-Print Initial Value-
        pop  ax             ;pop initial value to ax
        call display_hex    ;Display the Number in hex
        
        ;-Print Interior Message-
        push dx             ;temporarily push dx to the stack
        lea dx,outmsg       ;Load effective address of the standard outmsg 
        call print_string   ;print outmsg
        pop  dx             ;reload original dx value
        
        ;-Print Doubled Value-
        pop ax              ;pop doubled value to ax
        call display_hex    ;Print doubled value
        
        ;-Print CRLF-
        push dx             ;temporarily push dx to the stack
        lea dx, crlf        ;Load CRLF into dx for printout
        call print_string   ;print crlf
        pop dx              ;reload original dx value
        
        ;-Increment and Loop-
        inc  bx             ;increment dx 1 time
        jmp  print          ;Loop
    return_prntout:   
        push cx         ;Returns the return address for the function to the stack
        ret             ;Go back to main
    print_output ENDP
    
    ;------------------------------------------------------------------
    ; clrscrn - Clears the console screen
    ;------------------------------------------------------------------    
    clrscrn PROC near
        mov ah, 06h             ;White Chars
        mov bh, 07h             ;Background Black
        mov cx, 0000h           ;row 0/col0
        mov dh, 24d             ;row 24
        mov dl, 79              ;row 79
        int 10h                 ;Execute
        ret
    clrscrn ENDP
    
    ;------------------------------------------------------------------
    ;defpnt - Sets the default cursor point of 0,0 page 0
    ;------------------------------------------------------------------
    defpnt PROC near
        mov ah, 02h             ;Move Cursor
        mov bh, 00h             ;To Page 0
        mov dx, 0000h           ;row 0/col 0
        int 10h                 ;Execute
        ret
    defpnt ENDP
    
    
    END main   ;End of File      