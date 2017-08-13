using System.Collections;
using UnityEngine;

public class airplane : MonoBehaviour {

  public GameObject Explosion;

  void OnTriggerEnter()
  {
    Instantiate(Explosion, transform.position, Quaternion.identity);
    Destroy(this.gameObject);
  }

}
