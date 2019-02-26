# Hide and Seek in unity
The goal of this project is to emulate CSGO Hide and seek and other various "Minigames" from from within the unity engine
This project is in very early stages
> Thanks, Flame
## Documentation
### Weapon Class
```c#
public Weapon weapon = new Weapon(float Damage, float Firerate, float Accuracy, float range);
```
|  Attr   |   Accounts for  | Required |
|:-------:|:---------------------------------|:---:|
|Damage   | Amount damage dealt to hit object|yes|
|Firerate | Rate at which action occurs|yes|
|Accuracy| Accuracy relative attached cameras "transform.forward"|yes|
|Range| Range relative to players "transform.position"|yes|
