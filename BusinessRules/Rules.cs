using BusinessObjects;
using Data;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public class Rules
    {

        #region Functions

        public Rules()
        {
        }

        public static bool AddPatient(Patient p, int id) // adiciona um novo paciente na lista allPatients
        {
            
            if (id > 0)
            {
                try
                {
                    return Patients.AddPatient(p);
                }
                catch (InsertException e)
                {
                    throw e;
                }
            }
            return false;

        }

        public static void PrintList() //dá print à lista de todos os pacientes
        {
            try
            {
                Patients.PrintList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void InfectedCases() //Mostra o número de casos infetados
        {
            try
            {
                Patients.InfectedCases();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void CasesByRegion(string region) //Consulta os casos por region, recebe uma "region" digitada pelo o utilizador e mostra todos os dados inclusive o numero de casos infetados
        {
            try
            {
                Patients.CasesByRegion(region);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void CasesByGender(string gender) //Faz o mesmo que a função acima mas desta vez em relação ao genero
        {
            try
            {
                Patients.CasesByGender(gender);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void CasesByAge(int age) // Faz o mesmo que as outras duas mas em relação às idades
        {
            try
            {
                Patients.CasesByAge(age);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void RemovePatientTemp(int id)
        {
            try
            {
                Patients.RemovePatientTemp(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ChangeStatus(int id)
        {
            try
            {
                Patients.ChangeStatus(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region File Functions

        public static void LoadFile()
        {
            try
            {
                Patients.LoadAll();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public static void SaveAll(Patient p)
        {
            try
            {
                Patients.SaveAll(p);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
