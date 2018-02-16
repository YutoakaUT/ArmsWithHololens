using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Target_hard : MonoBehaviour
{
	public AudioClip clip;
	public GameObject ExploadObj;
	Renderer rend;
	int HP=3;
    // Use this for initialization
    void Start()
    {
		rend=GetComponent<Renderer>();
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
			HP--;
			if(HP>=0)
				rend.material.color=(Vector4)(rend.material.color)-new Vector4(0,0.33f,0,0);
            Vector3 hitPos = new Vector3(0,0,0);
            foreach (ContactPoint point in collision.contacts)
            {
                hitPos = point.point;
            }

			if(HP<=0)
			{
				Target_making.targetz.Remove(transform.parent.gameObject);//自滅
				Destroy(transform.parent.gameObject);
				GameObject effect = (GameObject)Instantiate (ExploadObj,hitPos, Quaternion.identity);
				AudioSource.PlayClipAtPoint(clip, transform.position);//音
				Target_making.tar++;              //再生成
				Score.score+=20;
			}
        }
    }
}