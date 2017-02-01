//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//
//public class EvolutionManager : MonoBehaviour {
//
//	public ExperimentControl cExperimentControl; 
//	public int iTotalScoreThisRound;
//	public int iElitismCutOf;
//	public float iNeuronMutationRate;
//	public float iSynapseMutationRate;
//
//
//void Start()
//	{
//		StartCoroutine(InitializeTimeCycle ());
//	}
//
//	public IEnumerator InitializeTimeCycle()
//	{
//		yield return new WaitForSeconds (cExperimentControl.iTimeCycle);
//
//			Evolve();
//			cExperimentControl.iGeneration++;
//			StartCoroutine(InitializeTimeCycle ());
//
//
//	}
//
//	public void Evolve()
//	{
//		List<GameObject> SortedList = cExperimentControl.Dogs.OrderBy (x => x.GetComponent<Dog>().iScore).Reverse ().ToList();
//
//		float a = (float)cExperimentControl.iPopulation / 100;
//		float b = (float)a * cExperimentControl.iElitism;
//		iElitismCutOf = (int)b;
//
//		int n = 0;
//		iTotalScoreThisRound = 0;
//	foreach(GameObject dog in SortedList)
//		{
//			Dog cDog = dog.GetComponent<Dog>();
//		iTotalScoreThisRound = iTotalScoreThisRound + cDog.iScore;
//
//			if(n < iElitismCutOf)
//			{
//				cDog.iScore = 0;
//				cDog.transform.position = new Vector3(Random.Range(-150,150),1.8f,Random.Range(-150,150));
//			}
//			else
//			{
//				ReplaceBrainWithChild(cDog);
//				cDog.iScore = 0;
//				cDog.transform.position = new Vector3(Random.Range(-150,150),1.8f,Random.Range(-150,150));
//			}
//
//			n++;
//		}
//		float tmp = cExperimentControl.fLastAverageFitness;
//		 cExperimentControl.fLastAverageFitness = (float)iTotalScoreThisRound / cExperimentControl.iPopulation;
//		cExperimentControl.fLastImprovementDifferential = cExperimentControl.fLastAverageFitness - tmp;
//		Debug.Log ("DIFF" + cExperimentControl.fLastImprovementDifferential.ToString ());
//	}
//
//	public void ReplaceBrainWithChild(Dog goChild)
//	{
//
//
//
//		GameObject goParentA = cExperimentControl.Dogs [Random.Range (0, iElitismCutOf)];
//		Dog cParentA = goParentA.GetComponent<Dog>();
//		List<float> ParentANeuronMap = cParentA.cBrain.cGenome.ThresholdMatrix;
//		List<float> ParentASynapseMap = cParentA.cBrain.cGenome.WeightMatrix;
//
//		GameObject goParentB = cExperimentControl.Dogs [Random.Range (0, iElitismCutOf)];
//		Dog cParentB = goParentB.GetComponent<Dog>();
//		List<float> ParentBNeuronMap = cParentB.cBrain.cGenome.ThresholdMatrix;
//		List<float> ParentBSynapseMap = cParentB.cBrain.cGenome.WeightMatrix;
//	
//	if (Random.Range (0, 2)== 0) {
//						//Evolve by averages
//
//						for (int i = 0; i < ParentANeuronMap.Count(); i++) {
//				goChild.GetComponent<Dog> ().cBrain.cGenome.ThresholdMatrix [i] = (ParentANeuronMap [i] + ParentBNeuronMap [i]) / 2;
//				if(Random.Range(0,100) < iNeuronMutationRate)
//				{
//					goChild.GetComponent<Dog> ().cBrain.cGenome.ThresholdMatrix [i] = Random.Range(0,100);
//				}
//				goChild.GetComponent<Dog>().cBrain.AllNeurons[i].fThreshold = 	goChild.GetComponent<Dog> ().cBrain.cGenome.ThresholdMatrix [i];
//						}
//						for (int n = 0; n < ParentASynapseMap.Count(); n++) {
//				goChild.GetComponent<Dog> ().cBrain.cGenome.WeightMatrix [n] = (ParentASynapseMap [n] + ParentBSynapseMap [n]) / 2;
//				if(Random.Range(0,100) < iSynapseMutationRate)
//				{
//					goChild.GetComponent<Dog> ().cBrain.cGenome.WeightMatrix [n] = Random.Range(-1,1);
//				}
//				goChild.GetComponent<Dog>().cBrain.AllSynapses[n].fWeight = 	goChild.GetComponent<Dog> ().cBrain.cGenome.WeightMatrix [n];
//
//						}
//				}
//		else {
//			////////////
//			int a = Random.Range(0, ParentANeuronMap.Count());
//			for (int i = 0; i < ParentANeuronMap.Count(); i++) {
//				if(i < a){
//					goChild.GetComponent<Dog> ().cBrain.cGenome.ThresholdMatrix [i] = ParentANeuronMap [i];
//					if(Random.Range(0,100) < iNeuronMutationRate)
//					{
//						goChild.GetComponent<Dog> ().cBrain.cGenome.ThresholdMatrix [i] = Random.Range(0,100);
//					}
//					goChild.GetComponent<Dog>().cBrain.AllNeurons[i].fThreshold() = 	goChild.GetComponent<Dog> ().cBrain.cGenome.ThresholdMatrix [i];
//			}
//				else
//				{
//					goChild.GetComponent<Dog> ().cBrain.cGenome.ThresholdMatrix [i] = ParentBNeuronMap [i];
//					if(Random.Range(0,100) < iNeuronMutationRate)
//					{
//						goChild.GetComponent<Dog> ().cBrain.cGenome.ThresholdMatrix [i] = Random.Range(0,100);
//					}
//					goChild.GetComponent<Dog>().cBrain.AllNeurons[i].fThreshold() = 	goChild.GetComponent<Dog> ().cBrain.cGenome.ThresholdMatrix [i];
//				}
//			}
//			int b = Random.Range(0, ParentASynapseMap.Count());
//
//			for (int n = 0; n < ParentASynapseMap.Count(); n++) {
//				if(n < b){
//					goChild.GetComponent<Dog> ().cBrain.cGenome.WeightMatrix [n] = ParentASynapseMap [n] ;
//					if(Random.Range(0,100) < iSynapseMutationRate)
//					{
//						goChild.GetComponent<Dog> ().cBrain.cGenome.WeightMatrix [n] = Random.Range(-1,1);
//					}
//					goChild.GetComponent<Dog>().cBrain.AllSynapses[n].fWeight = 	goChild.GetComponent<Dog> ().cBrain.cGenome.WeightMatrix [n];
//				
//			}
//				else
//				{
//					goChild.GetComponent<Dog> ().cBrain.cGenome.WeightMatrix [n] = ParentBSynapseMap [n] ;
//					if(Random.Range(0,100) < iSynapseMutationRate)
//					{
//						goChild.GetComponent<Dog> ().cBrain.cGenome.WeightMatrix [n] = Random.Range(-1,1);
//					}
//					goChild.GetComponent<Dog>().cBrain.AllSynapses[n].fWeight = 	goChild.GetComponent<Dog> ().cBrain.cGenome.WeightMatrix [n];
//
//				}
//			}
//		
//				}
//	}
//}
