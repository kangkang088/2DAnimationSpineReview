using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform ikPoint;
    private Vector3 seedPos;
    private bool recoverPoint = false;
    private Quaternion rootRotate;
    public Transform root;
    // Start is called before the first frame update
    void Start()
    {
        seedPos = ikPoint.position;
        rootRotate = ikPoint.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.Instance.IsCompleted()) {
            Instantiate(Resources.Load<GameObject>("TipPanel"),GameObject.Find("Canvas").transform);
            LevelManager.Instance.condition = 0;
        }
        if(Input.GetMouseButton(0)) {
            ikPoint.position = Vector3.Lerp(ikPoint.position,Camera.main.ScreenToWorldPoint(Input.mousePosition),Time.deltaTime);
            //Quaternion lookAtPos = Quaternion.LookRotation(Camera.main.WorldToScreenPoint(Input.mousePosition - seedPos));
            Quaternion dir = Quaternion.AngleAxis(Vector3.Angle(Input.mousePosition - root.position,Vector3.right),Vector3.forward);
            ikPoint.rotation = Quaternion.Slerp(ikPoint.rotation,dir,Time.deltaTime * 6);
        }
        if(Input.GetMouseButtonUp(0)) {
            recoverPoint = false;
            
        }
            
        if(!recoverPoint) {
            ikPoint.position = Vector3.Lerp(ikPoint.position,seedPos,Time.deltaTime);
            ikPoint.rotation = Quaternion.Slerp(ikPoint.rotation,rootRotate,Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            //Fire
            GameObject bullet = Instantiate(Resources.Load<GameObject>("Bullet"),root.position,ikPoint.rotation);

        }
    }
}
