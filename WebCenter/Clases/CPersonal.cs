using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCenter.Classes;


namespace WebCenter.Clases
{
    public class CPersonal
    {
        private int _personalID;
        private int _cedula;
        private string _nombrePersonal;
        private int _divisionID;
        private string _numeroExtension;
        private string _estatusPersonal;

        public int PersonalID
        {
            get
            {
                return _personalID;
            }

            set
            {
                _personalID = value;
            }
        }

        public int Cedula
        {
            get
            {
                return _cedula;
            }

            set
            {
                _cedula = value;
            }
        }
        public string NombrePersonal
        {
            get
            {
                return _nombrePersonal;
            }

            set
            {
                _nombrePersonal = value;
            }
        }

        public int DivisionID
        {
            get
            {
                return _divisionID;
            }

            set
            {
                _divisionID = value;
            }
        }

        public string NumeroExtension
        {
            get
            {
                return _numeroExtension;
            }

            set
            {
                _numeroExtension = value;
            }
        }

        public string EstatusPersonal
        {
            get
            {
                return _estatusPersonal;
            }

            set
            {
                _estatusPersonal = value;
            }
        }
        public CPersonal()
        {

        }
        public CPersonal(int personalID, int cedula, string nombrePersonal, int divisionID, string nummeroExtension, string estatusPersonal)
        {
            _personalID = personalID;
            _cedula = cedula;
            _nombrePersonal = nombrePersonal;
            _divisionID = divisionID;
            _numeroExtension = nummeroExtension;
            _estatusPersonal = estatusPersonal;

        }
    }
}