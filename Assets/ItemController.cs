using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    private GameObject maincamera;
    private float defference;

    // Start is called before the first frame update
    void Start()
    {
        this.maincamera = GameObject.Find("Main Camera");
        this.defference = maincamera.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの位置に合わせてオブジェクトを廃棄
        if(maincamera.transform.position.z >　this.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
