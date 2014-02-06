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
// usage
// 引数取得
// tail -f

namespace Main
{
	using System;
	using System.IO;

	class MainClass
	{
		static void Main()
		{
			string app_path     = Environment.GetCommandLineArgs()[0];
			string app_dirname  = Path.GetDirectoryName(app_path);
			string app_basename = Path.GetFileName(app_path);
			string app_filename = Path.GetFileNameWithoutExtension(app_path); // 拡張子除く

			Console.WriteLine(app_dirname);
			Console.WriteLine(app_basename);
			Console.WriteLine(app_filename);

			string log_path = string.Join(@"\", app_dirname, app_filename + ".log");
			Console.WriteLine(log_path);

			System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");
			File.AppendAllText(log_path, "test\r\n", enc);
		}
	}
}

