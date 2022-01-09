using System;

public class Class1
{
	public Class1()
	{
		private static void MakeHandyMatix(double[][] matrix, double[] freeMembers)
		{
			var result = new double[matrix[0].Length];
			var listRow = new List<int>();
			for (int column = 0; column < matrix[0].Length; column++)
			{
				var allNulles = true;
				for (int row = 0; row < matrix.Length; row++)
				{

					if (!listRow.Contains(row) && matrix[row][column] != 0)
					{
						listRow.Add(row);
						if (row != column)
						{
							SwitchLines(matrix, freeMembers, column, row);
						}

						NormalizeMatrix(matrix, freeMembers, column);
						GetTriangleMatrix(matrix, freeMembers, column);
						allNulles = false;
						break;
					}
				}
				if (allNulles)
					result[column] = 0;
			}
		}

		private static void GetTriangleMatrix(double[][] matrix, double[] freeMembers, int column)
		{
			for (int row = 0; row < matrix.Length; row++)
			{
				if (row != column)
				{
					var multiplexor = -1 * matrix[row][column];
					freeMembers[row] = freeMembers[row] + multiplexor * freeMembers[column];
					for (int internalColumn = column; internalColumn < matrix[0].Length; internalColumn++)
					{
						matrix[row][internalColumn] = matrix[row][internalColumn] + multiplexor * matrix[column][internalColumn];
					}
				}
			}
		}

		private static void NormalizeMatrix(double[][] matrix, double[] freeMembers, int column)
		{
			var devider = matrix[column][column];
			freeMembers[column] = freeMembers[column] / devider;
			for (int el = 0; el < matrix[column].Length; el++)
			{
				matrix[column][el] = matrix[column][el] / devider;
			}
		}

		private static void SwitchLines(double[][] matrix, double[] freeMembers, int column, int row)
		{
			var tempLine = matrix[column];
			matrix[column] = matrix[row];
			matrix[row] = tempLine;
			var tempMember = freeMembers[column];
			freeMembers[column] = freeMembers[row];
			freeMembers[row] = tempMember;
		}
	}
}
