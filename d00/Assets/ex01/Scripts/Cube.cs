using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Debug.Log, Random.Range, GameObject.Instantiate, GameObject.Destroy, Input.GetKeyDown, Transform.Translate
public class Cube : MonoBehaviour
{
    public float speed;
    public float position;
    public float lineUp = 3.4f;
    public float lineDown = -3.4f;
    private float precision = 0;

    void Start()
    {
        speed = Random.Range(9.0f, 45.0f);
    }

    void Update()
    {
        transform.Translate(new Vector3(0.0f, -(0.1f * Time.deltaTime * speed), 0.0f));
        position = (transform.position.y + lineUp) / (lineUp - lineDown);
        // if cube depasse tel point > destroy
        if (position < -1) {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.name == "keyA(Clone)") {
            destroyKey();
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.name == "keyS(Clone)") {
            destroyKey();
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.name == "keyD(Clone)") {
            destroyKey();
        }
    }

    void destroyKey()
    {
        if (position >= 0) {
            precision = 100 - (position * 100);
        } else {
            precision = 100 + (position * 100);
        }

        // calcul precision
        Destroy(gameObject);
        if (precision <= 100)
            Debug.Log("Precision: " + precision);
    }
}
