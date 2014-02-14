/*  HelloWorld
C:\tmp>path=%path%;C:\Windows\Microsoft.NET\Framework64\v4.0.30319
コンパイル　csc Hello.cs
実行　　　　Hello.exe
*/

// カレントディレクトリを取得する
//		アプリケーションの実行パスを取得する。どの方法が適切か検討してみた。 - tekkの日記 C#,VB.NET
//		http://d.hatena.ne.jp/tekk/20110222/1298371975
//		System.AppDomain.CurrentDomain.BaseDirectory
//		実行時のファイルパスやコマンドライン引数を取得する - Neareal
//		http://neareal.net/index.php?Programming%2F.NetFramework%2FWPF%2FGetRunningPathAndCommandLineArgs
//		Environment.GetCommandLineArgs()[0]
// ソースを埋め込む
// ログ出力
//		文字コードを指定してテキストファイルに書き込む: .NET Tips: C#, VB.NET
//		http://dobon.net/vb/dotnet/file/writefile.html
// ログ作成→dll化
//		csc.exe を使用したコマンド ラインからのビルド
//		http://msdn.microsoft.com/ja-jp/library/78f4aasd.aspx
//		NonSoft - ログファイルを出力するサンプル(C#.NET)
//		http://homepage2.nifty.com/nonnon/SoftSample/CS.NET/SampleTraceLog.html
//		DLLの作り方、および、呼び出し方（分割コンパイルのやり方） - プログラマとSEのあいだ
//		http://d.hatena.ne.jp/taka_2/20080124/p6
// usage
// 引数取得
// tail -f

namespace Main
{
	using System;
	using System.IO;
	using System.Reflection;

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

			//string log_path = string.Join(@"\", app_dirname, app_filename + ".log");
			//Console.WriteLine(log_path);

			//System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");
			//File.AppendAllText(log_path, "test\r\n", enc);
			
		}
	}
}

