/*  filepath.cs
 *	how to execute
 *	C:\tmp>path=%path%;C:\Windows\Microsoft.NET\Framework64\v4.0.30319
 *	C:\tmp>csc filepath.cs
 *	C:\tmp>filepath.exe
 */

/*
 * �J�����g�f�B���N�g�����擾����
 *		�A�v���P�[�V�����̎��s�p�X���擾����B�ǂ̕��@���K�؂��������Ă݂��B - tekk�̓��L C#,VB.NET
 *		http://d.hatena.ne.jp/tekk/20110222/1298371975
 *		System.AppDomain.CurrentDomain.BaseDirectory
 *		���s���̃t�@�C���p�X��R�}���h���C���������擾���� - Neareal
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

			Console.WriteLine("app_arg0=" + app_arg0);		// ���ӁFarg0�͎��s���̃R�}���h�v�����v�g����̑��΃p�X
			Console.WriteLine("dirname =" + app_dirname);	// 
			Console.WriteLine("basename=" + app_basename);	// 
			Console.WriteLine("app_path=" + app_path);		// 
			Console.WriteLine("app_log =" + app_log);		// 
		}
	}
}

