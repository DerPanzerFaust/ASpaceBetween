using UnityEngine;
using System.Collections;

public class HuntAndKillMazeAlgorithm : MazeAlgorithm {

	private int currentRow = 0; // Op start rij index = 0
	private int currentColumn = 0; // Op start column index = 0

	private bool courseComplete = false; // Als er na Hunt fase geen open Cells meer zijn, courseComplete = True.

	public HuntAndKillMazeAlgorithm(MazeCell[,] mazeCells) : base(mazeCells) {
	}

	public override void CreateMaze () {
		HuntAndKill ();
	}

	private void HuntAndKill() {
		mazeCells [currentRow, currentColumn].visited = true; // De Cell waar het programma nu is of al geweest is, dus currentRow en currentColumn. Staan dan op visited en kunnen niet meer bezocht worden.

		while (! courseComplete) {
			Kill(); // Lopen tot vastlopen. "DrunkenWalk"
			Hunt(); 
		}
	}

	// Als Kill niet meer kan dan wordt Hunt fase geinstantieerd
	private void Kill() {
		while (RouteStillAvailable (currentRow, currentColumn)) { // RouteStillAvailable wordt uitgevoerd. Wanneer Route beschikbaar is in elke richting (Noord, Oost, Zuid, West) dan wordt er een random.range nummer gegeven tussen 1 en 4
			int direction = Random.Range (1, 5);

			// 1 = Noord
			if (direction == 1 && CellIsAvailable (currentRow - 1, currentColumn)) {
				DestroyWallIfItExists (mazeCells [currentRow, currentColumn].northWall);
				DestroyWallIfItExists (mazeCells [currentRow - 1, currentColumn].southWall);
				currentRow--;
			} 
			// 2 = Zuid
			else if (direction == 2 && CellIsAvailable (currentRow + 1, currentColumn)) {
				DestroyWallIfItExists (mazeCells [currentRow, currentColumn].southWall);
				DestroyWallIfItExists (mazeCells [currentRow + 1, currentColumn].northWall);
				currentRow++;
			} 
			// 3 = Oost
			else if (direction == 3 && CellIsAvailable (currentRow, currentColumn + 1)) {
				DestroyWallIfItExists (mazeCells [currentRow, currentColumn].eastWall);
				DestroyWallIfItExists (mazeCells [currentRow, currentColumn + 1].westWall);
				currentColumn++;
			} 
			// 4 = West
			else if (direction == 4 && CellIsAvailable (currentRow, currentColumn - 1)) {
				DestroyWallIfItExists (mazeCells [currentRow, currentColumn].westWall);
				DestroyWallIfItExists (mazeCells [currentRow, currentColumn - 1].eastWall);
				currentColumn--;
			}

			mazeCells [currentRow, currentColumn].visited = true;
		}
	}


	private void Hunt() {
		courseComplete = true; // Als Hunt fase geen naast-liggend beschikbare Cells kan vinden, courseComplete = True

		for (int r = 0; r < mazeRows; r++) {
			for (int c = 0; c < mazeColumns; c++) {
				if (!mazeCells [r, c].visited && CellHasAnAdjacentVisitedCell(r,c)) { // Zijn er beschikbaar naast-liggende Cells
					courseComplete = false; // Zo ja? Dan is courseComplete nog niet klaar en begint Kill fase opnieuw
					currentRow = r;
					currentColumn = c;
					DestroyAdjacentWall (currentRow, currentColumn);
					mazeCells [currentRow, currentColumn].visited = true; 
					return; // Functie eindigd
				}
			}
		}
	}

	// Binnen de range (1 Cell) kijkt om zich heen in elke richting (Noord, Oost, Zuid, West) om te checken voor onbezochte Cells
	private bool RouteStillAvailable(int row, int column) {
		int availableRoutes = 0;

		if (row > 0 && !mazeCells[row-1,column].visited) {
			availableRoutes++;
		}

		if (row < mazeRows - 1 && !mazeCells [row + 1, column].visited) {
			availableRoutes++;
		}

		if (column > 0 && !mazeCells[row,column-1].visited) {
			availableRoutes++;
		}

		if (column < mazeColumns-1 && !mazeCells[row,column+1].visited) {
			availableRoutes++;
		}

		return availableRoutes > 0; 
	}

	// Is de Cell kloppend. Bij de meest noordelijke Cells kan je niet meer noord gaan. Hetzelfde geldt voor de meest westerlijke, oosterlijke en zuiderlijke uren
	private bool CellIsAvailable(int row, int column) {
		if (row >= 0 && row < mazeRows && column >= 0 && column < mazeColumns && !mazeCells [row, column].visited) {
			return true;
		} else {
			return false;
		}
	}

	private void DestroyWallIfItExists(GameObject wall) {
		if (wall != null) {
			GameObject.Destroy (wall);
		}
	}

	private bool CellHasAnAdjacentVisitedCell(int row, int column) {
		int visitedCells = 0;

		if (row > 0 && mazeCells [row - 1, column].visited) {
			visitedCells++;
		}
		if (row < (mazeRows-2) && mazeCells [row + 1, column].visited) {
			visitedCells++;
		}
		if (column > 0 && mazeCells [row, column - 1].visited) {
			visitedCells++;
		}
		if (column < (mazeColumns-2) && mazeCells [row, column + 1].visited) {
			visitedCells++;
		}
		return visitedCells > 0;
	}

	private void DestroyAdjacentWall(int row, int column) {
		bool wallDestroyed = false;

		while (!wallDestroyed) {
			int direction = Random.Range (1, 5);
			

			if (direction == 1 && row > 0 && mazeCells [row - 1, column].visited) {
				DestroyWallIfItExists (mazeCells [row, column].northWall);
				DestroyWallIfItExists (mazeCells [row - 1, column].southWall);
				wallDestroyed = true;
			} else if (direction == 2 && row < (mazeRows-2) && mazeCells [row + 1, column].visited) {
				DestroyWallIfItExists (mazeCells [row, column].southWall);
				DestroyWallIfItExists (mazeCells [row + 1, column].northWall);
				wallDestroyed = true;
			} else if (direction == 3 && column > 0 && mazeCells [row, column-1].visited) {
				DestroyWallIfItExists (mazeCells [row, column].westWall);
				DestroyWallIfItExists (mazeCells [row, column-1].eastWall);
				wallDestroyed = true;
			} else if (direction == 4 && column < (mazeColumns-2) && mazeCells [row, column+1].visited) {
				DestroyWallIfItExists (mazeCells [row, column].eastWall);
				DestroyWallIfItExists (mazeCells [row, column+1].westWall);
				wallDestroyed = true;
			}
		}

	}

}
