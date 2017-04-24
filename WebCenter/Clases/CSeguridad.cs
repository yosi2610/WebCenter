using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCenter.Classes;

namespace WebCenter.Clases
{
    public class CSeguridad
    {
        private int _seguridadUsuarioDatosID;
        private string _loginUsuario;
        private string _claveUsuario;
        private string _nombreCompleto;
        private string _descripcionUsuario;
        private int _seguridadGrupoID;
        private int _usuarioTecnico;
        private string _estatusUsuario;
        private string _nombreGrupo;
        private string _descripcionGrupo;
        private int _seguridadObjetoID;
        private string _nombreObjeto;
        private int _seguridadObjetoAccesoID;

        public CSeguridad()
        {

        }

        public CSeguridad(int _seguridadUsuarioDatosID, string _loginUsuario, string _claveUsuario, string _nombreCompleto, string _descripcionUsuario, int _seguridadGrupoID, int _usuarioTecnico, string _estatusUsuario, string _nombreGrupo, string _descripcionGrupo, int _seguridadObjetoID, string _nombreObjeto, int _seguridadObjetoAccesoID)
        {
            this._seguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this._loginUsuario = _loginUsuario;
            this._claveUsuario = _claveUsuario;
            this._nombreCompleto = _nombreCompleto;
            this._descripcionUsuario = _descripcionUsuario;
            this._seguridadGrupoID = _seguridadGrupoID;
            this._usuarioTecnico = _usuarioTecnico;
            this._estatusUsuario = _estatusUsuario;
            this._nombreGrupo = _nombreGrupo;
            this._descripcionGrupo = _descripcionGrupo;
            this._seguridadObjetoID = _seguridadObjetoID;
            this._nombreObjeto = _nombreObjeto;
            this._seguridadObjetoAccesoID = _seguridadObjetoAccesoID;
        }

        public int SeguridadUsuarioDatosID
        {
            get
            {
                return _seguridadUsuarioDatosID;
            }

            set
            {
                _seguridadUsuarioDatosID = value;
            }
        }

        public string LoginUsuario
        {
            get
            {
                return _loginUsuario;
            }

            set
            {
                _loginUsuario = value;
            }
        }

        public string ClaveUsuario
        {
            get
            {
                return _claveUsuario;
            }

            set
            {
                _claveUsuario = value;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return _nombreCompleto;
            }

            set
            {
                _nombreCompleto = value;
            }
        }

        public string DescripcionUsuario
        {
            get
            {
                return _descripcionUsuario;
            }

            set
            {
                _descripcionUsuario = value;
            }
        }

        public int SeguridadGrupoID
        {
            get
            {
                return _seguridadGrupoID;
            }

            set
            {
                _seguridadGrupoID = value;
            }
        }

        public int UsuarioTecnico
        {
            get
            {
                return _usuarioTecnico;
            }

            set
            {
                _usuarioTecnico = value;
            }
        }

        public string EstatusUsuario
        {
            get
            {
                return _estatusUsuario;
            }

            set
            {
                _estatusUsuario = value;
            }
        }

        public string NombreGrupo
        {
            get
            {
                return _nombreGrupo;
            }

            set
            {
                _nombreGrupo = value;
            }
        }

        public string DescripcionGrupo
        {
            get
            {
                return _descripcionGrupo;
            }

            set
            {
                _descripcionGrupo = value;
            }
        }

        public int SeguridadObjetoID
        {
            get
            {
                return _seguridadObjetoID;
            }

            set
            {
                _seguridadObjetoID = value;
            }
        }
        
        public string NombreObjeto
        {
            get
            {
                return _nombreObjeto;
            }

            set
            {
                _nombreObjeto = value;
            }
        }
        public int SeguridadObjetoAccesoID
        {
            get
            {
                return _seguridadObjetoAccesoID;
            }

            set
            {
                _seguridadObjetoAccesoID = value;
            }
        }

        public bool EsAccesoPermitido(int seguridadObjetoID)
        {
            bool esPermitido =false;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                    {
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, this.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("SeguridadObjetoID", SqlDbType.Int, 0, seguridadObjetoID),
                    };

                DataSet ds = DBHelper.ExecuteDataSet("[usp_Seguridad_ObtenerAccesoObjeto]", dbParams);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    esPermitido = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return esPermitido;
        }
        public bool EsUsuarioAdministrador()
        {
            bool esPermitido = false;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                    {
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, this.SeguridadUsuarioDatosID)
                   };

                DataSet ds = DBHelper.ExecuteDataSet("[usp_Seguridad_ObtenerAdministrador]", dbParams);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    esPermitido = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return esPermitido;
        }

    }
}