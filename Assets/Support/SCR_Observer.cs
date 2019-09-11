using System.Collections.Generic;

public abstract class SCR_Observer<OData> : SCR_SingletonMonobihavior<SCR_Observer<OData>>
{
    public delegate void CallBack(OData data);

    Dictionary<string, HashSet<CallBack>> distObserver = new Dictionary<string, HashSet<CallBack>>();
    
    public void Add<OData>(string topic, CallBack callback)
    {
        HashSet<CallBack> listOb = CreateListObserver(topic);
        listOb.Add(callback);
    }

    public void Remove<OData>(string topic, CallBack callback)
    {
        var listOb = CreateListObserver(topic);
        listOb.Remove(callback);
    }

    public void Notify(string topic, OData data)
    {
        var listOb = CreateListObserver(topic);
        foreach(CallBack cb in listOb)
        {
            cb(data);
        }
    }

    protected HashSet<CallBack> CreateListObserver(string topic)
    {
        if(!distObserver.ContainsKey(topic))
        {
            distObserver.Add(topic, new HashSet<CallBack>());
        }
        return distObserver[topic];
    }
}