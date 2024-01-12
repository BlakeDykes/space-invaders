# Space Invaders
*A clone of the 1978 arcade classic written in C# using OpenGL/irrKlang*

## Overview
My goal with this project was to clone an existing game by implementing object-oriented design patterns and principles in a real-time environment. Space Invaders was chosen for its design simplicity, as well as freely available assets. The project was completed in 12 weeks (7 sprints) and makes use of fifteen different object-oriented design patterns.

## Object-Oriented Design Patterns
- [Adaptor](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/Diagrams/Design%20Patterns/Adapter.cd)
- [Command](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/Diagrams/Design%20Patterns/Command.cd)
- [Composite](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/Diagrams/Design%20Patterns/Composite.cd)
- [Factory](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/Diagrams/Design%20Patterns/Factory.cd)
- [Flyweight](https://github.com/BlakeDykes/space-invaders/tree/main/SpaceInvaders/Image)
- [Iterator](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/Diagrams/Design%20Patterns/Iterator.cd)
- [Null Object](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/Diagrams/Design%20Patterns/NullObject.cd)
- [Object Pools](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/Diagrams/Design%20Patterns/ObjectPools.cd)
- [Observer](https://github.com/BlakeDykes/space-invaders/tree/main/SpaceInvaders/Observer)
- [Proxy](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/Diagrams/Design%20Patterns/Proxy.cd)
- [Singleton](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/Diagrams/Design%20Patterns/Singleton.cd)
- [State](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/Simulation/Simulation.cs#L86)
- [Strategy](https://github.com/BlakeDykes/space-invaders/tree/main/SpaceInvaders/GameObject/Ship)
- [Template](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/Diagrams/Design%20Patterns/Template.cd)
- [Visitor](https://github.com/BlakeDykes/space-invaders/tree/main/SpaceInvaders/Collision)

## Game Components
Functionality was divided into components which were then implemented in order of complexity and dependency.
- [Input Manager](https://github.com/BlakeDykes/space-invaders/tree/main/SpaceInvaders/Input)
- [Sprite System](https://github.com/BlakeDykes/space-invaders/tree/main/SpaceInvaders/Sprite)
- [Game Object Management](https://github.com/BlakeDykes/space-invaders/blob/main/SpaceInvaders/GameObject/GameObjectNodeManager.cs)
- [Collision System](https://github.com/BlakeDykes/space-invaders/tree/main/SpaceInvaders/Collision)
- [Scorekeeping System](https://github.com/BlakeDykes/space-invaders/tree/main/SpaceInvaders/Score)
- [Shield Display System](https://github.com/BlakeDykes/space-invaders/tree/main/SpaceInvaders/GameObject/Shield)
- [Sound System](https://github.com/BlakeDykes/space-invaders/tree/main/SpaceInvaders/Sound)

