/*
 * Created by SharpDevelop.
 * User: Peng
 * Date: 2012-10-6
 * Time: 21:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;

using PonsoleLib;

namespace PonsoleTest
{
	class Program
	{
		public static void Main(string[] args)
		{
			Ponsole.SetTitle("Ponsole Test");
			Ponsole.SetMenu(new string[]{"Exit","About"},
			                new int[]{0,0});
			Ponsole.SetAuthor("Powered by PonsoleLib v" + Ponsole.GetVersion());
			Ponsole.Initialize();
			Ponsole.SetStatusText("Initializing completely.",false);
			for(int i=0;i<100;i++){
				Ponsole.Print(i.ToString(),true,true);
				Thread.Sleep(100);
			}
			Thread.Sleep(1000);
			Ponsole.SetStatusText("Exception happened.",true);
			
			// TODO: Implement Functionality Here
		
			Console.ReadKey(true);
		}
	}
}
