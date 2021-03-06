using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

//THIS CLASS IS SO CLOSE TO A DIRECT COPY OF TEXTLOGTRACK.CS. 
//...this bothers me, but alas...
public class TextMeshLogTrack : LogTrack {

	TextMesh myText;
	string currentText = "";
	Color currentColor = Color.black;

	bool firstLog = false; //should make an initial log

	// Use this for initialization
	void Awake () {
		myText = GetComponent<TextMesh> ();
	}
	
	//log on late update so that everything for that frame gets set first
	void LateUpdate () {
		if (myText == null) {
			Debug.Log("Text is null! Did you mean to add a regular TextLogTrack instead?");
		}
		if (!firstLog) {
			firstLog = true;
			LogText ();
			LogColor();
		}
		if(ExperimentSettings_CoinTask.isLogging && ( currentText != myText.text ) ){ //if the text has changed, log it!
			LogText ();
		}
		if(ExperimentSettings_CoinTask.isLogging && ( currentColor != myText.color ) ){ //if the text has changed, log it!
			LogColor ();
		}
	}

	void LogText(){
		currentText = myText.text;

		string textToLog = myText.text;

		if (myText.text == "") {
			textToLog = " "; //log a space -- makes it easier to read it during replay!
		}
		else {
			textToLog = Regex.Replace( textToLog, "\r?\n", "_NEWLINE_"); //will replace line breaks on mac or windows with _NEWLINE_ for easier log file parsing.
		}

		subjectLog.Log (GameClock.SystemTime_Milliseconds, subjectLog.GetFrameCount(), gameObject.name + separator + "TEXT_MESH" + separator + textToLog );
	}

	void LogColor(){
		currentColor = myText.color;

		subjectLog.Log (GameClock.SystemTime_Milliseconds, subjectLog.GetFrameCount(), gameObject.name + separator + "TEXT_MESH_COLOR" + separator + myText.color.r + separator + myText.color.g + separator + myText.color.b + separator + myText.color.a);
	}
}