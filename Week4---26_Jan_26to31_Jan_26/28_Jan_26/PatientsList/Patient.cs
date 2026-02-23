using System;

namespace PatientsList
{
    public class Patient
    {
        private string _name;
        private int _age;
        private string _illness;
        private string _city;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Illness
        {
            get { return _illness; }
            set { _illness = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public Patient() { }

        public Patient(string name, int age, string illness, string city)
        {
            this._name = name;
            this._age = age;
            this._illness = illness;
            this._city = city;
        }

        public override string ToString()
        {
            return string.Format("{0,-21}{1,-6}{2,-17}{3,-20}", _name, _age, _illness, _city);
        }
    }
}