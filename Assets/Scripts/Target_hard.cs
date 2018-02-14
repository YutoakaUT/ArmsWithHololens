using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Target_hard : MonoBehaviour
{
	public AudioClip clip;
	int HP=3;
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
        if (collision.gameObject.tag == "leftGrove"||collision.gameObject.tag == "rightGrove")//相手のタグがpunchの場合
        {
			HP--;
            Vector3 hitPos = new Vector3(0,0,0);
            foreach (ContactPoint point in collision.contacts)
            {
                hitPos = point.point;
            }

			Target_making.targetz.Remove(transform.parent.gameObject);
            Destroy(transform.parent.gameObject);　　　//自滅
            Target_making.num--;
			AudioSource.PlayClipAtPoint(clip, transform.position);//音
			Target_making.create=true;              //再生成
			Score.score+=10;
            //FindObjectOfType<Score>().AddPoint(10);
        }
    }
}