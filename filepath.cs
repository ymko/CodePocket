/*  filepath.cs
 *	how to execute
 *	C:\tmp>path=%path%;C:\Windows\Microsoft.NET\Framework64\v4.0.30319
 *	C:\tmp>csc filepath.cs
 *	C:\tmp>filepath.exe
 */

/*
 * カレントディレクトリを取得する
 *		アプリケーションの実行パスを取得する。どの方法が適切か検討してみた。 - tekkの日記 C#,VB.NET
 *		http://d.hatena.ne.jp/tekk/20110222/1298371975
 *		System.AppDomain.CurrentDomain.BaseDirectory
 *		実行時のファイルパスやコマンドライン引数を取得する - Neareal
 *		http://neareal.net/index.php?Programming%2F.NetFramework%2FWPF%2FGetRunningPathAndCommandLineArgs
 *		Environment.GetCommandLineArgs()[0]
 */

namespace Main
{
	using System;
	using System.IO;

	class MainClass
	{
		static void Main()
		{
			string app_arg0     = Environment.GetCommandLineArgs()[0];
			string app_dirname  = System.AppDomain.CurrentDomain.BaseDirectory;
			string app_basename = System.AppDomain.CurrentDomain.FriendlyName;
			string app_path     = app_dirname + app_basename;
			string app_log      = app_dirname + Path.GetFileNameWithoutExtension(app_basename) + ".log";

			Console.WriteLine("app_arg0=" + app_arg0);		// 注意：arg0は実行時のコマンドプロンプトからの相対パス
			Console.WriteLine("dirname =" + app_dirname);	// 
			Console.WriteLine("basename=" + app_basename);	// 
			Console.WriteLine("app_path=" + app_path);		// 
			Console.WriteLine("app_log =" + app_log);		// 
		}
	}
}

