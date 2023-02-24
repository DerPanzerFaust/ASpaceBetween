using UnityEngine;
using System.Collections;

public class MazeLoader : MonoBehaviour {
	public int mazeRows, mazeColumns; // grootte van het doolhof raster
	public GameObject wall;
	public GameObject floor;
	public GameObject ceiling;
	public float size = 2f;

	private MazeCell[,] mazeCells;

	void Start () {
		InitializeMaze ();

		MazeAlgorithm ma = new HuntAndKillMazeAlgorithm (mazeCells); // Gebruik algoritme
		ma.CreateMaze (); // Maak doolhof met algoritme
	}
	
	void Update () {
	}

	private void InitializeMaze() {

		mazeCells = new MazeCell[mazeRows,mazeColumns];

		// Op positie 0,0,0,0 is het eigenlijk alleen nodig om zuidelijk en oosterlijke muren neer te zetten. Dit wekt wel het probleem dat de west en noord kanten geen dichte muren hebben

		for (int r = 0; r < mazeRows; r++) {
			for (int c = 0; c < mazeColumns; c++) {
				mazeCells [r, c] = new MazeCell ();

			
				mazeCells [r, c] .floor = Instantiate (floor, new Vector3 (r*size, -(size/2f), c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c] .floor.name = "Floor " + r + "," + c;

				mazeCells[r, c].Ceiling = Instantiate(ceiling, new Vector3(r * size, +(size / 2f), c * size), Quaternion.identity) as GameObject;
				mazeCells[r, c].Ceiling.name = "Ceiling " + r + "," + c;


				// In colum 0, plaats westerlijke muur om dichte muur te maken aan de west kant 
				if (c == 0) {
					mazeCells[r,c].westWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) - (size/2f)), Quaternion.identity) as GameObject;
					mazeCells [r, c].westWall.name = "West Wall " + r + "," + c;
				}

				mazeCells [r, c].eastWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) + (size/2f)), Quaternion.identity) as GameObject;
				mazeCells [r, c].eastWall.name = "East Wall " + r + "," + c;

				// In row 0, Plaats noordelijke muur om een dichte muur te maken aan de noord kant
				if (r == 0) {
					mazeCells [r, c].northWall = Instantiate (wall, new Vector3 ((r*size) - (size/2f), 0, c*size), Quaternion.identity) as GameObject;
					mazeCells [r, c].northWall.name = "North Wall " + r + "," + c;
					mazeCells [r, c].northWall.transform.Rotate (Vector3.up * 90f);
				}

				mazeCells[r,c].southWall = Instantiate (wall, new Vector3 ((r*size) + (size/2f), 0, c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c].southWall.name = "South Wall " + r + "," + c;
				mazeCells [r, c].southWall.transform.Rotate (Vector3.up * 90f);
			}
		}
	}
}
