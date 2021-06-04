using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHold : MonoBehaviour {

    private float unitsPerSec;
    public KeyCode keyToPress;
    public bool started = true;
    public char noteType;

    // Start is called before the first frame update
    void Start() {
        unitsPerSec = GameManager.instance.unitsPerSec;
    }

    // Update is called once per frame
    void Update() {
        transform.position -= new Vector3(0f, unitsPerSec * Time.deltaTime, 0f);
        if (gameObject.transform.position.y <= 0) {
            if (Input.GetKey(keyToPress)) {
                gameObject.SetActive(false);
                Destroy(gameObject);
                GameManager.instance.HoldHit(transform.position.x);
            } else {
                gameObject.SetActive(false);
                Destroy(gameObject);
                GameManager.instance.NoteMiss(transform.position.x);
            }
        }
    }
}
