using System.Collections;
using UnityEngine;

public class sniper : MonoBehaviour {

  public GameObject bulletPrefab;
  public Transform bulletSpawnPoint;

  public SteamVR_TrackedObject rightController;

	// Update is called once per frame
	void Update () {
    var device = SteamVR_Controller.Input((int) rightController.index);
    if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) ) {
      GameObject bullet = Instantiate(
      bulletPrefab, bulletSpawnPoint.position,
      bulletSpawnPoint.transform.rotation) as GameObject;

      bullet.GetComponent<Rigidbody>().velocity = 1000f * bulletSpawnPoint.transform.forward;
    }
	}
}
