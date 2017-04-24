using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCenter.Clases
{
        public class CAsignarEstatus
    {
        private int _estatusSolicitudServicioID;
        private int _solicitudServicioID;
        private int _solicitudServicioDetalleID;
        private int _seguridadUsuarioDatosID;
        private string _observacionesTecnico;
        private int _minutosEmpleados;
        private string _fechaFinalizacionTecnico;
        public CAsignarEstatus(int _estatusSolicitudServicioID,int _solicitudServicioID, int _seguridadUsuarioDatosID,string _observacionesTecnico, int _minutosEmpleados, int _solicitudServicioDetalleID, string _fechaFinalizacionTecnico)
        {
            this._estatusSolicitudServicioID = _estatusSolicitudServicioID;
            this._solicitudServicioID = _solicitudServicioID;
            this._seguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this._observacionesTecnico = _observacionesTecnico;
            this._minutosEmpleados = _minutosEmpleados;
            this._minutosEmpleados = _solicitudServicioDetalleID;
            this._fechaFinalizacionTecnico = _fechaFinalizacionTecnico;
        }
        public CAsignarEstatus()
        {

        }
        public int EstatusSolicitudServicioID
        {
            get
            {
                return _estatusSolicitudServicioID;
            }

            set
            {
                _estatusSolicitudServicioID = value;
            }
        }
        public int SolicitudServicioID
        {
            get
            {
                return _solicitudServicioID;
            }

            set
            {
                _solicitudServicioID = value;
            }
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
        public string ObservacionesTecnico
        {
            get
            {
                return _observacionesTecnico;
            }

            set
            {
                _observacionesTecnico = value;
            }
        }
        public int MinutosEmpleados
        {
            get
            {
                return _minutosEmpleados;
            }

            set
            {
                _minutosEmpleados = value;
            }
        }
        public int SolicitudServicioDetalleID
        {
            get
            {
                return _solicitudServicioDetalleID;
            }

            set
            {
                _solicitudServicioDetalleID = value;
            }
        }
        public string FechaFinalizacionTecnico
        {
            get
            {
                return _fechaFinalizacionTecnico;
            }

            set
            {
                _fechaFinalizacionTecnico = value;
            }
        }
    }
}