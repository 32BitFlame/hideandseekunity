# Hide and Seek in Unity
A simple hide and seek game developed in the Unity Engine
---
## Project Goals
> For goals in relation to the project check the project tab on github
---
## Documentation
### Weapon Class
#### Syntax: :
```c#
public Weapon weapon = new Weapon(float Damage, float Firerate, float Accuracy, float range);
```
#### Attributes: : 

|  Attr   |   Accounts for  | Required |
|:-------:|:---------------------------------|:---:|
|Damage   | Amount damage dealt to hit object|yes|
|Firerate | Rate at which action occurs|yes|
|Accuracy| Accuracy relative attached cameras "transform.forward"|yes|
|Range| Range relative to players "transform.position"|yes|

