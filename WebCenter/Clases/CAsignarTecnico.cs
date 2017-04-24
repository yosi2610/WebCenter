using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCenter.Clases
{
    public class CAsignarTecnico
    {
        public CAsignarTecnico()
        {

        }
        private int _solicitudServicioID;
        private int _seguridadUsuarioDatosID;
        private string _observacionTecnico;
        private int _minutosServicioTecnico;
        private int _estatusSolicitudServicioID;
        private string _fechaFinalizacionTecnico;
        private int _solicitudServicioDetalleID;

        public CAsignarTecnico(int _solicitudServicioID, int _seguridadUsuarioDatosID, string _observacionTecnico, int _minutosServicioTecnico, int _estatusSolicitudServicioID, string _fechaFinalizacionTecnico, int _solicitudServicioDetalleID)
        {
            this._solicitudServicioID = _solicitudServicioID;
            this._seguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this._observacionTecnico = _observacionTecnico;
            this._minutosServicioTecnico = _minutosServicioTecnico;
            this._estatusSolicitudServicioID = _estatusSolicitudServicioID;
            this._fechaFinalizacionTecnico = _fechaFinalizacionTecnico;
            this._solicitudServicioDetalleID = _solicitudServicioDetalleID;
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

        public string ObservacionTecnico
        {
            get
            {
                return _observacionTecnico;
            }

            set
            {
                _observacionTecnico = value;
            }
        }

        public int MinutosServicioTecnico
        {
            get
            {
                return _minutosServicioTecnico;
            }

            set
            {
                _minutosServicioTecnico = value;
            }
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
    }
}