using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class ServerService : GenericMonoSingleton<ServerService>
{
    
    public SocketIOComponent socket;
    private int userId =0;
    void Start()
    {
        // GameObject go = GameObject.Find("SocketIO");
		// socket = go.GetComponent<SocketIOComponent>();
        socket.Connect();

        socket.On("onConnected", TestOpen);
        socket.On("authAwait", AuthAwait);
        socket.On("error", TestError);
        socket.On("beep", Beep);
        socket.On("getState", getState);
        socket.On("authOk", authOk);
    }

    public void Beep (SocketIOEvent e)
    {
        Debug.Log("beeeeeep");
    }

    public void AuthAwait(SocketIOEvent e)
    {
        Debug.Log("-> Awaiting Auth");
        JSONObject iddata = JSONObject.obj;
        iddata.AddField("userId", userId); 

        socket.Emit("auth", iddata);
    }

    public void getState(SocketIOEvent e)
    {
        // Debug.Log(">" + e.state);
    }

    public void authOk(SocketIOEvent e)
    {
        Debug.Log("-> Login successful!");
        socket.Emit("startMatchmaking");
    }
    public void TestOpen(SocketIOEvent e)
	{
		Debug.Log("Server connected : " + e.name + " " + e.data);
		socket.Emit("start_auth");
	}

    public void TestError(SocketIOEvent e)
	{
		Debug.Log("Error received: " + e.name + " " + e.data);
	}
}
