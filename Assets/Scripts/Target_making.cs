using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
注意：标靶的形状最好严格为圆形
的の形は円の方がいい
*/
public class Target_making : MonoBehaviour
{
    public GameObject target_normal;
	public GameObject target_hard;
	public GameObject target_small;
	public Transform leftwall,rightwall/*yz*/,frontwall,backwall/*xy*/;
	public bool Debug=false;
	public static List<GameObject> targetz = new List<GameObject>();
	int countt=0,wall;
	public static int tar=0;//再生成の信号
	int nor_r=1,har_r=1,sma_r=1;//各種類の的が占めている比例
	float[,] para=new float[4,5];//para[0]=={xmin,xmax,ymin,ymax,z}或いは{x,ymin,ymax,zmin,zmax}


    float temp_x, temp_y,temp_z;  //座標のバッファ
    Vector3 pos;

    // Use this for initialization
    void Start()
    {
		para[0,0]=frontwall.position.x-frontwall.lossyScale.x/2;
		para[0,1]=frontwall.position.x+frontwall.lossyScale.x/2;
		para[0,2]=frontwall.position.y-frontwall.lossyScale.y/2;
		para[0,3]=frontwall.position.y+frontwall.lossyScale.y/2;
		para[0,4]=frontwall.position.z-frontwall.lossyScale.z/2;
		
		para[1,0]=backwall.position.x-backwall.lossyScale.x/2;
		para[1,1]=backwall.position.x+backwall.lossyScale.x/2;
		para[1,2]=backwall.position.y-backwall.lossyScale.y/2;
		para[1,3]=backwall.position.y+backwall.lossyScale.y/2;
		para[1,4]=backwall.position.z+backwall.lossyScale.z/2;
		
		para[2,0]=leftwall.position.x+leftwall.lossyScale.x/2;
		para[2,1]=leftwall.position.y-leftwall.lossyScale.y/2;
		para[2,2]=leftwall.position.y+leftwall.lossyScale.y/2;
		para[2,3]=leftwall.position.z-leftwall.lossyScale.z/2;
		para[2,4]=leftwall.position.z+leftwall.lossyScale.z/2;
		
		para[3,0]=rightwall.position.x-rightwall.lossyScale.x/2;
		para[3,1]=rightwall.position.y-rightwall.lossyScale.y/2;
		para[3,2]=rightwall.position.y+rightwall.lossyScale.y/2;
		para[3,3]=rightwall.position.z-rightwall.lossyScale.z/2;
		para[3,4]=rightwall.position.z+rightwall.lossyScale.z/2;
		createtarget(200);
    }

    // Update is called once per frame
    void Update()
    {
		/*if(Input.GetKeyDown (KeyCode.Q))
			createtarget(1);*/
		if(tar!=0)
			createtarget(tar--);
    }
	void createtarget(int number)
	{
		int nor=0,har=0,sma=0,num=0;
		while(number-->0)
		{
			num=Random.Range(1,nor_r+har_r+sma_r+1);
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
	/*前後左右*/
	void createnormal(int number)
	{
		bool create=true;
		float radii=target_normal.GetComponentInChildren<Renderer>().bounds.size.x/2;
		float thickness=target_normal.GetComponentInChildren<Renderer>().bounds.size.z;
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
			if(Debug==true)
				wall=3;
			if(wall==1)
			{
				temp_x = Random.Range(para[0,0]+radii,para[0,1]-radii);
				temp_y = Random.Range(para[0,2]+radii,para[0,3]-radii);
				temp_z = para[0,4]-thickness;
			}
			else if(wall==2)
			{
				temp_x = Random.Range(para[1,0]+radii,para[1,1]-radii);
				temp_y = Random.Range(para[1,2]+radii,para[1,3]-radii);
				temp_z = thickness+para[1,4];
			}
			else if(wall==3)
			{
				temp_x = thickness+para[2,0];
				temp_y = Random.Range(para[2,1]+radii,para[2,2]-radii);
				temp_z = Random.Range(para[2,3]+radii,para[2,4]-radii);
			}
			else if(wall==4)
			{
				temp_x = para[3,0]-thickness;
				temp_y = Random.Range(para[3,1]+radii,para[3,2]-radii);
				temp_z = Random.Range(para[3,3]+radii,para[3,4]-radii);
			}
			if(Debug==true)
				temp_y=2;
			
			foreach (GameObject gameo in targetz)
			{
				if((gameo.transform.position-new Vector3(temp_x,temp_y,temp_z)).sqrMagnitude<
				(gameo.GetComponentInChildren<Renderer>().bounds.size.y/2+radii)*
				(gameo.GetComponentInChildren<Renderer>().bounds.size.y/2+radii))
				{
					countt++;
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
		float radii=target_hard.GetComponentInChildren<Renderer>().bounds.size.x/2;
		float thickness=target_hard.GetComponentInChildren<Renderer>().bounds.size.z;
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
			if(Debug==true)
				wall=3;
			if(wall==1)
			{
				temp_x = Random.Range(para[0,0]+radii,para[0,1]-radii);
				temp_y = Random.Range(para[0,2]+radii,para[0,3]-radii);
				temp_z = para[0,4]-thickness;
			}
			else if(wall==2)
			{
				temp_x = Random.Range(para[1,0]+radii,para[1,1]-radii);
				temp_y = Random.Range(para[1,2]+radii,para[1,3]-radii);
				temp_z = thickness+para[1,4];
			}
			else if(wall==3)
			{
				temp_x = thickness+para[2,0];
				temp_y = Random.Range(para[2,1]+radii,para[2,2]-radii);
				temp_z = Random.Range(para[2,3]+radii,para[2,4]-radii);
			}
			else if(wall==4)
			{
				temp_x = para[3,0]-thickness;
				temp_y = Random.Range(para[3,1]+radii,para[3,2]-radii);
				temp_z = Random.Range(para[3,3]+radii,para[3,4]-radii);
			}
			if(Debug==true)
				temp_y=2;
			
			foreach (GameObject gameo in targetz)
			{
				if((gameo.transform.position-new Vector3(temp_x,temp_y,temp_z)).sqrMagnitude<
				(gameo.GetComponentInChildren<Renderer>().bounds.size.y/2+radii)*
				(gameo.GetComponentInChildren<Renderer>().bounds.size.y/2+radii))
				{
					countt++;
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
		bool create=true;
		float radii=target_small.GetComponentInChildren<Renderer>().bounds.size.x/2;
		float thickness=target_small.GetComponentInChildren<Renderer>().bounds.size.z;
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
			if(Debug==true)
				wall=3;
			if(wall==1)
			{
				temp_x = Random.Range(para[0,0]+radii,para[0,1]-radii);
				temp_y = Random.Range(para[0,2]+radii,para[0,3]-radii);
				temp_z = para[0,4]-thickness;
			}
			else if(wall==2)
			{
				temp_x = Random.Range(para[1,0]+radii,para[1,1]-radii);
				temp_y = Random.Range(para[1,2]+radii,para[1,3]-radii);
				temp_z = thickness+para[1,4];
			}
			else if(wall==3)
			{
				temp_x = thickness+para[2,0];
				temp_y = Random.Range(para[2,1]+radii,para[2,2]-radii);
				temp_z = Random.Range(para[2,3]+radii,para[2,4]-radii);
			}
			else if(wall==4)
			{
				temp_x = para[3,0]-thickness;
				temp_y = Random.Range(para[3,1]+radii,para[3,2]-radii);
				temp_z = Random.Range(para[3,3]+radii,para[3,4]-radii);
			}
			if(Debug==true)
				temp_y=2;
			
			
			foreach (GameObject gameo in targetz)
			{
				if((gameo.transform.position-new Vector3(temp_x,temp_y,temp_z)).sqrMagnitude<
				(gameo.GetComponentInChildren<Renderer>().bounds.size.y/2+radii)
				*(gameo.GetComponentInChildren<Renderer>().bounds.size.y/2+radii))
				{
					countt++;
					goto A;    //近すぎる場合は破棄し、再生成する
				}
			}
			
			countt=0;
			
			pos.x = temp_x;  //座標を代入
			pos.y = temp_y;
			pos.z = temp_z;
			
			GameObject targets = GameObject.Instantiate(target_small) as GameObject;
			targets.transform.position = pos;
			if(wall>2)
				targets.transform.Rotate(0f, 90f, 0f);
			targetz.Add(targets);
		}
	}
}