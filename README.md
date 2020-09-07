# Slawter
A single player FPS made in Unity with inspiration from Gears of War.
======

![game enter](https://user-images.githubusercontent.com/42195958/92342395-9d5a4480-f075-11ea-893a-5b2a4d12e315.png)
======
![Peeking Enemy](https://user-images.githubusercontent.com/42195958/92343006-6e44d280-f077-11ea-83c7-160badaa4ee3.png)
======
![Scope on enemy](https://user-images.githubusercontent.com/42195958/92343008-6edd6900-f077-11ea-8118-7929952b663f.png)
======
![Shooting enemies](https://user-images.githubusercontent.com/42195958/92343009-700e9600-f077-11ea-84b1-2b9e1fff09d5.png)
======
![Falling enemy](https://user-images.githubusercontent.com/42195958/92343013-70a72c80-f077-11ea-9bad-ab8a8b3bdf9d.png)
======
![Enemy](https://user-images.githubusercontent.com/42195958/92343014-71d85980-f077-11ea-9223-457a93402b34.png)
======

## Enemy State Machine
 - Implemented a Statemachine that has a dictionary of all its possible states which all derive from a BaseState class.
 - BaseState is an abstract class which has a abstract method called Tick() which is called in the Update method in the StateMachine class.
 - In the Enemy class they have a reference their own StateMachine initializing it with the states it needs. 
 ======
## Input System
 - All input in the game is handled with the new Unity InputSystem.
======
## C# Features
 - Use of LINQ, Delegates, Events, Inheritance.
![AttackPlayerState](https://user-images.githubusercontent.com/42195958/92345593-cdf2ac00-f07e-11ea-8f1c-0920ad1c2827.png)
![BaseState](https://user-images.githubusercontent.com/42195958/92345598-cfbc6f80-f07e-11ea-9c69-9423c1cfa9d9.png)
![InitializeStateMachine](https://user-images.githubusercontent.com/42195958/92345606-d4812380-f07e-11ea-80b0-4df319912358.png)
![StateMachine](https://user-images.githubusercontent.com/42195958/92345610-d814aa80-f07e-11ea-8079-cf37f69f8c12.png)

## Author
Justin Questroo

[![Linkedin](https://i.stack.imgur.com/gVE0j.png) LinkedIn](https://www.linkedin.com/in/justin-questroo-504452173/)
