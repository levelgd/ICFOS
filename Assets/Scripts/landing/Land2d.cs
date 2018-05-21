using UnityEngine;
using System.Collections;

public class Land2d : MonoBehaviour {

	public int num = 64;

	LineRenderer lr;
	EdgeCollider2D ec;
	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer>();
		ec = GetComponent<EdgeCollider2D>();

		Vector2 move = new Vector2(-(num/2),0);

		Vector2[] linePoints = new Vector2[num];
		lr.SetVertexCount(num);

        float min = 0;
        float max = 0;

		for(int i = 0; i < linePoints.Length; i++){

			move += (new Vector2(1,Random.Range(-1f,1f))).normalized;
            if (move.y < min) min = move.y;
            if (move.y > max) max = move.y;

            linePoints[i] = new Vector2(move.x, move.y);
			lr.SetPosition(i,new Vector3(linePoints[i].x,linePoints[i].y));
		}

		ec.points = linePoints;

        GameObject.Find("Water").transform.Translate(0, (max + min) / 2f, 0);
	}

	void OnCollisionEnter2D(Collision2D c){
		if(c.rigidbody.velocity.magnitude > 1f){
			c.gameObject.GetComponent<Ship2d>().peoples -= (int)(c.rigidbody.velocity.magnitude*5000);
		}else{
			c.gameObject.GetComponent<Ship2d>().peoples -= (int)(c.rigidbody.velocity.magnitude*1000);
		}
	}
}
