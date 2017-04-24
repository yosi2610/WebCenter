using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCenter
{
    public class CAtencionCallCenter
    {
        private int _solicitudServicioID;
        private int _personalID;
        private string _descripcionSolicitudServicio;
        private int _areaServicioDetalleID;
        private int _estatusSolicitudServicioID;
        private int _seguridadUsuarioDatosID;
        private string _fechaFinalizacionSolicitudServicio;

        public CAtencionCallCenter()
        {

        }
        public CAtencionCallCenter(int _solicitudServicioID,int _personalID, string _descripcionSolicitudServicio, int _areaServicioDetalleID, int _estatusSolicitudServicioID, int _seguridadUsuarioDatosID, string _fechaFinalizacionSolicitudServicio)
        {
            this._personalID = _solicitudServicioID;
            this._personalID = _personalID;
            this._descripcionSolicitudServicio = _descripcionSolicitudServicio;
            this._areaServicioDetalleID = _areaServicioDetalleID;
            this._estatusSolicitudServicioID = _estatusSolicitudServicioID;
            this._seguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this._fechaFinalizacionSolicitudServicio = _fechaFinalizacionSolicitudServicio;
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

        public string DescripcionSolicitudServicio
        {
            get
            {
                return _descripcionSolicitudServicio;
            }

            set
            {
                _descripcionSolicitudServicio = value;
            }
        }

        public int AreaServicioDetalleID
        {
            get
            {
                return _areaServicioDetalleID;
            }

            set
            {
                _areaServicioDetalleID = value;
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
        public string FechaFinalizacionSolicitudServicio
        {
            get
            {
                return _fechaFinalizacionSolicitudServicio;
            }

            set
            {
                _fechaFinalizacionSolicitudServicio = value;
            }
        }
    }
}