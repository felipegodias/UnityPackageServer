using Amazon.CDK;
using Constructs;

namespace UnityPackageServer.CDK;

public class UnityPackageServerStack : Stack
{
    public UnityPackageServerStack(Construct scope, string id, IStackProps props) : base(scope, id, props)
    {
    }
}