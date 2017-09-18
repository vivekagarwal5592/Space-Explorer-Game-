using UnityEngine;
using System.Collections;

public class ReactiveTarget2 : MonoBehaviour {

	public void ReactToHit() {
		enemy2 behavior2 = GetComponent<enemy2>();

		if (behavior2 != null) {
			print ("killing player 2");
			behavior2.SetAlive(false);
		}
		StartCoroutine(Die());
	}

	private IEnumerator Die() {
		this.transform.Rotate(-75, 0, 0);

		yield return new WaitForSeconds(0.01f);

		Destroy(this.gameObject);
	}
}
