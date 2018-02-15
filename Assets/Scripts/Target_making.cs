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
	int countt=0,wall;
	public static int tar=0;//生成あるいは再生成の信号
	int nor_r=1,har_r=1,sma_r=0;//各種類の的が占めている比例


    float temp_x, temp_y,temp_z;  //座標のバッファ
    Vector3 pos;

    // Use this for initialization
    void Start()
    {
		createtarget(50);
    }

    // Update is called once per frame
    void Update()
    {
		if(tar!=0)
			createtarget(tar--);
    }
	void createtarget(int number)
	{
		int nor=0,har=0,sma=0,num=0;
		while(number-->0)
		{
			num=Random.Range(1,nor_r+har_r+sma_r+1);
			print("num="+num);
			if(num<=nor_r)
				nor++;
			else
			{
				num-=nor_r;
				if(num<=har_r)
					har++;
				else
				{
					num-=har_r;
					if(num<=sma_r)
						sma++;
					else
						print("Error!!!");
				}
			}
		}
		/*print("nor="+nor);
		print("har="+har);
		print("sma="+sma);*/
		createnormal(nor);
		createhard(har);
		createsmall(sma);
	}
	void createnormal(int number)
	{
		bool create=true;
		while (create&&number-->0)
		{
	A:		if(countt>=100)
			{
				create=false;
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
			if(Debug==true)
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
			targetz.Add(targets);
		}
	}
	void createhard(int number)
	{
		bool create=true;
		while (create&&number-->0)
		{
A:		if(countt>=100)
			{
				create=false;
				countt=0;
				break;
			}
			//的の座標をランダムに作成
			wall=Random.Range(1,5);
			if(wall==1)
			{
				temp_x = Random.Range(-24.5f+target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2,24.5f-target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2);
				temp_y = Random.Range(target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2,50-target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2);
				temp_z = 24.5f-target_hard.GetComponentInChildren<Renderer>().bounds.size.z;
			}
			else if(wall==2)
			{
				temp_x = Random.Range(-24.5f+target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2,24.5f-target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2);
				temp_y = Random.Range(target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2,50-target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2);
				temp_z = target_hard.GetComponentInChildren<Renderer>().bounds.size.z-24.5f;
			}
			else if(wall==3)
			{
				temp_x = target_hard.GetComponentInChildren<Renderer>().bounds.size.z-24.5f;
				temp_y = Random.Range(target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2,50-target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2);
				temp_z = Random.Range(-24.5f+target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2,24.5f-target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2);
			}
			else if(wall==4)
			{
				temp_x = 24.5f-target_hard.GetComponentInChildren<Renderer>().bounds.size.z;
				temp_y = Random.Range(target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2,50-target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2);
				temp_z = Random.Range(-24.5f+target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2,24.5f-target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2);
			}
			if(Debug==true)
				temp_y=2;
			
			foreach (GameObject gameo in targetz)
			{
				if((gameo.transform.position-new Vector3(temp_x,temp_y,temp_z)).sqrMagnitude<target_hard.GetComponentInChildren<Renderer>().bounds.size.x*target_hard.GetComponentInChildren<Renderer>().bounds.size.x)
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
			
			GameObject targets = GameObject.Instantiate(target_hard) as GameObject;
			targets.transform.position = pos;
			if(wall>2)
				targets.transform.Rotate(0f, 90f, 0f);
			targetz.Add(targets);
		}
	}
	void createsmall(int number)
	{
		;
	}
}