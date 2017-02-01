using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

	public GameObject Ear1;
	public GameObject Ear2;
    public GameObject Nose;
	public Brain cBrain;
	public int iScore;
	public int iBestNeuronIndex;
	public float iBestNeuronOutput;


	public int iTurnSpeed  ;
	public bool bTurningLeft;
	public bool bTurningRight;

	public void FixedUpdate()
	{
	  Tick ();

		if(bTurningLeft == true)
		{
		transform.Rotate(Vector3.up, -iTurnSpeed * Time.deltaTime);
		}

		if(bTurningRight == true)
		{
			transform.Rotate(Vector3.up,  + iTurnSpeed * Time.deltaTime);

		}
		}
public void Tick()
	{
		UpdateInput ();
		cBrain.FireSynapses ();
		ReadOutput ();
	}

	public void UpdateInput()
	{
		GameObject[] goFoods = GameObject.FindGameObjectsWithTag ("Food");
		if(goFoods.Length !=0)
		{
			GameObject goFood = goFoods[0];
		
		foreach(GameObject goCurFood in goFoods)
		{
				float curDistance = Vector3.Distance(Nose.transform.position, goCurFood.transform.position);

				if(curDistance < Vector3.Distance(Nose.transform.position, goFood.transform.position))
				{
					goFood = goCurFood;
				}
		}

		cBrain.InputLayer.Neurons [0].fInput = Vector3.Distance (Ear1.transform.position, goFood.transform.position);
		cBrain.InputLayer.Neurons [1].fInput = Vector3.Distance (Ear2.transform.position, goFood.transform.position);
		cBrain.InputLayer.Neurons [2].fInput = Vector3.Distance (Nose.transform.position, goFood.transform.position);
			float fTotalVelocity =Mathf.Abs(GetComponent<Rigidbody>().velocity.x - 0) + Mathf.Abs(GetComponent<Rigidbody>().velocity.y - 0) + Mathf.Abs(GetComponent<Rigidbody>().velocity.y - 0);
			cBrain.InputLayer.Neurons [3].fInput =  fTotalVelocity;

		}
	}
	public void ReadOutput()
	{

	
		for(int i = 0; i < cBrain.OutputLayer.Neurons.Count; i++)
		{
			if(i == 0)
			{
				iBestNeuronIndex = i;
				iBestNeuronOutput = cBrain.OutputLayer.Neurons[i].fOutput;
			}

			if(cBrain.OutputLayer.Neurons[i].fOutput > iBestNeuronOutput)
			{
				iBestNeuronIndex = i;
				iBestNeuronOutput = cBrain.OutputLayer.Neurons[i].fOutput;
			}
		}

		ExecuteOutput (iBestNeuronIndex);
	}

	public void ExecuteOutput(int iDominantOutputNeuronIndex)
	{
		if(iDominantOutputNeuronIndex == 0)
		{
			MoveForward();
		}
		if(iDominantOutputNeuronIndex == 1)
		{
			TurnLeft();
		}
		if(iDominantOutputNeuronIndex == 2)
		{
			TurnRight();
		}
		if(iDominantOutputNeuronIndex == 3)
		{
			HardStop();
		}
	}
	public void Update()
	{
		if(Input.GetKeyUp(KeyCode.C))
		{
			MoveForward();
 		}
	}

	public void MoveForward()
	{
		GetComponent<Rigidbody>().AddRelativeForce (Vector3.forward * 1);
		bTurningLeft = false;
		bTurningRight = false;
	}
	public void TurnLeft()
	{
		GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
		GetComponent<Rigidbody>().angularVelocity = new Vector3 (0, 0, 0);
		bTurningLeft = true;
		bTurningRight = false;

	}
	public void TurnRight()
	{
		GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
		GetComponent<Rigidbody>().angularVelocity = new Vector3 (0, 0, 0);
		bTurningRight = true;
		bTurningLeft = false;
	}
	public void HardStop()
	{
		GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
		GetComponent<Rigidbody>().angularVelocity = new Vector3 (0, 0, 0);
	}

}
