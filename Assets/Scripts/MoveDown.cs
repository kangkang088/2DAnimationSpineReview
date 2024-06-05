using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private Vector3 deltaY = new Vector3(0,-2,0);
    private float minY = -2.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveDownPos() {
        transform.position += deltaY;
        if(transform.position.y == minY) {
            GameObject tipPanel = Instantiate(Resources.Load<GameObject>("TipPanel"),GameObject.Find("Canvas").transform);
        }
    }
}
