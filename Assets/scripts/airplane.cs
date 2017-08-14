using System.Collections;
using UnityEngine;

public class airplane : MonoBehaviour {

  public GameObject Explosion;

  void OnTriggerEnter()
  {
    Vector3 temp = transform.position;
    temp.y += 10f;
    Instantiate(Explosion, temp, Quaternion.identity);
    Destroy(this.gameObject);
  }

}
