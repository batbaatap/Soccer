using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject Ball;
	public GameObject Lvl1;
	public GameObject Lvl2;
	public GameObject Lvl3;
	internal GameObject[] xxa;

	public GameObject Score;
	public int scor;

	// Use this for initialization
	void Start () {
		// Instant();
	}
	// Update is called once per frame
	void Update () {
		xxa = GameObject.FindGameObjectsWithTag("Ball");
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Ball")
		{
			// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			//  SceneManager.LoadScene (activeScene.buildIndex);
			Destroy(other.gameObject);
			Instant();
		
			scor = scor + 1;
			Score.GetComponent<Text>().text = scor.ToString();
			if(scor == 1)
			{
				Lvl1.SetActive(true);
				Lvl2.SetActive(false);
				Lvl3.SetActive(false);
			}else if(scor == 2)
			{
				Lvl1.SetActive(false);
				Lvl2.SetActive(true);
				Lvl3.SetActive(false);
			}else if(scor ==3)
			{
				Lvl1.SetActive(false);
				Lvl2.SetActive(false);
				Lvl3.SetActive(true);
			}
		}		
	}

	public void Instant()
	{
		// if(xxa.Length <= 1){
			Instantiate(Ball, new Vector3(0, -1.7f, 0), transform.rotation);
		// }
	}



	
}
