using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Services
{
	public static Player Player;

	public static Transform Managers;

	public static EnemyMngr EnemyMngr;
	public static SpawnEnemyMngr SpawnEnemyMngr;
	public static BackgroundMngr BackgroundMngr;

	public static void Init()
	{
		Player = GameObject.Find("Player").GetComponent<Player>();
		Managers = GameObject.Find("Managers").transform;
	}

	public static T GetComponentManagers<T>() where T : class
	{
		for (int i = 0; i < Managers.childCount; i++)
		{
			if (Managers.GetChild(i).GetComponent<T>() != null)
				return Managers.GetChild(i) as T;
		}

		return null;
	}
}
