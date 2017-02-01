using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ExperimentControl : MonoBehaviour {

	public GameObject goDogPrefab;
	public GameObject goFoodPrefab;
	public List<GameObject> Dogs = new List<GameObject>();

	public int iPopulation;
	public int  iFoodRate;
	public int iTimeCycle;
	public int iElitism;
	public int iGeneration;
	public float fLastAverageFitness;
	public float fLastImprovementDifferential;


	void Start()
	{
		for(int x = 0; x< iPopulation; x++)
		{
			GameObject Dog = (GameObject)Instantiate(goDogPrefab, new Vector3(Random.Range(-150,150),1.8f,Random.Range(-150,150)), Quaternion.identity);
			Dogs.Add (Dog);
		}
		for(int x = 0; x< iFoodRate; x++)
		{
			GameObject Food = (GameObject)Instantiate(goFoodPrefab, new Vector3(Random.Range(-150,150),1.0f,Random.Range(-150,150)), Quaternion.identity);
		}
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 20), "Generation: " + iGeneration.ToString() );
		GUI.Label(new Rect(10, 40, 100, 20), "Last ave fitness: " + fLastAverageFitness.ToString() );
		GUI.Label(new Rect(10, 70, 100, 20), "Improvement: " + fLastImprovementDifferential.ToString() );


	}
}
