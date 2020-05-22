using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{

    public class Patient : IPatient
    {
        #region Atributes
       
        private static int countID = 0;
        int id;
        int age;
        int height;
        int weight;
        string name;
        string adress;
        string region;
        string gender;
        bool status;

        #endregion

        #region Constructors

        public Patient()
        {
            countID++;
            id = countID;
        }

        public Patient(string name, int age, int height, int weight, string adress, string region, bool status, string gender)
        {
            countID++;

            id = countID;
            this.age = age;
            this.name = name;
            this.adress = adress;
            this.region = region;
            this.height = height;
            this.weight = weight;
            this.status = status;
            this.gender = gender;


        }

        #endregion

        #region Propreties

        public int Id
        {
            get { return id; }

        }

        public int Age
        {
            get { return age; }
            set { if (value > 0) age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        public int Height
        {
            get { return height; }
            set { if (value > 0) height = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { if (value > 0) weight = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }


        #endregion

    }
}



