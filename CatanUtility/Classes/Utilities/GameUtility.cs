using System;
namespace CatanUtility.Classes
{
    public static class GameUtility
    {
        public static int BoardIndex(int hex, int position)
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
    }
}
