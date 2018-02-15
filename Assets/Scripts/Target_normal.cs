using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Target_normal : MonoBehaviour
{
	public GameObject ExploadObj;
	public AudioClip clip;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        //衝突判定
        if (collision.gameObject.tag == "leftGrove"||collision.gameObject.tag == "rightGrove")//相手のタグがGroveの場合
        {
            Vector3 hitPos = new Vector3(0,0,0);
            foreach (ContactPoint point in collision.contacts)
            {
                hitPos = point.point;
            }

			Target_making.targetz.Remove(transform.parent.gameObject);
            Destroy(transform.parent.gameObject);　　　//自滅
			GameObject effect = (GameObject)Instantiate (ExploadObj,hitPos, Quaternion.identity);
			AudioSource.PlayClipAtPoint(clip, transform.position);//音
			Target_making.tar++;              //再生成
			Score.score+=10;
        }
    }
}
