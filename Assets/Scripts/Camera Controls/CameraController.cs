using UnityEngine;
using System.Collections;
using UnityEngine.XR;
//this oculus switching is mainly for MAC
//for Oculus in Windows, just use the VR checkbox in player settings.
public class CameraController : MonoBehaviour {

	//Experiment exp { get { return Experiment.Instance; } }
	//ExperimentSettings expSettings { get { return ExperimentSettings.Instance; } }
	
	public GameObject AvatarStandardCameraRig;
	public GameObject UICamera;
	public GameObject ReplayOverHeadCamera;

	public GameObject OculusRig;

	public Transform AvatarOculusParent;
	public Transform InstructionsOculusParent;

	// Use this for initialization
	void Start () {
		if (ExperimentSettings_CoinTask.isReplay) {
			ReplayOverHeadCamera.SetActive (true);
		} else {
			ReplayOverHeadCamera.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetInGame(){

		//Debug.Log("oh hey in game cameras");
		TurnOffAllCameras();

		if(ExperimentSettings_CoinTask.isOculus){
			//OculusRig.transform.position = AvatarOculusParent.transform.position;
			//OculusRig.transform.parent = AvatarOculusParent;
			if(!OculusRig.activeSelf){
				SetOculus(true);
			}
			UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 1.5f;
		}
		else{
			EnableCameras(AvatarStandardCameraRig, true);
		}
		EnableCameras(AvatarStandardCameraRig, true);

	}

	void TurnOffAllCameras(){
		EnableCameras(AvatarStandardCameraRig, false);

		if(!ExperimentSettings_CoinTask.isOculus){
			OculusRig.SetActive(false);
		}
	}


	void EnableCameras(GameObject cameraRig, bool setOn){
		Camera[] cameras = cameraRig.GetComponentsInChildren<Camera>();
		for(int i = 0; i < cameras.Length; i++){
			cameras[i].enabled = setOn;
		}
	}

	void SetOculus(bool isActive){
		/*Camera[] cameras = OculusRig.GetComponentsInChildren<Camera>();
		for(int i = 0; i < cameras.Length; i++){
			cameras[i].orthographic = false;
			//cameras[i].clearFlags = CameraClearFlags.Skybox;
		}*/
//		OculusRig.SetActive (isActive);
	}
}
