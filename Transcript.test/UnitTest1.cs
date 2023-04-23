namespace Transcript.test
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void 總分()
		{
			var exam = new Dictionary<string, int>
			{
				{ "國文", 20 },
				{ "數學", 90 },
				{ "英文", 100 },
			};
			int expected = 210;

			Transcript student = new Transcript("a", exam);
			var actual = student.GetSum();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void 平均分()
		{
			var exam = new Dictionary<string, int>
			{
				{ "國文", 20 },
				{ "數學", 90 },
				{ "英文", 100 },
			};
			double expected = 70d;

			Transcript student = new Transcript("b", exam);
			var actual = student.GetMean();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void 最高分()
		{
			var exam = new Dictionary<string, int>
			{
				{ "國文", 80 },
				{ "數學", 90 },
				{ "英文", 90 },
			};
			var expected = new Dictionary<string, int>
			{
				{ "數學", 90 },
				{ "英文", 90 }
			};

			Transcript student = new Transcript("c", exam);
			var actual = student.GetMax();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void 最低分()
		{
			var exam = new Dictionary<string, int>
			{
				{ "國文", 80 },
				{ "數學", 80 },
				{ "英文", 90 },
			};
			var expected = new Dictionary<string, int>
			{
				{ "國文", 80 },
				{ "數學", 80 },
			};

			Transcript student = new Transcript("d", exam);
			var actual = student.GetMin();

			Assert.AreEqual(expected, actual);
		}
	}
}