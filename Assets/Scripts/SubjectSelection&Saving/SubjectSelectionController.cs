using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class SubjectSelectionController : MonoBehaviour {
	List <GameObject> subjectButtonObjList;

	public SubjectReaderWriter subjectReaderWriter;

	public InputField SubjectInputField;

	
	public GameObject subjectButtonPrefab;
	public RectTransform SlidingButtonParent;

	public Text subjectNameText;
	public Text subjectScoreText;
	public Text subjectSessionText;

	//subject parameters
	/*string currentSubjectName;
	int currentSubjectScore;
	int currentSubjectSession;
*/

	// Use this for initialization
	void Start () {

		if(ExperimentSettings_CoinTask.currentSubject == null){
			SetSubjectStatText("N/A", "N/A", "N/A");
		}
		else{
			SetSubjectStatText(ExperimentSettings_CoinTask.currentSubject.name, ExperimentSettings_CoinTask.currentSubject.score.ToString(), ExperimentSettings_CoinTask.currentSubject.trials.ToString());
		}

		subjectButtonPrefab.SetActive(false);

		subjectReaderWriter.ReadSubjects(); //also have to make buttons from the subject list!
		Debug.Log("subject list count: " + SubjectReaderWriter.subjectDict.Count);

		GenerateSubjectButtons();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void AddNewSubject() {
		UnityEngine.Debug.Log("enferfomfyureofxirfiuehfiuziue");

#if UNITY_WEBPLAYER
		string newSubjName = "WebSubject";
#else
		//string newSubjName = SubjectInputField.text;
		string newSubjName = "NameSubject";
#endif

		if (newSubjName != ""){ //the subject must have a name!

			newSubjName = SubjectInputField.text.Replace("\n", "");
			newSubjName = newSubjName.Replace("\r", "");
			
			//don't want a duplicate subject
			bool isDuplicateSubject = SubjectReaderWriter.subjectDict.ContainsKey( newSubjName );
			if(!isDuplicateSubject || ExperimentSettings_CoinTask.Instance.isRelease){

				//make and add a new subject
				Subject newSubject = new Subject( newSubjName, 0, 0 ); //should subject be its own class?
																					//or a monobehavior to tie to the button?
																					//or does each subject button just have a public subject variable?

				if(!isDuplicateSubject){
					SubjectReaderWriter.subjectDict.Add( newSubject.name, newSubject );
				}

				if(!ExperimentSettings_CoinTask.Instance.isRelease){

					subjectReaderWriter.WriteNewSubject( newSubject.name );

					//now get rid of input text
					SubjectInputField.text = "";

					//GameObject newSubjectButton = AddSubjectButton(newSubject.name);
					AddSubjectButton(newSubject.name);
				}

				ChooseSubject(newSubject.name);

			}
			else{
				ChooseSubject(newSubjName);
			}
		}
	}

	void GenerateSubjectButtons(){
		if (!ExperimentSettings_CoinTask.Instance.isRelease) {
			subjectButtonObjList = new List<GameObject> ();

			//float distanceBetweenButtons = subjectButtonPrefab.GetComponent<RectTransform>().rect.width;

			//TODO: sort alphabetically or arrange alphabetically
			int buttonCount = 0;
			foreach (KeyValuePair<string, Subject> entry in SubjectReaderWriter.subjectDict) {
				//GameObject newButton = AddSubjectButton (entry.Key);
				AddSubjectButton (entry.Key);
				//newButton.transform.position += Vector3.right*distanceBetweenButtons*buttonCount;

				buttonCount++;
			}
		}
	}

	GameObject AddSubjectButton(string name){

		subjectButtonPrefab.SetActive(true);


		//TODO: change to a diff transform just for init position?
		//TODO: make public?

		GameObject newSubjectButton = Instantiate(subjectButtonPrefab, subjectButtonPrefab.transform.position, Quaternion.identity) as GameObject;
		newSubjectButton.transform.SetParent(SlidingButtonParent,false);
		newSubjectButton.GetComponent<RectTransform>().anchoredPosition = subjectButtonPrefab.GetComponent<RectTransform>().anchoredPosition;//.localPosition = initButtonPosition;
		                                              
		//set name
		newSubjectButton.GetComponent<SubjectButton>().subjectName = name;

		//set button text
		Button button = newSubjectButton.GetComponent<Button> ();
		button.GetComponentInChildren<Text>().text = name;


		//move button next to the last button
		float distanceBetweenButtons = subjectButtonPrefab.GetComponent<RectTransform>().rect.width;
		newSubjectButton.transform.position += Vector3.right*distanceBetweenButtons*subjectButtonObjList.Count;


		/* 
		 * resizes scroll area depending on # of buttons
		 * THE PROBLEM: the actual bar that you click and drag doesn't resize on the fly -- only the scrolling area

		//number of buttons that fit in the viewable scroll area
		int numButtonsInScroll = 4;
		if(subjectButtonObjList.Count > numButtonsInScroll) {
			float newWidth = SlidingButtonParent.rect.width + subjectButtonPrefab.GetComponent<RectTransform>().rect.width;
			SlidingButtonParent.sizeDelta = new Vector2( newWidth , SlidingButtonParent.rect.height); 

		}

		*/


		//add to subject button list
		subjectButtonObjList.Add(newSubjectButton);

		subjectButtonPrefab.SetActive(false);

		return newSubjectButton;
	}

	//required for when you click a subject button in the main menu
	public void ChooseSubject(SubjectButton subjectButton) {
		ChooseSubject (subjectButton.subjectName);
	}

	//for more standard subject selection, by name
	void ChooseSubject(string subjectName) {
		Subject subjectToChoose;
		SubjectReaderWriter.subjectDict.TryGetValue( subjectName, out subjectToChoose);
		if(subjectToChoose != null){
			ExperimentSettings_CoinTask.currentSubject = subjectToChoose;
		}
		
		SetSubjectStatText(ExperimentSettings_CoinTask.currentSubject.name, ExperimentSettings_CoinTask.currentSubject.score.ToString(), ExperimentSettings_CoinTask.currentSubject.trials.ToString());
		
		Debug.Log("chose subject! " + ExperimentSettings_CoinTask.currentSubject.name);
	}

	void SetSubjectStatText(string name, string scoreString, string sessionString){
		subjectNameText.text = name;
		subjectScoreText.text = scoreString;
		subjectSessionText.text = sessionString;
	}


}
