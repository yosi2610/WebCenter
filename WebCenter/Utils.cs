using System;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Net;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Security;

namespace WebCenter.Utils
{
    using TDALDateTime = System.Double;
    using System.Web.UI.WebControls;

    public struct NameValuePair
    {
        public string Name;
        public string Value;
    }

    public class utils
    {
        public static readonly double NullDALDateTime = -693594.0;
        public static readonly DateTime NullDateTime = DateTime.MinValue;

        public static string GetValorDeConfiguracion(string key, string valordefault)
        {
            string sValor = valordefault;
            try
            {
                sValor = ConfigurationManager.AppSettings.Get(key);
            }
            catch (Exception)
            {
                                   
            }
            return sValor;
        }

        public static void llenarTipoProductos( DropDownList cbTipoProducto,bool incluirVacio)
        {
            //List<TipoProductos> lista = new List<TipoProductos>();
            //if (incluirVacio)
            //    lista.Add(new TipoProductos(0, "Todos"));
            //lista.Add(new TipoProductos(1, "Prendas"));
            //lista.Add(new TipoProductos(2, "Carteras"));
            //lista.Add(new TipoProductos(3, "Accesorios"));

            //cbTipoProducto.DataTextField = "Descripcion";
            //cbTipoProducto.DataValueField = "Id";
            //cbTipoProducto.DataSource = lista;
            //cbTipoProducto.DataBind();


        }

        public static string GetTipoById(int id)
        {
            string res = "";
            switch (id)
            {
                case 1: res = "Prendas";
                    break;
                case 2: res = "Carteras";
                    break;
                case 3: res = "Accesorios";
                    break;
                default: break;
            }
            return res;
        }

        public static void llenarTipoTalles(DropDownList cbTalle, bool incluirVacio)
        {
            //List<Talle> lista = new List<Talle>();
            //if (incluirVacio)
            //    lista.Add(new Talle("", "Todos"));

            //lista.Add(new Talle("U", "Unico"));
            //lista.Add(new Talle("XS", "Extra Small"));
            //lista.Add(new Talle("S", "Small"));
            //lista.Add(new Talle("M", "Medium"));
            //lista.Add(new Talle("L", "Large"));
            //lista.Add(new Talle("XL", "Extra Large"));
            //lista.Add(new Talle("-", "Sin Medida"));
            //lista.Add(new Talle("36", "36"));
            //lista.Add(new Talle("38", "38"));
            //lista.Add(new Talle("40", "40"));
            //lista.Add(new Talle("42", "42"));
            //lista.Add(new Talle("44", "44"));
            //lista.Add(new Talle("46", "46"));

            //cbTalle.DataTextField = "Descripcion";
            //cbTalle.DataValueField = "Id";
            //cbTalle.DataSource = lista;
            //cbTalle.DataBind();


        }
        #region Serialization
        public static string SerializeObject<T>(T obj, System.Text.Encoding encoding)
        {
            XmlWriter xmlWriter = null;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.CloseOutput = true;
                settings.Encoding = encoding;
                xmlWriter = XmlWriter.Create(memoryStream, settings);

                xs.Serialize(xmlWriter, obj);
                return encoding.GetString(memoryStream.ToArray());
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                if (xmlWriter != null)
                {
                    xmlWriter.Close();
                }
            }
        }

        public static T DeserializeObject<T>(string xml, System.Text.Encoding encoding)
        {
            MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(xml));
            XmlSerializer xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(memoryStream);
        }
        #endregion

        public static bool IsAlphanumeric(string input)
        {
            return IsAlphanumeric(input, false);
        }

        public static bool IsAlphanumeric(string input, bool mandatory)
        {
            bool result = false;
            input = input ?? String.Empty;
            if (!mandatory && input.Trim() == string.Empty)
            {
                result = true;
            }
            else
            {
                Regex regexAlphaNum = new Regex(@"^\w+");
                result = regexAlphaNum.IsMatch(input.Trim());
            }
            return result;
        }

        public static bool IsNumeric(string input)
        {
            return IsNumeric(input, false);
        }

        public static int ToInt(object valor)
        {
            try
            {
               return Convert.ToInt32(valor);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public static string DateTimeFormat(object dateTime)
        {
            DateTime dt= Convert.ToDateTime(dateTime);
            return String.Format("{0:dd/MM/yyyy}", dt);
        }

        public static DateTime DateTimeNet(object dateTime)
        {
            string[] obj= dateTime.ToString().Split('/');
            return new DateTime(ToInt(obj[2]),ToInt(obj[1]),ToInt(obj[0]));
            //return String.Format("{0:dd/MM/yyyy}", dt);
        }
        public static double ToDouble(object valor)
        {
          var separatorFormat = System.Globalization.NumberFormatInfo.CurrentInfo;
          
            try
            {
              string  strinValor = valor.ToString();
                if (separatorFormat.CurrencyDecimalSeparator == ",")
                    strinValor = valor.ToString().Replace(".",",");

                var decimalValue = Convert.ToDouble(strinValor);
                return decimalValue;
            }
            catch (Exception ex)
            {

                return 0.00;
            }
        }
        public static bool IsNumeric(string input, bool mandatory)
        {
            bool result = false;
            input = input ?? String.Empty;
            if (!mandatory && input.Trim() == string.Empty)
            {
                result = true;
            }
            else
            {
                Regex regexAlphaNum = new Regex(@"^\d+");
                result = regexAlphaNum.IsMatch(input.Trim());
            }
            return result;
        }

        /*! \fn   	T To<T>(object value, T defaultValue)
         *  \brief 	Convert value to the specified type &lt;T&gt;
         * 
         * If value is NULL or DBNull.Value, the defaultValue is returned.
         * 
         * \param value
         * \param defaultValue
         * \exception	InvalidCastException conversion is not supported
         * \return 		defaultValue if NULL or DBNull.Value; value converted to T otherwise
         */
        public static T To<T>(object value, T defaultValue)
        {
            if (value == null || value == DBNull.Value) return defaultValue;
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static Int64 HexToInt(String NumeroHex)
        {
            return Int64.Parse(NumeroHex, System.Globalization.NumberStyles.HexNumber, null);
        }


        public static char KTCLuhn(String BarCode)
        {
            string IntSerialNumber;
            double Year, Month, SerialNumber;

            // Manufacturer

            IntSerialNumber = BarCode.Substring(0, 2);

            // Year

            Year = Int64.Parse(BarCode.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, null);
            IntSerialNumber = IntSerialNumber + Year.ToString().PadLeft(2, '0');

            // Month
            Month = Int64.Parse(BarCode.Substring(4, 1), System.Globalization.NumberStyles.HexNumber, null);
            IntSerialNumber = IntSerialNumber + Month.ToString().PadLeft(2, '0');

            // Serialnumber
            SerialNumber = Int64.Parse(BarCode.Substring(5, 5), System.Globalization.NumberStyles.HexNumber, null);
            IntSerialNumber = IntSerialNumber + SerialNumber.ToString().PadLeft(7, '0');

            // Calculate the checknumber
            return Luhn(IntSerialNumber);
        }

        public static char Luhn(string Numero)
        {
            int i, j, k, resu;

            resu = 0;
            j = 1;
            for (i = Numero.Length - 1; i >= 0; i--)
            {
                if (j % 2 == 0) k = int.Parse(Numero[i].ToString());
                else k = int.Parse(Numero[i].ToString()) * 2;

                resu += k / 10;
                resu += k % 10;
                j++;
            }
            if (resu % 10 == 0) resu = '0';
            else resu = 58 - (resu % 10);
            return Convert.ToChar(resu);
        }

        public static void BytesToFile(byte[] Bytes, String FileName)
        {
            FileStream Stream = new FileStream(FileName, FileMode.Create);
            Stream.Write(Bytes, 0, Bytes.Length);
            Stream.Close();
        }

        public static byte[] FileToBytes(string FileName)
        {
            byte[] result;
            FileStream Stream;
            Stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                result = new byte[Stream.Length];
                Stream.Read(result, 0, (int)Stream.Length);
                return result;
            }
            finally
            {
                Stream.Close();
            }
        }

        public static string ImageToBase64(byte[] ImageBytes)
        {
            // Convert byte[] to Base64 String
            string base64String = Convert.ToBase64String(ImageBytes);
            return base64String;
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static System.Array SetLength(System.Array sArray, int size)
        {
            System.Type t = sArray.GetType().GetElementType();
            System.Array nArray = System.Array.CreateInstance(t, size);
            System.Array.Copy(sArray, 0, nArray, 0, Math.Min(sArray.Length, size));
            return nArray;
        }

        #region IsNull
        public static char IsNullChr(object o)
        {
            return IsNullChr(o, (char)0);
        }

        public static char IsNullChr(object o, char NullValue)
        {
            if (o == null || o == DBNull.Value)
                return NullValue;
            else
                return Convert.ToChar(o);
        }

        public static double IsNullDouble(object o)
        {
            return IsNullDouble(o, (double)0);
        }

        public static double IsNullDouble(object o, double NullValue)
        {
            if (o == null || o == DBNull.Value)
                return NullValue;
            else
                return Convert.ToDouble(o);
        }

        public static DateTime IsNullDateTime(object o)
        {
            return IsNullDateTime(o, NullDateTime);
        }

        public static DateTime IsNullDateTime(object o, DateTime NullValue)
        {
            if (o == null || o == DBNull.Value)
                return NullValue;
            else
                return Convert.ToDateTime(o);
        }

        public static decimal IsNullDecimal(object o)
        {
            return IsNullDecimal(o, 0);
        }

        public static decimal IsNullDecimal(object o, decimal NullValue)
        {
            if (o == null || o == DBNull.Value)
                return NullValue;
            else
                return Convert.ToDecimal(o);
        }

        public static Int32 IsNullInt(object o)
        {
            return IsNullInt(o, 0);
        }

        public static Int32 IsNullInt(object o, Int32 NullValue)
        {
            if (o == null || o == DBNull.Value)
                return NullValue;
            else
                return Convert.ToInt32(o);
        }

        public static Int16 IsNullInt16(object o)
        {
            return IsNullInt16(o, 0);
        }

        public static Int16 IsNullInt16(object o, Int16 NullValue)
        {
            if (o == null || o == DBNull.Value)
                return NullValue;
            else
                return Convert.ToInt16(o);
        }

        public static Int64 IsNullInt64(object o)
        {
            return IsNullInt64(o, 0);
        }

        public static Int64 IsNullInt64(object o, Int64 NullValue)
        {
            if (o == null || o == DBNull.Value)
                return NullValue;
            else
                return Convert.ToInt64(o);
        }

        public static string IsNullStr(object o)
        {
            return IsNullStr(o, string.Empty);
        }

        public static string IsNullStr(object o, string NullValue)
        {
            if (o == null || o == DBNull.Value)
                return NullValue;
            else
                return Convert.ToString(o);
        }

        public static byte[] IsNullBytes(object o, byte[] NullValue)
        {
            if (o == null || o == DBNull.Value)
                return NullValue;
            else
                return (byte[])o;
        }

        public static bool IsNullOrEmpty(object value)
        {
            if (value == null
                || value == DBNull.Value
                || (value is string && String.Empty == ((string)value).Trim())
                || (value is byte && 0 == ((byte)value))
                || (value is int && 0 == ((int)value))
                || (value is short && 0 == ((short)value))
                || (value is long && 0 == ((long)value))
                || (value is double && 0 == ((double)value))
                || (value is decimal && 0 == ((decimal)value))
                || (value is byte[] && 0 == ((byte[])value).Length)
                || (value is DateTime && NullDateTime == ((DateTime)value))
               )
            {
                return true;
            }
            return false;
        }
        #endregion

        #region NullIf
        public static object NullIfValue(Int64 I, Int64 Value)
        {
            if (I == Value)
                return DBNull.Value;
            else
                return I;
        }

        public static object NullIfEmpty(string s)
        {
            if (string.IsNullOrEmpty(s))
                return DBNull.Value;
            else
                return s;
        }

        public static object NullIfGuidEmpty(System.Guid G)
        {
            if (G.Equals(Guid.Empty))
                return DBNull.Value;
            else
                return G;
        }

        public static object NullIfZero(Int64 I)
        {
            return NullIfValue(I, 0);
        }

        public static object NullIfDoubleZero(double D)
        {
            if (D == 0.0)
                return DBNull.Value;
            else
                return D;
        }

        public static object NullIfDALDateTime(TDALDateTime D)
        {
            if (D == NullDALDateTime || D == 0)
                return DBNull.Value;
            else
                return DALDateTimeToDateTime(D);
        }

        public static object NullIfDateTime(DateTime dateTime)
        {
            if (dateTime == NullDateTime)
                return DBNull.Value;
            else
                return dateTime;
        }
        #endregion

        #region DateTime Conversions
        public static DateTime DALDateTimeToDateTime(TDALDateTime DALDateTime)
        {
            DateTime Result;
            //Se devuelve el 01/01/0001 como null. Para comparar usar DateTime.MinValue
            if (DALDateTime == NullDALDateTime || DALDateTime == 0)
                Result = NullDateTime;
            else
                Result = DateTime.FromOADate(DALDateTime);
            return Result;
        }

        public static TDALDateTime ObjectToDALDateTime(object o)
        {
            TDALDateTime Result;
            if (o == DBNull.Value)
                Result = NullDALDateTime;
            else
                Result = DateTimeToDALDateTime(Convert.ToDateTime(o));
            return Result;
        }

        public static TDALDateTime DateTimeToDALDateTime(DateTime aDateTime)
        {
            return aDateTime.ToOADate();
        }

        public static DateTime ParseXMLDateTime(string dateTime)
        {
            // \d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(.\d{1,6})
            if (String.IsNullOrEmpty(dateTime))
                return NullDateTime;

            switch (dateTime.Length)
            {
                case 21:
                    return DateTime.ParseExact(dateTime, "yyyy-MM-ddTHH:mm:ss.f", System.Globalization.CultureInfo.InvariantCulture);
                case 22:
                    return DateTime.ParseExact(dateTime, "yyyy-MM-ddTHH:mm:ss.ff", System.Globalization.CultureInfo.InvariantCulture);
                case 23:
                    return DateTime.ParseExact(dateTime, "yyyy-MM-ddTHH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                default:
                    return DateTime.ParseExact(dateTime, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        public static string FormatXMLDateTime(DateTime dateTime)
        {
            if (dateTime == NullDateTime)
                return string.Empty;
            else
                return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
        }

        #endregion

        [SuppressUnmanagedCodeSecurity, DllImport("LegacyCompress.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal static extern void CompressFile(string InputFile, string OutputFile);

        [SuppressUnmanagedCodeSecurity, DllImport("LegacyCompress.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal static extern void DecompressFile(string InputFile, string OutputFile);

        /// <summary>
        /// Encodes a string to be represented as a string literal. The format
        /// is essentially a JSON string.
        /// 
        /// The string returned includes outer quotes 
        /// Example Output: "Hello \"Rick\"!\r\nRock on"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string EncodeJsString(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        int i = (int)c;
                        if (i < 32 || i > 127)
                        {
                            sb.AppendFormat("\\u{0:X04}", i);
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            sb.Append("\"");

            return sb.ToString();
        }
    }

    public class CompressionUtils
    {
        public static string COMPRESSION_SIGNATURE = "DPS.Compressed.";


        public static void CompressFile(String InputFile, String OutputFile)
        {
            utils.CompressFile(InputFile, OutputFile);
        }

        public static void DecompressFile(String InputFile, String OutputFile)
        {
            utils.DecompressFile(InputFile, OutputFile);
        }

        public static byte[] CompressBytes(byte[] InputBytes)
        {
            byte[] Result;
            string AuxInFile = Path.GetTempFileName();
            try
            {
                FileStream fsAuxInFile = new FileStream(AuxInFile, FileMode.Create);
                try
                {
                    fsAuxInFile.Write(InputBytes, 0, InputBytes.Length);
                    fsAuxInFile.Close();
                    string AuxOutFile = Path.GetTempFileName();
                    try
                    {
                        utils.CompressFile(AuxInFile, AuxOutFile);
                        FileStream fsAuxOutFile = new FileStream(AuxOutFile, FileMode.Open);
                        try
                        {
                            Result = new byte[fsAuxOutFile.Length];
                            fsAuxOutFile.Read(Result, 0, (int)fsAuxOutFile.Length);
                        }
                        finally
                        {
                            fsAuxOutFile.Close();
                        }
                    }
                    finally
                    {
                        File.Delete(AuxOutFile);
                    }
                }
                finally
                {
                    fsAuxInFile.Close();
                }
            }
            finally
            {
                File.Delete(AuxInFile);
            }
            return Result;
        } // public static byte[] CompressBytes

        public static byte[] DecompressBytes(byte[] InputBytes)
        {
            byte[] Result;
            string AuxInFile = Path.GetTempFileName();
            try
            {
                FileStream fsAuxInFile = new FileStream(AuxInFile, FileMode.Create);
                try
                {
                    fsAuxInFile.Write(InputBytes, 0, InputBytes.Length);
                    fsAuxInFile.Close();
                    string AuxOutFile = Path.GetTempFileName();
                    try
                    {
                        utils.DecompressFile(AuxInFile, AuxOutFile);
                        FileStream fsAuxOutFile = new FileStream(AuxOutFile, FileMode.Open);
                        try
                        {
                            Result = new byte[fsAuxOutFile.Length];
                            fsAuxOutFile.Read(Result, 0, (int)fsAuxOutFile.Length);
                        }
                        finally
                        {
                            fsAuxOutFile.Close();
                        }
                    }
                    finally
                    {
                        File.Delete(AuxOutFile);
                    }
                }
                finally
                {
                    fsAuxInFile.Close();
                }
            }
            finally
            {
                File.Delete(AuxInFile);
            }
            return Result;
        } // public static byte[] DecompressBytes

    }

    public class LogFile
    {
        /******************************** Function Header ******************************
        Function Name: SaveMessageIntoLogFile
        Author : ggomez
        Date Created : 11/02/2008
        Description : Save into a file a message.
        Parameters : const Path, FileName, FileExtension, Msg, MachineName, UserName: String
            Path: Path where the file is located.
            Filename: Name of de file.
            FileExtension: Extension of the file.
            Msg: Message to save.
            MachineName: Name of the machine associated to the Msg.
            UserName: Name of the user associated to the Msg.
        Return Value : None
        Comments: Se pasa la funcion de _commonprocs aqui pues no compilaba para win32.
                  Si se quiere hacer un logueo en win32 y C# habria que revisarla para poder
                  utilizarla en ambas plataformas(aparini)
         *******************************************************************************
         * Modified by      alopez
         * Date             26-Oct-2009
         * Description      If the folder or the file doesn't exist, creates them.
         * ******************************************/
        public static void SaveMessageIntoLogFile(String Path, String FileName, String FileExtension, String Msg, String MachineName, String UserName)
        {
            const int MAX_RETRIES = 100;

            byte[] S;
            string FileNameComplete;
            FileStream Stream;

            //Chequea que tenga '\' como ultimo caracter, de lo contrario, lo agrega
            Path = Path.Trim();
            Path = ((char)Path[Path.Length - 1]).Equals('\\') ? Path : string.Format("{0}\\", Path);
            FileNameComplete = string.Format("{0}{1}{2}.{3}", new object[] { Path, FileName, DateTime.Now.ToString("yyyyMMdd"), FileExtension });
            for (int i = 0; i < MAX_RETRIES; i++)
            {
                try
                {
                    if (!System.IO.Directory.Exists(Path))
                        System.IO.Directory.CreateDirectory(Path);

                    // ggomez 20100518: NO hay que crear el archivo de esta manera ya que new FileStream(FileNameComplete, FileMode.Append, FileAccess.Write, FileShare.None);
                    // lo crea si no existe.
                    // Al crearlo con las sentencias comentadas, la escritura fallaba y dejaba el archivo si lo que se había pedido escribir.
                    //if (!System.IO.File.Exists(FileNameComplete))
                    //    System.IO.File.Create(FileNameComplete);

                    Stream = new FileStream(FileNameComplete, FileMode.Append, FileAccess.Write, FileShare.None);
                    try
                    {
                        // Cabecera
                        S = System.Text.Encoding.UTF8.GetBytes(string.Format("{0}, {1}, {2}" + (char)13 + (char)10, new object[] { System.DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss"), MachineName, UserName }));
                        Stream.Write(S, 0, S.Length);
                        // Cabecera
                        S = System.Text.Encoding.UTF8.GetBytes(Msg + (char)13 + (char)10);
                        Stream.Write(S, 0, S.Length);
                        return;
                    }
                    finally
                    {
                        Stream.Close();
                    }
                }
                catch (Exception e)
                {
                    if (i == MAX_RETRIES)
                        throw e;
                }
            }
        }
    }

    /*public abstract class UtilsCs
    {
        public static readonly DateTime NullDateTime = DateTime.MinValue;
		
        public static object NullIfDateTimeNull(DateTime dateTime)
        {
            if (dateTime == NullDateTime)
                return DBNull.Value;
            else
                return dateTime;
        }
		
        public static DateTime IsNullDateTime(object o, DateTime DateTimeValue)
        {
            if (o == null || o == DBNull.Value)
                return DateTimeValue;
            else
                return Convert.ToDateTime(o);
        }
		
        public static DateTime IsNullDateTime(object o)
        {
            return IsNullDateTime(o, NullDateTime);
        }
		
        public static string SerializeObject<T>(T obj, System.Text.Encoding encoding)
        {
            XmlWriter xmlWriter = null;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.CloseOutput = true;
                settings.Encoding = encoding;
                xmlWriter = XmlWriter.Create(memoryStream, settings);
			
                xs.Serialize(xmlWriter, obj);
                return encoding.GetString(memoryStream.ToArray());
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                if (xmlWriter != null)
                {
                    xmlWriter.Close();
                }
            }
        }
		
        public static T DeserializeObject<T>(string xml, System.Text.Encoding encoding)
        {
           MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(xml));
           XmlSerializer xs = new XmlSerializer(typeof(T));
           return (T) xs.Deserialize(memoryStream);
        }
		
        public static bool IsAlphanumeric(string input, bool mandatory)
        {
            input = input ?? String.Empty;
			
            if (mandatory && String.IsNullOrEmpty(input.Trim()))
            {
                return false;
            }
            else
            {
                Regex regexAlphaNum = new Regex(@"\w*");
//				string[] elementsToReplace = new string[]{};
//				foreach (string s in elementsToReplace){
//					input = input.Replace(s, string.Empty);
//				}
                return regexAlphaNum.IsMatch(input.Trim());
            }
        }
		
        public static DateTime ParseXMLDateTime(string dateTime)
        {
            // \d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(.\d{1,6})
            if (String.IsNullOrEmpty(dateTime))
                return NullDateTime;
            else if (dateTime.Contains("."))
                return DateTime.ParseExact(dateTime, "yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.CultureInfo.InvariantCulture);
            else
                return DateTime.ParseExact(dateTime, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }
		
		
		
        public static DateTime UTCDateTimeToConcessionTimeZone(DateTime DateTimeValue)
        {
            // Lo inicializo con MinValue porque sino no me compilaba, y es muy poco probable que el resultado sea MinValue.
            DateTime Result = DateTime.MinValue;
            if (!DALDB.ExecuteCommandScalarDateTime("SELECT dbo.UTCDateTimeToLocalTimeZone(dbo.Const_ConcessionID_Issuer(), ?)",
                                               ref Result,
                                               new object[]{DateTimeValue})) {
                throw new Exception("There was an error while obtaining concession date time: " + DateTimeValue.ToString());
            }
            return Result;
        } // UTCDateTimeToConcessionTimeZone
				
//		/*! \fn   	T To<T>(object value, T defaultValue)
//		 *  \brief 	Convert value to the specified type &lt;T&gt;
//		 * 
//		 * If value is NULL or DBNull.Value, the defaultValue is returned.
//		 * 
//		 * \param value
//		 * \param defaultValue
//		 * \exception	InvalidCastException conversion is not supported
//		 * \return 		defaultValue if NULL or DBNull.Value; value converted to T otherwise
//		 */
    //		public static T To<T>(object value, T defaultValue)
    //		{
    //			if ( value == null || value == DBNull.Value ) return defaultValue;
    //		    return (T) Convert.ChangeType( value, typeof( T ) );
    //		}
    //
    //
    //		/*! \fn   	object DBNullify (object value)
    //		 *  \brief 	Check if a NULL value is passed and if so, cast it to DBNull.Value.
    //		 *
    //		 * Strings with value="" and bytes / ints with value=0 are handled as NULL values.
    //		 * 
    //		 * \param value
    //		 * \return 		value or DBNull.Value
    //		 */
    //		public static object DBNullify (object value)
    //		{
    //			if ( value == null
    //			    || (value is string && String.Empty == ((string) value).Trim())
    //			    || (value is byte  && 			  0 == ((byte) value))
    //			    || (value is int  && 			  0 == ((int) value)))
    //			{
    //				return DBNull.Value;
    //			}
    //		    return value;
    //		}
    //}
}
