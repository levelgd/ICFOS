using UnityEngine;
using System.Collections;

public class PlanetGen : MonoBehaviour {

	public int sectorX = 0;
	public int sectorY = 0;
	public int sectorZ = 0;

	public float size;

	public Vector3 worldPos;

	public GameObject atmosphere;
	public GameObject ring1;
	public GameObject ring2;

	public GameObject icon;

	public bool far = true;

	public Color atmColor;
	public float atmStr;

	public Texture2D tex;
	public Texture2D normalmap;

	public bool founded = false;
	// Use this for initialization
	void Start () {

		name = "Planet (check on second pass)";

		int tandnW = IntPow(2,Random.Range(5,11));
		int tandnH = IntPow(2,Random.Range(5,11));
		
		tex = new Texture2D(tandnW,tandnH);
		normalmap = new Texture2D(tandnW,tandnH);

		Color[] colors = tex.GetPixels();
		Color[] normalmapColors = normalmap.GetPixels();

		GenMain(tex,colors,normalmapColors);
		float waterStr = AtmGen();
		GenWater(tex,colors,normalmapColors,waterStr);
		GenRing();

		tex.SetPixels(colors);
		tex.Apply();

		normalmap.SetPixels(normalmapColors);
		normalmap.Apply();
		
		GetComponent<Renderer>().material.mainTexture = tex;
		GetComponent<Renderer>().material.SetTexture("_BumpMap",normalmap);

		size = Random.Range(5f,50f);

		worldPos = transform.position;

		sectorX = Mathf.RoundToInt(worldPos.x);
		sectorY = Mathf.RoundToInt(worldPos.y);
		sectorZ = Mathf.RoundToInt(worldPos.z);

		if(sectorX == 0 && sectorY == 0 && sectorZ == 0) Destroy(gameObject);
	}

	void Update(){
		if(!far) transform.Rotate(0,0.1f*Time.deltaTime,0);
	}

	public void Founded(){
		founded = true;
		GameObject ic = Instantiate(icon) as GameObject;
		ic.transform.SetParent(GameObject.FindObjectOfType<Canvas>().gameObject.transform);
		ic.GetComponent<PlanetIcon>().parent = transform;
		ic.transform.localScale = Vector3.one*2;
	}

	public void InSector(){
		far = false;
		GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		GetComponent<MeshRenderer>().receiveShadows = true;
	}

	public void OutSector(){
		far = true;
		GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		GetComponent<MeshRenderer>().receiveShadows = false;
	}

	void GenMain(Texture2D tex, Color[] colors, Color[] normalmapColors){
		float xOrg = Random.Range(0f,64000f);
		float yOrg = Random.Range(0f,64000f);
		
		float scale = Random.Range(1f,20f);

		float tintg = Random.Range(.5f,4f);
		float tintb = Random.Range(.5f,4f);
		
		float y = 0.0f;
		while (y < tex.height) {
			float x = 0.0f;
			while (x < tex.width) {
				float xCoord = xOrg + x / tex.width * scale;
				float yCoord = yOrg + y / tex.height * scale;
				int idx = (int)(y * tex.width + x);
				colors[idx].r = Mathf.PerlinNoise(xCoord, yCoord);
				colors[idx].g = colors[idx].r/tintg;
				colors[idx].b = colors[idx].r/tintb;

				normalmapColors[idx].r = normalmapColors[idx].g = normalmapColors[idx].b = colors[idx].r;

				x++;
			}
			y++;
		}
	}

	void GenRing(){
		if(Random.Range(0,10) > 8){

			//GameGen gg = GameObject.FindObjectOfType<GameGen>();

			Texture2D ringTex = new Texture2D(256,256);
			Color[] colors = ringTex.GetPixels();

			for(int c = 0; c < colors.Length; c++){
				colors[c].a = 0;
			}

			int hS = (ringTex.width/2);

			int num = Random.Range(1,16);

			while(num-- > 0){

				float tintr = Random.Range(.2f,.8f);
				float tintg = tintr*Random.Range(.8f,1.2f);
				float tintb = tintr*Random.Range(.8f,1.2f);

				int rad = (hS - Random.Range(0,24));

				float i = 359;
				while((i-=0.5f) > 0){

					if(Random.Range(0,10) > 8) continue;

					int x = (int)(Mathf.Cos(i)*rad) + hS;
					int y = (int)(Mathf.Sin(i)*rad) + hS;

					int idx = y * ringTex.width + x;
					if(idx < 0 || idx >= colors.Length) continue;
					colors[y * ringTex.width + x] = new Color(tintr,tintg,tintb,Random.Range(.8f,1f));
				}
			}

			ringTex.SetPixels(colors);
			ringTex.Apply();

			ring1.GetComponent<Renderer>().material.mainTexture = ringTex;
			ring2.GetComponent<Renderer>().material = ring1.GetComponent<Renderer>().material;

			Vector3 s = ring1.transform.localScale;
			s.x = s.y = Random.Range(2f,5f);
			ring1.transform.localScale = s;

			ring1.transform.Rotate(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360));
		}else{
			Destroy(ring1);
		}
	}

	void GenWater(Texture2D tex, Color[] colors, Color[] normalmapColors, float waterStr){
		float xOrg = Random.Range(0f,64000f);
		float yOrg = Random.Range(0f,64000f);
		
		float scale = Random.Range(1f,20f);
		
		float waterline = Random.Range(0f,waterStr/524288f);
		float ocColor = Random.Range(0.2f,1f);
		
		float y = 0.0f;
		while (y < tex.height) {
			float x = 0.0f;
			while (x < tex.width) {

				float xCoord = xOrg + x / tex.width * scale;
				float yCoord = yOrg + y / tex.height * scale;

				float noise = Mathf.PerlinNoise(xCoord, yCoord);

				if(noise > waterline){
					int idx = (int)(y * tex.width + x);
					colors[idx].r = ocColor;
					colors[idx].g = ocColor;
					colors[idx].b += noise;

					normalmapColors[idx].r = normalmapColors[idx].g = normalmapColors[idx].b = 0f;
				}
				x++;
			}
			y++;
		}
	}

	float AtmGen(){

		float strenght = 0f;

		int atmW = IntPow(2,Random.Range(5,11));
		int atmH = IntPow(2,Random.Range(5,11));

		Texture2D texA = new Texture2D(atmW,atmH);
		Color[] colorsA = texA.GetPixels();

		float xOrg = Random.Range(0f,64000f);
		float yOrg = Random.Range(0f,64000f);
		
		float scale = Random.Range(1f,10f);
		
		float tintr = Random.Range(.8f,1f);
		float tintg = tintr*Random.Range(.8f,1.2f);
		float tintb = tintr*Random.Range(.8f,1.2f);

		atmColor = new Color(tintr,tintg, tintb);
		
		float max = Random.Range(.01f,8f);
		//float min = Random.Range(.01f,0.1f);
		
		float y = 0.0f;
		while (y < texA.height) {
			float x = 0.0f;
			while (x < texA.width) {
				float xCoord = xOrg + x / texA.width * scale;
				float yCoord = yOrg + y / texA.height * scale;
				int idx = (int)(y * texA.width + x);

				colorsA[idx].a = Mathf.PerlinNoise(xCoord, yCoord) * max;

				strenght += colorsA[idx].a;

				colorsA[idx].r = tintr;
				colorsA[idx].g = tintg;
				colorsA[idx].b = tintb;
				x++;
			}
			y++;
		}
		
		texA.SetPixels(colorsA);
		texA.Apply();
		
		atmosphere.GetComponent<Renderer>().material.mainTexture = texA;

		atmStr = strenght;
		return strenght;
	}

	int IntPow(int x, int pow){
		int ret = 1;
		while (pow != 0){
			if ((pow & 1) == 1 )
				ret *= x;
			x *= x;
			pow >>= 1;
		}
		return ret;
	}
}
