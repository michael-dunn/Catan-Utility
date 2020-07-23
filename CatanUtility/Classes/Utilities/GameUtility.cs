using System;
using System.Collections.Generic;
using System.Linq;

namespace CatanUtility.Classes
{
    public static class GameUtility
    {
        public static int GetBoardIndex(int hex, int position)
        {
            int topNumber = 0;
            int returnNumber = 0;
            if (1 <= hex && hex <= 3)
            {
                switch (position)
                {
                    case 1:
                        returnNumber = hex;
                        break;
                    case 2:
                        returnNumber = hex + 4;
                        break;
                    case 3:
                        returnNumber = hex + 8;
                        break;
                    case 4:
                        returnNumber = hex + 12;
                        break;
                    case 5:
                        returnNumber = hex + 7;
                        break;
                    case 6:
                        returnNumber = hex + 3;
                        break;
                }
            }
            else if (4 <= hex && hex <= 7)
            {
                topNumber = (hex * 2) - (hex - 4);
                switch (position)
                {
                    case 1:
                        returnNumber = topNumber;
                        break;
                    case 2:
                        returnNumber = topNumber + 5;
                        break;
                    case 3:
                        returnNumber = topNumber + 10;
                        break;
                    case 4:
                        returnNumber = topNumber + 15;
                        break;
                    case 5:
                        returnNumber = topNumber + 9;
                        break;
                    case 6:
                        returnNumber = topNumber + 4;
                        break;
                }
            }
            else if (8 <= hex && hex <= 12)
            {
                topNumber = hex * 2 - (hex - 9);
                switch (position)
                {
                    case 1:
                        returnNumber = topNumber;
                        break;
                    case 2:
                        returnNumber = topNumber + 6;
                        break;
                    case 3:
                        returnNumber = topNumber + 12;
                        break;
                    case 4:
                        returnNumber = topNumber + 17;
                        break;
                    case 5:
                        returnNumber = topNumber + 11;
                        break;
                    case 6:
                        returnNumber = topNumber + 5;
                        break;
                }
            }
            else if (13 <= hex && hex <= 16)
            {
                topNumber = hex * 2 - (hex - 16);
                switch (position)
                {
                    case 1:
                        returnNumber = topNumber;
                        break;
                    case 2:
                        returnNumber = topNumber + 6;
                        break;
                    case 3:
                        returnNumber = topNumber + 11;
                        break;
                    case 4:
                        returnNumber = topNumber + 15;
                        break;
                    case 5:
                        returnNumber = topNumber + 10;
                        break;
                    case 6:
                        returnNumber = topNumber + 5;
                        break;
                }
            }
            else if (17 <= hex && hex <= 19)
            {
                topNumber = hex * 2 - (hex - 23);
                switch (position)
                {
                    case 1:
                        returnNumber = topNumber;
                        break;
                    case 2:
                        returnNumber = topNumber + 5;
                        break;
                    case 3:
                        returnNumber = topNumber + 9;
                        break;
                    case 4:
                        returnNumber = topNumber + 12;
                        break;
                    case 5:
                        returnNumber = topNumber + 8;
                        break;
                    case 6:
                        returnNumber = topNumber + 4;
                        break;
                }
            }
            if (returnNumber == 0)
                returnNumber = -2;
            return returnNumber - 1;
        }

        public static int GetVertexScore(List<int> hexValues)
        {
            int score = 0;
            foreach (var value in hexValues)
            {
                if (value == 2 || value == 12)
                {
                    score += 1;
                }
                else if (value == 3 || value == 11)
                {
                    score += 2;
                }

                else if (value == 4 || value == 10)
                {
                    score += 3;
                }
                else if (value == 5 || value == 9)
                {
                    score += 4;
                }
                else if (value == 6 || value == 8)
                {
                    score += 5;
                }
            }
            return score;
        }

        public static List<int> GetTouchingHexIndices(int vertexIndex)
        {
            vertexIndex++;
            return HexVertices.Select((vertices, index) => new { vertices, index })
                    .Where(hexIndices => hexIndices.vertices.Contains(vertexIndex))
                    .Select(hexIndices => hexIndices.index).ToList();
        }

        public static void SetupGraph(Board board, string file = "../../../Data/Constants")
        {
            board.Edges = FileUtility.SetEdgeGraph(board.Edges, file + "EdgeEdges.txt");
            board.Vertices = FileUtility.SetVertexGraph(board.Vertices, file + "VertexEdges.txt");
            board.Hexes = FileUtility.SetBoardHexIndices(board.Hexes, file + "VertexConstants.txt", file + "EdgeConstants.txt");
        }

        public static bool CanPlaceOnVertex(Game game, int vertexIndex, string playerColor)
        {
            //Ensure vertex doesn't have building
            if (game.Board.Vertices[vertexIndex].Occupied)
            {
                return false;
            }
            //Make sure no buildings are one vertex away
            if (game.Board.Vertices[vertexIndex].LinkedVertices.Any(v => game.Board.Vertices[v].Occupied))
            {
                return false;
            }
            //Make sure same color road is on at least one edge
            if (game.Board.Vertices[vertexIndex].LinkedVertices.Any(e => GetEdgeBetweenVertices(game, e, vertexIndex).Color == playerColor))
            {
                return true;
            }
            return false;
        }

        public static bool CanPlaceRoad(Game game, int edgeIndex, string playerColor)
        {
            //Check index doesn't already have road
            if (game.Board.Edges[edgeIndex].Occupied)
            {
                return false;
            }
            //Check at least one edge has same color
            //Connecting to road
            if (game.Board.Edges[edgeIndex].LinkedEdges.Any(e => game.Board.Edges[e].Color == playerColor))
            {
                return true;
            }
            //Otherwise, check at least one edge vertex has same color
            //Connecting to city or settlement
            if (game.Board.Edges[edgeIndex].LinkedEdges.Any(e => GetVertexBetweenEdges(game, e, edgeIndex).Color == playerColor))
            {
                return true;
            }
            //If we got this far, return false
            return false;
        }

        public static List<List<Edge>> GetLongestRoad(Game game)
        {
            var roads = new List<List<Edge>>();
            var colorRoads = game.Board.Edges.Where(e => e.Color != "");

            foreach (var edge in colorRoads)
            {
                var tempRoads = getLongestRoad(colorRoads, new List<Edge>() { edge }, edge);
                if (tempRoads.FirstOrDefault()?.Count > (roads.FirstOrDefault()?.Count == null ? 0 : roads.FirstOrDefault()?.Count))
                    roads = tempRoads;
                else if (tempRoads.FirstOrDefault()?.Count == (roads.FirstOrDefault()?.Count == null ? 0 : roads.FirstOrDefault()?.Count))
                    roads.AddRange(tempRoads);
            }
            return roads.Select(r => r.OrderBy(e => e.Index).ToList()).Distinct(new ListEdgeComparer()).ToList();
        }

        private static List<List<Edge>> getLongestRoad(IEnumerable<Edge> possibleEdges, IEnumerable<Edge> edges, Edge previousEdge)
        {
            var longestEdges = new List<List<Edge>>() { edges.ToList() };
            var tempEdges = new List<List<Edge>>() { };
            foreach (var edgeIndex in previousEdge.LinkedEdges)
            {
                if (!edges.Any(e => e.Index == edgeIndex))//Is the edge already counted?
                {
                    var nextEdge = possibleEdges.FirstOrDefault(e => e.Index == edgeIndex);//Does the edge have a road on it?
                    if (nextEdge != null)
                    {
                        if (previousEdge.Color == nextEdge.Color)//Does the edge match the color
                        {
                            tempEdges = getLongestRoad(possibleEdges, edges.Append(nextEdge), nextEdge);
                            if ((tempEdges.Count != 0 ? tempEdges.First().Count : 0) > (longestEdges.Count != 0 ? longestEdges.First().Count : 0))
                            {
                                longestEdges = tempEdges;
                            }
                            else if ((tempEdges.Count != 0 ? tempEdges.First().Count : 0) == (longestEdges.Count != 0 ? longestEdges.First().Count : 0))
                            {
                                longestEdges.AddRange(tempEdges);
                            }
                        }
                    }
                }
            }
            return longestEdges;
        }

        public static Vertex GetVertexBetweenEdges(Game game, int edgeIndex1, int edgeIndex2)
        {
            var hex = game.Board.Hexes.
                    FirstOrDefault(h => h.EdgeIndices.Contains(edgeIndex1) && h.EdgeIndices.Contains(edgeIndex2));
            var relativeIndex1 = hex.EdgeIndices.FindIndex(r => r == edgeIndex1);
            var relativeIndex2 = hex.EdgeIndices.FindIndex(r => r == edgeIndex2);
            var smallerIndex = relativeIndex1 > relativeIndex2 ? relativeIndex2 : relativeIndex1;

            if (relativeIndex1 == 0 && relativeIndex2 == 5)
            {
                return game.Board.Vertices[hex.VertexIndices[5]];
            }
            return game.Board.Vertices[hex.VertexIndices[smallerIndex]];
        }
        public static Edge GetEdgeBetweenVertices(Game game, int vertexIndex1, int vertexIndex2)
        {
            var hex = game.Board.Hexes.
                    FirstOrDefault(h => h.VertexIndices.Contains(vertexIndex1) && h.VertexIndices.Contains(vertexIndex2));
            var relativeIndex1 = hex.VertexIndices.FindIndex(v => v == vertexIndex1);
            var relativeIndex2 = hex.VertexIndices.FindIndex(v => v == vertexIndex2);
            var largerIndex = relativeIndex1 < relativeIndex2 ? relativeIndex2 : relativeIndex1;
            if (relativeIndex1 == 0 && relativeIndex2 == 5)
            {
                return game.Board.Edges[hex.VertexIndices[0]];
            }
            return game.Board.Edges[hex.VertexIndices[largerIndex]];
        }

        private static readonly List<List<int>> HexVertices = new List<List<int>>()
        {
            new List<int>() { 1,5,9,13,8,4 },       //1
            new List<int>() { 2,6,10,14,9,5 },      //2
            new List<int>() { 3,7,11,15,10,6 },     //3
            new List<int>() { 8,13,18,23,17,12 },   //4
            new List<int>() { 9,14,19,24,18,13 },   //5
            new List<int>() { 10,15,20,25,19,14 },  //6
            new List<int>() { 11,16,21,26,20,15 },  //7
            new List<int>() { 17,23,29,34,28,22 },  //8
            new List<int>() { 18,24,30,35,29,23 },  //9
            new List<int>() { 19,25,31,36,30,24 },  //10
            new List<int>() { 20,26,32,37,31,25 },  //11
            new List<int>() { 21,27,33,38,32,26 },  //12
            new List<int>() { 29,35,40,44,39,34 },  //13
            new List<int>() { 30,36,41,45,40,35 },  //14
            new List<int>() { 31,37,42,46,41,36 },  //15
            new List<int>() { 32,38,43,47,42,37 },  //16
            new List<int>() { 40,45,49,52,48,44 },  //17
            new List<int>() { 41,46,50,53,49,45 },  //18
            new List<int>() { 42,47,51,54,50,46 },  //19
        };
        private static readonly List<List<int>> HexEdges = new List<List<int>>()
        {
            new List<int>() { 0,1,7,12,11,6 },
            new List<int>() { 2,3,8,14,13,7 },
            new List<int>() { 4,5,9,16,15,8 },
            new List<int>() { 10,11,19,25,24,18 },
            new List<int>() { 12,13,20,27,26,19 },
            new List<int>() { 14,15,21,29,28,20 },
            new List<int>() { 16,17,22,31,30,21 },
            new List<int>() { 23,24,34,40,39,33 },
            new List<int>() { 25,26,35,42,41,34 },
            new List<int>() { 27,28,36,44,43,35 },
            new List<int>() { 29,30,37,46,45,36 },
            new List<int>() { 31,32,38,48,47,37 },
            new List<int>() { 40,41,50,55,54,49 },
            new List<int>() { 42,43,51,57,56,50 },
            new List<int>() { 44,45,52,59,58,51 },
            new List<int>() { 46,47,53,61,60,52 },
            new List<int>() { 55,56,63,67,66,62 },
            new List<int>() { 57,58,64,69,68,63 },
            new List<int>() { 59,60,65,71,70,64 }
        };
        public static readonly List<List<int>> EdgeEdges = new List<List<int>>()
        {
            new List<int>() { 1,6 },
            new List<int>() { 0,7,2 },
            new List<int>() { 1,3,7 },
            new List<int>() { 2,4,8 },
            new List<int>() { 3,5,8 },
            new List<int>() { 4,9 },
            new List<int>() { 0,10,11 },
            new List<int>() { 1,2,12,13 },
            new List<int>() { 3,4,14,15 },
            new List<int>() { 5,16,17 },
            new List<int>() { 6,11,18 },
            new List<int>() { 6,10,12,19 },
            new List<int>() { 7,11,13,19 },
            new List<int>() { 7,12,14,20 },
            new List<int>() { 8,13,15,20 },
            new List<int>() { 8,14,16,21 },
            new List<int>() { 9,15,17,21 },
            new List<int>() { 9,16,22 },
            new List<int>() { 10,23,24 },
            new List<int>() { 11,12,25,26 },
            new List<int>() { 13,14,27,28 },
            new List<int>() { 15,16,29,30 },
            new List<int>() { 17,31,32 },
            new List<int>() { 18,24,33 },
            new List<int>() { 18,23,25,34 },
            new List<int>() { 19,24,26,34 },
            new List<int>() { 19,25,27,35 },
            new List<int>() { 20,26,28,35 },
            new List<int>() { 20,27,29,36 },
            new List<int>() { 21,28,30,36 },
            new List<int>() { 21,29,21,37 },
            new List<int>() { 22,30,32,37 },
            new List<int>() { 22,31,38 },
            new List<int>() { 23,39 },
            new List<int>() { 24,25,40,41 },
            new List<int>() { 26,27,42,43 },
            new List<int>() { 28,29,44,45 },
            new List<int>() { 30,31,46,47 },
            new List<int>() { 32,48 },
            new List<int>() { 33,40,49 },
            new List<int>() { 34,39,41,49 },
            new List<int>() { 34,40,42,50 },
            new List<int>() { 35,41,43,50 },
            new List<int>() { 35,42,44,51 },
            new List<int>() { 36,43,45,51 },
            new List<int>() { 36,44,46,52 },
            new List<int>() { 37,45,47,52 },
            new List<int>() { 37,46,48,53 },
            new List<int>() { 38,47,53 },
            new List<int>() { 39,40,54 },
            new List<int>() { 41,42,55,56 },
            new List<int>() { 43,44,57,58 },
            new List<int>() { 45,46,59,60 },
            new List<int>() { 47,48,61 },
            new List<int>() { 49,55,62 },
            new List<int>() { 50,54,56,62 },
            new List<int>() { 50,55,57,63 },
            new List<int>() { 51,56,58,63 },
            new List<int>() { 51,57,59,64 },
            new List<int>() { 52,58,60,64 },
            new List<int>() { 52,59,61,65 },
            new List<int>() { 53,60,65 },
            new List<int>() { 54,55,66 },
            new List<int>() { 56,57,67,68 },
            new List<int>() { 58,59,69,70 },
            new List<int>() { 60,61,71 },
            new List<int>() { 62,67 },
            new List<int>() { 63,66,68 },
            new List<int>() { 63,67,69 },
            new List<int>() { 64,68,70 },
            new List<int>() { 64,69,71 },
            new List<int>() { 65,70 }
        };
        public static readonly List<List<int>> VertexEdges = new List<List<int>>()
        {
            new List<int>() { 3,4 },
            new List<int>() { 4,5 },
            new List<int>() { 5,6 },
            new List<int>() { 0,7 },
            new List<int>() { 0,1,8 },
            new List<int>() { 1,2,9 },
            new List<int>() { 2,10 },
            new List<int>() { 3,11,12 },
            new List<int>() { 4,12,13 },
            new List<int>() { 5,13,14 },
            new List<int>() { 6,14,15 },
            new List<int>() { 7,16 },
            new List<int>() { 7,8,17 },
            new List<int>() { 8,9,18 },
            new List<int>() { 9,10,19 },
            new List<int>() { 15,20 },
            new List<int>() { 11,21,22 },
            new List<int>() { 12,22,23 },
            new List<int>() { 13,23,24 },
            new List<int>() { 14,24,25 },
            new List<int>() { 15,25,26 },
            new List<int>() { 16,27 },
            new List<int>() { 16,17,28 },
            new List<int>() { 17,18,29 },
            new List<int>() { 18,19,30 },
            new List<int>() { 19,20,31 },
            new List<int>() { 20,32 },
            new List<int>() { 21,33 },
            new List<int>() { 22,33,34 },
            new List<int>() { 23,34,35 },
            new List<int>() { 24,35,36 },
            new List<int>() { 25,36,37 },
            new List<int>() { 26,37 },
            new List<int>() { 27,28,38 },
            new List<int>() { 28,29,39 },
            new List<int>() { 29,30,40 },
            new List<int>() { 30,31,41 },
            new List<int>() { 31,32,42 },
            new List<int>() { 33,43 },
            new List<int>() { 34,43,44 },
            new List<int>() { 35,44,45 },
            new List<int>() { 36,45,46 },
            new List<int>() { 37,46 },
            new List<int>() { 38,39,47 },
            new List<int>() { 39,40,48 },
            new List<int>() { 40,41,49 },
            new List<int>() { 41,42,50 },
            new List<int>() { 43,51 },
            new List<int>() { 44,51,52 },
            new List<int>() { 45,52,53 },
            new List<int>() { 46,53 },
            new List<int>() { 47,48 },
            new List<int>() { 48,49 },
            new List<int>() { 49,50 }
        };
    }
}