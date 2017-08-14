using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class airplane : MonoBehaviour {

  public GameObject Explosion;

  public Text countText;
  public Text winText;
  private int count;

  void Start() {
    count = 0;
    SetCountText();
    winText.text = "";
  }
  void OnTriggerEnter()
  {
    Vector3 temp = transform.position;
    temp.y += 10f;
    Instantiate(Explosion, temp, Quaternion.identity);
    Destroy(this.gameObject);
    count += 1;
    SetCountText();
  }

  void SetCountText() {
    countText.text = "Score: " + count.ToString();
    if (count >= 15)  {
      winText.text = "You Win!";
    }
  }

}
