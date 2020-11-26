using NUnit.Framework;
using CatanUtility.Classes;
using System.Linq;
using System.Collections.Generic;
using CatanUtility.Classes.Enums;

namespace CatanUtilityTests
{
    public class EdgeTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void EdgeNameWorks()
        {
            var edge1 = new Edge()
            {
                Color = "Red",
                Index = 12,
                LinkedEdges = new List<int>() { 1, 2, 3, 4 },
                Occupied = true
            };

            var edge2 = new Edge();

            Assert.AreEqual("Red road", edge1.ToString());
            Assert.AreEqual("No road", edge2.ToString());
        }

        [Test]
        public void RoadsShouldBeEqual()
        {
            var road1 = new List<Edge>() {
                new Edge() { Index = 11 },
                new Edge() { Index = 6 },
                new Edge() { Index = 0 },
                new Edge() { Index = 1 },
                new Edge() { Index = 7 },
                new Edge() { Index = 12 },
                new Edge() { Index = 19 }
            };
            var road2 = new List<Edge>() {
                new Edge() { Index = 12 },
                new Edge() { Index = 7 },
                new Edge() { Index = 1 },
                new Edge() { Index = 0 },
                new Edge() { Index = 6 },
                new Edge() { Index = 11 },
                new Edge() { Index = 19 }
            };

            var distinctRoads = new List<List<Edge>>() { road1, road2 }.Distinct(new ListEdgeComparer()).ToList();

            Assert.AreEqual(1, distinctRoads.Count);
        }

        [Test]
        public void RoadsShouldNotBeEqual()
        {
            var road1 = new List<Edge>() {
                new Edge() { Index = 35 },
                new Edge() { Index = 27 },
                new Edge() { Index = 28 },
                new Edge() { Index = 36 },
                new Edge() { Index = 45 },
                new Edge() { Index = 46 },
                new Edge() { Index = 37 }
            };
            var road2 = new List<Edge>() {
                new Edge() { Index = 35 },
                new Edge() { Index = 43 },
                new Edge() { Index = 44 },
                new Edge() { Index = 36 },
                new Edge() { Index = 29 },
                new Edge() { Index = 30 },
                new Edge() { Index = 37 }
            };

            var distinctRoads = new List<List<Edge>>() { road1, road2 }.Distinct(new ListEdgeComparer()).ToList();

            Assert.AreEqual(2, distinctRoads.Count);
        }
    }
}