/*
 * Created by QuickSharp.
 * User: Peng
 * Date: 2012-10-5
 * Time: 11:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;
using System.Collections.Generic;

namespace PonsoleLib
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class Ponsole
	{
		static int titleLine = 0;
		static int menuLine = 1;
		static int statusLine = Console.WindowHeight - 2;
		static int authorLine = Console.WindowHeight - 1;
		
		static ConsoleColor titleColor = ConsoleColor.Cyan;
		static ConsoleColor menuColor = ConsoleColor.Blue;
		static ConsoleColor statusColor = ConsoleColor.Cyan;
		static ConsoleColor mainColor = ConsoleColor.Gray;
		
		static string mTitle = "Ponsole Application";
		static string[] mMenu = new string[]{"Exit"};
		static int[] mHighlightPos = new int[]{0};
		static string mAuthor = "Copyright (c) " + DateTime.Now.Year.ToString();
		
		static int currentLine = menuLine + 1;
		
		public static void Initialize(){
			PrintAuthor();
			PrintMenu();
			PrintTitle();
			
			PaintBackgroundColor(titleLine,titleColor);
			PaintBackgroundColor(statusLine, statusColor);
			PaintBackgroundColor(menuLine, menuColor);
			
			PaintMainBackground(mainColor);
			
			Console.SetCursorPosition(0,0);
			Console.BufferHeight = Console.WindowHeight;
			Console.BufferWidth = Console.WindowWidth;
		}
		
		#region Background
		static void PaintMainBackground(ConsoleColor clr){
			for(int i = (menuLine + 1);i < statusLine;i++){
				PaintBackgroundColor(i, mainColor);
			}
		}
		
		static void PaintBackgroundColor(int top,ConsoleColor clr){
			Console.SetCursorPosition(0,top);
			Console.BackgroundColor = clr;
			for(int i=0;i<Console.WindowWidth;i++){
				Console.Write(" ");
			}
		}
		#endregion
		
		#region Title
		public static void SetTitle(string title){
			mTitle = title;
		}
		
		static void PrintTitle(){
			if(mTitle != string.Empty){
				PaintBackgroundColor(titleLine,titleColor);
				Console.ForegroundColor = ConsoleColor.Black;
				Console.SetCursorPosition((Console.WindowWidth - mTitle.Length)/2,titleLine);
				Console.Write(mTitle);
			}
		}
		#endregion
		
		#region Author
		public static void SetAuthor(string about){
			mAuthor = about;
		}
		
		static void PrintAuthor(){
			if(mAuthor != string.Empty){
				PaintBackgroundColor(authorLine, ConsoleColor.DarkBlue);
				Console.ForegroundColor = ConsoleColor.White;
				Console.SetCursorPosition((Console.WindowWidth - mAuthor.Length)/2,authorLine);
				Console.Write(mAuthor);
			}
		}
		#endregion
		
		#region Menu
		public static void SetMenu(string[] menu,int[] highlightPos){
			if(menu.Length != highlightPos.Length){
				return;
			}
			
			mMenu = (string[])menu.Clone();
			mHighlightPos = (int[])highlightPos.Clone();
		}
		
		static void PrintMenu()
		{
			if(mMenu != null && mHighlightPos != null){
				PaintBackgroundColor(menuLine,menuColor);
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.SetCursorPosition(0,menuLine);
				for(int i=0;i<mMenu.Length;i++){
//					Console.SetCursorPosition(Console.CursorLeft + (8-mMenu[i].Length)/2,menuLine);
					Console.Write("[");
					for(int j=0;j<mMenu[i].Length;j++){
						if(j==mHighlightPos[i])
							Console.ForegroundColor = ConsoleColor.Red;
						else
							Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write(mMenu[i][j]);
					}
					Console.Write("]");
				}
			}
		}
		#endregion
		
		#region Status
		public static void SetStatusText(string status,bool exception){
			if(exception){
				Console.BackgroundColor = ConsoleColor.Red;
				Console.ForegroundColor = ConsoleColor.White;
				PaintBackgroundColor(statusLine,ConsoleColor.Red);
			}else{
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = statusColor;
				PaintBackgroundColor(statusLine,statusColor);
			}
			Console.SetCursorPosition(0,statusLine);
			Console.Write(status);
			
			PrintMenu();
			PrintTitle();
		}
		#endregion
		
		#region Screen
		public static void ClearScreen(){
			Console.BackgroundColor = mainColor;
			Console.ForegroundColor = ConsoleColor.Black;
			for(int i=menuLine+1;i<statusLine;i++){
				PaintBackgroundColor(i,mainColor);
			}
		}
		#endregion
		
		#region Print
		public static void Print(string line,bool autoClearScreen){
			Console.BackgroundColor = mainColor;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.SetCursorPosition(0,currentLine);
			Console.Write(line);
			currentLine++;
			if(currentLine > (statusLine-1)){
				if(autoClearScreen){
					ClearScreen();
				}
				currentLine = menuLine + 1;
			}
		}
		
		public static void Print(string line,bool autoClearScreen,bool isPause){
			Console.BackgroundColor = mainColor;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.SetCursorPosition(0,currentLine);
			Console.Write(line);
			currentLine++;
			if(currentLine > (statusLine-1)){
				if(isPause){
					SetStatusText("Press any key to display others...",false);
					Console.ReadKey(true);
				}
				
				if(autoClearScreen){
					ClearScreen();
				}
				currentLine = menuLine + 1;
			}
		}
		#endregion
		
        #region Version
		public static string GetVersion(){
			return "1.0.0";
		}
        #endregion
	}
}
