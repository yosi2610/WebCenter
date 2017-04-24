using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Net;
using System.Web.Services;
using System.Web.Services.Protocols;
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
using WebCenter.Utils;
//using Ktcar.Cs.Dal.Common;


namespace Utils
{	
	public abstract class XmlUtils
	{		
		public static byte[] StringToXML (string s)
		{	
			byte [] result;	
			if (ConfigurationManager.AppSettings["CompressDatasets"] == "1")
			{ 
				// El sistema está configurado para utilizar compresión
				string InFile = null;
			   	string OutFile = null;				
				try
				{
					InFile = Path.GetTempFileName();
			   		OutFile = Path.GetTempFileName();					
					using (StreamWriter streamwriter = new StreamWriter(InFile))
					{
						try 
						{
							streamwriter.Write(s);
						}
						finally
						{
							streamwriter.Close();
						}
					}
                    CompressionUtils.CompressFile(InFile, OutFile);					
					List<byte> list = new List<byte>();
                    list.AddRange(Encoding.Default.GetBytes(CompressionUtils.COMPRESSION_SIGNATURE));					
					using (FileStream filestream = new FileStream (OutFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						try
						{
							byte[] buffer = new byte[filestream.Length];
							filestream.Read(buffer, 0, buffer.Length);
							list.AddRange(buffer);
						}
						finally
						{
							filestream.Close();
						}
					}					
					result = list.ToArray();					
				}
				finally
				{
					try
		   			{
			   			if (!String.IsNullOrEmpty(InFile)) {
							File.Delete(InFile);
						}
		   			} catch {}
		   			try
		   			{
						if (!String.IsNullOrEmpty(OutFile)) {
							File.Delete(OutFile);
						}
		   			} catch {}
				}
			} 
			else 
			{
				result = Encoding.Default.GetBytes(s);
			}
			return result;
		}

		public static byte[] DatasetToXML (DataSet DS)
		{			
		   using (MemoryStream memstream = new MemoryStream())
		   {
		   		string InFile = null;
			   	string OutFile = null;		   	
		   		try
		   		{
			   		if (ConfigurationManager.AppSettings["CompressDatasets"] == "1")
				   	{
			   			InFile = Path.GetTempFileName();
			   			OutFile = Path.GetTempFileName();
			   			DS.WriteXml(InFile, XmlWriteMode.WriteSchema);
                        CompressionUtils.CompressFile(InFile, OutFile);
			   			
			   			using (FileStream filestream = new FileStream (OutFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			   			{
			   				try
			   				{
			   					byte[] buffer = Encoding.Default.GetBytes(CompressionUtils.COMPRESSION_SIGNATURE);
					   			memstream.Write(buffer, 0, buffer.Length);
					   			buffer = new byte[filestream.Length];
					   			filestream.Read(buffer, 0, buffer.Length);
					   			memstream.Write(buffer, 0, buffer.Length);
			   				}
			   				finally
			   				{
			   					filestream.Close();
			   				}
			   			}
				   }
				   else
				   {			   
			   			DS.WriteXml(memstream, XmlWriteMode.WriteSchema);
				   }		   
		   		}
		   		finally
		   		{
		   			memstream.Close();
		   			
		   			try
		   			{
			   			if (!String.IsNullOrEmpty(InFile)) {
							File.Delete(InFile);
						}
		   			} catch {}
		   			try
		   			{
						if (!String.IsNullOrEmpty(OutFile)) {
							File.Delete(OutFile);
						}
		   			} catch {}
		   		}
		   		
		   		return memstream.ToArray();
		   }
		}
		
		public static DataSet XMLToDataset(byte[] XML)
    	{
    		string inFile = null, outFile = null;
    		try
    		{
	    		DataSet ds = new DataSet();
	    		if (Encoding.Default.GetString(XML, 0, CompressionUtils.COMPRESSION_SIGNATURE.Length) == CompressionUtils.COMPRESSION_SIGNATURE)
	    		{
	    			inFile = Path.GetTempFileName();
	    			outFile = Path.GetTempFileName();
	    			
	    			using (FileStream fs = new FileStream(inFile, FileMode.Open, FileAccess.Write))
	    			{
            			fs.Write(
	    					XML, 
	    					CompressionUtils.COMPRESSION_SIGNATURE.Length, 
	    					XML.Length - CompressionUtils.COMPRESSION_SIGNATURE.Length
	    				);
	    			}
	    			
	    			CompressionUtils.DecompressFile(inFile, outFile);	    			
	    			ds.ReadXml(outFile, XmlReadMode.ReadSchema);
	    		}
	    		else
	    		{
	    			using (MemoryStream ms = new MemoryStream(XML))
	    			{
	    				ds.ReadXml(ms, XmlReadMode.ReadSchema);
	    			}
	    		}
	    		return ds;
    		}
    		finally
    		{
    			if (!String.IsNullOrEmpty(inFile) && File.Exists(inFile))
    			{
	    			try {
	    				File.Delete(inFile);
	    			} catch {}
    			}
    			if (!String.IsNullOrEmpty(outFile) && File.Exists(outFile))
    			{
	    			try {
	    				File.Delete(outFile);
	    			} catch {}
    			}
    		}
    	}		
		
		public static string XMLToString(byte[] XML)
    	{
    		string inFile = null, outFile = null;
    		try
    		{
    			string result = string.Empty;
	    		if (Encoding.Default.GetString(XML, 0, CompressionUtils.COMPRESSION_SIGNATURE.Length) == CompressionUtils.COMPRESSION_SIGNATURE)
	    		{
	    			inFile = Path.GetTempFileName();
	    			outFile = Path.GetTempFileName();
	    			
	    			using (FileStream fs = new FileStream(inFile, FileMode.Open, FileAccess.Write))
	    			{
	    				try
	    				{
	            			fs.Write(
		    					XML, 
		    					CompressionUtils.COMPRESSION_SIGNATURE.Length, 
		    					XML.Length - CompressionUtils.COMPRESSION_SIGNATURE.Length
		    				);
	    				}
	    				finally
	    				{
	    					fs.Close();
	    				}
	    			}
	    			
	    			CompressionUtils.DecompressFile(inFile, outFile);	    			
	    			
	    			using (FileStream fs = new FileStream(outFile, FileMode.Open, FileAccess.Read))
	    			{
	    				try
	    				{
		    				StringBuilder sb = new StringBuilder();
		    				const int BUFFER_SIZE = 4096;
		    				byte[] buffer = new byte[BUFFER_SIZE];
		    				int bytesRead = 0;
		    				while(0 < (bytesRead = fs.Read(buffer, 0, BUFFER_SIZE)))
		    				{
		    					sb.Append(Encoding.Default.GetString(buffer, 0, bytesRead));
		    				}
		    				result = sb.ToString();
	    				}
	    				finally
	    				{
	    					fs.Close();
	    				}
	    			}
	    		}
	    		else
	    		{
	    			result = Encoding.Default.GetString(XML);
	    		}
	    		return result;
    		}
    		finally
    		{
    			if (!String.IsNullOrEmpty(inFile) && File.Exists(inFile))
    			{
	    			try {
	    				File.Delete(inFile);
	    			} catch {}
    			}
    			if (!String.IsNullOrEmpty(outFile) && File.Exists(outFile))
    			{
	    			try {
	    				File.Delete(outFile);
	    			} catch {}
    			}
    		}
    	}		
		
    	
		
		public static XmlSchema GetDataSetSchema (XmlTypeMapping mapping, string dataSetName, string dataTableName)
		{
			// create schema
            XmlSchema xsd = new XmlSchema();
            xsd.Id = dataSetName;
            
            // create dataset-element
			XmlSchemaElement xsdDataset = new XmlSchemaElement();
			xsdDataset.Name = dataSetName;
			// anonymous complextype
			XmlSchemaComplexType xsdDatasetType = new XmlSchemaComplexType();
			// anonymous sequence
			XmlSchemaSequence xsdDatasetSequence = new XmlSchemaSequence();
			// add sequence to complextype
			xsdDatasetType.Particle = xsdDatasetSequence;
			// add complextype to dataset-element
			xsdDataset.SchemaType = xsdDatasetType;
						
			// add mapped type
			XmlSchemas schemas = new XmlSchemas();
			schemas.Add(xsd);
            XmlSchemaExporter exporter = new XmlSchemaExporter(schemas);            
            exporter.ExportTypeMapping(mapping);  
            
            // get datatable-element and move it to dataset-sequence
            XmlSchemaObject o = xsd.Items[0];
            xsd.Items.RemoveAt(0);
            xsdDatasetSequence.Items.Add(o);
            // add dataset-element to xsd
            xsd.Items.Add(xsdDataset);
            						
			//schemas.Compile(null, false);		// we only need the string
			return schemas[mapping.Namespace];
        }	
	
		
    	public static DataSet ArrayToDataSet<T>(T[] array)
		{		
			string DataTableName = "Table";		// required for correct parsing of delphi-clientdataset
			
			// create XmlTypeMapping
			XmlAttributeOverrides xOver = new XmlAttributeOverrides();
			XmlAttributes xAtt = new XmlAttributes();
			// rename the DataTable element (needed for coorect parsing of delphi-clientdataset)
			xAtt.XmlType = new XmlTypeAttribute(DataTableName);
			xOver.Add(typeof(T), xAtt);			
			// example code:
			// rename the XXX element
//			xAtt = new XmlAttributes();	
//			xAtt.XmlElements.Add(new XmlElementAttribute("XXX"));
//			xOver.Add(typeof(T), "NewXXX", xAtt);//			
			// ignore the YYY field
//			xAtt = new XmlAttributes();		
//			xAtt.XmlIgnore = true;
//			xOver.Add(typeof(T), "YYY", xAtt);			
			XmlTypeMapping typeMapping = new XmlReflectionImporter(xOver, String.Empty).ImportTypeMapping(typeof(T));
			
			return ArrayToDataSet(array, typeMapping);
		}
		
		public static DataSet ArrayToDataSet<T>(T[] array, XmlTypeMapping typeMapping)
		{
			string DataTableName = "Table";		// required for correct parsing of delphi-clientdataset
			string DataSetName = "NewDataSet";	// required for correct parsing of delphi-clientdataset
					
			return ArrayToDataSet(array, DataSetName, DataTableName, typeMapping);
		}
		    	
    	public static DataSet ArrayToDataSet<T>(T[] array, string DataSetName, string DataTableName, XmlTypeMapping typeMapping)
		{
			DataSet dataset = new DataSet();
			using (MemoryStream stream = new MemoryStream())
			{
				XmlWriterSettings settings 		= new XmlWriterSettings();
				settings.OmitXmlDeclaration 	= true;
				settings.Indent 				= true;
								
				XmlWriter writer = XmlWriter.Create(stream, settings);	
				try	
				{
					XmlSerializer serializer = new XmlSerializer(typeMapping);
				 
					// write dataset start element
					writer.WriteStartElement(DataSetName);					
					if (array != null && array.Length > 0)
					{
						foreach (T element in array)
						{
							serializer.Serialize(writer, element);
						}
					}
					else
					{
						// need to insert a dummy element to 
						// ensure that the scheme is serialized
						T dummy = (T) typeof(T).GetConstructor(new Type[] {}).Invoke(new object[] {});
						serializer.Serialize(writer, dummy);
					}
					// write dataset end element
					writer.WriteEndElement();
				}
				finally
				{
					writer.Close();
				}			
				stream.Seek(0, SeekOrigin.Begin);
								
				dataset.ReadXml(stream, XmlReadMode.InferTypedSchema);
				if (array == null || array.Length == 0)
				{
					dataset.Clear();
				}
				dataset.Tables[0].TableName = DataTableName;
				dataset.AcceptChanges();
			}	
			return dataset;	
		}
				
		
    	public static string ArrayToXmlStringSerializedDataSet<T>(T[] array)
		{		
			string DataTableName = "Table";
			
			// create XmlTypeMapping
			XmlAttributeOverrides xOver = new XmlAttributeOverrides();
			XmlAttributes xAtt = new XmlAttributes();
			// rename the DataTable element (needed for coorect parsing of delphi-clientdataset)
			xAtt.XmlType = new XmlTypeAttribute(DataTableName);
			xOver.Add(typeof(T), xAtt);			
			// example code:
			// rename the XXX element
//			xAtt = new XmlAttributes();	
//			xAtt.XmlElements.Add(new XmlElementAttribute("XXX"));
//			xOver.Add(typeof(T), "NewXXX", xAtt);//			
			// ignore the YYY field
//			xAtt = new XmlAttributes();		
//			xAtt.XmlIgnore = true;
//			xOver.Add(typeof(T), "YYY", xAtt);			
			XmlTypeMapping typeMapping = new XmlReflectionImporter(xOver, String.Empty).ImportTypeMapping(typeof(T));
			
			return ArrayToXmlStringSerializedDataSet(array, typeMapping);
		}
		
		public static string ArrayToXmlStringSerializedDataSet<T>(T[] array, XmlTypeMapping typeMapping)
		{
			string DataSetName = "NewDataSet";	// required for coorect parsing of delphi-clientdataset
			string DataTableName = "Table";		// required for coorect parsing of delphi-clientdataset
			
			XmlSchema xsd = GetDataSetSchema(typeMapping, DataSetName, DataTableName);			
			return ArrayToXmlStringSerializedDataSet(array, DataSetName, typeMapping, xsd);
		}
		
		public static string ArrayToXmlStringSerializedDataSet<T>(T[] array, string DataSetName, string DataTableName, XmlTypeMapping typeMapping)
		{
			XmlSchema xsd = GetDataSetSchema(typeMapping, DataSetName, DataTableName);
			return XmlUtils.ArrayToXmlStringSerializedDataSet(array, DataSetName, typeMapping, xsd);
		}
		
		public static string ArrayToXmlStringSerializedDataSet<T>(T[] array, string DataSetName, XmlTypeMapping typeMapping, XmlSchema xsd)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				XmlWriterSettings settings 		= new XmlWriterSettings();
				settings.OmitXmlDeclaration 	= true;
				settings.Indent 				= true;		
				
				// create writer
				XmlWriter writer = XmlWriter.Create(stream, settings);	
				try
				{
					// write start root element
					writer.WriteStartElement(DataSetName, String.Empty);
					// write schema
					xsd.Write(writer);
					
					// don´t need namespace information on table element
					XmlSerializerNamespaces ns = new XmlSerializerNamespaces();						
					ns.Add(String.Empty, String.Empty);	
					
					// create xmlserializer
					XmlSerializer serializer = new XmlSerializer(typeMapping);				

					// write dataset start element
					writer.WriteStartElement(String.Empty, DataSetName, String.Empty);
					if (array != null && array.Length > 0)
					{
						// serialize each array element as datable
						foreach (T element in array)
						{							
							serializer.Serialize(writer, element, ns);
						}
					}		
					// write dataset end element
					writer.WriteEndElement();
					
					// write root end element
					writer.WriteEndElement();
				}
				finally
				{
					writer.Flush();
					writer.Close();					
				}	
				
				stream.Seek(0, SeekOrigin.Begin);
				StreamReader reader = new StreamReader(stream);
				return reader.ReadToEnd();
			}
		}
	
    	
    	public static byte[] ArrayToXmlSerializedDataSet<T>(T[] array)
		{		
			return XmlUtils.StringToXML(ArrayToXmlStringSerializedDataSet(array));
		}
		
		public static byte[] ArrayToXmlSerializedDataSet<T>(T[] array, XmlTypeMapping typeMapping)
		{
			return XmlUtils.StringToXML(ArrayToXmlStringSerializedDataSet(array, typeMapping));
		}
		
		private static byte[] ArrayToXmlSerializedDataSet<T>(T[] array, string DataSetName, string DataTableName, XmlTypeMapping typeMapping)
		{
			return XmlUtils.StringToXML(ArrayToXmlStringSerializedDataSet(array, DataSetName, DataTableName, typeMapping));
		}
		
		public static byte[] ArrayToXmlSerializedDataSet<T>(T[] array, string DataSetName, XmlTypeMapping typeMapping, XmlSchema xsd)
		{
			return XmlUtils.StringToXML(ArrayToXmlStringSerializedDataSet(array, DataSetName, typeMapping, xsd));
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
		
		public static void ValidateXml(string xmlFile, XmlReaderSettings settings)
		{
			XmlReader reader = null;
			try
			{
				using (FileStream fs = File.OpenRead(xmlFile))
				{					
					reader = XmlReader.Create(fs, settings);		         	
		        	while(reader.Read());
				}
		    }
			finally
			{
				if (reader != null) reader.Close();
			}
		}
		
		public static void ValidateXmlStr(string xml, XmlReaderSettings settings)
		{
			XmlReader reader = null;
			try
			{
				using (StringReader sr = new StringReader(xml))
				{					
					reader = XmlReader.Create(sr, settings);		         	
		        	while(reader.Read());
				}
		    }
			finally
			{
				if (reader != null) reader.Close();
			}
		}
	
	
		#region from CS.Common.Utils class XMLUtils: se usa?	
//		public static byte[] XMLToBytes(XmlDocument Doc)
//		{
//		    return XMLToBytes(Doc, false);
//		}
//		
//		/******************************** Function Header ******************************
//		Function Name: XMLToBytes
//		Author : fmalisia
//		Date Created : 31/08/2006
//		Description : Convert a xml document in a array of bytes.
//		Parameters : Doc: XmlDocument; AddXMLLine: Boolean = False
//		Return Value : TBytes
//		*******************************************************************************/
//		public static byte[] XMLToBytes(XmlDocument Doc, bool AddXMLLine)
//		{
//			byte[] Result;
//			if(AddXMLLine)
//		        Result = Encoding.UTF8.GetBytes(@"<?xml version=""1.0""?>" + (char)13 + (char)10 + Doc.OuterXml);
//		    else
//		        Result = Encoding.UTF8.GetBytes(Doc.OuterXml);
//		    return Result;
//		}
//		
//		/******************************** Function Header ******************************
//		Function Name: BytesToXML
//		Author : fmalisia
//		Date Created : 31/08/2006
//		Description : Converts an array of bytes to XML.
//		Parameters : const Bytes: TBytes
//		Return Value : XmlDocument
//		*******************************************************************************/
//		public static XmlDocument BytesToXML(byte[] Bytes)
//		{
//		    XmlDocument Result = new XmlDocument();
//		    MemoryStream Stream = new MemoryStream(Bytes);
//		    Result.Load(Stream);
//		    return Result;
//		}
//		
//		public static void XMLToFile(XmlDocument Doc, String FileName)
//		{
//		    XMLToFile(Doc, FileName, false);
//		}
//		
//		/******************************** Function Header ******************************
//		Function Name: XMLToFile
//		Author : fmalisia
//		Date Created : 31/08/2006
//		Description : Save a xml document in a file.
//		Parameters : Doc: XmlDocument; FileName: String
//		Return Value : None
//		*******************************************************************************/
//		public static void XMLToFile(XmlDocument Doc, String FileName, bool AddXMLLine)
//		{
//			byte[] Bytes;
//		    FileStream Stream;
//		
//		    Bytes = XMLToBytes(Doc, AddXMLLine);
//		    Stream = new FileStream(FileName, FileMode.Create);
//		    Stream.Write(Bytes, 0, Bytes.Length);
//		    Stream.Close();
//		}
//		
//		/******************************** Function Header ******************************
//		Function Name: FileToXML
//		Author : fmalisia
//		Date Created : 31/08/2006
//		Description : Load a XML file and returns a XML Document.
//		Parameters : FileName: String
//		Return Value : XmlDocument
//		*******************************************************************************/
//		public static XmlDocument FileToXML(String FileName)
//		{
//			XmlDocument Result;
//			byte[] Bytes;
//		    FileStream Stream;
//		    Stream = new FileStream(FileName, FileMode.Open);
//		    try{
//		    	Bytes = new byte[Stream.Length];
//		        Stream.Read(Bytes, 0, Bytes.Length);
//		        Result = BytesToXML(Bytes);
//		    }
//		    finally{
//		    	Stream.Close();
//		    }
//		    return Result;
//		}
//		
//		/******************************** Function Header ******************************
//		Function Name: AppendNode
//		Author : fmalisia
//		Date Created : 31/08/2006
//		Description : Add a node to a XML Document.
//		Parameters : Doc: XmlDocument; Node: XmlNode; NodeName: String
//		Return Value : XmlNode
//		*******************************************************************************/
//		public static XmlNode AppendNode(XmlDocument Doc, XmlNode Node, String NodeName)
//		{
//		    XmlNode Result = Doc.CreateElement(NodeName);
//		    Node.AppendChild(Result);
//		    return Result;
//		}
//		
//		/******************************** Function Header ******************************
//		Function Name: AppendAttribute
//		Author : fmalisia
//		Date Created : 31/08/2006
//		Description : Add an attribute to a node in a XML Document.
//		Parameters : Doc: XmlDocument; Node: XmlNode; AttributeName, Value: String
//		Return Value : None
//		*******************************************************************************/
//		public static void AppendAttribute(XmlDocument Doc, XmlNode Node, String AttributeName, String Value)
//		{
//		    XmlAttribute Attr;
//		    Attr = Doc.CreateAttribute(AttributeName);
//		    Attr.Value = Value;
//		    Node.Attributes.Append(Attr);
//		}
//		
//		private static String MakeUnicode(String s)
//		{
//	        StringBuilder sb = new StringBuilder(6 * s.Length);
//	        for(int i = 0 ; i < s.Length ; i++)
//	        	if(Convert.ToInt32(s[i]) > 127)
//	        		sb.Append("&#" + Convert.ToString(s[i]) + ";");
//	            else sb.Append(s[i]);
//	        return sb.ToString();
//		}
//	    
//		public static String MakeValidXML(String s)
//		{
//			String Result;
//		    // Hacemos los reemplazos elementales de XML
//		    Result = s.Replace("&", "&amp;");
//		    Result = s.Replace("<", "&lt;");
//		    Result = s.Replace(">", "&gt;");
//		    Result = s.Replace("'", "&apos;");
//		    Result = s.Replace(@"""", "&quot;");
//		    // Convertimos los caracteres mayores al 127 a la notaciÃ³n "&#nnnnn;"
//		    for(int i = 0 ; i < Result.Length ; i++){
//		    	if(Convert.ToInt32(Result[i]) > 127){
//		            Result = MakeUnicode(Result);
//		            break;
//		    	}
//		    }
//		    return Result;
//		}		
		#endregion	
	}
}
