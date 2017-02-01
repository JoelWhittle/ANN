using UnityEngine;
using System.Collections;

public class LogicGateController : MonoBehaviour {
	public Brain cBrain;

	void Start()
	{
		cBrain = gameObject.GetComponent<Brain> ();
	}

void Update()
	{
		if (Input.GetKeyUp (KeyCode.Space))
		{
			cBrain.FireSynapses();
				}
	}
}
