// See https://aka.ms/new-console-template for more information

using Amazon.CDK;
using UnityPackageServer.CDK;

public class Program
{
    public static void Main()
    {
        var app = new App();
        var unityPackageServerStack = new UnityPackageServerStack(app, "UnityPackageServerStack", null)
        {
        };
        app.Synth();
    }
}