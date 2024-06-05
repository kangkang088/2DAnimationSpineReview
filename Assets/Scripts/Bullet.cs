using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float moveSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(transform.right * Time.deltaTime * moveSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Monster")) {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            LevelManager.Instance.condition++;
        }
    }
}
