using UnityEngine;
using UnityEngine;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using UnityEngine.UI;
using System.IO;
public class CommandExecution : MonoBehaviour {
	//  public Text trialText;
	private int testInt = 0;
	private string sphinxLogPath;
	private string keyphrase;
	private string appDataPath = "";
	private string resultFormat = "";
	//SINGLETON
	private static CommandExecution _instance;

	public static CommandExecution Instance{
		get{
			return _instance;
		}
	}

	void Awake(){

		if (_instance != null) {
			UnityEngine.Debug.Log ("Instance already exists!");
			Destroy (transform.gameObject);
			return;
		}
		_instance = this;
		appDataPath = Application.dataPath + "/";
		UnityEngine.Debug.Log("app data path is: " + appDataPath);
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {


	}
	public static void ExecuteTobiiEyetracker(string device_sn,string mode,string filepath)
	{
		var thread = new Thread(delegate () { CommandTobii(device_sn,mode,filepath); });
		thread.Start();
		UnityEngine.Debug.Log("Starting thread");
	}

	static void CommandTobii(string device_sn, string mode,string filepath)
	{
		UnityEngine.Debug.Log("executing command");
		var proc = new Process();
		proc.StartInfo.CreateNoWindow = true;
		proc.StartInfo.RedirectStandardOutput = false;
		proc.StartInfo.UseShellExecute = false;
		#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
		proc.StartInfo.FileName = "cmd.exe";
		#else
		proc.StartInfo.FileName=@"/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
//		string filepath=System.IO.Directory.GetCurrentDirectory();
		UnityEngine.Debug.Log (filepath);
		proc.StartInfo.Arguments=filepath+@"/TobiiProEyeTrackerManager.app/Contents/MacOS/TobiiProEyeTrackerManager --device-sn=" + device_sn + " --mode="+mode;
		#endif
		#if UNITY_EDITOR_WIN
		proc.StartInfo.Arguments ="/C " +filepath+ @"/Tobii.Pro.Eye.Tracker.Manager.Windows-AMD64-1.6.0.exe --device-sn=" + device_sn+" --mode="+mode;
		UnityEngine.Debug.Log("datapath is: " +filepath + @"/Tobii.Pro.Eye.Tracker.Manager.Windows-AMD64-1.6.0.exe");
#elif UNITY_STANDALONE_WIN
		proc.StartInfo.Arguments ="/C "+ filepath+@"/Tobii.Pro.Eye.Tracker.Manager.Windows-AMD64-1.6.0.exe --device-sn="+device_sn+" --mode="+mode;
		UnityEngine.Debug.Log("datapath is: " + filepath + @"/Tobii.Pro.Eye.Tracker.Manager.Windows-AMD64-1.6.0.exe");
#endif
        proc.Start();
		//
		proc.WaitForExit();
		proc.Close();
	}
}