using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{

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
        if (collision.gameObject.tag == "Punch")
        {
            Vector3 hitPos = new Vector3(0,0,0);
            foreach (ContactPoint point in collision.contacts)
            {
                hitPos = point.point;
            }

            print((int)hitPos.x);
            print((int)hitPos.y);
            print(hitPos.z);
            Target_location.px.Remove((int)hitPos.x);  //リストから参照データを削除
            Target_location.py.Remove((int)hitPos.y);
            Target_location.pz.Remove((int)hitPos.z);

            //相手のタグがpunchならば、自分を消す
            Destroy(this.gameObject);
            Target_location.num--;
            FindObjectOfType<Score>().AddPoint(10);

        }
    }
}