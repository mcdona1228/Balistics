using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph 
{
    List<Connect> mConnect;

    public List<Connect> getConnect(Node fromNode)
    {
        List<Connect> connect = new List<Connect>();
        foreach (Connect c in mConnect)
        {
            if (c.getFromNode() == fromNode)
            {
                connect.Add(c);
            }
        }
        return connect;
    }

    public void Build()
    {
        mConnect = new List<Connect>();
        Node[] nodes = GameObject.FindObjectsOfType<Node>();
        foreach (Node fromNode in nodes)
        {
            foreach (Node toNode in fromNode.ConnectsTo)
            {
                float cost = (toNode.transform.position - fromNode.transform.position).magnitude;
                Connect c = new Connect(cost, fromNode, toNode);
                mConnect.Add(c);
            }
        }
    }
}
public class Connect
{
    float cost;
    Node fromNode;
    Node toNode;

    public Connect(float cost, Node fromNode, Node toNode)
    {
        this.cost = cost;
        this.fromNode = fromNode;
        this.toNode = toNode;
    }
    public float getCost()
    {
        return cost;
    }
    public Node getFromNode()
    {
        return fromNode;
    }
    public Node getToNode()
    {
        return toNode;
    }
}