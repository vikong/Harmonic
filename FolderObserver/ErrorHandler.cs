using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FolderObserver
{
	public static class ErrorHandler
	{
		public static String GetErrorDescribe(this Exception ex)
		{
			String result=ErrorNode(ex, "error").ToString();
			return result;
		}

		public static XElement ErrorNode(Exception ex, String nodeName)
		{
			if (ex==null)
				return null;
			
			String[] separators={"в ","in "};
			String[] stack = ex.StackTrace.Split(separators, StringSplitOptions.None);
			XElement[] stk = new XElement[stack.Length];
			int i=0;
			foreach (String st in stack) 
				if (!String.IsNullOrWhiteSpace(st)) 
					stk[i++]=new XElement("call", st);
			XElement node=new XElement(nodeName, 
				new XAttribute("date",DateTime.Now.ToString()), 
				new XElement("message", ex.Message),
				new XElement("source",ex.Source),
				new XElement("assembly", System.Reflection.Assembly.GetEntryAssembly().FullName),
				new XElement("type", ex.GetType().ToString()),
				new XElement("target",ex.TargetSite),
				new XElement("stack", stk),
				ErrorNode(ex.InnerException, "inner")
			);
			return node;
		}

		public static XElement ErrorNode(IEnumerable<Exception> exceptionList, String nodeName)
		{
			if (exceptionList==null || exceptionList.Count()==0)
				return null;
			XElement[] stk = new XElement[exceptionList.Count()];
			int i=0;
			foreach (Exception ex in exceptionList)
				stk[i++]=ErrorNode(ex,"error");
			XElement node=new XElement(nodeName,stk);
			return node;
		}

		public static void Log(Exception ex, String path)
		{
			Log(ex.GetErrorDescribe(), path);
		}
		public static void Log(IEnumerable<Exception> exceptionList, String path)
		{
			Log(ErrorNode(exceptionList,"errors").ToString(), path);
		}
		public static void Log(String message, String path)
		{
			File.AppendAllText(path, message);
		}
	}
}
