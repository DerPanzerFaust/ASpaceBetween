using UnityEngine;

public class MazeCell {
	public bool visited = false; // Cell is bezocht = ja/nee
	public GameObject northWall, southWall, eastWall, westWall, floor, Ceiling;
}
