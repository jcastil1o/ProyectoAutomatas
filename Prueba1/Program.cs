using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class TuringMachine
    {
        // Define los estados de la máquina de Turing
        enum State { Start, CheckDigits, CheckFinalLetter, Accepted, Rejected }

        static void Main()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                // Solicita al usuario que introduzca una identificación para verificar
                Console.WriteLine("Introduce la identificación del empleado (Formato: LDDD L):");
                string input = Console.ReadLine();

                // Valida la longitud de la cadena para que sea exactamente 5 caracteres
                if (input.Length != 5)
                {
                    Console.WriteLine("La identificación debe tener exactamente 5 caracteres.");
                    continue; // Pide una nueva entrada
                }

                // Cinta inicializada con la cadena de identificación
                char[] tape = input.ToCharArray();
                int head = 0; // Posición inicial de la cabeza en la cinta
                State currentState = State.Start; // Estado inicial de la máquina de Turing
                int step = 0; // Contador de pasos para la simulación

                Console.WriteLine("Simulación de la Máquina de Turing:");
                Console.WriteLine("{0,5} {1,20} {2,20}", "Paso", "Estado", "Transición");

                // Simulación de la máquina de Turing
                while (currentState != State.Accepted && currentState != State.Rejected)
                {
                    // Imprime el estado actual, el paso y la transición
                    Console.WriteLine("{0,5} {1,20} {2,20}", step, currentState, $"Cinta[{head}] = {(head < tape.Length ? tape[head].ToString() : "Fuera de rango")}");

                    switch (currentState)
                    {
                        case State.Start:
                            // Verifica que el primer carácter sea una letra
                            if (head == 0 && Char.IsLetter(tape[head]))
                            {
                                currentState = State.CheckDigits; // Cambia al siguiente estado
                                head++; // Mueve la cabeza a la derecha
                            }
                            else
                            {
                                currentState = State.Rejected; // Identificación no válida
                            }
                            break;

                        case State.CheckDigits:
                            // Verifica que los siguientes tres caracteres sean dígitos
                            if (head < tape.Length && Char.IsDigit(tape[head]))
                            {
                                head++; // Mueve la cabeza a la derecha
                                if (head == 4) // Después de verificar los tres dígitos
                                {
                                    currentState = State.CheckFinalLetter; // Cambia al siguiente estado
                                }
                            }
                            else
                            {
                                currentState = State.Rejected; // Identificación no válida
                            }
                            break;

                        case State.CheckFinalLetter:
                            // Verifica que el último carácter sea una letra
                            if (head < tape.Length && Char.IsLetter(tape[head]))
                            {
                                currentState = State.Accepted; // Identificación aceptada
                            }
                            else
                            {
                                currentState = State.Rejected; // Identificación no válida
                            }
                            break;
                    }

                    step++;
                }

                // Imprime el estado final y el resultado de la verificación
                Console.WriteLine("{0,5} {1,20} {2,20}", step, currentState, $"Cinta[{head}] = {(head < tape.Length ? tape[head].ToString() : "Fuera de rango")}");
                Console.WriteLine("Estado final: " + currentState);
                if (currentState == State.Accepted)
                {
                    Console.WriteLine("Identificación aceptada.");
                }
                else
                {
                    Console.WriteLine("Identificación no aceptada.");
                }

                // Pregunta si el usuario desea introducir otra identificación
                Console.WriteLine("¿Desea introducir otra identificación? (S/N):");
                string response = Console.ReadLine().ToUpper();
                continueRunning = response == "S";
            }

            // Espera a que el usuario presione una tecla antes de salir
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }