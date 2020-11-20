public class Parameters {
    public bool ShouldRun { get;set; } = true;
}

Setup(ctx => {
    var buildParams = new Parameters();
    return buildParams;
});

Task("C")
.Does<Parameters>((context, buildparams) => {
    Information("C");
    buildparams.ShouldRun = false;
});

Task("A")
.IsDependentOn("C")
.IsDependentOn("B")
.WithCriteria<Parameters>((context, buildparams) => buildparams.ShouldRun)
.Does(() => {
    Information("A");
});


Task("B")
.Does(() => {
    throw new NotImplementedException();
});

RunTarget("A");