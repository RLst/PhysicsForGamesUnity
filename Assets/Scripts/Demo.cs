using System.Collections;
using UnityEngine;

public class Demo : MonoBehaviour {
	[SerializeField] Material skin;
	[SerializeField] PhysicMaterial physicsMaterial;
    [SerializeField] float minForce = 10f;
    [SerializeField] float maxForce = 100f;
	[SerializeField] float delay = 0.5f;


    // Use this for initialization
    void Start () {
		StartCoroutine(TimedAction());
	}

    private void SpawnNewObject()
    {
        //spawn some random objects randomly
        GameObject newObject = null;
        switch (Random.Range(1, 5))
        {
            case 1: newObject = GameObject.CreatePrimitive(PrimitiveType.Capsule); break;
            case 2: newObject = GameObject.CreatePrimitive(PrimitiveType.Cube); break;
            case 3: newObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder); break;
            case 4: newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere); break;
        }

        //Color the object, apply random force
		newObject.transform.position = transform.position;
		newObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        newObject.transform.SetParent(transform);
        newObject.GetComponent<MeshRenderer>().material = skin;
        newObject.AddComponent<Rigidbody>();
        newObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(minForce, maxForce), Random.Range(minForce, maxForce), Random.Range(minForce, maxForce)));
        newObject.GetComponent<Collider>().material = physicsMaterial;
    }

    IEnumerator TimedAction()
    {
		while (true)
		{
			yield return new WaitForSeconds(delay);
			SpawnNewObject();
		}
    }

}
