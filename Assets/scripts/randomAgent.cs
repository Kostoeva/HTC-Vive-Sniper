using System.Collections;
using UnityEngine;

public class randomAgent : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
		//Check if destination has been reached
		if (!agent.pathPending) {
			if (agent.remainingDistance <= agent.stoppingDistance) {
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
					//Done
					newDestination();
				}
			}
		}
	}

	private void newDestination() {
		Vector3 newDest = Random.insideUnitSphere * 500f + new Vector3(139, 86f, -172f);
		UnityEngine.AI.NavMeshHit hit;
		bool hasDestination = UnityEngine.AI.NavMesh.SamplePosition (newDest, out hit, 100f, 1);
		if (hasDestination) {
			agent.SetDestination(hit.position);
		}
	}
}
