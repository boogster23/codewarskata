using NUnit.Framework;

namespace CodeKataConsole
{
    public class KataBattleship
    {
        public static bool ValidateBattlefield(int[,] field)
        {
            var ships = new ShipContainer();
            var shipContainer = new List<int>();

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (field[j, i] != 0)
                    {
                        shipContainer.Add(i + (j * 10));
                        continue;
                    }
                }
            }

            var shipSizeCounter = 1;
            var shipContainerCounted = new List<int>();

            for (int i = 0; i < shipContainer.Count; i++)
            {
                // check for adjacents
                if (shipContainer.Contains(shipContainer[i] + 9) ||
                    shipContainer.Contains(shipContainer[i] + 11))
                    return false;

                if (shipContainerCounted.Contains(shipContainer[i])) continue;

                shipContainerCounted.Add(shipContainer[i]);

                if ((i + 1 < shipContainer.Count) && shipContainer[i + 1] - shipContainer[i] == 1) // next to each other
                {
                    shipSizeCounter++;
                    continue;
                }

                if (shipSizeCounter == 1) // vertical check
                {
                    var x = shipContainer[i];
                    while (x < 100)
                    {
                        x += 10;

                        if (shipContainer.Contains(x))
                        {
                            shipContainerCounted.Add(x);
                            shipSizeCounter++;
                            continue;
                        }

                        break;
                    }
                }

                if (shipSizeCounter > 0)
                {
                    if (shipSizeCounter == 1)
                        ships.Submarine++;
                    else if (shipSizeCounter == 2)
                        ships.Destroyer++;
                    else if (shipSizeCounter == 3)
                        ships.Cruiser++;
                    else if (shipSizeCounter == 4)
                        ships.Battleship++;
                    else
                        return false;

                    shipSizeCounter = 1;
                }
            }

            // Validate Ships
            return ships.Submarine == 4 && ships.Destroyer == 3 && ships.Cruiser == 2 && ships.Battleship == 1;
        }
    }

    public class ShipContainer
    {
        public int Submarine { get; set; } = 0;
        public int Destroyer { get; set; } = 0;
        public int Cruiser { get; set; } = 0;
        public int Battleship { get; set; } = 0;
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void HorizontalTestCaseShouldReturnTrue()
        {
            int[,] field = new int[10, 10]
                {
                    {1, 0, 1, 0, 1, 0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 0, 1, 1, 0, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 1, 0, 1, 1, 1, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 1, 1, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
                };

            Assert.That(KataBattleship.ValidateBattlefield(field), Is.True);
        }

        [Test]
        public void HorizontalTestCaseShouldReturnFalse()
        {
            int[,] field = new int[10, 10]
                {
                    {1, 0, 1, 0, 1, 0, 0, 1, 0, 1}, // extra submarine here
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 0, 1, 1, 0, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 1, 0, 1, 1, 1, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 1, 1, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
                };

            Assert.That(KataBattleship.ValidateBattlefield(field), Is.False);
        }

        [Test]
        public void VerticalTestCaseShouldReturnTrue()
        {
            int[,] field = new int[10, 10]
                {
                    {1, 0, 1, 0, 1, 0, 0, 1, 0, 1},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                    {1, 0, 0, 1, 0, 1, 0, 0, 0, 1},
                    {1, 0, 0, 1, 0, 1, 0, 0, 0, 1},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
                };

            Assert.That(KataBattleship.ValidateBattlefield(field), Is.False);
        }

        [Test]
        public void VerticalTestCaseShouldReturnFalse()
        {
            int[,] field = new int[10, 10]
                {
                    {1, 0, 1, 0, 1, 0, 0, 1, 0, 1},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                    {1, 0, 0, 1, 1, 0, 0, 0, 0, 1},
                    {1, 0, 0, 1, 1, 0, 0, 0, 0, 1},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
                };

            Assert.That(KataBattleship.ValidateBattlefield(field), Is.False);
        }

        [Test]
        public void TestCase()
        {
            int[,] field = new int[10, 10]
                      {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                      {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                      {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Assert.That(KataBattleship.ValidateBattlefield(field), Is.True);
        }

        [Test]
        public void ShipsInContactFirstCase()
        {
            int[,] field = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                {1, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                {1, 0, 0, 0, 1, 1, 1, 0, 1, 0},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 1, 0, 0, 0, 0, 0, 0, 1, 0},
                {0, 1, 0, 0, 1, 1, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };
            Assert.That(KataBattleship.ValidateBattlefield(field), Is.False);
        }
    }
}
