using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessRules;
using Exceptions;
using System.IO;

namespace ManagePatients
{
    class Program
    {
        static void Main(string[] args)
        {
			Rules.LoadFile(); //Funcao que dá load aos dados do ficheiro

			#region Variables

			/* Aqui estão todas as variaveis usadas no main, a primeira secção de variaveis serve para a 
			 * registrar um novo caso na lista
			 * Todas as outras são usadas para auxiliar o programa a fazer as escolhas
			 * de acordo com o menu utilizado
			 *
			 */
			int id, height, weight, age;
			string name, adress, region, gender;
			bool status;

			bool aux;
			string opcao;
			int opcaoI;

			#endregion

			/*
			 * Na regiao "DefaultPatients" contem o codigo para a inserçao
			 * manual de pacientes, uma vez que consegui fazer
			 * uma insercao automatica de pacientes pré definidos
			 * num ficheiro, não foi necessario a utilização este
			 * codigo
			 */
			#region DefaultPatients
			/*
			 Nesta secção foram criados alguns pacientes 
			 para a facilitar a utilização da aplicação
			 no entanto é possível inserir/registrar novos casos
			 se o utilizador desejar
			 */
			 /*
			Patient p1 = new Patient(1, "Carlos", 18, 180, 69, "Guimaraes", "Norte", false, "M");
			Patient p2 = new Patient(2, "Diogo", 20, 182, 95, "Viana do Castelo", "Norte", false, "M");
			Patient p3 = new Patient(3, "Vitor", 55, 200, 140, "Algarve", "Sul", true, "M");
			Patient p4 = new Patient(4, "Maria", 25, 165, 64, "Porto", "Sul", true, "F");
			Patient p5 = new Patient(5, "Rita", 18, 165, 59, "Bairro", "Centro", true, "F");

			Rules.AddPatient(p1, 1);
			Rules.AddPatient(p2, 2);
			Rules.AddPatient(p3, 3);
			Rules.AddPatient(p4, 4);
			Rules.AddPatient(p5, 5);

			/*try
            {
				aux = Rules.AddPatient(p1, 1);
				if (aux == true)
				{
					Console.WriteLine("Inserido");
				}
			}
			catch (InsertException e)
			{

				Console.WriteLine(e.Message);
				
			}
			try
			{
				aux = Rules.AddPatient(p2, 2);
				if (aux == true)
				{
					Console.WriteLine("Inserido");
				}
			}
			catch (InsertException e)
			{

				Console.WriteLine(e.Message);

			}
			try
			{
				aux = Rules.AddPatient(p3, 3);
				if (aux == true)
				{
					Console.WriteLine("Inserido");
				}
			}
			catch (InsertException e)
			{

				Console.WriteLine(e.Message);

			}
			try
			{
				aux = Rules.AddPatient(p4, 4);
				if (aux == true)
				{
					Console.WriteLine("Inserido");
				}
			}
			catch (InsertException e)
			{

				Console.WriteLine(e.Message);

			}
			try
			{
				aux = Rules.AddPatient(p5, 5);
				if (aux == true)
				{
					Console.WriteLine("Inserido");
				}
			}
			catch (InsertException e)
			{

				Console.WriteLine(e.Message);

			}
			*/
			#endregion // nesta região está escrito o cód//Esta região contem o codg

			#region Menu

			int myChoice;
            do
            {
				

				Console.WriteLine("MENU \n");
				Console.WriteLine("1 - Ver ficha de pacientes");
				Console.WriteLine("2 - Ver o numero total de casos infetados");
				Console.WriteLine("3 - Registrar um novo paciente");
				Console.WriteLine("4 - Consultar casos por regiao");
				Console.WriteLine("5 - Consultar casos por sexo");
				Console.WriteLine("6 - Consultar casos por idade");
				Console.WriteLine("7 - Remover um paciente");
				Console.WriteLine("8 - Mudar o estado de um paciente");
				Console.WriteLine("0 - Sair\n");
				Console.Write("Opcao: ");
								
				myChoice = Convert.ToInt32(Console.ReadLine()); //Armazena a opcao inserida pelo utilizador
				Console.Clear();

				switch (myChoice)
				{
					case 1:

						Console.WriteLine();
						Console.WriteLine("Ficha de Pacientes");
						Console.WriteLine();
						Rules.PrintList();
				
						break;
					case 2:

						Console.WriteLine();
						Rules.InfectedCases();

						break;
					case 3:

						Console.WriteLine("Nome do paciente: ");
						name = Console.ReadLine();
						Console.Clear();
						Console.WriteLine("Idade do paciente: ");
						age = int.Parse(Console.ReadLine());
						Console.Clear();
						Console.WriteLine("Altura do paciente: ");
						height = int.Parse(Console.ReadLine());
						Console.Clear();
						Console.WriteLine("Peso do paciente: ");
						weight = int.Parse(Console.ReadLine());
						Console.Clear();
						Console.WriteLine("Morada do paciente: ");
						adress = Console.ReadLine();
						Console.Clear();
						Console.WriteLine("Regiao do paciente: ");
						region = Console.ReadLine();
						Console.Clear();
						Console.WriteLine("Sexo do paciente: ");
						gender = Console.ReadLine();
						Console.Clear();
						Console.WriteLine("Estado do paciente: ");
						status = Boolean.Parse(Console.ReadLine());
						Console.Clear();

						Patient p = new Patient(name, age, height, weight, adress, region, status, gender);
						id = 0;
						Rules.SaveAll(p);

						try
						{
							aux = Rules.AddPatient(p, id);
							if (aux == true)
							{
								Console.WriteLine("Inserido");
							}
						}
						catch (InsertException e)
						{
							Console.WriteLine(e.Message);
						}

						break;
					case 4:

						Console.WriteLine("Digite a regiao: ");
						opcao = Console.ReadLine();
						Console.Clear();
						Rules.CasesByRegion(opcao);
						
						break;

					case 5:

						Console.WriteLine("Digite o sexo: ");
						opcao = Console.ReadLine();
						Console.Clear();
						Rules.CasesByGender(opcao);

						break;

					case 6:

						Console.WriteLine("Digite a idade: ");
						opcaoI = int.Parse(Console.ReadLine());
						Console.Clear();
						Rules.CasesByAge(opcaoI);

						break;

					case 7:

						Console.WriteLine("Digite o Id do paciente: ");
						opcaoI = int.Parse(Console.ReadLine());
						Console.Clear();
						Rules.RemovePatient(opcaoI);

						break;

					case 8:

						Console.WriteLine("Digite o Id do paciente: ");
						opcaoI = int.Parse(Console.ReadLine());
						Console.Clear();
						Rules.ChangeStatus(opcaoI);

						break;

					default:

						Console.WriteLine("A opcao {0} nao exise", myChoice);
						break;
				}
				if (myChoice != 0)
				{
					Console.WriteLine("\n");
					Console.WriteLine("Precione uma tecla para voltar ao menu... ");
					Console.ReadLine();
					Console.WriteLine();
					Console.Clear();
				}
				
			} while (myChoice != 0);

            #endregion
        }
    }
}
