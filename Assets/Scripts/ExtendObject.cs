using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendObject : MonoBehaviour {
	//private Vector3 m_mouseDownPosition = Vector3.zero;
	// Use this for initialization

	public string groveName;
	public string armName;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tmp = GameObject.Find(groveName).transform.position;
		Vector3 anchor = GameObject.Find(armName).transform.position;
		Vector3 player = GameObject.Find("Player").transform.position;
		//Vector3 inputPosition   = new Vector3( tmp.x, tmp.y, tmp.z );
		//Vector3 cubePos        = Camera.main.ScreenToWorldPoint( inputPosition );
		Vector3 mediumPos       =(tmp-anchor) / 2.0f;
		float   dist            = Vector3.Distance( tmp, anchor );

		//cube
		//transform.localScale    = new Vector3( 1.0f, 1.0f, dist );

		//cylinder
		//transform.Rotate = Vector3.Angle( tmp, anchor );
		//transform.Rotate(new Vector3( 0, 0, 90));
		transform.localScale    = new Vector3( 0.1f, 0.1f, dist);
		transform.position      = mediumPos+anchor;
		transform.LookAt( tmp );
	}

	void OnMouseDown()
	{
		// マウスクリックした際の初期位置を保存。
		//m_mouseDownPosition = transform.position;
	}

	void OnMouseDrag()
	{
		

	}

}
