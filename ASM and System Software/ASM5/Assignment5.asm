;-------------------------------------------------------------
;- CIS333 Assignment 5
;- Author: Austin Sliter
;- Date Created: 10/7/19 @ 1:08 PM
;- Date Modified: 10/9/19 @ 2:27 PM 
;- Date Finished: 10/9/19 @ 2:27 PM
;-------------------------------------------------------------
.MODEL SMALL

.STACK 100h     

;---------------------------------------------------------------------------
;- Declare Data and constants
;---------------------------------------------------------------------------
.DATA             
;-Punctuation and Standard out-
cr          equ 0Dh                         ;carriage return
lf          equ 0Ah                         ;line feed
crlf        db  cr,lf,'$'                   ;crlf in one string

;-File Headers-
mfg         equ 'Manufacturer: '            
mdl         equ 'Model: '
colr        equ 'Color: '
mtrsz       equ 'Engine Size: '
door        equ 'Doors: '

;-Standard Prompts-
;-Prompts for getting input-
pmpt_mfg        db mfg,'$'
pmpt_mdl        db mdl,'$'
pmpt_colr       db colr,'$'
pmpt_mtrsz      db mtrsz,'$'
pmpt_door       db door,'$'

;-Standard Out For More Input or After File Processing-
pmpt_more       db cr,lf,cr,lf,'Add more inventory (Y/N):$'
pmpt_written    db cr,lf,cr,lf 
                db 'Struct information written to file C:\asm\test.txt$'
pmpt_prc_done   db 3 DUP('*') 
                db ' Awesome Auto Lot Inventory file has been processed '
                db 3 DUP('*'), '$'

;-Input Structure-
INPUTSTRUCT1     LABEL   BYTE
    MaxLen1      db      11
    ActLen1      db      0
    InputBuf1    db      11 DUP(20h)
    inender1     db     '$'
    
INPUTSTRUCT2     LABEL   BYTE
    MaxLen2      db      11
    ActLen2      db      0
    InputBuf2    db      11 DUP(20h)
    inender2     db     '$' 
    
INPUTSTRUCT3     LABEL   BYTE
    MaxLen3      db      11
    ActLen3      db      0
    InputBuf3    db      11 DUP(20h)
    inender3     db     '$'
           
INPUTSTRUCT4     LABEL   BYTE
    MaxLen4      db      11
    ActLen4      db      0
    InputBuf4    db      11 DUP(20h)
    inender4     db     '$'
    
INPUTSTRUCT5     LABEL   BYTE
    MaxLen5      db      11
    ActLen5      db      0
    InputBuf5    db      11 DUP(20h)
    inender5     db     '$'
    
;-File Related-                
file_buf    db  55 DUP (20h)  ;Make a file buffer of 55 as 55 bytes of information maximum 
                              ;will be read for each record
file_name   db  'C:\asm\test.txt', 00h
dir_name    db  'C:\asm', 00h
handle1     dw  0

;-----------------------------------------------------
;--- err_chk routine related data - DR. James Example Code
;-----------------------------------------------------   
      err1      DB      'Invalid function number',lf,cr,'$'
      err2      DB      'File not found',lf,cr,'$'
      err3      DB      'Path not found',lf,cr,'$'
      err4      DB      'Too many open files',lf,cr,'$'
      err5      DB      'Access denied',lf,cr,'$'
      err6      DB      'Invalid handle',lf,cr,'$'
      err12     DB      'Invalid access code',lf,cr,'$'
      errtbl    DW      0,err1,err2,err3,err4,err5,err6
                DW      5 DUP (0)
                DW      err12

.CODE
main:
    ;---
    ;-START
    ;---
    mov ax, @DATA           ;init data segment
    mov ds, ax
    
    ;-Get File and Dir Ready-
    call cte_dir       ;Create Directory
    call cte_opfile    ;Open File
    
    do:
    ;Clear Screen twice because prmopt to continue from last execution
    ;Will not be cleared the first time
    call clrscrn
    call defpnt
    call clrscrn
    call defpnt
    
    ;-Print Prompt for Data 1/5-
    mov cx,1d
    lea dx, pmpt_mfg
    call print_string
    call get_data       ;get input from the user
    lea dx, crlf
    call print_string 
                                 
    ;-Print Prompt for Data 2/5-
    mov cx,2d
    lea dx, pmpt_mdl
    call print_string
    call get_data       ;get input from the user
    lea dx, crlf
    call print_string 
    
    ;-Print Prompt for Data 3/5- 
    mov cx,3d
    lea dx, pmpt_colr
    call print_string
    call get_data       ;get input from the user
    lea dx, crlf
    call print_string 
    
    
    ;-Print Prompt for Data 4/5-
    mov cx,4d
    lea dx, pmpt_mtrsz
    call print_string
    call get_data       ;get input from the user
    lea dx, crlf
    call print_string 
    
    ;-Print Prompt for Data 5/5-
    mov cx,5d    
    lea dx, pmpt_door
    call print_string
    call get_data       ;get input from the user
    
    ;-To File and Print Struct-
    call write_data    ;Write Data to the File
    call clrscrn       ;Each Iteration, Clear Screen when input is done
    call defpnt        ;Each iteration set default point after clear screen
    call print_struct  ;Print the Structure out after screen is cleared
        
    
    ;--Prompt for Continuation of Data Entry--
    lea dx, crlf        ;Print crlf followed by the prompt
    call print_string
    
    ;-Prompt for more inventory-
    lea dx,pmpt_more
    call print_string
    call erase_data
    mov ah,01h          ;Read Char
    int 21h             ;If char is y or Y
    cmp al,'y'          ;loop again
    jz  do   
    cmp al,'Y'
    jz  do                  
    
    ;-EXIT LOOP-
    call clse_file     ;Close File
    
    ;-Display Information after loop is done- 
    lea dx, crlf
    call print_string 
    lea dx, pmpt_written
    call print_string
    lea dx, crlf
    call print_string 
    lea dx, crlf
    call print_string 
    
    ;-Reread File for Output-
    call read_file     ;Reread file to standard output for final output
    
    ;-Print Final Message-
    lea dx, crlf
    call print_string 
    lea dx, crlf
    call print_string 
    lea dx,pmpt_prc_done
    call print_string 
    
    
    ;---
    ;-END
    ;---
    mov ax, 4C00h ;Call int21h to
    int 21h       ;End the Program
    
    ;----------------------------------------------------------------
    ;write_data - Writes data to file
    ;----------------------------------------------------------------
    write_data PROC near
        ;--- write data to file
        ;-Data 1/5-
        mov     cx,11           ;actual bytes to write
        mov     ah,40h          ;write to file
        mov     bx,handle1      ;file handle
        lea     dx,INPUTSTRUCT1+2;address to actual data &crlf&$
        int     21h
        call    err_chk         ;exit on error
        
        ;-Data 2/5-
        mov     cx,11           ;actual bytes to write
        mov     ah,40h          ;write to file
        mov     bx,handle1      ;file handle
        lea     dx,INPUTSTRUCT2+2;address to actual data &crlf&$
        int     21h
        call    err_chk         ;exit on error
        
        ;-Data 3/5-
        mov     cx,11           ;actual bytes to write
        mov     ah,40h          ;write to file
        mov     bx,handle1      ;file handle
        lea     dx,INPUTSTRUCT3+2;address to actual data &crlf&$
        int     21h
        call    err_chk         ;exit on error 
        
        ;-Data 4/5-
        mov     cx,11           ;actual bytes to write
        mov     ah,40h          ;write to file
        mov     bx,handle1      ;file handle
        lea     dx,INPUTSTRUCT4+2;address to actual data &crlf&$
        int     21h
        call    err_chk         ;exit on error
        
        ;-Data 5/5-
        mov     cx,11           ;actual bytes to write
        mov     ah,40h          ;write to file
        mov     bx,handle1      ;file handle
        lea     dx,INPUTSTRUCT5+2;address to actual data &crlf&$
        int     21h
        call    err_chk         ;exit on error
        ret
    write_data ENDP
    
    ;-----------------------------------------------------------------
    ;erase_data - Erases the data structures
    ;-----------------------------------------------------------------    
    erase_data PROC near
        ;-Erase Struct Data 1/5-
        mov cl, MaxLen1
        mov si, 0000
        loop1:
            mov InputBuf1[si],20h
            inc si
            loop loop1          
        
        ;-Erase Struct Data 2/5-
        mov cl, MaxLen2
        mov si, 0000
        loop2:
            mov InputBuf2[si],20h
            inc si
            loop loop2
        
        ;-Erase Struct Data 3/5-
        mov cl, MaxLen3
        mov si, 0000
        loop3:
            mov InputBuf3[si],20h
            inc si
            loop loop3
        
        ;-Erase Struct Data 4/5-
        mov cl, MaxLen4
        mov si, 0000
        loop4:
            mov InputBuf4[si],20h
            inc si
            loop loop4
        
        ;-Erase Struct Data 5/5-
        mov cl, MaxLen5
        mov si, 0000
        loop5:
            mov InputBuf5[si],20h
            inc si
            loop loop5
        ret 
    erase_data ENDP
    
    ;-----------------------------------------------------------------
    ;print_struct - Prints the Data Structures
    ;-----------------------------------------------------------------
    print_struct PROC near
        
        ;-Print Struct Data 1/5-
        lea dx, pmpt_mfg
        call print_string
        lea dx,INPUTSTRUCT1 + 2
        call print_string
        lea dx, crlf
        call print_string
        
        ;-Print Struct Data 2/5-
        lea dx, pmpt_mdl
        call print_string
        lea dx,INPUTSTRUCT2 + 2
        call print_string
        lea dx, crlf
        call print_string
        
        ;-Print Struct Data 3/5-
        lea dx, pmpt_colr
        call print_string
        lea dx,INPUTSTRUCT3 + 2
        call print_string
        lea dx, crlf
        call print_string
        
        ;-Print Struct Data 4/5-
        lea dx, pmpt_mtrsz
        call print_string
        lea dx,INPUTSTRUCT4 + 2
        call print_string
        lea dx, crlf
        call print_string
        
        ;-Print Struct Data 5/5-
        lea dx, pmpt_door
        call print_string
        lea dx,INPUTSTRUCT5 + 2
        call print_string
        lea dx, crlf
        call print_string
        ret
    print_struct ENDP

    ;-----------------------------------------------------------------
    ;get_data - Get data from the user
    ;-----------------------------------------------------------------
    get_data PROC near
        cmp cx,1d ;if cx = 1
        jz input1           
        
        cmp cx,2d ;if cx = 2
        jz input2
        
        cmp cx,3d ;if cx = 3
        jz input3           
        
        cmp cx,4d ;if cx = 4
        jz input4           
        
        cmp cx,5d ;if cx = 5
        jz input5
        
        input1:                 ;input 1
        lea     dx,INPUTSTRUCT1
        mov     ah,0ah          ;request input
        int     21h
        mov     bh,00h           ;replace return char
        mov     bl,ActLen1        ;with the a null since we
        mov     InputBuf1[bx],20h ;have CR/LF at end of struct
        dec     bl
        mov     ActLen1,bl
        jmp doreturn
        
        input2:
        lea     dx,INPUTSTRUCT2 ;offset input 2
        mov     ah,0ah          ;request input
        int     21h
        mov     bh,00h           ;replace return char
        mov     bl,ActLen2        ;with the a null since we
        mov     InputBuf2[bx],20h ;have CR/LF at end of struct
        dec     bl
        mov     ActLen2,bl
        jmp doreturn
        
        input3:
        lea     dx,INPUTSTRUCT3 ;offset input 3
        mov     ah,0ah          ;request input
        int     21h
        mov     bh,00h           ;replace return char
        mov     bl,ActLen3        ;with the a null since we
        mov     InputBuf3[bx],20h ;have CR/LF at end of struct
        dec     bl
        mov     ActLen3,bl
        jmp doreturn
        
        input4:    
        lea     dx,INPUTSTRUCT4 ;offset input 4
        mov     ah,0ah          ;request input
        int     21h
        mov     bh,00h           ;replace return char
        mov     bl,ActLen4        ;with the a null since we
        mov     InputBuf4[bx],20h ;have CR/LF at end of struct
        dec     bl
        mov     ActLen1,bl
        jmp doreturn
        
        input5:
        lea     dx,INPUTSTRUCT5  ;offset for input 5
        mov     ah,0ah          ;request input
        int     21h
        mov     bh,00h           ;replace return char
        mov     bl,ActLen5        ;with the a null since we
        mov     InputBuf5[bx],20h ;have CR/LF at end of struct
        dec     bl
        mov     ActLen1,bl
        
        doreturn: 
        ret
    get_data ENDP
    ;------------------------------------------------------------------
    ;cte_dir - Creates the Directory Needed - Dr. James Example Code
    ;------------------------------------------------------------------       
    cte_dir PROC near
        mov     ax, SEG dir_name
        mov     ds, ax
        mov     dx, OFFSET dir_name ;pointer to directory name
        mov     ah,39h             ;Create directory
        int     21h
        call    err_chk            ;trap any errors which occur
        ret    
    cte_dir ENDP
    
    ;------------------------------------------------------------------
    ;cte_opfile - Create and open file Needed - Dr. James Example Code
    ;------------------------------------------------------------------       
    cte_opfile PROC near
        mov     ah,3Ch          ;Create file
        mov     cx,00           ;"normal" attribute
        lea     dx,file_name    ;pointer to name of file
        int     21h
                                ;all file routines return
                                ;error status codes which
                                ;we need to trap and deal with
        call    err_chk         ;so, exit on error
        mov     handle1,ax      ;otherwise, this is our handle        
        ret
    cte_opfile ENDP
                  
    ;------------------------------------------------------------------
    ;read_file - Read the file and proceed to output
    ;------------------------------------------------------------------                  
    read_file PROC near
        mov     ah,3Dh          ;open file
        mov     al,000b         ;read access
        lea     dx,file_name    ;address    
        int     21h
        call    err_chk         ;exit on error
        mov     handle1,ax      ;save file handle
        ;--- Get length of file
        mov     ah,42h          ;move pointer
          ;---
          ;- Set an open file's location pointer at the offset
          ;- in CX:DX
          ;-
          ;- To Call:     ah = 42h
          ;-              al = method for starting pointer
          ;-                       00h = offset from start of file
          ;-                       01h = signed offset from current ptr
          ;-                       02h - signed offset from end of file
          ;-              bx = handle from open
          ;-              cx = most significant word (MSW) of offset
          ;-              dx = least significant word (LSW) of offset
          ;-
          ;- Returns:     If function was successful,
          ;-                      carry flag = clear
          ;-                      DX = MSW of new pointer offset
          ;-                      AX = LSW of new pointer offset
          ;-              If unsuccessful,
          ;-                      carry flag = set
          ;-                      AX = error code
          ;---
          mov     al,02h          ;offset from end of file
          mov     bx,handle1      ;file handle
          xor     cx,cx           ;set cx = 0
          xor     dx,dx           ;set dx = 0
          int     21h             ;file length in DS:AX
          push    ax              ;AX = file length
                                  ;DX = 0 in this example
          call    err_chk
          ;--- Reset file pointer to beginning of file
          mov     ah,42h          ;move pointer
          mov     al,00h          ;set at start of file
          mov     bx,handle1      ;file handle
          xor     cx,cx           ;CX = 0
          xor     dx,dx           ;DX = 0
          int     21h
          call    err_chk
          push    55d             ;push the number of bytes 
                                  ;read initially
          
          readnprint:
          ;--- Read file
          mov     ah,3Fh          ;read file
          mov     bx,handle1      ;file handle
          mov     cx,55d          ;read 55 byes
          lea     dx,file_buf     ;address
          int     21h
          call    err_chk
          
          ;-Print 55 bytes-
          lea dx, pmpt_mfg
          call print_string
          ;-Data 1/5-
          mov     ah,40h          ;write to device
          mov     bx,1            ;device = screen
          mov     cx,11           ;write 11 bytes
          lea     dx,file_buf     ;address
          int     21h                
          lea dx, crlf
          call print_string
          
          lea dx, pmpt_mdl
          call print_string
          ;-Data 2/5
          mov     ah,40h          ;write to device
          mov     bx,1            ;device = screen
          mov     cx,11           ;write 11 bytes
          lea     dx,file_buf+11  ;address + 11
          int     21h
          lea dx, crlf
          call print_string
          
          lea dx, pmpt_colr
          call print_string
          ;-Data 3/5
          mov     ah,40h          ;write to device
          mov     bx,1            ;device = screen
          mov     cx,11           ;write 11 bytes
          lea     dx,file_buf+22  ;address + 22
          int     21h
          lea dx, crlf
          call print_string
          
          lea dx, pmpt_mtrsz
          call print_string
          ;-Data 4/5
          mov     ah,40h          ;write to device
          mov     bx,1            ;device = screen
          mov     cx,11           ;write 11 bytes
          lea     dx,file_buf+33  ;address + 33
          int     21h    
          lea dx, crlf
          call print_string
          
          
          lea dx, pmpt_door
          call print_string
          ;-Data 5/5
          mov     ah,40h          ;write to device
          mov     bx,1            ;device = screen
          mov     cx,11           ;write 11 bytes
          lea     dx,file_buf+44  ;address + 44
          int     21h

          
          ;-Postcondition for continue-
          pop ax                  ;pop number of bytes read
          add ax,1d               ;add one byte extra for the number of
                                  ;bytes + EOF
          pop bx                  ;puts the file length in bx to compare
          cmp ax,bx               ;if ax is greater than or equal to bx
          jae closenend           ;exit loop
                  
          ;--ELSE--
          dec ax        ;decrement ax by 1
          add ax,55d    ;add another 55 bytes to AX          
          push bx       ;push values back to the stack
          push ax       ;push values back to the stack
          
          ;-Print two CRLFs for next entry
          lea dx, crlf
          call print_string
          lea dx, crlf
          call print_string
          
          ;-Repeat Loop-
          jmp readnprint
          
          ;-Close File and Return-
          closenend:
          call clse_file
          ret
    read_file ENDP
    
    ;------------------------------------------------------------------
    ;clse_file - Closes open file - Dr. James Code
    ;------------------------------------------------------------------
    clse_file PROC near
        mov     ah,3Eh          ;close file
        mov     bx,handle1      ;file handle
        int     21h
        call    err_chk
        ret
    clse_file ENDP
    
    ;-----------------------------------------------------
    ;--- err_chk routine - Dr. James Code
    ;-----------------------------------------------------
    err_chk        PROC    near
                jnc     exitproc        ;no error then exit procedure
                mov     bx,ax
                mov     ah,9            ;display string
                mov     dx,errtbl[bx]   ;message offset
                int     21h
                mov     ax,4C00h        ;terminate on error
                int     21h
    exitproc:   ret
    err_chk        ENDP
    
    ;------------------------------------------------------------------
    ;print_string - Prints any string as long as lea dx, msg is defined
    ;------------------------------------------------------------------
    print_string PROC near
        push ax                 ;Push ax, it might contain something important
        mov ah, 09h             ;Print Service
        int 21h                 ;Execute output to console (21h)
        pop ax                  ;Pop value of ax back into the program
        ret
    print_string ENDP
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