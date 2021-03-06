using UnityEngine;
using System.Collections;

public class TileSelector : MonoBehaviour {

	//public ArcGenerator myArc;
	/*EnvironmentGrid grid { get { return Experiment_CoinTask.Instance.environmentController.myGrid; } }
	int selectedRow = 0;
	int selectedCol = 0;
	[HideInInspector] public Tile selectedTile;

	int numRows { get { return Experiment_CoinTask.Instance.environmentController.myGrid.Rows; } }
	int numCols { get { return Experiment_CoinTask.Instance.environmentController.myGrid.Columns; } }

	bool shouldSelect = false;

	//when a direction is held down, a certain amount of time must pass before automatically selecting the next tile
	float inputTimePassed = 0;
	float autoNextTileTime = 0.3f;

	//for keyboard only, must make sure that there is no jittering of keypresses, causing tile selection to jump 2-3 tiles
	float timeBetweenKeyDown = 0.0f;
	float minTimeBetweenKeyPresses = 0.1f;


	//used for precise joystick control
	public enum DirectionType{
		colUp,
		colDown,
		rowUp,
		rowDown,
		none
	}
	
	DirectionType lastSelectionDirection = DirectionType.none;


	// Use this for initialization
	void Start () {
		SelectDefault ();
		Disable (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldSelect) {
			if (GetChangedRowColInput ()) {
				SelectTile ();
			}
		}
	}

	

	bool CheckWithinBounds(float value, float min, float max){
		if (value >= min && value <= max) {
			return true;
		}

		return false;
	}

	bool GetChangedRowColInput(){

		if (lastSelectionDirection != DirectionType.none) {
			inputTimePassed += Time.deltaTime;

			if(inputTimePassed > autoNextTileTime){
				inputTimePassed = 0;
				lastSelectionDirection = DirectionType.none;
			}
		}

		int origRow = selectedRow;
		int origCol = selectedCol;
		
		float horizontalInput = Input.GetAxis (Config_CoinTask.HorizontalAxisName);
		float verticalInput = Input.GetAxis (Config_CoinTask.VerticalAxisName);


		if (ExperimentSettings_CoinTask.isJoystickInput) { */
			//if we want it on the diagonal
			/*bool horizInMaxBounds = CheckWithinBounds(horizontalInput, 0.0f, 1.0f);
			bool vertInMaxBounds = CheckWithinBounds(verticalInput, 0.0f, 1.0f);
			bool horizInMinBounds = CheckWithinBounds(horizontalInput, -1.0f, 0.0f);
			bool vertInMinBounds = CheckWithinBounds(verticalInput, -1.0f, 0.0f);*/

			/*bool horizInMaxBounds = CheckWithinBounds (horizontalInput, 0.3f, 1.0f);
			bool vertInMaxBounds = CheckWithinBounds (verticalInput, 0.3f, 1.0f);
			bool horizInMinBounds = CheckWithinBounds (horizontalInput, -1.0f, -0.3f);
			bool vertInMinBounds = CheckWithinBounds (verticalInput, -1.0f, -0.3f);

			Debug.Log("horizontal: " + horizontalInput + " vertical: " + verticalInput);

			float absHorizInput = Mathf.Abs (horizontalInput);
			float absVertInput = Mathf.Abs (verticalInput);

			if (absHorizInput > absVertInput) {
				if (horizInMaxBounds && lastSelectionDirection != DirectionType.rowDown) {
					if (selectedRow > 0) {
						selectedRow -= 1;
						lastSelectionDirection = DirectionType.rowDown;
					}
				} else if (horizInMinBounds && lastSelectionDirection != DirectionType.rowUp) {
					if (selectedRow < numRows - 1) {
						selectedRow += 1;
						lastSelectionDirection = DirectionType.rowUp;
					}
				}
			} else {
				if (vertInMaxBounds && lastSelectionDirection != DirectionType.colUp) {
					if (selectedCol < numCols - 1) {
						selectedCol += 1;
						lastSelectionDirection = DirectionType.colUp;
					}
				} else if (vertInMinBounds && lastSelectionDirection != DirectionType.colDown) {
					if (selectedCol > 0) {
						selectedCol -= 1;
						lastSelectionDirection = DirectionType.colDown;
					}
				}
			}

			if (!horizInMinBounds && !horizInMaxBounds && !vertInMinBounds && !vertInMaxBounds) {
				lastSelectionDirection = DirectionType.none;
			}
		}*/




			//both in max bounds
			/*if (horizInMaxBounds && vertInMaxBounds && lastSelectionDirection != DirectionType.colUp) {
				if (selectedCol < numCols - 1) {
					selectedCol += 1;
					lastSelectionDirection = DirectionType.colUp;
				}
			} 
			//both in min bounds
			else if (horizInMinBounds && vertInMinBounds && lastSelectionDirection != DirectionType.colDown) {
				if (selectedCol > 0) {
					selectedCol -= 1;
					lastSelectionDirection = DirectionType.colDown;
				}
			}
			//horiz in max bounds, vert in min bounds
			else if (horizInMaxBounds && vertInMinBounds && lastSelectionDirection != DirectionType.rowDown) {
				if (selectedRow > 0) {
					selectedRow -= 1;
					lastSelectionDirection = DirectionType.rowDown;
				}
			} 
			//horiz in min bounds, vert in max bounds
			else if (horizInMinBounds && vertInMaxBounds && lastSelectionDirection != DirectionType.rowUp) {
				if (selectedRow < numRows - 1) {
					selectedRow += 1;
					lastSelectionDirection = DirectionType.rowUp;
				}
			} 
			else if(!horizInMinBounds && !horizInMaxBounds && !vertInMinBounds && !vertInMaxBounds) {
				lastSelectionDirection = DirectionType.none;
			}

		}*/

		//keyboard
		/*else {
			if(timeBetweenKeyDown >= minTimeBetweenKeyPresses){
				if (Input.GetKey(KeyCode.RightArrow)) {
					if (selectedRow > 0 && lastSelectionDirection != DirectionType.rowDown) {
						timeBetweenKeyDown = 0;
						selectedRow -= 1;
						lastSelectionDirection = DirectionType.rowDown;
					}
				}
				else if (Input.GetKey(KeyCode.LeftArrow)) {
					if (selectedRow < numRows - 1 && lastSelectionDirection != DirectionType.rowUp) {
						timeBetweenKeyDown = 0;
						selectedRow += 1;
						lastSelectionDirection = DirectionType.rowUp;
					}
				} 
				else if (Input.GetKey(KeyCode.DownArrow)) {
					if (selectedCol > 0 && lastSelectionDirection != DirectionType.colDown) {
						timeBetweenKeyDown = 0;
						selectedCol -= 1;
						lastSelectionDirection = DirectionType.colDown;
					}
				} 
				else if (Input.GetKey(KeyCode.UpArrow)) {
					if (selectedCol < numCols - 1 && lastSelectionDirection != DirectionType.colUp) {
						timeBetweenKeyDown = 0;
						selectedCol += 1;
						lastSelectionDirection = DirectionType.colUp;
					}
				}
				else{
					//redundant?
					lastSelectionDirection = DirectionType.none;
				}
			}
			else{
				lastSelectionDirection = DirectionType.none;
				timeBetweenKeyDown += Time.deltaTime;
			}
		}

		if (selectedRow != origRow || selectedCol != origCol) {
			return true;
		}
		
		return false;
	}

	void SelectDefault(){
		selectedRow = 0;
		selectedCol = 0;
		if(numRows > 0 && numCols > 0){
			SelectTile();
		}
	}

	//enable or disable selection
	public void Enable(){
		shouldSelect = true;
		//myArc.gameObject.SetActive(true);

		SelectDefault ();
	}

	public void Disable(bool shouldDeselect){
		//myArc.gameObject.SetActive(false);
		shouldSelect = false;
		if(selectedTile != null && shouldDeselect){
			selectedTile.myHighlighter.UnHighlight();
		}
	}

	void SelectTile(){

		if(selectedTile != null){
			selectedTile.myHighlighter.HighlightLow();
		}
		selectedTile = grid.GetGridTile( selectedRow, selectedCol );
		selectedTile.myHighlighter.HighlightHigh();

		//myArc.GenerateArc(selectedTile.transform.position);

		//Log the tile selection
		grid.MyGridLogTrack.LogGridTile(selectedTile, GridLogTrack.LoggedTileType.currentSelectedTile);

	}*/

}
