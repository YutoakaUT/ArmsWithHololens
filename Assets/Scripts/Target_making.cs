using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Target_making : MonoBehaviour
{
    public GameObject target_normal;
	public GameObject target_hard;
	public GameObject target_small;
	public bool Debug=false;
	public static List<GameObject> targetz = new List<GameObject>();
    public int max = 5; //的の最大数
	int countt=0,wall;
	public static bool create=true;


    float temp_x, temp_y,temp_z;  //座標のバッファ

    public static int num = 0; //的の生成された数
    Vector3 pos;

    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        if (num < max)
        {
            while (create)
            {
				if(num==max)
				{
					create=false;
					break;
				}
A:				if(countt>=100)
				{
					create=false;
					print("的の数が多すぎるため、生成不可能、今既に的"+num+"個を生成した");
					countt=0;
					break;
				}
                //的の座標をランダムに作成
				wall=Random.Range(1,5);
				if(wall==1)
				{
					temp_x = Random.Range(-24.5f+target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2,24.5f-target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2);
					temp_y = Random.Range(target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2,50-target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2);
					temp_z = 24.5f-target_normal.GetComponentInChildren<Renderer>().bounds.size.z;
				}
				else if(wall==2)
				{
					temp_x = Random.Range(-24.5f+target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2,24.5f-target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2);
					temp_y = Random.Range(target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2,50-target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2);
					temp_z = target_normal.GetComponentInChildren<Renderer>().bounds.size.z-24.5f;
				}
				else if(wall==3)
				{
					temp_x = target_normal.GetComponentInChildren<Renderer>().bounds.size.z-24.5f;
					temp_y = Random.Range(target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2,50-target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2);
					temp_z = Random.Range(-24.5f+target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2,24.5f-target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2);
				}
				else if(wall==4)
				{
					temp_x = 24.5f-target_normal.GetComponentInChildren<Renderer>().bounds.size.z;
					temp_y = Random.Range(target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2,50-target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2);
					temp_z = Random.Range(-24.5f+target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2,24.5f-target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2);
				}
				if(Debug==true&&num<=10)
					temp_y=2;
				
				foreach (GameObject gameo in targetz)
				{
					if((gameo.transform.position-new Vector3(temp_x,temp_y,temp_z)).sqrMagnitude<target_normal.GetComponentInChildren<Renderer>().bounds.size.x*target_normal.GetComponentInChildren<Renderer>().bounds.size.x)
					{
						countt++;
						print("countt="+countt);
						goto A;    //近すぎる場合は破棄し、再生成する
					}
				}
				
				countt=0;
				
                pos.x = temp_x;  //座標を代入
                pos.y = temp_y;
                pos.z = temp_z;
				
                GameObject targets = GameObject.Instantiate(target_normal) as GameObject;
                targets.transform.position = pos;
				if(wall>2)
					targets.transform.Rotate(0f, 90f, 0f);
                num++;
				targetz.Add(targets);
            }
        }
    }
}