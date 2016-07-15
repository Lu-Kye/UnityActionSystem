# Description
A simple unity framework to make tasks(which want to run every frame) easily.

# Target
To make a task(eg: fadeIn, fadeOut, moveTo in duration) without Coroutine and realized by only one line.

# Example
```csharp
ActionManager.Instance.Add(this.gameObject,
	ActionMove.Create(
		this.target,
		2f,
		Vector3.zero,
		new Vector3(10f, 0f, 0f)
	)
);
```
