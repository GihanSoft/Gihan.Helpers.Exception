gihansoft lib to handle Exceptions
master branch: [![Build status](https://ci.appveyor.com/api/projects/status/xeu1yq04u7mrhqss/branch/master?svg=true)](https://ci.appveyor.com/project/chiefmb/gihan-helpers-exception/branch/master)
TryNTimes class try some Action N time before give up.

```c#
bool isSucceed = TryNTimes.TryCatchNTimes(()=>{
	//try
}, (Exception err, byte i)=>{
	// each time catch, "err" is Exception & "i" is counter
}, err => {
	// on fail (after n try and fail) catch
}, 3 /* try times */);
```
