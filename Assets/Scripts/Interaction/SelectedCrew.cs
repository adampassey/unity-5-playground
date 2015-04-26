using UnityEngine;
using System.Collections;

public class SelectedCrew : Singleton<SelectedCrew>
{

	public Crew active;
	public Crew Active {
		get { return active; }
		set { active = value; }
	}

    public void Start() {
        DontDestroyOnLoad(this);
    }
}
