using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WanderingAI : MonoBehaviour {
	public const float baseSpeed = 3.0f;

	public float speed = 3.0f;
	public float obstacleRange = 5.0f;
	[SerializeField] private GameObject fireballPrefab;
  
   private GameObject boss;
   private  GameObject enemy ;
   private GameObject _fireball;
   private Animator _animator;
   float distance = 0;
   private bool enemy_found;
   private bool _alive;

   void Awake(){
     boss = GameObject.Find("boss");
   }



   void Start() {
      _alive = true;
		//player = GameObject.Find ("Skeleton@Attack");
      _animator = GetComponent<Animator>();
      enemy_found= false;
     
  }

  void Update() {

      if (_animator.GetBool("alive") ) {
          if(!searchForGameObject()){
            searchEnemy();
            if(enemy_found == false){
              roamFreely();
          }
          else{

            if(enemy !=null){
              if(enemy.GetComponent<enemy2>().GetAlive()== true){
                _animator.SetBool("enemy_found",true);
                Attack (enemy);
              }
            }
            else{
              _animator.SetBool("enemy_found",false);
                enemy_found = false;
            }
        }
   
  }
  else{
    //  print("movig towards boss");
     moveTowardsBoss();
 }

    
}



if(_fireball != null){
  //_fireball = Instantiate(fireballPrefab) as GameObject;
      //Vector3 p = new Vector3(0,1,1);
     // _fireball.transform.position = transform.TransformPoint(p * 1f);
      //_fireball.transform.rotation = transform.rotation;
      //_fireball.transform.Rotate(0,45,0);
  //    _fireball.transform.LookAt (boss.transform);
    //  Physics.IgnoreCollision(_fireball.GetComponent<Collider>(), GetComponent<Collider>());
}
} 



public void SetAlive(bool alive) {
    _alive = alive;
}

public bool GetAlive(){
  return _alive;
}

private void OnSpeedChanged(float value) {
  speed = baseSpeed * value;
}

private void Attack(GameObject enemy){
 Vector3 targetPostition = new Vector3( enemy.transform.position.x, 
    0, enemy.transform.position.z );
  transform.LookAt (targetPostition);//		playercharacter = 	player.GetComponent<PlayerCharacter> ();
  if (_fireball == null) {	
    fire_bullet(enemy);
    }
}

void OnTriggerEnter(Collider other) {
print(other);
}

public void moveTowardsBoss(){
 if(Vector3.Distance(boss.transform.position,transform.position) >15 ){
   Vector3 targetPostition = new Vector3( boss.transform.position.x, 
    0, 
    boss.transform.position.z ) ;
   transform.LookAt (targetPostition);
   transform.Translate (0, 0, speed * Time.deltaTime);
}

else{
  _animator.SetBool("boss_found",true);
   Attack (boss);
}
}

public void searchEnemy(){

 Collider[] hitColliders = Physics.OverlapSphere(transform.position,15);
 for ( int i = 0;i <hitColliders.Length; i++)
 {
  if(hitColliders[i].gameObject.GetComponent<enemy2>() != null){
     enemy_found = true;
     enemy = hitColliders[i].gameObject;
     break;
 }
}
}

public void roamFreely(){
  transform.Translate (0, 0, speed * Time.deltaTime);
  Ray ray = new Ray(transform.position, transform.forward);
  RaycastHit hit;
  if (Physics.SphereCast(ray,0.75f, out hit)) {
   GameObject hitObject = hit.transform.gameObject;
   if (hit.distance < obstacleRange) {
     float angle = Random.Range(-110, 110);
     transform.Rotate(0, angle, 0);
 }
}
}

public bool searchForGameObject(){
  if(GameObject.Find("boss")!=null){
    boss = GameObject.Find("boss");
    return true;
  }
  return false;
}


public void fire_bullet(GameObject enemy){
 _fireball = Instantiate(fireballPrefab) as GameObject;
     Vector3 p = new Vector3(0,7,1);
     _fireball.transform.position = transform.TransformPoint(p * 1f);
     _fireball.transform.LookAt(enemy.transform);
      Physics.IgnoreCollision(_fireball.GetComponent<Collider>(), GetComponent<Collider>());
 
}



}
