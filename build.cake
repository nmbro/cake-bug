Task("C")
.Does(() => {
    Information("C");
});

Task("A")
.IsDependentOn("C")
.IsDependentOn("B")
.WithCriteria(() => false)
.Does(() => {
    Information("A");
});


Task("B")
.Does(() => {
    throw new NotImplementedException();
});

RunTarget("A");