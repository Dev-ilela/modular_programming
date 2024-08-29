// Exercício 1
// Escreva um programa que receba um número
// inteiro entre 1 e 10, inclusive, digitado pelo usuário.
// O programa deve utilizar uma função que receba
// este número como argumento e retorne o número
// correspondente por extenso.
//class Program
//{
//    static void Main(string[] args)
//    {
//        int num;
//        bool sucesso;
//        do
//        {
//            Console.Write("Digite um número inteiro entre 1 e 10, por favor: ");
//            sucesso = int.TryParse(Console.ReadLine(), out num);
//        } while (!sucesso || num > 10 || num < 1);

//        Console.WriteLine("O número digitado em extenso é " + EscreveNumero(num) + "!");
//    }
//    static string EscreveNumero(int num)
//    {
//        return num switch
//        {
//            1 => "Um",
//            2 => "Dois",
//            3 => "Três",
//            4 => "Quatro",
//            5 => "Cinco",
//            6 => "Seis",
//            7 => "Sete",
//            8 => "Oito",
//            9 => "Nove",
//            _ => "Dez",
//        };
//    }
//}


// Exercício 2
// Desenvolvoda um programa que funcione como
// uma calculadora simples. o programa deve
// solicitar ao usuário 2 (dois) números e uma
// operação matemática (adição, subtração,
// multiplicação ou divisão). crie uma função para
// cada operação matemática que receba os dois
// números como argumentos e retorne o resultado da
// operação.

//class Program
//{
//    static void Main(string[] args)
//    {
//        float num1;
//        float num2;
//        char oper;
//        bool sucesso;
//        Console.WriteLine("Olá! Seja bem vindo à UniCalculadora!\n");

//        do
//        {
//            Console.Write("Digite o 1° valor númerico da operação, por favor: ");
//            sucesso = float.TryParse(Console.ReadLine(), out num1);
//        } while (!sucesso);

//        do
//        {
//            Console.Write("Digite o 2° valor númerico da operação, por favor: ");
//            sucesso = float.TryParse(Console.ReadLine(), out num2);
//        } while (!sucesso);

//        Console.WriteLine("Agora, escolha a operação matemática a ser realizada.");
//        Console.WriteLine("Basta pressionar a inicial da operação como consta na tabela abaixo:");
//        Console.WriteLine("| A: Adição | D: Divisão | M: Multipliação | S: Subtração |");

//        do
//        {
//            Console.Write("Digite a letra referente à operação: ");
//            sucesso = char.TryParse(Console.ReadLine(), out oper);
//            if (sucesso)
//            {
//                oper = char.ToUpper(oper);
//                if (oper != 'A' && oper != 'D' && oper != 'M' && oper != 'S')
//                {
//                    sucesso = !sucesso;
//                }
//                else if (oper == 'D' && num2 == 0)
//                {
//                    do
//                    {
//                        Console.Write("Digite o 2° valor númerico da operação novamente pois divisão não pode ser feita por 0: ");
//                        sucesso = float.TryParse(Console.ReadLine(), out num2);
//                    } while (!sucesso || num2 == 0);
//                }
//            }
//        } while (!sucesso);

//        switch (oper)
//        {
//            case 'A':
//                Console.WriteLine($@"{num1} + {num2} = {Soma(num1, num2)}!");
//                break;
//            case 'D':
//                Console.WriteLine($@"{num1} / {num2} = {Divisao(num1, num2)}!");
//                break;
//            case 'M':
//                Console.WriteLine($@"{num1} X {num2} = {Multiplicacao(num1, num2)}!");
//                break;
//            default:
//                Console.WriteLine($@"{num1} - {num2} = {Subtracao(num1, num2)}!");
//                break;
//        }
//    }

//    static float Soma(float num1, float num2)
//    {
//        return num1 + num2;
//    }

//    static float Divisao(float num1, float num2)
//    {
//        return num1 / num2;
//    }

//    static float Multiplicacao(float num1, float num2)
//    {
//        return num1 * num2;
//    }

//    static float Subtracao(float num1, float num2)
//    {
//        return num1 - num2;
//    }
//}

// Exercício 3
// Desenvolva um programa que receba via teclado
// o número do CPF do usuário e o valide através de
// uma função C#. 
class Program
{
    static void Main(string[] args)
    {
        string cpf;
        Console.WriteLine("Olá! Seja bem vindo ao UniValidator de CPF!\n");
        Console.Write("Digite um número de CPF para verificar se é válido ou não: ");
        cpf = Console.ReadLine();

        while (!ValidaCPF(cpf))
        {
            Console.Write("Puxa... CPF inválido, digite novamente: ");
            cpf = Console.ReadLine();
        }

        Console.WriteLine($@"Ai sim hein, o CPF: {cpf} é um CPF válido! Boa garoto(a)");
    }

    static bool ValidaCPF(string cpf)
    {
        bool isValido = true;
        int[] numCPF = new int[11];
        int dig1;
        int dig2;
        int soma = 0;

        if (cpf.Length == 11)
        {
            for (int i = 0; i < numCPF.Length; i++)
            {
                numCPF[i] = int.Parse(cpf[i].ToString());
            }

            //Descobrir o 10° dígito
            for (int i = 1; i < 10; i++)
            {
                soma += numCPF[i-1] * (i);
            }

            dig1 = soma % 11;
            if (dig1 == 10)
            {
                dig1 = 0;
            }
            if (dig1 != numCPF[9])
            {
                isValido = false;
            }
            else
            {
                soma = 0;

                //Descobrir o 11° dígito
                for (int i = 0; i < 10; i++)
                {
                    soma += numCPF[i] * (i);
                }

                dig2 = soma % 11;
                if (dig2 == 10)
                {
                    dig2 = 0;
                }
                if (dig2 != numCPF[10])
                {
                    isValido = false;
                }
            }
        }
        else
        {
            isValido = false;
        }

        return isValido;
    }
}