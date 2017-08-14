using System.Collections;
using UnityEngine;

public class sniper : MonoBehaviour {

  public GameObject bulletPrefab;
  public Transform bulletSpawnPoint;

  public SteamVR_TrackedObject rightController;

  public Camera scopeCamera;
  public const float minFOV = 10f;
  public const float maxFOV = 90f;

  public AudioClip shot;
  public AudioSource audioSource;

  void Start() {
    audioSource = GetComponent<AudioSource>();
  }

	// Update is called once per frame
	void Update () {
    var device = SteamVR_Controller.Input((int) rightController.index);
    if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) ) {
      GameObject bullet = Instantiate(
      bulletPrefab, bulletSpawnPoint.position,
      bulletSpawnPoint.transform.rotation) as GameObject;

      bullet.GetComponent<Rigidbody>().velocity = 250f * bulletSpawnPoint.transform.forward;
      audioSource.PlayOneShot(shot);
    }

    if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
      float touchY = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y;
      float fov = scopeCamera.fieldOfView - touchY;
      if (fov < minFOV) {
        scopeCamera.fieldOfView = minFOV;
      } else if (fov > maxFOV) {
        scopeCamera.fieldOfView = maxFOV;
      } else {
        scopeCamera.fieldOfView = fov;
      }

    }
	}
}
