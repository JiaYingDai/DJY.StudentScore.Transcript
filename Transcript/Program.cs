using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcript
{
	// 設計一個學生類別，輸入姓名，各科成績，能顯示總分扔平均分數，最高/最低是哪一科，分數是多少
	internal class Program
	{
		static void Main(string[] args)
		{
			var exam = new Dictionary<string, int>
			{
				{ "國文", 80 },
				{ "數學", 90 },
				{ "英文", 90 },
				{ "地理", 60 },
				{ "歷史", 60 },
				{ "公民", 100 }
			};

			Transcript student = new Transcript("Judy", exam);
			student.GetExamResult();
		}
	}

	public class Transcript
	{
		private string _name;
		public string Name
		{
			get => _name;
			set
			{
				_name = string.IsNullOrEmpty(value) ?
					throw new ArgumentOutOfRangeException("姓名不能為空或超過有效範圍") : value;
			}
		}
		private Dictionary<string, int> _grade;
		public Dictionary<string, int> Grade
		{
			get => _grade;
			set
			{
				foreach (var item in value)
				{
					if (string.IsNullOrEmpty(item.Key) || item.Value > 100 || item.Value < 0)
					{
						throw new ArgumentOutOfRangeException("科目不能為空或超過有效範圍");
					}
					else
					{
						_grade = value;
					}
				}
			}
		}

		public Transcript(string name, Dictionary<string, int> grade)
		{
			this.Name = name;
			this.Grade = grade;
		}

		public int GetSum()
		{
			int sum = Grade.Sum(x => x.Value);
			return sum;
		}

		public double GetMean()
		{
			double mean = Math.Round(Grade.Average(x => x.Value), 1, MidpointRounding.AwayFromZero);
			return mean;
		}

		public Dictionary<string, int> GetMax()
		{
			Dictionary<string, int> max = new Dictionary<string, int>(); // 最高分有可能不只一科，因此設Dictionary
			int maxValue = Grade.Max(x => x.Value); // 最低分為幾分
			var maxKey = Grade.Where(x => x.Value == maxValue).ToList(); // 找出最高分的科目

			foreach (var item in maxKey)
			{
				max.Add(item.Key, item.Value); // 將最高分的科目加進Dictionary
			}

			return max;
		}

		public Dictionary<string, int> GetMin()
		{
			Dictionary<string, int> min = new Dictionary<string, int>(); // 最低分有可能不只一科，因此設Dictionary
			int minValue = Grade.Min(x => x.Value); // 最低分為幾分
			var minKey = Grade.Where(x => x.Value == minValue).ToList(); // 找出最低分的科目

			foreach (var item in minKey)
			{
				min.Add(item.Key, item.Value); // 將最低分的科目加進Dictionary
			}

			return min;
		}

		public void GetExamResult()
		{
			string maxResult = "";
			foreach (var subjects in GetMax())
			{
				maxResult += $"{subjects.Value} ({subjects.Key}) ";
			}

			string minResult = "";
			foreach (var subjects in GetMin())
			{
				minResult += $"{subjects.Value} ({subjects.Key}) ";
			}

			string grade = "";
			foreach (var subjects in this.Grade)
			{
				grade += $"{subjects.Key}: {subjects.Value}\r\n";
			}

			string message = string.Format("<{0}的成績單>\r\n" +
@"{1}
總分: {2}
平均: {3}
最高分: {4}
最低分: {5}",
this.Name, grade, GetSum(), GetMean(), maxResult, minResult);

			Console.WriteLine(message);
		}
	}
}
