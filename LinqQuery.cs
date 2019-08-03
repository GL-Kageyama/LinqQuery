using System;
using System.Linq;
using System.Collections.Generic;

// This Code is need a mono.

namespace LinqQuery
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var QueryObj = new QueryClass();

			QueryObj.QueryLength();

			QueryObj.QueryLower();

			QueryObj.QuerySelect();

			QueryObj.QueryDeferred();

			// リストの中身は書き換えられている
			QueryObj.QueryLength();

			QueryObj.QueryImmediate();
		}
	}

	class QueryClass
	{
		List<string> names = new List<string>
		{
			"Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Canberra", "Hong Kong", "Amsterdam", "Ankara", "Napoli", 
			"Nazca", "Nairobi", "Yangon", "Yalta", "Southsampton", "San Diego", "Santos", "Seattle", "Jakarta", "Shanghai", 
		};

		// 5文字以下の都市名を抽出
		public void QueryLength()
		{
			IEnumerable<string> query = names.Where(s => s.Length <= 5);
			foreach (string s in query)
				Console.WriteLine(s);
			Console.WriteLine();
		}

		// 5文字以下の都市名を小文字に変換
		public void QueryLower()
		{
			var query = names.Where(s => s.Length <= 5)
							.Select(s => s.ToLower());
			foreach (string s in query)
				Console.WriteLine(s);
			Console.WriteLine();
		}

		// 都市名を文字数に変換
		public void QuerySelect()
		{
			var query = names.Select(s => s.Length);
			foreach (var n in query)
				Console.WriteLine("{0} ", n);
			Console.WriteLine();
		}

		// 0番目と6番目を名称変更して遅延実行
		public void QueryDeferred()
		{
			var query = names.Where(s => s.Length <= 5);
			foreach (var item in query)
				Console.WriteLine(item);
			Console.WriteLine("- - -");

			names[0] = "Kyoto";
			names[6] = "Koube";
			foreach (var item in query)
				Console.WriteLine(item);
			Console.WriteLine();
		}

		// 即時実行（0番目と6番目を名称変更）
		public void QueryImmediate()
		{
			var query = names.Where(s => s.Length <= 5).ToArray();
			foreach (var item in query)
				Console.WriteLine(item);
			Console.WriteLine("- - -");

			// ToArray関数が呼び出された時にクエリが実行されるため、以下の変換は反映されない
			names[0] = "Gihu";
			names[6] = "Salem";
			foreach (var item in query)
				Console.WriteLine(item);
			Console.WriteLine();
		}
	}
}
























