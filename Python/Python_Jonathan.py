#Autómata creador de secuencia en grafo, lectura de estados y conexiónes, simbología, estado final e inicio
#validador de cadenas


import re

#Funcion de leer el caracter del lenguaje
def caracter(character):
    global simbolo
    simbolo = ""
    global Fin
    Fin = ""
    digito = "[0-9]"
    operador = "(+|-|*|/)"

    #Comparar digito o operador
    if(re.match(digito, character)):
        simbolo = "Digito"
        return 0
    else:
        if(re.match(operador, character)):
            simbolo = "Operador"
            return 1
        else:
            if(character==Fin):
                return 2
    
    #La entrada no coincide
    print("Error el ", character, " no es valido")
    exit()

#Definir funcion de lectura
def encabezado():
   print(""" | Q Actual  | Caracter | Simbolo | Q Siguiente """)  
   body()

#Definir funcion de guardar variables
def contenido(estadosig,character,simbolo,estado):
    print("|    ", estadosig, "     |   ", character, "     |   ", simbolo, "   |   ", estado, "    |")
    body()

#Definir funcion de mostar linea 
def body():
    print("+------------------------+-----------------------+-------------------+--------------------+")

def saludo():
    print("\t Bienvenido al proyecto de Automatas y Lenguajes Formales")
    print("\t Grupo #")
    print("[Isabel Lopez], [Emily Lopez], [Jonathan Castillo]")

#Inicio del programa
#Tabla de transiciones AFD
tabla = [[1,"E","E"],[1,2,"E"],[3,"E","E"],[3,2,"A"]]
estado = 0

saludo()
print("\t Ingrese una cadena a evaluar")
cadena = input()
body()
encabezado()

#Ciclo para leer cadena
for character in cadena:
    estadosig=estado

    #Metodo para evaluar el caracter ingresado
    character = caracter(character)

    #Guardar estado el valor de tabla de posicion
    estado = tabla[estado][character]

    #condifiocn del valor optenido es E
    if (estado == "E"):
        print("|    ", estadosig, "     |   ", character, "     |   ", simbolo, "   |   ", estado, "    |")
        body()
        print("\t Cadena no valida")
        exit()
    contenido(estadosig,character,simbolo,estado)

    #Condicion de minimo de estados, 3
    if(estado!=3):
        print("\t Cadena no valida")
    
    #Condicion en aceptacion del automata
    if(estado==3):
        print("|    ",estado,"      |       |   FND     |       |")
        body()
        print("\t Cadena Valida")