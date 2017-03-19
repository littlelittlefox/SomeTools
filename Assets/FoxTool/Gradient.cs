using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 来自 http://www.xuanyusong.com/archives/3471
/// http://blog.csdn.net/langresser_king/article/details/50158199
/// </summary>
[AddComponentMenu("UI/Effects/Gradient")]
public class Gradient : BaseMeshEffect
{
	public Color32 TopColor = Color.white;
	public Color32 BottomColor = Color.black;

	public override void ModifyMesh(VertexHelper vh) {
		if(!IsActive())
			return;

		var vertexList = new List<UIVertex>();
		vh.GetUIVertexStream(vertexList);
		int count = vertexList.Count;
		ApplyGradient(vertexList, 0, count);
		vh.Clear();
		vh.AddUIVertexTriangleStream(vertexList);
	}

	private void ApplyGradient(List<UIVertex> vertexList,int start,int end)
	{
		float bottomY = vertexList[0].position.y;
		float topY = vertexList[0].position.y;
		for (int i = start; i < end; ++i)
		{
			float y = vertexList[i].position.y;
			if (y > topY)
			{
				topY = y;
			}else if (y < bottomY)
			{
				bottomY = y;
			}
		}

		float uiElementHeight = topY - bottomY;
		for (int i = start; i < end; ++i)
		{
			UIVertex uiVertex = vertexList[i];
			uiVertex.color = Color32.Lerp(BottomColor, TopColor, (uiVertex.position.y - bottomY)/uiElementHeight);
			vertexList[i] = uiVertex;
		}
	}
}
