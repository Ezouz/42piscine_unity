using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {

	public SpriteRenderer		body;
	//public GameObject		circleCollider;
	public GameObject		head;
	// public GameObject		weapon;
	public GameObject		player;
	//public detection		childScript;
	public Rigidbody2D		rigidbody;
	public Vector3			target;
	public Vector2			vec2_1, vec2_2;
	public GameObject weaponToBody;
    private AudioSource source;
    public AudioClip[] Dead;
    public int PV = 1;
    public bool fire = false;
    public float dizzy = 0;
    float t;
	//public LayerMask		wallMask;
	//public LayerMask		charaMask;
	//public LayerMask		mask;
//	public GameObject		loader;

	//public  PathFind.Grid	grid;
	//PathFind.Point _from;
//	PathFind.Point _to;
//	List<PathFind.Point> path;

	public bool				alerted;
	public bool				playerVisible;
	public float			timeToUnalert;


	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
		alerted = false;
		playerVisible = false;
		timeToUnalert = 0f;
		player = GameObject.FindWithTag("player");
		//childScript = (transform.GetComponentsInChildren<detection>())[0];
		//circleCollider = transform.GetComponent<CircleCollider2D>();
		//mask = LayerMask.GetMask("obstacles", "characters");
		//charaMask = LayerMask.GetMask("characters");
		rigidbody = transform.GetComponent<Rigidbody2D>();
		
		//alerted = true;
		//Debug.Log(transform.position);
//		loader = GameObject.Find("mapLoader");
//		grid = loader.GetComponent<PathFind.Grid>();
//		Debug.Log(grid);
	}
	
	// Update is called once per frame
	void Update () {
		target = player.transform.position;
		//Debug.Log(target);
		//Debug.Log(transform.position);
		if (PV <= 0) {
            // Debug.Log(transform.name + " = dead ");
            // TO DO SOUND ENNEMY DEAD
            source.PlayOneShot(Dead[Random.Range(0, 4)], 1f);
            Destroy(transform.gameObject);
        }
		if ((Time.time - t) >= dizzy) {
			if  (alerted){
				checkPlayerSight();
				if (playerVisible){
					//Debug.Log("Player visible");
					timeToUnalert = 5f;
					//check distance
					//if distance  too great then move
					//else shoot
				}
				else{
					timeToUnalert -= Time.deltaTime;
					//locate checkpoint that sees player
					//locate closest checkpoint that sees that checkpoint
					//etc until enemy sees checkpoint
					//move to first checkpoint of list
				}
			}
			else{
				checkPlayerSight();
			}
			if (timeToUnalert <= 0f){
				alerted = false;
			}
	//		_from = new PathFind.Point(Mathf.FloorToInt(transform.position.x) + 5, Mathf.FloorToInt(transform.position.y) + 3);
	//		_to = new PathFind.Point(Mathf.FloorToInt(target.transform.position.x) + 5, Mathf.FloorToInt(target.transform.position.y) + 3);
	//		path = PathFind.Pathfinding.FindPath(grid, _from, _to);
	//		Debug.Log(path);
			if (fire) {
                if ((Time.time - t) >= weaponToBody.GetComponent<Weapon2body>().shotFreq)
                {
                    t = Time.time;
                    weaponToBody.GetComponent<Weapon2body>().fire = true;
                    weaponToBody.GetComponent<Weapon2body>().playerRotation = transform.localRotation.eulerAngles;
                }
            }
            // dizzy = 0;
        } else {
            Debug.Log("cui cui");
        }
	}

	void FixedUpdate(){
		if (alerted){
			Vector3 direction = (target - transform.position).normalized;
			rigidbody.MovePosition(transform.position + direction * Time.fixedDeltaTime);
		}
	}


	public void checkPlayerSight(){
		//Debug.Log("Checking sight");
		vec2_1 = transform.position;
		vec2_2 = target;
		RaycastHit2D hit = Physics2D.Raycast(vec2_1, vec2_2 - vec2_1, 5f);
		//Debug.Log(hit.collider.transform);
		if (hit.collider.tag == "player"){
			//Debug.Log("Player Sighted");
			playerVisible = true;
			if (!alerted){
				alerted = true;
				timeToUnalert = 5f;
			}
		}
		else{
			playerVisible = false;
		}
		
	}

	
}
