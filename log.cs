/*
 *	how to execute
 *	C:\tmp>path=%path%;C:\Windows\Microsoft.NET\Framework64\v4.0.30319
 *	C:\tmp>csc log.cs
 *	C:\tmp>log.exe
 */

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
//		共通 I/O タスク
//		http://msdn.microsoft.com/ja-jp/library/ms404278(v=vs.110).aspx
//		方法 : ログ ファイルを開いて情報を追加する
//		http://msdn.microsoft.com/ja-jp/library/3zc0w663(v=vs.110).aspx
//	ログローテート

namespace Main
{
	using System;
	using System.IO;

	class MainClass
	{
		static void Main()
		{
			WriteLog("日本語SJIS");
			//WriteLog("てすと");
		}
		
		private static void WriteLog(String msg)
		{
			string app_dirname  = System.AppDomain.CurrentDomain.BaseDirectory;
			string app_basename = System.AppDomain.CurrentDomain.FriendlyName;
			string app_path     = app_dirname + app_basename;
			string app_log      = app_dirname + Path.GetFileNameWithoutExtension(app_basename) + ".log";

			string format = DateTime.Now.ToString() + " " + msg;

			// 書き込み
			using (StreamWriter w = new StreamWriter(
				app_log, true, System.Text.Encoding.GetEncoding("shift_jis")))
			{
				w.WriteLine(format);
			}

			// ローテート
			int maxSize = 1 * 1024 * 1024;
			int maxFile = 5;

			FileInfo fi = new FileInfo(app_log);
			if (fi.Length > maxSize) {

				// 4->5,3->2,2->1
				string src, dst;
				for (int i = maxFile; 0 < i; i--)
				{
					if (i == maxFile) continue;
					src = String.Format("{0:S}.{1:D}", app_log, i);
					dst = String.Format("{0:S}.{1:D}", app_log, i + 1);

					if (! File.Exists(src)) continue;

					FileInfo srcfi = new FileInfo(src);
					srcfi.CopyTo(dst, true);// 上書き許可
				}
				// .log->1
				src = String.Format("{0:S}", app_log);
				dst = String.Format("{0:S}.{1:D}", app_log, 1);
				fi.CopyTo(dst, true);

				// 切り詰める
				using (FileStream fs = new FileStream(
					app_log, FileMode.Truncate))
				{
					;
				}
			}
		}
	}
}

