# Hide and Seek in Unity
The goal of this project is to emulate CSGO Hide and Seek and other various "Minigames" from from within the Unity Engine
This project is in very early stages. I would not expect to see the game in playable state until the end of the year.
> Thanks, Flame
---
## Project Goals
> For goals in relation to the project check the project tab on github
---
## Documentation
### Weapon Class
Syntax
```c#
public Weapon weapon = new Weapon(float Damage, float Firerate, float Accuracy, float range);
```
Attributes
|  Attr   |   Accounts for  | Required |
|:-------:|:---------------------------------|:---:|
|Damage   | Amount damage dealt to hit object|yes|
|Firerate | Rate at which action occurs|yes|
|Accuracy| Accuracy relative attached cameras "transform.forward"|yes|
|Range| Range relative to players "transform.position"|yes|
Functions
> None at the moment though some are to come
