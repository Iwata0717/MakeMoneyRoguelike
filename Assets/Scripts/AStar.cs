using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
	private Node[,] nodes;

	/// <summary>
	/// Initialize
	/// </summary>
	public void Initialize()
	{
		nodes = new Node[Managers.Dungeon.GetMapHeight(), Managers.Dungeon.GetMapWidth()];

		int height = Managers.Dungeon.GetMapHeight();
		int width = Managers.Dungeon.GetMapWidth();

		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				if (Managers.Dungeon.GetMap(j, i))
				{
					nodes[i, j].state = NODESTATE.NONE;
				}
				else
				{
					nodes[i, j].state = NODESTATE.CLOSE;
				}
			}
		}
	}

	/// <summary>
	/// SearchRoot
	/// </summary>
	public void SearchRoot(int StartPosX, int StartPosY, int GoalPosX, int GoalPosY)
	{
		int minScore = 0;
		int minScoreElement = 0;
		List<Vector2Int> openNodeList = new List<Vector2Int>();

		//実コストをセット
		nodes[StartPosY, StartPosX].actuallCost = 0;

		//推定コストをセット
		nodes[StartPosY, StartPosX].heuristicCost = HeuristicCostCalc(StartPosX, StartPosY, GoalPosX, GoalPosY);

		//スコアをセット
		nodes[StartPosY, StartPosX].score = nodes[StartPosY, StartPosX].actuallCost + nodes[StartPosY, StartPosX].heuristicCost;
		minScore = nodes[StartPosY, StartPosX].score;

		//OPENにする
		nodes[StartPosY, StartPosX].state = NODESTATE.OPTEN;

		//Listにセットする
		openNodeList.Add(new Vector2Int(StartPosX, StartPosY));

		//
		while (true)
		{
			for (int i = 0; i < openNodeList.Count; i++)
			{
				if (nodes[openNodeList[i].y, openNodeList[i].x].state == NODESTATE.OPTEN)
				{
					//上
					if (nodes[openNodeList[i].y + 1, openNodeList[i].x].state == NODESTATE.NONE)
					{
						nodes[openNodeList[i].y + 1, openNodeList[i].x].actuallCost = nodes[openNodeList[i].y, openNodeList[i].x].actuallCost + 1;
						nodes[openNodeList[i].y + 1, openNodeList[i].x].heuristicCost = HeuristicCostCalc(openNodeList[i].x, openNodeList[i].y + 1, GoalPosX, GoalPosY);
						nodes[openNodeList[i].y + 1, openNodeList[i].x].score = nodes[openNodeList[i].y + 1, openNodeList[i].x].actuallCost + nodes[openNodeList[i].y + 1, openNodeList[i].x].heuristicCost;
						nodes[openNodeList[i].y + 1, openNodeList[i].x].parentPos.x = openNodeList[i].x;
						nodes[openNodeList[i].y + 1, openNodeList[i].x].parentPos.y = openNodeList[i].y;
						nodes[openNodeList[i].y + 1, openNodeList[i].x].state = NODESTATE.OPTEN;
						openNodeList.Add(new Vector2Int(openNodeList[i].x, openNodeList[i].y + 1));
					}
					//下
					if (nodes[openNodeList[i].y - 1, openNodeList[i].x].state == NODESTATE.NONE)
					{
						nodes[openNodeList[i].y - 1, openNodeList[i].x].state = NODESTATE.OPTEN;
					}
					//右
					if (nodes[openNodeList[i].y, openNodeList[i].x + 1].state == NODESTATE.NONE)
					{
						nodes[openNodeList[i].y, openNodeList[i].x + 1].state = NODESTATE.OPTEN;
					}
					//左
					if (nodes[openNodeList[i].y, openNodeList[i].x - 1].state == NODESTATE.NONE)
					{
						nodes[openNodeList[i].y, openNodeList[i].x - 1].state = NODESTATE.OPTEN;
					}
					//右上
					if (nodes[openNodeList[i].y + 1, openNodeList[i].x + 1].state == NODESTATE.NONE)
					{
						nodes[openNodeList[i].y + 1, openNodeList[i].x + 1].state = NODESTATE.OPTEN;
					}
					//右下
					if (nodes[openNodeList[i].y - 1, openNodeList[i].x + 1].state == NODESTATE.NONE)
					{
						nodes[openNodeList[i].y - 1, openNodeList[i].x + 1].state = NODESTATE.OPTEN;
					}
					//左上
					if (nodes[openNodeList[i].y + 1, openNodeList[i].x - 1].state == NODESTATE.NONE)
					{
						nodes[openNodeList[i].y + 1, openNodeList[i].x - 1].state = NODESTATE.OPTEN;
					}
					//左下
					if (nodes[openNodeList[i].y - 1, openNodeList[i].x - 1].state == NODESTATE.NONE)
					{
						nodes[openNodeList[i].y - 1, openNodeList[i].x - 1].state = NODESTATE.OPTEN;
					}

					//
					nodes[openNodeList[i].y, openNodeList[i].x].state = NODESTATE.CLOSE;
					openNodeList.RemoveAt(minScoreElement);
					minScore = SearchMinScore(openNodeList);
					minScoreElement = SearchMinScoreElement(openNodeList, minScore, minScoreElement);
				}
			}

		}
	}

	/// <summary>
	/// SearchMinScore
	/// </summary>
	/// <returns></returns>
	internal int SearchMinScore(List<Vector2Int> list)
	{
		int score = nodes[list[0].y, list[0].x].score;

		for (int i = 1; i < list.Count; i++)
		{
			if (score > nodes[list[i].y, list[i].x].score)
			{
				score = nodes[list[i].y, list[i].x].score;
			}
		}
		return score;
	}

	/// <summary>
	/// SearchMinScoreElement
	/// </summary>
	/// <param name="list"></param>
	/// <returns></returns>
	internal int SearchMinScoreElement(List<Vector2Int> list, int minScore, int minScoreElement)
	{
		for (int i = minScoreElement; i < list.Count; i++)
		{
			if (minScore == nodes[list[i].y, list[i].x].score)
			{
				return i;
			}
		}
		return 0;
	}

	/// <summary>
	/// HeuristicCostCalc
	/// </summary>
	/// <param name="StartPosX"></param>
	/// <param name="StartPosY"></param>
	/// <param name="GoalPosX"></param>
	/// <param name="GoalPosY"></param>
	/// <returns></returns>
	internal int HeuristicCostCalc(int StartPosX, int StartPosY, int GoalPosX, int GoalPosY)
	{
		int dx;
		int dy;

		//
		if (GoalPosX > StartPosX)
		{
			dx = GoalPosX - StartPosX;
		}
		else
		{
			dx = StartPosX - GoalPosX;
		}

		//
		if (GoalPosY > StartPosY)
		{
			dy = GoalPosY - StartPosY;
		}
		else
		{
			dy = StartPosY - GoalPosY;
		}

		//
		if (dx > dy)
		{
			return dx;
		}
		else
		{
			return dy;
		}
	}
}

/// <summary>
/// Node
/// </summary>
public class Node
{
	internal int actuallCost;
	internal int heuristicCost;
	internal int score;
	internal Vector2Int parentPos;
	internal NODESTATE state;
}

/// <summary>
/// NODESTATE
/// </summary>
public enum NODESTATE
{
	NONE,
	OPTEN,
	CLOSE
}