using System;
using System.Collections.Generic;
using System.Linq;

namespace CatanUtility.Classes
{
    public static class GameUtility
    {
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

        public static int GetBoardIndex(int hex, int position)
        {
            int topNumber = 0;
            int returnNumber = 0;
            if (1<= hex && hex <= 3)
            {
                switch (position)
                {
                    case 1:
                        returnNumber = hex;
                        break;
                    case 2:
                        returnNumber = hex+4;
                        break;
                    case 3:
                        returnNumber = hex+8;
                        break;
                    case 4:
                        returnNumber = hex+12;
                        break;
                    case 5:
                        returnNumber = hex+7;
                        break;
                    case 6:
                        returnNumber = hex+3;
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

        public static List<int> GetTouchingHexIndices(int vertexIndex)
        {
            vertexIndex++;
            return HexVertices.Select((vertices, index) => new { vertices, index })
                    .Where(hexIndices => hexIndices.vertices.Contains(vertexIndex))
                    .Select(hexIndices => hexIndices.index).ToList();
        }
    }
}
