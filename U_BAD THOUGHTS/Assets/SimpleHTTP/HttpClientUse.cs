using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleHTTP;

public class HttpClientUse : MonoBehaviour
{
    
    IEnumerator Get() {
        // Create the request object
        Request request = new Request ("https://jsonplaceholder.typicode.com/posts/1");
        
        // Instantiate the client
        Client http = new Client ();
        
        // Send the request
        yield return http.Send (request);
        
        // Use the response if the request was successful, otherwise print an error
        if (http.IsSuccessful ()) {
            Response resp = http.Response ();
            Debug.Log("status: " + resp.Status().ToString() + "\nbody: " + resp.Body());
        }
        else {
            Debug.Log("error: " + http.Error());
        }
    }

}
