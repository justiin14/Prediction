using System;

namespace Predictiv
{
    internal class Matrix
    {
        public static int[,] ComputePredictionMatrix(int[,] originalMatrix, int predictor)
        {
            int[,] result = new int[originalMatrix.GetLength(0), originalMatrix.GetLength(1)];

            for(int i=0;i<originalMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < originalMatrix.GetLength(1); j++)
                {
                    if (i == 0 && j == 0 || predictor==0)
                    {
                        result[i, j] = 128;
                    }
                    else if (i == 0 && j > 0)
                    {
                        result[i, j] = originalMatrix[i, j - 1];
                    }
                    else if (i > 0 && j == 0)
                    {
                        result[i, j] = originalMatrix[i - 1, j];
                    }
                    else
                    {
                        result[i,j] = Predictor(originalMatrix,i,j, predictor);
                        
                    }
                }
            }

            return result;
        }

        internal static int Predictor(int[,] originalMatrix, int i, int j, int predictor)
        {
            int rez = 0;

            switch (predictor)
            {
                case 1: //A
                    rez = originalMatrix[i, j - 1];
                    break;

                case 2: //B
                    rez = originalMatrix[i - 1, j];
                    break;

                case 3: //C
                    rez = originalMatrix[i - 1, j - 1];
                    break;

                case 4: //A+B-C
                    rez = originalMatrix[i, j - 1] + originalMatrix[i - 1, j] - originalMatrix[i - 1, j - 1];
                    break;

                case 5: //A+(B-C)/2
                    rez = originalMatrix[i, j - 1] + (originalMatrix[i - 1, j] - originalMatrix[i - 1, j - 1]) / 2;
                    break;

                case 6: //B+(A-C)/2
                    rez = originalMatrix[i - 1, j] + (originalMatrix[i, j - 1] - originalMatrix[i - 1, j - 1]) / 2;
                    break;

                case 7: //(A+B)/2
                    rez = (originalMatrix[i, j - 1] + originalMatrix[i - 1, j]) / 2;
                    break;

                case 8: //jpeg ls
                    if (originalMatrix[i-1,j-1]>=Math.Max(originalMatrix[i, j - 1], originalMatrix[i - 1, j]))
                    {
                        rez = Math.Min(originalMatrix[i, j - 1], originalMatrix[i - 1, j]);
                    }
                    else if (originalMatrix[i - 1, j - 1] <= Math.Min(originalMatrix[i, j - 1], originalMatrix[i - 1, j]))
                    {
                        rez = Math.Max(originalMatrix[i, j - 1], originalMatrix[i - 1, j]);
                    }
                    else
                    {
                        rez = originalMatrix[i, j - 1] + originalMatrix[i - 1, j] - originalMatrix[i - 1, j - 1];
                    }
                    break;
            }

            return rez;
        }

        internal static int[,] ComputeErrorMatrix(int[,] originalMatrix, int[,] predictionMatrix)
        {
            int[,] result = new int[originalMatrix.GetLength(0), originalMatrix.GetLength(1)];
            
            for(int i=0;i<originalMatrix.GetLength(0); i++)
            {
                for(int j=0;j<originalMatrix.GetLength(1); j++)
                {
                    result[i, j] = originalMatrix[i, j] - predictionMatrix[i,j];
                }
            }

            return result;
        }

        internal static int[] GetPixelAppearances(int[,] matrix)
        {
            int[] appearances = new int[512];
            for (int i = 0; i < 512; i++)
            {
                appearances[i] = 0;
            }

            for(int i = 0; i < matrix.GetLength(0); i++)
                for(int j=0;j<matrix.GetLength(1); j++)
                {
                    appearances[matrix[i, j] + 255]++;
                }

            return appearances;
        }

        internal static void ComputePredictionAndOriginalMatrixAfterDecoding(int[,] errorMatrix, int[,] predictionMatrix, int[,] originalMatrix, int predictor)
        {
            for(int i = 0; i <errorMatrix.GetLength(0); i++)
            {
                for(int j=0;j<errorMatrix.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        predictionMatrix[i, j] = 128;
                        originalMatrix[i,j] = errorMatrix[i,j] + predictionMatrix[i,j];
                    }
                    else if (i == 0 && j > 0)
                    {
                        predictionMatrix[i,j] = originalMatrix[i,j - 1];
                        originalMatrix[i,j] = errorMatrix[i,j] + predictionMatrix[i,j];
                    }
                    else if (i > 0 && j == 0)
                    {
                        predictionMatrix[i,j] = originalMatrix[i - 1,j];
                        originalMatrix[i,j] = errorMatrix[i,j] + predictionMatrix[i,j];
                    }
                    else
                    {
                        predictionMatrix[i, j] = Predictor(originalMatrix, i, j, predictor);
                        originalMatrix[i, j] = errorMatrix[i, j] + predictionMatrix[i, j];
                    }
                }
            }
        }
    }
}
