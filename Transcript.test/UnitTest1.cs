namespace Transcript.test
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void �`��()
		{
			var exam = new Dictionary<string, int>
			{
				{ "���", 20 },
				{ "�ƾ�", 90 },
				{ "�^��", 100 },
			};
			int expected = 210;

			Transcript student = new Transcript("a", exam);
			var actual = student.GetSum();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ������()
		{
			var exam = new Dictionary<string, int>
			{
				{ "���", 20 },
				{ "�ƾ�", 90 },
				{ "�^��", 100 },
			};
			double expected = 70d;

			Transcript student = new Transcript("b", exam);
			var actual = student.GetMean();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void �̰���()
		{
			var exam = new Dictionary<string, int>
			{
				{ "���", 80 },
				{ "�ƾ�", 90 },
				{ "�^��", 90 },
			};
			var expected = new Dictionary<string, int>
			{
				{ "�ƾ�", 90 },
				{ "�^��", 90 }
			};

			Transcript student = new Transcript("c", exam);
			var actual = student.GetMax();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void �̧C��()
		{
			var exam = new Dictionary<string, int>
			{
				{ "���", 80 },
				{ "�ƾ�", 80 },
				{ "�^��", 90 },
			};
			var expected = new Dictionary<string, int>
			{
				{ "���", 80 },
				{ "�ƾ�", 80 },
			};

			Transcript student = new Transcript("d", exam);
			var actual = student.GetMin();

			Assert.AreEqual(expected, actual);
		}
	}
}