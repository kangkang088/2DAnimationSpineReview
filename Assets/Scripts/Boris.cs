using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boris : MonoBehaviour
{
    public Transform ikPoint;
    private Vector3 seedPos;
    private bool recoverPoint = false;

    float mouseY;
    float ikY;
    Vector3 deltaY = new Vector3(0,-1,0);
    // Start is called before the first frame update
    void Start()
    {
        seedPos = ikPoint.position;
        ikY = seedPos.y;
    }
    private void FixedUpdate() {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            recoverPoint = true;
            ikPoint.position = Vector3.Lerp(ikPoint.position,Camera.main.ScreenToWorldPoint(Input.mousePosition),Time.deltaTime);
            mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            if(ikY - mouseY >= 1) {
                this.gameObject.transform.position += deltaY;
                ikY -= 1f;
                seedPos += deltaY;
                GameObject.Find("chuanglian").GetComponent<MoveDown>().MoveDownPos();
            }
        }
        if(Input.GetMouseButtonUp(0))
            recoverPoint = false;
        if(!recoverPoint) {
            ikPoint.position = Vector3.Lerp(ikPoint.position,seedPos,Time.deltaTime);
        }
    }
}
