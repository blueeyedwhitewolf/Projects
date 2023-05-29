; Vamos informar o LINK que esta rotina pode ser usada noutros m¢dulos
PUBLIC BIN2ASCII

;O costume para assemblar
.model small
.stack 100h
.code

;Rotina que faz a conversao de bin rio para ascii
BIN2ASCII PROC
        ; Guardar os valores dos registos
        pushf
        push ax
        push bx
        push cx
        push dx
        ; Vamos ver se AX<0
        or ax, ax
        ; Se for nÆo salta
        jge ciclo1
        push ax
        ; Vamos escrever o sinal -
        mov dl,'-'
        mov ah, 2
        int 21H
        pop ax
        ; Vamos transformar AX em positivo
        neg ax
ciclo1: xor cx,cx       ;inicializa o contador ( n§ de digitos )
        mov bx,10       ;divisor
salto1: xor dx,dx       ;inicializa-se a zero devido ao resto da divisao
        div bx
        push dx         ;guarda o resto na stack
        inc cx          ;incrementa o n§ de digitos
        or ax,ax        ;enquanto o quociente for...
        jne salto1      ;...diferente de 0 faz divisäes consecutivas 
        mov ah,2        ; vai escrever...
salto2: pop dx          ;...os caracteres...
        or dl,30h       ;...que colocou na stack, adicionando 30h para obter o codigo
        int 21h         ;...ascii, no ecran
        loop salto2
        ; Repomos os valores nos registos (ordem inversa)
        pop dx
        pop cx
        pop bx
        pop ax
        popf
        ret
BIN2ASCII ENDP
          END
