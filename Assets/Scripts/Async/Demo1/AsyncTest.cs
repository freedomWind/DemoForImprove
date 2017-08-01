using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using MathCollection;
using System.Text;
public class AsyncTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

        
        string str = MyMathf.BigAdd("2334444555887739932048762732738747878738487487389478934","849347837487878278328378748574878374738947398748394737487389"+
           "78473874872937827389273867473874879423829382908309437587593489028032974878347");
        Debug.Log("r = "+str);
        Debug.Log("r =" + MyMathf.BigAdd("234", "1023"));
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log(1);
            var v = getResult<int>(400);
            Debug.Log(3);
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            Debug.Log(1);
            getResultAsync<int>(400,_=> { Debug.Log("last" + _); });
            Debug.Log(3);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Debug.Log(1);
            getResult1<int>(400, a => { Debug.Log("last" + a); });
            Debug.Log(3);
        }
	}
    //async int aa()
    //{
    //    return 3;
    //}

    T getObjectAsync<T>(T a)
    {
        Thread.Sleep(1000);
        return a;
    }
    T getObjectAsync1<T>() 
    {
        Thread.Sleep(1000);
        return default(T);
    }
    /// <summary>
    /// 不可取方式 异步 如果直接在其它线程中获取结果 会发生阻塞
    /// 既然是异步 就不应该通过返回方式获取值 而应该用回调
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    async Task<T> getResult<T>(T t)
    {
        Debug.Log(2);
        var t1 = await Task.Run<T>(() => { return getObjectAsync<T>(t); });
        Debug.Log("last"+t1);
        return t1;
    }
    async void getResult1<T>(T t,System.Action<T> callback)
    {
        Debug.Log(2);
        var v = await getRR<T>(t);
        if (callback != null)
            callback(v);
    }
    Task<T> getRR<T>(T t)
    {
        Task<T> ta = new Task<T>(() => { Thread.Sleep(1000); return t; });
        ta.Start();
        return ta;
    }
    /// <summary>
    /// 异步 相对async await 比较难以理解
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <param name="callback"></param>
    void getResultAsync<T>(T t,System.Action<T> callback)
    {
        Debug.Log(2);
        var result = Task.Run<T>(() => { return getObjectAsync<T>(t); }).GetAwaiter();
        Thread.Sleep(1000);
        result.OnCompleted(()=> { callback(result.GetResult()); });
    }
    T getResult<T>()
    {
        Thread.Sleep(1000);
        return default (T);
    }
}
