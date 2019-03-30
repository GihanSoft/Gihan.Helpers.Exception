gihansoft lib to handle Exceptions

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