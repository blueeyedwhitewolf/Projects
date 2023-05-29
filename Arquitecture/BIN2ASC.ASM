.MODEL SMALL

.STACK 100H

.CODE

PUBLIC  BIN2ASC

BIN2ASC PROC
        PUSH AX
        PUSH BX
        PUSH CX
        PUSH DX
             
        OR AX,AX
        JGE CICLO1
        PUSH AX
        MOV DL,'-'
        MOV AH,2
        INT 21H
        POP AX
        NEG AX
CICLO1: XOR CX,CX
        MOV BX,10
CICLO2: XOR DX,DX
        DIV BX
        PUSH DX
        INC CX
        OR AX,AX
        JNE CICLO2
        MOV AH,2
CICLO3: POP DX
        OR DL,30H
        INT 21H
        LOOP CICLO3
        POP DX
        POP CX
        POP BX
        POP AX
        RET
BIN2ASC ENDP	

	END
