using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Exceptions;
using System.IO;

namespace Data
{
    public class Patients 
    {


        private static List<Patient> allPatients; //criação da lista privada

        static Patients()
        {
            allPatients = new List<Patient>();
        }


    public static bool AddPatient(Patient p) //função para adicionar um novo paciente na lista
        {
            try
            {
                if (allPatients.Contains(p)) return false; //verifica se contem um paciente esse paciente
                allPatients.Add(p); //caso contrario adiciona-o na lista

            }
            catch (InsertException e)
            {
                throw e;
            }
            return true;
        }

        #region File Functions

        public static void SaveAll(Patient p)//salva os dados de um novo paciente
        {
            allPatients.Add(p); //adiciona os dados do paciente introduzido pelo o utilizador na lista allPatients

            string filePath = @"D:\LP2\data.txt"; //Caminho onde está guardado o documento de texto

            List<string> output = new List<string>(); //cria uma nova lista para armazenar o output 

            foreach (var item in allPatients) //percorre todos os dados na lista
            {
                output.Add($"{item.Name},{item.Age},{item.Height},{item.Weight},{item.Adress},{item.Region},{item.Status},{item.Gender}"); //adiciona as variaveis introduzidas na lista do output
            }

            File.WriteAllLines(filePath, output); //E por fim armazena os dados no documento de texto
            
        }

        public static void LoadAll() //funcao para dar load ao ficheiro
        {

            string filePath = @"D:\LP2\data.txt"; //Caminho onde está guardado o documento de texto


            List<string> file = File.ReadAllLines(filePath).ToList(); //cria uma nova lista file do tipo string que vai armazenar todas as linhas do ficheiro


            foreach (var data in file) //percorre todos os valores na lista file
            {

                string[] entries = data.Split(','); //guarda num array os dados individualmente utilizando a vírgula como referência

                Patient newPatient = new Patient(); //criacao de um novo paciente

                //em cada um destes parâmetros é feito uma transferencia de dados para o newPatient 
                newPatient.Name = entries[0];
                newPatient.Age = int.Parse(entries[1]);
                newPatient.Height = int.Parse(entries[2]);
                newPatient.Weight = int.Parse(entries[3]);
                newPatient.Adress = entries[4];
                newPatient.Region = entries[5];
                newPatient.Status = Boolean.Parse(entries[6]);
                newPatient.Gender = entries[7];

                allPatients.Add(newPatient); //Por fim o newPatient é adicionada na lista allPatients
            }
        }

        #endregion

        #region MainFunctions

        public static void PrintList() //funcao para listar todos os pacientes
        {
            string status;

            foreach (var item in allPatients) //percorre todos os dados da lista
            {
                if (item.Status == true)
                {
                    status = "Infetado";
                }
                else
                {
                    status = "Não Infetado";
                }
                Console.WriteLine("----- Estado do Paciente -----\n");
                Console.WriteLine($"ID: {item.Id}\nNome: {item.Name}\nIdade: {item.Age}\nAltura {item.Height}\nPeso {item.Weight}\nRegiao: {item.Region}\nMorada: {item.Adress}\nSexo: {item.Gender}\nInfetado: {status}\n");
                Console.WriteLine();
            }
        }

        public static void InfectedCases() //função para contar o numero total de casos
        {
            int counter = 0;

            foreach (var item in allPatients) //percorre a lista
            {
                if (item.Status == true) //caso se verfique que o bool status é verdadeiro
                {
                    counter++; //acrescenta-se um novo caso com infecao
                }
            }

            Console.WriteLine("Numero total de casos infetados: {0}", counter); //imprime o numero de casos

        }

        public static void CasesByRegion(string region) //Consulta os casos por região
        {
            int counter = 0;
            string status;

            foreach (var item in allPatients)
            {
                if (item.Status == true)
                {
                    status = "Infetado";
                }
                else
                {
                    status = "Não Infetado";
                }
                bool result = string.Equals(item.Region, region, StringComparison.OrdinalIgnoreCase);
                if (result)
                {
                    Console.WriteLine("----- Estado do Paciente -----\n");
                    Console.WriteLine($"Nome: {item.Name}\nIdade: {item.Age}\nAltura {item.Height}\n Peso {item.Weight}\nRegiao: {item.Region}\nMorada: {item.Adress}\nSexo: {item.Gender}\nInfetado: {status}\n");
                    Console.WriteLine();

                    if (item.Status)
                    {
                        counter++;
                    }
                }

            }
            Console.WriteLine("\nNumero total de infetados na Região {0}: {1}\n", region, counter);
        }

        public static void CasesByGender(string gender) // consulta os casos por sexo
        {
            int counter = 0;
            string status;

            foreach (var item in allPatients)
            {
                if (item.Status == true)
                {
                    status = "Infetado";
                }
                else
                {
                    status = "Não Infetado";
                }
                bool result = string.Equals(item.Gender, gender, StringComparison.OrdinalIgnoreCase);
                if (result)
                {
                    Console.WriteLine("----- Estado do Paciente -----\n");
                    Console.WriteLine($"Nome: {item.Name}\nIdade: {item.Age}\nAltura {item.Height}\n Peso {item.Weight}\nRegiao: {item.Region}\nMorada: {item.Adress}\nSexo: {item.Gender}\nInfetado: {status}\n");
                    Console.WriteLine();

                    if (item.Status)
                    {
                        counter++;
                    }
                }

            }
            Console.WriteLine("\nNumero total de infetados do sexo {0}: {1}\n", gender, counter);
        }

        public static void CasesByAge(int age) //consulta os casos por idades
        {
            int counter = 0;
            string status;
            foreach (var item in allPatients)
            {
                if (item.Age == age)
                {
                    if (item.Status == true)
                    {
                        status = "Infetado";
                    }
                    else
                    {
                        status = "Não Infetado";
                    }
                    Console.WriteLine("----- Estado do Paciente -----\n");
                    Console.WriteLine($"ID: {item.Id}\nNome: {item.Name}\nIdade: {item.Age}\nRegion: {item.Region}\nMorada: {item.Adress}\nSexo: {item.Gender}\nInfetado: {status}\n");
                    Console.WriteLine();

                    if (item.Status)
                    {
                        counter++;
                    }
                }

            }
            Console.WriteLine("\nNumero total de infetados com {0} anos: {1}\n", age, counter);
        }

        public static void RemovePatient(int id) //Remove um paciente temporariamente da aplicação
        {
            string filePath = @"D:\LP2\data.txt";

            var removeId = allPatients.SingleOrDefault(r => r.Id == id); //removeId toma o valor da comparacao feita entre o id da lista e o id recebido
            if (removeId != null) //caso o resultado der null então 
                allPatients.Remove(removeId); //É feita a remoção do paciente

            List<string> output = new List<string>(); //cria uma nova lista para armazenar o novo output 

            foreach (var item in allPatients) //percorre todos os dados na lista
            {
                output.Add($"{item.Name},{item.Age},{item.Height},{item.Weight},{item.Adress},{item.Region},{item.Status},{item.Gender}"); //adiciona as variaveis introduzidas na lista do output
            }

            File.WriteAllLines(filePath, output);

            Console.WriteLine("Paciente removido");
        }

        public static void ChangeStatus(int id)
        {
            string status;
            string filePath = @"D:\LP2\data.txt";
            List<string> output = new List<string>();

            foreach (var item in allPatients)
                {
                    if (item.Id == id)
                    {
                    if (item.Status == true)
                    {
                        status = "Infetado";
                    }
                    else
                    {
                        status = "Não Infetado";
                    }

                    if (item.Status == true)
                        {
                            item.Status = false;
                            Console.WriteLine($"ID:{item.Id}\nNome:{item.Name}\nEstado alterado: {status}\n");
                        }
                        else
                        {
                            item.Status = true;
                            Console.WriteLine($"ID:{item.Id}\nNome:{item.Name}\nEstado alterado: {status}\n");
                        }
                    }

                output.Add($"{item.Name},{item.Age},{item.Height},{item.Weight},{item.Adress},{item.Region},{item.Status},{item.Gender}");
                            }
            File.WriteAllLines(filePath, output);
        }

        #endregion 

    }

}
