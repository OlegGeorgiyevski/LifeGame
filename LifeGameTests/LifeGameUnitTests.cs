using NUnit.Framework;
using LifeGame;

namespace LifeGameTests
{
    public class LifeGameUnitTests
    {

        [TestCaseSource("_testDataCollection")]
        public void Process_NextDayGeneration_NumberOfAlivePoints(TestData testData)
        {
            var lifegame = new LifeGameProcessor(testData.row, testData.column, testData.points);

            var expected = lifegame.Process();

            Assert.AreEqual(expected, testData.actual);
        }

        static readonly TestData[] _testDataCollection = new[]
        {
           new TestData {row = 3, column = 3, points = new Point[] {
           new Point { X=0, Y=0 }, new Point { X=1, Y=0 }, new Point { X=2,Y=0},
           new Point { X=0, Y=1 }, new Point { X=1, Y=1 }, new Point { X=2,Y=1},
           new Point { X=0, Y=2 }, new Point { X=1, Y=2 }, new Point { X=2,Y=2}},
               actual = new Point[] { new Point { X=0, Y=0 }, new Point { X=0, Y=2 }, new Point { X=2, Y=0 }, new Point { X=2, Y=2 } } },

           new TestData {row = 1, column = 10, points = new Point[] { new Point {X=0, Y=0 } },
               actual = new Point[] {} },

           new TestData {row= 10, column = 1, points= new Point[] {},
               actual = new Point[]{ } },

           new TestData {row= 5, column = 1, points= new Point[] {new Point { X=1, Y=0 }, new Point { X=2, Y=0 }, new Point { X=3, Y=0 },
                                                                  new Point { X=4, Y=0 }}, 
               actual = new Point[]{ new Point { X=0, Y=0 }, new Point { X=3, Y=0 } } },

           new TestData {row= 5, column = 5, points= new Point[] {new Point { X=1, Y=2 }, new Point { X=1, Y=3 },
                                                                  new Point { X=2, Y=1 }, new Point { X=2, Y=4 },
                                                                  new Point { X=3, Y=1 }, new Point { X=3, Y=3 },
                                                                  new Point { X=4, Y=2 }
           },  actual = new Point[]{new Point { X=1, Y=2 }, new Point { X=1, Y=3 },
                                   new Point { X=2, Y=1 }, new Point { X=2, Y=4 },
                                   new Point { X=3, Y=1 }, new Point { X=3, Y=3 },
                                   new Point { X=4, Y=2 } } }
        };

    } 
}
